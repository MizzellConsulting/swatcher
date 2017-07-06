using System;
using System.IO;
using System.Reactive.Disposables;
using BraveLantern.Swatcher;
using BraveLantern.Swatcher.Config;
using BraveLantern.Swatcher.Logging;

namespace ReactiveHelloWorld
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "Reactive Hello World";
            Console.WriteLine("Starting up Swatcher...");

            var disposables = new CompositeDisposable();
            var config = CreateConfiguration();
            var swatcher = new Swatcher(config);

            //NOTE: you will get logging message output to the console if you enabled logging in the Swatcher config.
            //put your business logic in the handlers below and you're good to go.
            swatcher.Changed.Subscribe(x =>
                    {
                        if (config.LoggingEnabled) return;
                        Console.WriteLine($"[Changed] Name: {x.Name}, OccurredAt:{x.TimeOccurred.ToLocalTime()}");
                    },
                    () => Console.WriteLine("The changed stream has completed."))
                .DisposeWith(disposables);

            swatcher.Created.Subscribe(x =>
                    {
                        if (config.LoggingEnabled) return;
                        var processingTime = x.Duration.Seconds > 1
                            ? $"{x.Duration.Seconds} sec"
                            : $"{x.Duration.Milliseconds} ms";

                        Console.WriteLine(
                            $"[Created] Name: {x.Name}, OccurredAt:{x.TimeOccurred.ToLocalTime()}, ProcessingTime: {processingTime}");
                    },
                    () => Console.WriteLine("The created stream has completed."))
                .DisposeWith(disposables);

            swatcher.Deleted.Subscribe(x =>
                    {
                        if (config.LoggingEnabled) return;
                        Console.WriteLine($"[Deleted] Name: {x.Name}, OccurredAt:{x.TimeOccurred.ToLocalTime()}");
                    },
                    () => Console.WriteLine("The deleted stream has completed."))
                .DisposeWith(disposables);

            swatcher.Renamed.Subscribe(x =>
                    {
                        if (config.LoggingEnabled) return;
                        Console.WriteLine(
                            $"[Renamed] OldName: {x.OldName}, Name: {x.Name}, OccurredAt:{x.TimeOccurred.ToLocalTime()}");
                    },
                    () => Console.WriteLine("The renamed stream has completed."))
                .DisposeWith(disposables);

            //to see the behavior when an exception is encountered, delete the Swatcher folder ;-).
            swatcher.Exception.Subscribe(x =>
            {
                Console.WriteLine(x.Message);
            })
            .DisposeWith(disposables);

            swatcher.Start().GetAwaiter().GetResult();

            Console.WriteLine("Swatcher has started and is listening for events...");
            Console.ReadKey();

            //Do stuff in your monitored folder....

            //Shutting down
            swatcher.Stop().GetAwaiter().GetResult();
            //Unsubscribe after you Stop if you're done with the component.
            disposables.Dispose();
            swatcher.Dispose();

            //voila! contrived, but pretty easy, eh?
        }

        private static ISwatcherConfig CreateConfiguration()
        {
            LogProvider.SetCurrentLogProvider(new ColoredConsoleLogProvider());
            //The swatcherId parameter is optional in case you don't want to use it. It really comes 
            //in handy when you are creating several Swatchers at runtime and you need to know from  
            //which Swatcher an event is being raised.
            //var swatcherId = 12345;

            //The folderPath parameter is the path to a folder that you want Swatcher to watch.
            //UNC paths are not supported! If you want to monitor a network folder, you need to map
            //it as a drive.
            var folderPath = @"C:\Users\Marti\Desktop\Monitored";
            //The changeTypes parameter is an bitwise OR of the change types that you want Swatcher to tell you about.
            //see docs here: https://msdn.microsoft.com/en-us/library/t6xf43e0(v=vs.110).aspx
            var changeTypes = WatcherChangeTypes.All;
            //The itemTypes parameter is used to tell Swatcher if you want to be notified of changes to files, folders,
            //or both. 
            var itemTypes = SwatcherItemTypes.All;
            //see docs here: https://msdn.microsoft.com/en-us/library/system.io.notifyfilters(v=vs.110).aspx
            var notificationFilters = SwatcherNotificationTypes.All;

            return new SwatcherConfig(folderPath, changeTypes, itemTypes, notificationFilters, loggingEnabled: true);
        }
    }
}