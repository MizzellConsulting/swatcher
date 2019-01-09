## Why another rendition of FileSystemWatcher?
The FileSystemWatcher is great for demo apps. For production code? Not so much. Swatcher was written from the ground-up to replace FileSystemWatcher and add the features you need: speed, reliability, events raised when they're supposed to be and an intuitive API that's awesome. Heck, it even provides both observables and events to cater to your coding style.

## Building

To build Swatcher just open the `Swatcher.sln` in Visual Studio.

Note that Swatcher has been compiled against the .Net 4.5.2 Framework.

## Licensing

### Swatcher

Swatcher is licensed under the RPL 1.5 license. More details can be found [here](LICENSE.md).

### Features
* No false change notifications when a file system item is created, deleted or renamed.
* When a large file is being uploaded, copied or moved, Swatcher will wait until the IO operations are completed before sending a creation notice.
* In addition to the aforementioned, `SwatcherCreatedEventArgs` includes a `ProcessingTime` property to inform you as to how long the IO operation took.
* In the `ISwatcherConfig`, you can specify a custom filter for `Created`, `Changed`, `Deleted` and `Renamed` events so an event is never raised for stuff you're not interested in.
* I added `LibLog` to enable developers to "hook" diagnostic info as a Swatcher is processing file system events. Thus, you'll be able to seamlessly integrate a Swatcher with whatever logging mechanism you're using. 

### Installation
Swatcher is installed using [NuGet](https://www.nuget.org/packages/Swatcher/):
`Install-Package Swatcher`

### Quirky Results with Text Editors
You may notice some strange artifacts when using a text editor (e.g. Visual Studio, Word, Atom ). Swatcher is'nt going nuts! These text editors may create temp files or delete and re-create the file you're editing frequently. There are plans to add extensions for popular text editors. Let me know if there's one most important to you or if you'd like to contribute!

### Configuring a Swatcher
```c#
private static ISwatcherConfig CreateConfiguration()
{
    BraveLantern.Swatcher.Logging.LogProvider.SetCurrentLogProvider(new ColoredConsoleLogProvider());

    //The swatcherId parameter is optional in case you don't want to use it. It really comes 
    //in handy when you are creating several Swatchers at runtime and you need to know from  
    //which Swatcher an event is being raised.
    //var swatcherId = 12345;

    //The folderPath parameter is the path to a folder that you want Swatcher to watch.
    //UNC paths are not supported! If you want to monitor a network folder, you need to map
    //it as a drive.
    var folderPath = @"C:\Users\Martin\Desktop\Monitored";

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
```

### Consuming a Swatcher
There are two different ways a Swatcher can be consumed:
* [Usage via Events](https://github.com/bravelantern/Swatcher/wiki/Usage-via-Events)
* [Usage via Rx Observables](https://github.com/bravelantern/Swatcher/wiki/Usage-via-Rx-Observables)
