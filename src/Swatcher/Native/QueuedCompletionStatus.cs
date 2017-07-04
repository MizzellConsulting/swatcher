using System.Runtime.InteropServices;
using System.Threading;

namespace BraveLantern.Swatcher.Native
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct QueuedCompletionStatus
    {
        public unsafe QueuedCompletionStatus(
            NativeOverlapped* overlappedPointer,uint completionKey,uint bytesRead, bool wasSuccessful)
        {
            OverlappedPointer = overlappedPointer;
            CompletionKey = completionKey;
            BytesRead = bytesRead;
            WasSuccessful = wasSuccessful;
        }

        internal unsafe NativeOverlapped* OverlappedPointer { get; }
        internal uint CompletionKey { get; }
        internal uint BytesRead { get; }
        internal bool WasSuccessful { get; }
    }
}
