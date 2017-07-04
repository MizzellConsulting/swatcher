using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BraveLantern.Swatcher.Args;

namespace BraveLantern.Swatcher
{
    /// <summary>
    /// A contract which defines the events of an <see cref="ISwatcher"/> object.
    /// </summary>
    public interface ISwatcherEvents
    {
        /// <summary>
        /// Provides notifications when a <b>change</b> event occurs.
        /// </summary>
        /// <value>The <see cref="SwatcherEventArgs"/> meta for a <b>change</b> event.</value>
        event EventHandler<SwatcherEventArgs> ItemChanged;
        /// <summary>
        /// Provides notifications when a <b>created</b> event occurs.
        /// </summary>
        /// <value>The <see cref="SwatcherCreatedEventArgs"/> meta for a <b>created</b> event.</value>
        event EventHandler<SwatcherCreatedEventArgs> ItemCreated;
        /// <summary>
        /// Provides notifications when a <b>deleted</b> event occurs.
        /// </summary>
        /// <value>The <see cref="SwatcherEventArgs"/> meta for a <b>deleted</b> event.</value>
        event EventHandler<SwatcherEventArgs> ItemDeleted;
        /// <summary>
        /// Provides notifications when a <b>renamed</b> event occurs.
        /// </summary>
        /// <value>The <see cref="SwatcherRenamedEventArgs"/> meta for a <b>renamed</b> event.</value>
        event EventHandler<SwatcherRenamedEventArgs> ItemRenamed;
        /// <summary>
        /// Provides notifications when an internal exception is encountered. See <see cref="ISwatcherRx.Exception"/>.
        /// </summary>
        event EventHandler<SwatcherException> ItemException;
    }
}
