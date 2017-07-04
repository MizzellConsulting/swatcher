using System;
using System.Threading.Tasks;
using BraveLantern.Swatcher.Args;

namespace BraveLantern.Swatcher
{
    /// <summary>
    /// The contract for consuming the reactive version of a <see cref="Swatcher"/>.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="ISwatcherRx"/>
    /// <seealso cref="ISwatcherEvents"/>
    public interface ISwatcher : ISwatcherRx, ISwatcherEvents,  IDisposable
    {
        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value><c>true</c> if this instance is disposed; otherwise, <c>false</c>.</value>
        bool IsDisposed { get; }
        /// <summary>
        /// Returns a value indicating whether or not this Swatcher is running.
        /// </summary>
        /// <value><c>true</c> if this instance is running; otherwise, <c>false</c>.</value>
        bool IsRunning { get; }


        /// <summary>
        /// Causes the <see cref="ISwatcher"/> to start listening for file system events.
        /// </summary>
        Task Start();
        /// <summary>
        /// Causes the <see cref="ISwatcher"/> to stop listening for file system events.
        /// </summary>
        /// <remarks>If a long running file copy|create|upload operation was in progress when 
        /// the <see cref="Stop"/> method is called, the <see cref="ISwatcherRx.Created"/> stream will still notify subscribers when that
        /// operation is completed as long as the subscription is in place and the <see cref="IDisposable.Dispose"/> method
        /// has not been called. </remarks>
        Task Stop();
    }
}