using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;
using BraveLantern.Swatcher.Args;
using BraveLantern.Swatcher.Extensions;
using BraveLantern.Swatcher.Logging;
using Microsoft.Win32.SafeHandles;
using BraveLantern.Swatcher.Config;
using BraveLantern.Swatcher.Native;

namespace BraveLantern.Swatcher
{
    public sealed class Swatcher : ISwatcher
    {
        /// <summary>
        ///     Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value><c>true</c> if this instance is disposed; otherwise, <c>false</c>.</value>
        public bool IsDisposed { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether this instance is running.
        /// </summary>
        /// <value><c>true</c> if this instance is running; otherwise, <c>false</c>.</value>
        public bool IsRunning { get; private set; }

        public IObservable<SwatcherEventArgs> Changed { get; private set; }
        public IObservable<SwatcherCreatedEventArgs> Created { get; private set; }
        public IObservable<SwatcherEventArgs> Deleted { get; private set; }
        public IObservable<SwatcherRenamedEventArgs> Renamed { get; private set; }
        public event EventHandler<SwatcherEventArgs> ItemChanged;
        public event EventHandler<SwatcherCreatedEventArgs> ItemCreated;
        public event EventHandler<SwatcherEventArgs> ItemDeleted;
        public event EventHandler<SwatcherRenamedEventArgs> ItemRenamed;

        public Swatcher(ISwatcherConfig config) : this(config, new WindowsFacade())
        {
        }

        internal Swatcher(ISwatcherConfig config, IWindowsFacade windowsFacade)
        {
            Config = config;
            WindowsFacade = windowsFacade;

            var createdEventStream = CreateCreatedEventStream();
            var finishedCreatedEventStream = CreateFinishedCreatedEventStream(createdEventStream);

            finishedCreatedEventStream
                .Delay(TimeSpan.FromSeconds(2.5))
                .Subscribe(x => CreatedEventsInProgress.Remove(x.FullPath));

            var createdEventWindows = CreateCreatedEventWindowStream(createdEventStream);
            var finishedCreatedEventWindows = CreateFinishedCreatedEventWindows(finishedCreatedEventStream);

            var changedEventStream = CreateChangedEventStream();
            var changedEventWindows = CreatedChangedEventWindows(changedEventStream);

            Renamed = CreatePublicRenamedStream(Config);
            Deleted = CreatePublicDeletedStream();
            Created = CreatePublicCreatedStream(finishedCreatedEventStream);
            Changed = CreatePublicChangedStream(changedEventStream,
                changedEventWindows, createdEventWindows, finishedCreatedEventWindows);

            ChangedEventPatternSource =
                Changed.Select(x => new EventPattern<SwatcherEventArgs>(this, x)).ToEventPattern();
            ChangedEventPatternSource.OnNext += OnItemChanged;

            DeletedEventPatternSource =
                Deleted.Select(x => new EventPattern<SwatcherEventArgs>(this, x)).ToEventPattern();
            DeletedEventPatternSource.OnNext += OnItemDeleted;

            CreatedEventPatternSource =
                Created.Select(x => new EventPattern<SwatcherCreatedEventArgs>(this, x)).ToEventPattern();
            CreatedEventPatternSource.OnNext += OnItemCreated;

            RenamedEventPatternSource =
                Renamed.Select(x => new EventPattern<SwatcherRenamedEventArgs>(this, x)).ToEventPattern();
            RenamedEventPatternSource.OnNext += OnItemRenamed;
        }

        private IObservable<SwatcherRenamedEventArgs> CreatePublicRenamedStream(ISwatcherConfig config)
        {
            return Observable.Create<SwatcherRenamedEventArgs>(observer =>
                {
                    return _renamedSubject
                        .CombineWithPrevious((previous, current) =>
                        {
                            if ((previous?.Event == FileSystemItemEvent.RenamedOldName) &&
                                (current.Event == FileSystemItemEvent.RenamedNewName))
                                return new SwatcherRenamedEventArgs(config, current.Name, previous.Name);

                            return null;
                        })
                        .WhereNotNull()
                        .Do(x =>
                        {
                            if (!Config.LoggingEnabled) return;
                            Logger.Debug(
                                $"[Renamed] OldName: {x.OldName}, Name: {x.Name}, OccurredAt:{x.TimeOccurred.ToLocalTime()}");
                        })
                        .SubscribeSafe(observer);
                })
                .Publish()
                .RefCount();
        }

        private IObservable<SwatcherEventArgs> CreatePublicDeletedStream()
        {
            return Observable.Create<SwatcherEventArgs>(observer =>
                {
                    return _deletedSubject
                        .SelectConfiguredItemTypes(Config)
                        .Do(x =>
                        {
                            if (!Config.LoggingEnabled) return;

                            Logger.Debug($"[Deleted] Name: {x.Name}, OccurredAt:{x.TimeOccurred.ToLocalTime()}");
                        })
                        .SubscribeSafe(observer);
                })
                .Publish()
                .RefCount();

        }

        private IObservable<SwatcherCreatedEventArgs> CreatePublicCreatedStream(
            IObservable<SwatcherCreatedEventArgs> finishedCreatedEvents)
        {
            return finishedCreatedEvents
                .Do(x =>
                {
                    if (!Config.LoggingEnabled) return;
                    var processingTime = (x.Duration.Seconds > 1)
                        ? $"{x.Duration.Seconds} sec"
                        : $"{x.Duration.Milliseconds} ms";

                    Logger.Debug(
                        $"[Created] Name: {x.Name}, OccurredAt:{x.TimeOccurred.ToLocalTime()}, ProcessingTime: {processingTime}");
                })
                .Publish()
                .RefCount();
        }

        private IObservable<SwatcherCreatedEventArgs> CreateCreatedEventStream()
        {
            return _createdSubject.AsObservable()
                .SelectConfiguredItemTypes(Config)
                .Do(x => CreatedEventsInProgress.Add(x.FullPath))
                .Publish()
                .RefCount();
        }

        private IObservable<SwatcherCreatedEventArgs> CreateFinishedCreatedEventStream(
            IObservable<SwatcherCreatedEventArgs> createdEventStream)
        {
            return Observable.Create<SwatcherCreatedEventArgs>(observer =>
                {
                    return
                        createdEventStream
                            .SelectConfiguredItemTypes(Config)
                            .Select(x =>
                                Observable.Interval(OneSecond, ThreadPoolScheduler.Instance)
                                    .StartWith(-1L)
                                    .SkipWhile(_ => IsFileLocked(x.FullPath))
                                    .Take(1)
                                    .Do(_ => x.MarkCompleted())
                                    .Select(_ => x)
                            )
                            .Merge()
                            .SubscribeSafe(observer);
                })
                .Publish()
                .RefCount();
        }

        private IObservable<SwatcherEventArgs> CreateChangedEventStream()
        {
            return _changedSubject.AsObservable()
                .Delay(TimeSpan.FromMilliseconds(250))
                .Publish()
                .RefCount();
        }

        private IObservable<IList<SwatcherEventArgs>> CreatedChangedEventWindows(
            IObservable<SwatcherEventArgs> changedEventStream)
        {
            return changedEventStream
                .Buffer(OneSecond, QuarterSecond)
                .CombineWithPreviousBuffer()
                .Publish()
                .RefCount();
        }

        private IObservable<SwatcherEventArgs> CreatePublicChangedStream(
            IObservable<SwatcherEventArgs> changedEventStream,
            IObservable<IList<SwatcherEventArgs>> changedEventWindows,
            IObservable<IList<SwatcherCreatedEventArgs>> createdEventWindows,
            IObservable<IList<SwatcherCreatedEventArgs>> finishedCreatedEventWindows)
        {
            return Observable.Create<SwatcherEventArgs>(observer =>
                {
                    var createdEventsFiltered =
                        ChangedEventsNotResultingFromACreatedEventStream(changedEventStream, createdEventWindows);
                    //.Do(x => Logger.Debug($"[CreatedEventsFiltered] Allowed {x.FullPath}"));

                    var duplicatesFiltered =
                        DuplicateChangedEventsFiltered(changedEventWindows, createdEventsFiltered);
                    //.Do(x => Logger.Debug($"[DuplicatesFiltered] Allowed {x.FullPath}"));

                    var finishedCreatedEventsFiltered =
                        ChangedEventsNotResultingFromAFinishedCreatedEventStream(duplicatesFiltered,
                            finishedCreatedEventWindows);
                    //.Do(x => Logger.Debug($"[FinishedCreatedEventsFiltered] Allowed {x.FullPath}"));

                    return finishedCreatedEventsFiltered.SubscribeSafe(observer);
                })
                .Do(x =>
                {
                    if (!Config.LoggingEnabled) return;
                    Logger.Debug($"[Changed] Name: {x.Name}, OccurredAt:{x.TimeOccurred.ToLocalTime()}");
                })
                .Publish()
                .RefCount();
        }

        private IObservable<SwatcherEventArgs> ChangedEventsNotResultingFromACreatedEventStream(
            IObservable<SwatcherEventArgs> changedEvents,
            IObservable<IList<SwatcherCreatedEventArgs>> createdEventWindows)
        {
            return changedEvents.CombineLatestFromLeft(createdEventWindows,
                    (c, w) => new
                    {
                        Changed = c,
                        Created = w
                    })
                .Where(x => ItemExists(x.Changed))
                .Where(x => IsWatchedItemType(x.Changed, Config))
                .Where(x => !CreatedEventsInProgress.Contains(x.Changed.FullPath))
                .Where(x => x.Created.All(created => created.FullPath != x.Changed.FullPath))
                .Select(x => x.Changed);
        }

        private static IObservable<SwatcherEventArgs> DuplicateChangedEventsFiltered(
            IObservable<IList<SwatcherEventArgs>> changedEventWindows,
            IObservable<SwatcherEventArgs> createdEventsFiltered)
        {
            return
                createdEventsFiltered.CombineLatestFromLeft(changedEventWindows,
                        (c, w) => new
                        {
                            Changed = c,
                            Comparison = w
                        })
                    .Where(x => x.Comparison.All(comparison => comparison.FullPath != x.Changed.FullPath))
                    .Select(x => x.Changed);
        }

        private IObservable<SwatcherEventArgs> ChangedEventsNotResultingFromAFinishedCreatedEventStream(
            IObservable<SwatcherEventArgs> duplicatesFilteredStream,
            IObservable<IList<SwatcherCreatedEventArgs>> finishedCreatedEventWindows)
        {
            return
                duplicatesFilteredStream.CombineLatestFromLeft(finishedCreatedEventWindows,
                        (c, w) => new
                        {
                            Changed = c,
                            Comparison = w
                        })
                    .Where(x => x.Comparison.All(comparison => comparison.FullPath != x.Changed.FullPath))
                    .Select(x => x.Changed);
        }

        #region Start & Stop

        public async Task Start()
        {
            if (IsDisposed)
                throw new ObjectDisposedException(GetType().Name);

            if (IsRunning) return;
            IsRunning = true;

            TokenSource = new CancellationTokenSource();
            CreatedEventsInProgress = new HashSet<string>();

            await DoSecurityAssertions(Config.PathToWatch).ConfigureAwait(false);
            await SetDirectoryHandle().ConfigureAwait(false);
            await SetCompletionPortHandle(Config.Id ?? -1).ConfigureAwait(false);
            

            var threadPoolSubscription = Observable.Range(1, Environment.ProcessorCount * 2)
                .Select(threadNumber => new Thread(ThreadPoolWorker()) {Name = $"{threadNumber}"})
                .Subscribe(t => t.Start(TokenSource.Token));

            Disposables = new CompositeDisposable()
            {
                threadPoolSubscription,
                CompletionPortHandle,
                DirectoryHandle,
            };

            if (Config.LoggingEnabled)
                Logger.Info($"Swatcher has started");
        }

        public async Task Stop()
        {
            await Task.Run(() =>
                {
                    if (IsDisposed)
                        throw new ObjectDisposedException(GetType().Name);

                    if (!IsRunning) return;
                    IsRunning = false;

                    TokenSource.Cancel();

                    SignalWorkerThreadsToStop();
                })
                .ConfigureAwait(false);
        }

        private ParameterizedThreadStart ThreadPoolWorker()
        {
            return parameter =>
            {
                try
                {
                    if (Config.LoggingEnabled)
                        Logger.Info($"Starting Thread {Thread.CurrentThread.Name}");

                    Interlocked.Increment(ref _runningThreads);

                    var token = (CancellationToken) parameter;
                    while (!token.IsCancellationRequested)
                    {
                        WatchFolderForChanges(Config, WindowsFacade, DirectoryHandle);
                        DoQueuedCompletionWork(
                            Config, WindowsFacade, CompletionPortHandle, _createdSubject,
                            _deletedSubject, _changedSubject, _renamedSubject);
                    }
                }
                catch (SwatcherFolderDeletedException e)
                {
                    Logger.Trace($"Stopping {Thread.CurrentThread.Name}");
                    Interlocked.Decrement(ref _runningThreads);

                    Stop().GetAwaiter().GetResult();
                    throw;
                }
                catch (ThreadAbortException)
                {
                    Logger.Trace($"Stopping {Thread.CurrentThread.Name}");
                    Interlocked.Decrement(ref _runningThreads);
                }
            };
        }

        private unsafe void SignalWorkerThreadsToStop()
        {
            Observable.Interval(TimeSpan.FromMilliseconds(25))
                .TakeWhile(_ => _runningThreads > 0)
                .Select(_ =>
                {
                    var result = new SwatcherAsyncResult {Buffer = new byte[0]};
                    var overlapped = new Overlapped {AsyncResult = result};

                    //the first parameter is null because we're not using IO completion callbacks; they're too slow.
                    //we're taking the byte array from our empty byte array and passing that as user data to the overlapped.
                    var overlappedPointer = overlapped.UnsafePack(null, result.Buffer);
                    //when using IOCPs, we can send our own custom messages to the GetQueuedCompletionStatus
                    //method by call PostQueuedCompletionStatus. In this case, we want to stop the threads that are
                    //waiting on change events, so we will send a custom completion key "StopIocpThreads".
                    WindowsFacade.PostQueuedCompletionStatus(CompletionPortHandle, 0, StopIocpThreads,
                        overlappedPointer);
                    return Unit.Default;
                })
                .AsCompletion()
                .Where(_ => Config.LoggingEnabled)
                .Subscribe(_ =>
                {
                    Disposables.Dispose();
                    Logger.Info("Swatcher has stopped");
                });
        }

        #endregion

        #region Handle Initialization

        private async Task SetCompletionPortHandle(int completionKey)
        {
            await Task.Run(() =>
                {
                    //if the completion port doesn't exist yet, this call will create it.
                    //if it already exists, this call will bind the directory handle to the completion port,
                    //whilst retaining any other directory handles that were previously bound.
                    //passing 0 to the last parameter uses the default number of concurrent threads, which
                    //is the number of CPUs on the machine.
                    var pointer = WindowsFacade.CreateIoCompletionPort(
                        DirectoryHandle, SafeLocalMemHandle.Empty,
                        (uint) completionKey, (uint) Environment.ProcessorCount);

                    CompletionPortHandle = new SafeLocalMemHandle(pointer);
                })
                .ConfigureAwait(false);
        }

        private async Task SetDirectoryHandle()
        {
            await Task.Run(() =>
                {
                    var directoryHandle = WindowsFacade.CreateFile(
                        Config.PathToWatch,
                        FileSystemConstants.FileListDirectory, // access (read-write) mode
                        FileSystemConstants.FileShareRead | FileSystemConstants.FileShareDelete |
                        FileSystemConstants.FileShareWrite, // share mode
                        null, // security descriptor
                        FileSystemConstants.OpenExisting, // how to create
                        FileSystemConstants.FileFlagBackupSemantics | FileSystemConstants.FileFlagOverlapped,
                        // file attributes
                        new SafeFileHandle(IntPtr.Zero, false) // file with attributes to copy
                    );

                    if (!directoryHandle.IsHandleValid())
                        throw new ApplicationException(
                            $"Swatcher failed to start because it couldn't access the folder path provided in configuration.");

                    DirectoryHandle = directoryHandle;
                })
                .ConfigureAwait(false);
        }

        private static async Task DoSecurityAssertions(string folderPath)
        {
            await Task.Run(() =>
                {
                    try
                    {
                        new EnvironmentPermission(PermissionState.Unrestricted).Assert();

                        var fullPath = Path.GetFullPath(folderPath);

                        var permission = new FileIOPermission(FileIOPermissionAccess.Read, fullPath);
                        permission.Demand();
                    }
                    catch (SecurityException)
                    {
                        throw new SecurityException(
                            "Swatcher does not have sufficient permissions to monitor the specified folder.");
                    }
                    finally
                    {
                        CodeAccessPermission.RevertAssert();
                    }
                })
                .ConfigureAwait(false);
        }

        #endregion

        private IObservable<IList<SwatcherCreatedEventArgs>> CreateFinishedCreatedEventWindows(
            IObservable<SwatcherCreatedEventArgs> finishedCreatedEventStream)
        {
            return finishedCreatedEventStream
                .Buffer(OneSecond, QuarterSecond)
                .CombineWithPreviousBuffer()
                .Publish()
                .RefCount();
        }

        private IObservable<IList<SwatcherCreatedEventArgs>> CreateCreatedEventWindowStream(
            IObservable<SwatcherCreatedEventArgs> createdEventStream)
        {
            return createdEventStream
                .Buffer(OneSecond, QuarterSecond)
                .CombineWithPreviousBuffer()
                .Publish()
                .RefCount();
        }

        #region Native Methods

        // ReSharper disable once SuggestVarOrType_Elsewhere
        private static unsafe void WatchFolderForChanges(
            ISwatcherConfig config, IWindowsFacade windowsFacade, SafeFileHandle directoryHandle)
        {
            var result = new SwatcherAsyncResult {Buffer = new byte[DefaultBufferSize]};
            var overlapped = new Overlapped {AsyncResult = result};

            //the first parameter is null because we're not using IO completion callbacks; they're too slow.
            //we're taking the byte array from our empty byte array and passing that as user data to the overlapped.
            var overlappedPointer = overlapped.UnsafePack(null, result.Buffer);

            var success = false;
            try
            {
                //now we wrap this section in a fixed block to pin it to the original address.
                //we cannot have it move because the OS will write information about the changes
                //into this byte array.
                fixed (byte* bufferPointer = result.Buffer)
                {
                    var bytesReturnedNotUsed = 0;
                    var bufferHandle = new HandleRef(result, (IntPtr) bufferPointer);
                    var isRecursive = Convert.ToInt32(config.IsRecursive);

                    //because we're using IO completion ports, we pass our overlapped pointer into this unmanaged 
                    //call. when a change has been received, the OS will callback via GetQueuedCompletionStatus
                    //passing the overlapped pointer (which has our IAsyncResult/byte array) back to us.
                    success = windowsFacade.ReadDirectoryChangesW(
                        directoryHandle, bufferHandle, DefaultBufferSize, isRecursive,
                        (int) config.NotificationTypes, bytesReturnedNotUsed, overlappedPointer, SafeLocalMemHandle.Empty);

                }
            }
            finally
            {
                //if success is false, our directory handle has likely become invalid. attempt to re-establish it.
                if (!success)
                {
                    Debugger.Break();
                    //before doing anything else, cleanup here to prevent memory leaks.
                    Overlapped.Free(overlappedPointer);
                }
            }
        }

        private static unsafe void DoQueuedCompletionWork(
            ISwatcherConfig config, IWindowsFacade facade, SafeLocalMemHandle completionPortHandle,
            ISubject<SwatcherCreatedEventArgs> createdSubject, ISubject<SwatcherEventArgs> deletedSubject,
            ISubject<SwatcherEventArgs> changedSubject, ISubject<RenamedInfo> renamedSubject)
        {
            //this is a blocking call...
            var completionStatus = WaitForCompletionStatus(config, facade, completionPortHandle);
            if (completionStatus == null) return;

            var overlapped = Overlapped.Unpack(completionStatus.Value.OverlappedPointer);
            var asyncResult = (SwatcherAsyncResult) overlapped.AsyncResult;
            var currentOffset = 0;
            // ReSharper disable once TooWideLocalVariableScope
            var nextOffset = 0;
            try
            {
                do
                {
                    nextOffset = DeserializeMessage(
                        config, asyncResult, ref currentOffset, createdSubject,
                        deletedSubject, changedSubject, renamedSubject);
                } while (nextOffset != 0);
            }
            finally
            {
                //*always* free up the overlapped. otherwise, we will have a ~65kb memory leak after each callback.
                Overlapped.Free(completionStatus.Value.OverlappedPointer);
            }
        }

        private static unsafe int DeserializeMessage(
            ISwatcherConfig config, SwatcherAsyncResult asyncResult, ref int currentOffset,
            ISubject<SwatcherCreatedEventArgs> createdSubject, ISubject<SwatcherEventArgs> deletedSubject,
            ISubject<SwatcherEventArgs> changedSubject, ISubject<RenamedInfo> renamedSubject)
        {
            int nextOffset;
            string name;
            int @event;

            fixed (byte* bufferPointer = asyncResult.Buffer)
            {
                //buffer pointer was the address where we started.
                //add current offset to get the address of our the next offset.
                //4 bytes in an integer ;-).
                nextOffset = *(int*) (bufferPointer + currentOffset);
                // the next integer contains the action.
                @event = *(int*) (bufferPointer + currentOffset + 4);
                //next int pointer has the address that contains the length of the name
                //of the item that was created,changed,renamed or deleted.
                var nameLength = *(int*) (bufferPointer + currentOffset + 8);
                //finally, retrieve the string via char* using the name length from above.
                //we divide the length by 2 because a char is 2 bytes.
                name = new string((char*) (bufferPointer + currentOffset + 12), 0, nameLength / 2);
            }

            switch ((FileSystemItemEvent) @event)
            {
                case FileSystemItemEvent.Created:
                    OnItemCreatedInternal(config, createdSubject, name);
                    break;
                case FileSystemItemEvent.Deleted:
                    OnItemDeletedInternal(config, deletedSubject, name);
                    break;
                case FileSystemItemEvent.Changed:
                    OnItemChangedInternal(config, changedSubject, name);
                    break;
                case FileSystemItemEvent.RenamedOldName:
                    OnItemRenamedInternal(config, renamedSubject, name, FileSystemItemEvent.RenamedOldName);
                    break;
                case FileSystemItemEvent.RenamedNewName:
                    OnItemRenamedInternal(config, renamedSubject, name, FileSystemItemEvent.RenamedNewName);
                    break;
                default:
                    if (config.LoggingEnabled)
                        Logger.Trace(
                            $"[Skipped] An event was skipped because it didn't map to a Swatcher FileSystemEvent. Value={@event}, Name={name ?? "null"}.");
                    break;
            }

            currentOffset += nextOffset;
            return nextOffset;
        }

        private static unsafe QueuedCompletionStatus? WaitForCompletionStatus(
            ISwatcherConfig config, IWindowsFacade facade, SafeLocalMemHandle completionPortHandle)
        {
            uint bytesRead;
            uint completionKey;
            NativeOverlapped* overlappedPointer;

            //when change events have occurred, the OS will callback on this blocking method.
            //the key is that we provide the completion port handle, which has been bound to the 
            //directory handle being watched (see InitializeCompletionPort() method). we get our change data
            //by passing a pointer by reference to our nativeoverlapped -> IAsyncResult -> buffer. 
            var success = facade.GetQueuedCompletionStatus(
                completionPortHandle, out bytesRead, out completionKey,
                &overlappedPointer, InfiniteTimeout);

            if (!success)
                throw new SwatcherFolderDeletedException(config, facade.GetLastError());

            if (completionKey == StopIocpThreads)
            {
                Thread.CurrentThread.Abort();
                return null;
            }

            if (bytesRead == 0)
                return null;

            return new QueuedCompletionStatus()
            {
                BytesRead = bytesRead,
                CompletionKey = completionKey,
                OverlappedPointer = overlappedPointer
            };
        }

        #endregion

        #region Dispatcher Methods

        private static void OnItemRenamedInternal(ISwatcherConfig config,
            ISubject<RenamedInfo> renamedSubject, string name, FileSystemItemEvent @event)
        {
            if (!config.ChangeTypes.HasFlag(WatcherChangeTypes.Renamed)) return;

            renamedSubject.OnNext(new RenamedInfo
            {
                Name = name,
                Event = @event
            });
        }

        private static void OnItemChangedInternal(ISwatcherConfig config, ISubject<SwatcherEventArgs> changedSubject,
            string name)
        {
            if (config.ChangeTypes.HasFlag(WatcherChangeTypes.Changed))
                changedSubject.OnNext(
                    new SwatcherEventArgs(config, WatcherChangeTypes.Changed, name));
        }

        private static void OnItemDeletedInternal(ISwatcherConfig config, ISubject<SwatcherEventArgs> deletedSubject,
            string name)
        {
            if (config.ChangeTypes.HasFlag(WatcherChangeTypes.Deleted))
                deletedSubject.OnNext(
                    new SwatcherEventArgs(config, WatcherChangeTypes.Deleted, name));
        }

        private static void OnItemCreatedInternal(ISwatcherConfig config,
            ISubject<SwatcherCreatedEventArgs> createdSubject,
            string name)
        {
            if (config.ChangeTypes.HasFlag(WatcherChangeTypes.Created))
                createdSubject.OnNext(
                    new SwatcherCreatedEventArgs(config, name));
        }

        private void OnItemRenamed(object sender, SwatcherRenamedEventArgs e)
        {
            ItemRenamed?.Invoke(sender, e);
        }

        private void OnItemCreated(object sender, SwatcherCreatedEventArgs e)
        {
            ItemCreated?.Invoke(sender, e);
        }

        private void OnItemDeleted(object sender, SwatcherEventArgs e)
        {
            ItemDeleted?.Invoke(sender, e);
        }

        private void OnItemChanged(object sender, SwatcherEventArgs e)
        {
            ItemChanged?.Invoke(sender, e);
        }

        #endregion

        #region Private Fields & Properties

        private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();
        private static readonly TimeSpan QuarterSecond = TimeSpan.FromMilliseconds(500);
        private static readonly TimeSpan OneSecond = TimeSpan.FromSeconds(1);
        private static readonly TimeSpan ThreeSeconds = TimeSpan.FromSeconds(3);
        private readonly ISubject<SwatcherEventArgs> _changedSubject = new Subject<SwatcherEventArgs>();
        private readonly ISubject<SwatcherCreatedEventArgs> _createdSubject = new Subject<SwatcherCreatedEventArgs>();
        private readonly ISubject<SwatcherEventArgs> _deletedSubject = new Subject<SwatcherEventArgs>();
        private readonly ISubject<RenamedInfo> _renamedSubject = new Subject<RenamedInfo>();
        private int _runningThreads;
        private IEventPatternSource<SwatcherEventArgs> ChangedEventPatternSource { get; set; }
        private IEventPatternSource<SwatcherEventArgs> DeletedEventPatternSource { get; set; }
        private IEventPatternSource<SwatcherRenamedEventArgs> RenamedEventPatternSource { get; set; }
        private IEventPatternSource<SwatcherCreatedEventArgs> CreatedEventPatternSource { get; set; }
        private CancellationTokenSource TokenSource { get; set; }
        private ISwatcherConfig Config { get; }
        private IWindowsFacade WindowsFacade { get; }
        private SafeFileHandle DirectoryHandle { get; set; }
        private SafeLocalMemHandle CompletionPortHandle { get; set; }
        private HashSet<string> CreatedEventsInProgress { get; set; }
        private CompositeDisposable Disposables { get; set; }
        private const int DefaultBufferSize = 16384;
        private const uint StopIocpThreads = 0x7FFFFFFF;
        private const uint InfiniteTimeout = 0xFFFFFFFF;

        #endregion

        #region Helper Methods

        private static bool IsFileLocked(string filePath)
        {
            if (!File.Exists(filePath))
                return false;
            try
            {
                using (var x = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                }
                return false;
            }
            catch (IOException)
            {
                return true;
            }
        }

        private bool IsWatchedItemType(SwatcherEventArgs e, ISwatcherConfig config)
        {
            var itemType = GetItemType(e.FullPath);
            return config.ItemTypes.HasFlag(itemType);
        }

        private static bool ItemExists(SwatcherEventArgs e)
        {
            return File.Exists(e.FullPath) || Directory.Exists(e.FullPath);
        }

        private static SwatcherItemTypes GetItemType(string fullPath)
        {
            if (File.Exists(fullPath) || Directory.Exists(fullPath))
                try
                {
                    var attributes = File.GetAttributes(fullPath);
                    return attributes.HasFlag(FileAttributes.Directory)
                        ? SwatcherItemTypes.Folder
                        : SwatcherItemTypes.File;
                }
                catch
                {
                    /*a race condition occurred where the file/folder was deleted after the check but before inspecting attributes */
                }

            //If a file has been deleted, the previous will not work and we only have the path to work with.
            var fileName = Path.GetFileName(fullPath);

            return string.IsNullOrWhiteSpace(
                Path.GetExtension(fileName))
                ? SwatcherItemTypes.Folder
                : SwatcherItemTypes.File;
        }

        #endregion

        public void Dispose()
        {
            Stop().GetAwaiter().GetResult();

            ChangedEventPatternSource.OnNext -= OnItemChanged;
            DeletedEventPatternSource.OnNext -= OnItemDeleted;
            RenamedEventPatternSource.OnNext -= OnItemRenamed;
            CreatedEventPatternSource.OnNext -= OnItemCreated;

            IsDisposed = true;
        }
    }
}