using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BraveLantern.Swatcher.Args;

namespace BraveLantern.Swatcher
{
    /// <summary>
    /// A contract which defines the reactive properties of an <see cref="ISwatcher"/> object.
    /// </summary>
    public interface ISwatcherRx
    {
        /// <summary>
        /// Gets a stream of <see cref="SwatcherEventArgs"/> that are pushed when a <b>change</b> event occurs.
        /// </summary>
        /// <value>The <see cref="SwatcherEventArgs"/> meta for a <b>change</b> event.</value>
        IObservable<SwatcherEventArgs> Changed { get; }
        /// <summary>
        /// Gets a stream of <see cref="SwatcherCreatedEventArgs"/> that are pushed when a <b>created</b> event occurs.
        /// </summary>
        /// <value>The <see cref="SwatcherCreatedEventArgs"/> meta for a <b>created</b> event.</value>
        IObservable<SwatcherCreatedEventArgs> Created { get; }
        /// <summary>
        /// Gets a stream of <see cref="SwatcherEventArgs"/> that are pushed when a <b>deleted</b> event occurs.
        /// </summary>
        /// <value>The <see cref="SwatcherEventArgs"/> meta for a <b>deleted</b> event.</value>
        IObservable<SwatcherEventArgs> Deleted { get; }
        /// <summary>
        /// Gets a stream of <see cref="SwatcherRenamedEventArgs"/> that are pushed when a <b>renamed</b> event occurs.
        /// </summary>
        /// <value>The <see cref="SwatcherRenamedEventArgs"/> meta for a <b>renamed</b> event.</value>
        IObservable<SwatcherRenamedEventArgs> Renamed { get; }

        /// <summary>
        /// Gets a stream of <see cref="SwatcherException"/> that are pushed when a <see cref="ISwatcher"/> encounters an internal exception.
        /// </summary>
        /// <value>The <see cref="SwatcherException"/> that descibes the exception.</value>
        /// <remarks>Immediately prior to pushing an exception onto the stream, <see cref="ISwatcher.Stop"/> will be called which will do the following:
        /// <list type="bullet">
        /// <item>
        /// <description>Complete the streams on the <see cref="ISwatcherRx"/> interface.</description>
        /// </item>
        /// <item>
        /// <description>Remove event handlers for the <see cref="ISwatcherEvents"/> interface.</description>
        /// </item>
        /// </list>
        /// NOTE: While it is possible to restart the <see cref="ISwatcher"/>, it is highly recommended to call <see cref="IDisposable.Dispose"/> and create a new instance.
        /// </remarks>
        IObservable<SwatcherException> Exception { get; }
    }
}
