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
    /// <summary>
    /// Class Swatcher. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="BraveLantern.Swatcher.ISwatcher" />
    public sealed class Swatcher : ISwatcher
    {
        #region Public Properties

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
        /// <summary>
        /// Gets a stream of <see cref="SwatcherEventArgs" /> that are pushed when a <b>change</b> event occurs.
        /// </summary>
        /// <value>The <see cref="SwatcherEventArgs" /> meta for a <b>change</b> event.</value>
        public IObservable<SwatcherEventArgs> Changed { get; private set; }
        /// <summary>
        /// Gets a stream of <see cref="SwatcherCreatedEventArgs" /> that are pushed when a <b>created</b> event occurs.
        /// </summary>
        /// <value>The <see cref="SwatcherCreatedEventArgs" /> meta for a <b>created</b> event.</value>
        public IObservable<SwatcherCreatedEventArgs> Created { get; private set; }
        /// <summary>
        /// Gets a stream of <see cref="SwatcherEventArgs" /> that are pushed when a <b>deleted</b> event occurs.
        /// </summary>
        /// <value>The <see cref="SwatcherEventArgs" /> meta for a <b>deleted</b> event.</value>
        public IObservable<SwatcherEventArgs> Deleted { get; private set; }
        /// <summary>
        /// Gets a stream of <see cref="SwatcherRenamedEventArgs" /> that are pushed when a <b>renamed</b> event occurs.
        /// </summary>
        /// <value>The <see cref="SwatcherRenamedEventArgs" /> meta for a <b>renamed</b> event.</value>
        public IObservable<SwatcherRenamedEventArgs> Renamed { get; private set; }
        /// <summary>
        /// Gets a stream of <see cref="SwatcherException" /> that are pushed when a <see cref="ISwatcher" /> encounters an internal exception.
        /// </summary>
        /// <value>The <see cref="SwatcherException" /> that descibes the exception.</value>
        /// <remarks>Immediately prior to pushing an exception onto the stream, <see cref="ISwatcher.Stop" /> will be called which will do the following:
        /// <list type="bullet"><item><description>Complete the streams on the <see cref="ISwatcherRx" /> interface.</description></item><item><description>Remove event handlers for the <see cref="ISwatcherEvents" /> interface.</description></item></list>
        /// NOTE: While it is possible to restart the <see cref="ISwatcher" />, it is highly recommended to call <see cref="IDisposable.Dispose" /> and create a new instance.</remarks>
        public IObservable<SwatcherException> Exception { get; private set; }
        /// <summary>
        /// Provides notifications when a <b>change</b> event occurs.
        /// </summary>
        /// <value>The <see cref="SwatcherEventArgs" /> meta for a <b>change</b> event.</value>
        public event EventHandler<SwatcherEventArgs> ItemChanged;
        /// <summary>
        /// Provides notifications when a <b>created</b> event occurs.
        /// </summary>
        /// <value>The <see cref="SwatcherCreatedEventArgs" /> meta for a <b>created</b> event.</value>
        public event EventHandler<SwatcherCreatedEventArgs> ItemCreated;
        /// <summary>
        /// Provides notifications when a <b>deleted</b> event occurs.
        /// </summary>
        /// <value>The <see cref="SwatcherEventArgs" /> meta for a <b>deleted</b> event.</value>
        public event EventHandler<SwatcherEventArgs> ItemDeleted;
        /// <summary>
        /// Provides notifications when a <b>renamed</b> event occurs.
        /// </summary>
        /// <value>The <see cref="SwatcherRenamedEventArgs" /> meta for a <b>renamed</b> event.</value>
        public event EventHandler<SwatcherRenamedEventArgs> ItemRenamed;
        /// <summary>
        /// Provides notifications when an internal exception is encountered. See <see cref="ISwatcherRx.Exception" />.
        /// </summary>
        public event EventHandler<SwatcherException> ItemException;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Swatcher"/> class.
        /// </summary>
        /// <param name="config">The configuration for this <see cref="Swatcher"/> instance.</param>
        public Swatcher(ISwatcherConfig config) : this(config, new WindowsFacade()) { }

        internal Swatcher(ISwatcherConfig config, IWindowsFacade windowsFacade)
        {
            Config = config;
            WindowsFacade = windowsFacade;


            NotificationStream = CreateNotificationStream();

            var createdEventStream = CreateCreatedEventStream();
            var finishedCreatedEventStream = CreateFinishedCreatedEventStream(createdEventStream);

            finishedCreatedEventStream
                .Delay(TimeSpan.FromSeconds(2.5))
                .Subscribe(x => CreatedEventsInProgress.Remove(x.FullPath));

            var createdEventWindows = CreateCreatedEventWindowStream(createdEventStream);
            var finishedCreatedEventWindows = CreateFinishedCreatedEventWindows(finishedCreatedEventStream);

            var changedEventStream = CreateChangedEventStream();
            var changedEventWindows = CreatedChangedEventWindows(changedEventStream);

            Exception = _exceptionSubject.AsObservable().Publish().RefCount();
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

            ExceptionEventPatternSource =
                Exception.Select(x => new EventPattern<SwatcherException>(this, x)).ToEventPattern();
        }

        #endregion

        #region Stream Creation Methods

        private IObservable<EventNotification> CreateNotificationStream()
        {
            return Observable.Create<EventNotification>(observer =>
                {
                    return _startThreadPoolSubject.Subscribe(_ =>
                    {

                        Observable.Range(1, Environment.ProcessorCount * 2)
                            .ObserveOn(NewThreadScheduler.Default)
                            .Select(StartSwatcherThread)
                            .Merge()
                            //if the user stops this swatcher, gracefully catch the thread abortion and complete the sequence.
                            .Catch<EventNotification, ThreadAbortException>(__ => Observable
                                .Empty<EventNotification>())
                            .Subscribe(observer.OnNext,
                                async e =>
                                {
                                    observer.OnCompleted();

                                    await Stop().ConfigureAwait(false);

                                    _exceptionSubject.OnNext((SwatcherException)e);
                                });
                    });
                })
                .Publish()
                .RefCount();

        }

        private IObservable<SwatcherRenamedEventArgs> CreatePublicRenamedStream(ISwatcherConfig config)
        {
            return NotificationStream
                .WithConfiguredEventTypes(FileSystemItemEvent.RenamedNewName, FileSystemItemEvent.RenamedOldName)
                .WithConfiguredItemTypes(Config)
                .Where(x => Config.ChangeTypes.HasFlag(WatcherChangeTypes.Renamed))
                .CombineWithPrevious((previous, current) =>
                {
                    if ((previous.Event == FileSystemItemEvent.RenamedOldName) &&
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
                .Publish()
                .RefCount();
        }

        private IObservable<SwatcherEventArgs> CreatePublicDeletedStream()
        {
            return NotificationStream
                .WithConfiguredEventTypes(FileSystemItemEvent.Deleted)
                .WithConfiguredItemTypes(Config)
                .Where(x => Config.ChangeTypes.HasFlag(WatcherChangeTypes.Deleted))
                .Select(x => new SwatcherEventArgs(Config, WatcherChangeTypes.Deleted, x.Name))
                .Do(x =>
                {
                    if (!Config.LoggingEnabled) return;

                    Logger.Debug($"[Deleted] Name: {x.Name}, OccurredAt:{x.TimeOccurred.ToLocalTime()}");
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
            return NotificationStream
                .WithConfiguredEventTypes(FileSystemItemEvent.Created)
                .WithConfiguredItemTypes(Config)
                .Where(x => Config.ChangeTypes.HasFlag(WatcherChangeTypes.Created))
                .Select(x => new SwatcherCreatedEventArgs(Config, x.Name))
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
            return NotificationStream
                .WithConfiguredEventTypes(FileSystemItemEvent.Changed)
                .WithConfiguredItemTypes(Config)
                .Where(x => Config.ChangeTypes.HasFlag(WatcherChangeTypes.Changed))
                .Select(x => new SwatcherEventArgs(Config, WatcherChangeTypes.Changed, x.Name))
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

                    return finishedCreatedEventsFiltered.Subscribe(observer);
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

        #endregion

        #region Start & Stop

        /// <summary>
        /// Causes the <see cref="ISwatcher" /> to start listening for file system events.
        /// </summary>
        /// <returns>Task.</returns>
        /// <exception cref="ObjectDisposedException"></exception>
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

            _startThreadPoolSubject.OnNext(Unit.Default);

            Disposables = new CompositeDisposable()
            {
                CompletionPortHandle,
                DirectoryHandle,
            };

            if (Config.LoggingEnabled)
                Logger.Info($"Swatcher has started");
        }

        /// <summary>
        /// Causes the <see cref="ISwatcher" /> to stop listening for file system events.
        /// </summary>
        /// <returns>Task.</returns>
        /// <remarks>If a long running file copy|create|upload operation was in progress when
        /// the <see cref="Stop" /> method is called, the <see cref="ISwatcherRx.Created" /> stream will still notify subscribers when that
        /// operation is completed as long as the subscription is in place and the <see cref="IDisposable.Dispose" /> method
        /// has not been called.</remarks>
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


        private IObservable<EventNotification> StartSwatcherThread(int threadNumber)
        {
            return Observable.Create<EventNotification>(observer =>
                {
                    //first, we bind to folder change notifications.
                    var folderChangeBindingStream = Observable.Repeat(Unit.Default)
                        .Select(_ => 
                            SubscribeToFolderChanges(Config, WindowsFacade, DirectoryHandle) && Directory.Exists(Config.PathToWatch))
                        .Publish()
                        .RefCount();
                    //if we successfully bound to folder changes, try to wait for notification callbacks.
                    var notificationStream = folderChangeBindingStream
                        .WhereTrue()
                        //this is a blocking call.
                        .Select(_ => OnNativeNotification(Config, WindowsFacade, CompletionPortHandle))
                        .Where(x => x.HasValue)
                        .Select(x => x.Value)
                        .Publish()
                        .RefCount();

                    //this is our happy path
                    var notificationSuccessSubscription = notificationStream
                        .Where(x => x.WasSuccessful)
                        .MapToEventNotification()
                        .SubscribeSafe(observer);

                    //if the folder change binding or wait for notifications call fails...we're done.
                    var failureSubscription = Observable.Merge(
                        folderChangeBindingStream.WhereFalse(),
                        notificationStream.Where(x => !x.WasSuccessful).Select(_ => false))
                        .Take(1)
                        .Subscribe(_ =>
                        {
                            observer.OnError(new SwatcherException(Config, WindowsFacade.GetLastError()));
                        });

                    return new CompositeDisposable(notificationSuccessSubscription, failureSubscription);
                })
                .Finally(() =>
                {
                    if (Config.LoggingEnabled)
                        Logger.Trace($"{Thread.CurrentThread.Name} Stopped.");

                    Interlocked.Decrement(ref _runningThreads);
                });
        }



        private unsafe void SignalWorkerThreadsToStop()
        {
            Observable.Interval(TimeSpan.FromMilliseconds(25))
                .TakeWhile(_ => _runningThreads > 0)
                .Select(_ =>
                {
                    var result = new SwatcherAsyncResult { Buffer = new byte[0] };
                    var overlapped = new Overlapped { AsyncResult = result };

                    //the first parameter is null because we're not using IO completion callbacks; they're too slow.
                    //we're taking the byte array from our empty byte array and passing that as user data to the overlapped.
                    var overlappedPointer = overlapped.UnsafePack(null, result.Buffer);
                    //when using IOCPs, we can send our own custom messages to the GetQueuedCompletionStatus
                    //method by call PostQueuedCompletionStatus. In this case, we want to stop the threads that are
                    //waiting on change events, so we will send a custom completion key "StopIocpThreads".
                    WindowsFacade.PostQueuedCompletionStatus(CompletionPortHandle, 0, Constants.StopIocpThreads, overlappedPointer);
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
                        (uint)completionKey, (uint)Environment.ProcessorCount);

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
        
        #region Native Methods

        // ReSharper disable once SuggestVarOrType_Elsewhere
        private static unsafe bool SubscribeToFolderChanges(
            ISwatcherConfig config, IWindowsFacade windowsFacade, SafeFileHandle directoryHandle)
        {
            var result = new SwatcherAsyncResult { Buffer = new byte[Constants.DefaultBufferSize] };
            var overlapped = new Overlapped { AsyncResult = result };

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
                    var bufferHandle = new HandleRef(result, (IntPtr)bufferPointer);
                    var isRecursive = Convert.ToInt32(config.IsRecursive);

                    //because we're using IO completion ports, we pass our overlapped pointer into this unmanaged 
                    //call. when a change has been received, the OS will callback via GetQueuedCompletionStatus
                    //passing the overlapped pointer (which has our IAsyncResult/byte array) back to us.
                    success = windowsFacade.ReadDirectoryChangesW(
                        directoryHandle, bufferHandle, Constants.DefaultBufferSize, isRecursive,
                        (int)config.NotificationTypes, bytesReturnedNotUsed, overlappedPointer, SafeLocalMemHandle.Empty);
                }

                return success;
            }
            finally
            {
                //if success is false, our directory handle has likely become invalid. 
                if (!success)
                {
                    //before doing anything else, cleanup here to prevent memory leaks.
                    Overlapped.Free(overlappedPointer);
                }
            }
        }

        internal static unsafe QueuedCompletionStatus? OnNativeNotification(
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
                &overlappedPointer, Constants.InfiniteTimeout);

            if (!success)
                return new QueuedCompletionStatus(overlappedPointer, completionKey, bytesRead, false);

            if (completionKey == Constants.StopIocpThreads)
                Thread.CurrentThread.Abort();

            if (bytesRead == 0)
                return null;

            return new QueuedCompletionStatus(overlappedPointer, completionKey, bytesRead, success);
        }


        #endregion

        #region Dispatcher Methods

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

        private void OnItemException(object sender, SwatcherException e)
        {
            ItemException?.Invoke(sender,e);
        }

        #endregion

        #region Private Fields & Properties

        private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();
        private static readonly TimeSpan QuarterSecond = TimeSpan.FromMilliseconds(500);
        private static readonly TimeSpan OneSecond = TimeSpan.FromSeconds(1);
        private readonly ISubject<Unit> _startThreadPoolSubject = new Subject<Unit>();
        private readonly ISubject<SwatcherException> _exceptionSubject = new Subject<SwatcherException>();
        private int _runningThreads;
        private IObservable<EventNotification> NotificationStream { get; set; }
        private IEventPatternSource<SwatcherEventArgs> ChangedEventPatternSource { get; set; }
        private IEventPatternSource<SwatcherEventArgs> DeletedEventPatternSource { get; set; }
        private IEventPatternSource<SwatcherRenamedEventArgs> RenamedEventPatternSource { get; set; }
        private IEventPatternSource<SwatcherCreatedEventArgs> CreatedEventPatternSource { get; set; }
        private IEventPatternSource<SwatcherException> ExceptionEventPatternSource { get; set; }
        private CancellationTokenSource TokenSource { get; set; }
        private ISwatcherConfig Config { get; }
        private IWindowsFacade WindowsFacade { get; }
        private SafeFileHandle DirectoryHandle { get; set; }
        private SafeLocalMemHandle CompletionPortHandle { get; set; }
        private HashSet<string> CreatedEventsInProgress { get; set; }
        private CompositeDisposable Disposables { get; set; }


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

            return String.IsNullOrWhiteSpace(
                Path.GetExtension(fileName))
                ? SwatcherItemTypes.Folder
                : SwatcherItemTypes.File;
        }

        #endregion

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Stop().GetAwaiter().GetResult();

            ChangedEventPatternSource.OnNext -= OnItemChanged;
            DeletedEventPatternSource.OnNext -= OnItemDeleted;
            RenamedEventPatternSource.OnNext -= OnItemRenamed;
            CreatedEventPatternSource.OnNext -= OnItemCreated;
            ExceptionEventPatternSource.OnNext -= OnItemException;

            IsDisposed = true;
        }
    }
}
