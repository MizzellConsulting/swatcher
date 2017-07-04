using System;
using System.IO;
using BraveLantern.Swatcher.Config;

namespace BraveLantern.Swatcher.Args
{
    /// <summary>
    /// Class SwatcherEventArgs. 
    /// </summary>
    public class SwatcherEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwatcherEventArgs" /> class.
        /// </summary>
        /// <param name="config">The configuration for the <see cref="Swatcher"/>that created this instance.</param>
        /// <param name="changeType">Type of the change.</param>
        /// <param name="name">The name.</param>
        public SwatcherEventArgs(ISwatcherConfig config, WatcherChangeTypes changeType, string name)
        {
            SwatcherId = config.Id;
            ChangeType = changeType;
            Name = name;
            TimeOccurred = DateTime.UtcNow;
            EventId = Guid.NewGuid();
            FullPath = string.Concat(config.PathToWatch,name);
        }

        /// <summary>
        /// Gets the Swatcher identifier, if provided.
        /// </summary>
        /// <value>The swatcher identifier.</value>
        public int? SwatcherId { get; }
        /// <summary>
        /// Gets the type of the change.
        /// </summary>
        /// <value>The type of the change.</value>
        public WatcherChangeTypes ChangeType { get; }
        /// <summary>
        /// Gets the full path to the file or folder that changed.
        /// </summary>
        /// <value>The full path.</value>
        public string FullPath { get; }
        /// <summary>
        /// Gets the name of the file or folder that changed.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; }
        /// <summary>
        /// Gets a unique event id for this event.
        /// </summary>
        /// <value>The event identifier.</value>
        public Guid EventId { get; }
        /// <summary>
        /// Gets the UTC time that this event occurred.
        /// </summary>
        /// <value>The received time.</value>
        public DateTime TimeOccurred { get; }
    }
}
