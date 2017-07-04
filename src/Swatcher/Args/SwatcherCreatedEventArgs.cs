using System;
using System.IO;
using BraveLantern.Swatcher.Config;

namespace BraveLantern.Swatcher.Args
{

    /// <summary>
    /// Class SwatcherCreatedEventArgs. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="SwatcherEventArgs" />
    public sealed class SwatcherCreatedEventArgs : SwatcherEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SwatcherCreatedEventArgs"/> class.
        /// </summary>
        /// <param name="config">The configuration for the <see cref="Swatcher"/>that created this instance.</param>
        /// <param name="name">The name of the file system item that was created.</param>
        public SwatcherCreatedEventArgs(ISwatcherConfig config, string name)
            : base(config,WatcherChangeTypes.Created, name)
        {}

        internal void MarkCompleted()
        {
            if (TimeCompleted.HasValue)
                throw new InvalidOperationException(
                    "The SwatcherCreatedEventArgs class has previous been marked as completed.");

            TimeCompleted = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets the time that it took from the initial creation of the file to when it was ready for access.
        /// </summary>
        /// <value>The processing time.</value>
        public TimeSpan Duration
        {
            get
            {
                if (TimeCompleted == null)
                    return TimeSpan.MinValue;

                return (TimeCompleted.Value - TimeOccurred);
            }
        }

        /// <summary>
        /// Gets the size of the file. N/A for folders.
        /// </summary>
        /// <value>The size.</value>
        public long? Size
        {
            get
            {
                if (!File.Exists(FullPath)) return null;
                if (TimeCompleted == null) return null;

                return new FileInfo(FullPath).Length;
            }
        }

        /// <summary>
        /// Gets the completed time.
        /// </summary>
        /// <value>The completed time.</value>
        public DateTime? TimeCompleted { get; private set; }
    }
}
