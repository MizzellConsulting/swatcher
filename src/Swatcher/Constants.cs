using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraveLantern.Swatcher
{
    internal static class Constants
    {
        public const int DefaultBufferSize = 16384;
        public const uint StopIocpThreads = 0x7FFFFFFF;
        public const uint SwatcherFolderDeleted = 0x7FFFFFFE;
        public const uint InfiniteTimeout = 0xFFFFFFFF;
    }
}
