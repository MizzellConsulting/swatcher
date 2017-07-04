using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BraveLantern.Swatcher.Args;
using BraveLantern.Swatcher.Config;
using BraveLantern.Swatcher.Native;

namespace BraveLantern.Swatcher.Extensions
{
    internal static class SwatcherExtensions
    {

        internal static unsafe IObservable<EventNotification> MapToEventNotification(
            this IObservable<QueuedCompletionStatus> source)
        {
            return source
                .Select(notification =>
                {
                    return Observable.Create<EventNotification>(observer =>
                    {
                        var overlapped = Overlapped.Unpack(notification.OverlappedPointer);
                        var asyncResult = (SwatcherAsyncResult)overlapped.AsyncResult;
                        var currentOffset = 0;
                        // ReSharper disable once TooWideLocalVariableScope
                        var nextOffset = 0;

                        try
                        {
                            do
                            {
                                string name;
                                FileSystemItemEvent @event;
                                fixed (byte* bufferPointer = asyncResult.Buffer)
                                {
                                    //buffer pointer was the address where we started.
                                    //add current offset to get the address of our the next offset.
                                    //4 bytes in an integer ;-).
                                    nextOffset = *(int*)(bufferPointer + currentOffset);
                                    // the next integer contains the action.
                                    @event = (FileSystemItemEvent)(*(int*)(bufferPointer + currentOffset + 4));
                                    //next int pointer has the address that contains the length of the name
                                    //of the item that was created,changed,renamed or deleted.
                                    var nameLength = *(int*)(bufferPointer + currentOffset + 8);
                                    //finally, retrieve the string via char* using the name length from above.
                                    //we divide the length by 2 because a unicode char is 2 bytes.
                                    name = new string((char*)(bufferPointer + currentOffset + 12), 0, nameLength / 2);
                                }

                                observer.OnNext(new EventNotification(@event,name));

                                currentOffset += nextOffset;

                            } while (nextOffset != 0);
                        }
                        finally
                        {
                            //*always* free up the overlapped. otherwise, we will have a memory leak equal to the buffer size after each callback.
                            Overlapped.Free(notification.OverlappedPointer);
                        }

                        return Disposable.Empty;
                    });
                })
                .Merge();
        }

        internal static IObservable<EventNotification> WithConfiguredEventTypes(
            this IObservable<EventNotification> @event, params FileSystemItemEvent[] eventTypes)
        {
            return @event.Where(x => eventTypes.Contains(x.Event));    
        }

        internal static IObservable<EventNotification> WithConfiguredItemTypes(
            this IObservable<EventNotification> @event, ISwatcherConfig config)
        {
            return @event
                .Select(x => new
                {
                    ItemType = GetItemType(string.Concat(config.PathToWatch,x.Name)),
                    Model = x
                })
                .Where(x => config.ItemTypes.HasFlag(x.ItemType))
                .Select(x => x.Model);
        }

        internal static IObservable<SwatcherEventArgs> WhereExists(this IObservable<SwatcherEventArgs> @events)
        {
            return @events.Where(x => File.Exists(x.FullPath) || Directory.Exists(x.FullPath));
        }

        internal static SwatcherItemTypes GetItemType(this string fullPath, bool throwIfNotExists = false)
        {
            if (File.Exists(fullPath) || Directory.Exists(fullPath))
            {
                try
                {
                    var attributes = File.GetAttributes(fullPath);
                    return attributes.HasFlag(FileAttributes.Directory)
                        ? SwatcherItemTypes.Folder
                        : SwatcherItemTypes.File;
                }
                /*a race condition occurred where the file/folder was deleted after the check but before inspecting attributes */
                catch(FileNotFoundException e)
                {
                    if (throwIfNotExists)
                        throw e;
                }
            }

            var fileName = Path.GetFileName(fullPath);

            return string.IsNullOrWhiteSpace(
                Path.GetExtension(fileName))
                ? SwatcherItemTypes.Folder
                : SwatcherItemTypes.File;
        }
    }
}