using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable 1591

namespace BraveLantern.Swatcher.Native
{
    [StructLayout(LayoutKind.Sequential)]

    public class SecurityAttributes
    {
        public int nLength = 12;
        public SafeLocalMemHandle lpSecurityDescriptor = SafeLocalMemHandle.Empty;
        public bool bInheritHandle = false;
    }
}
