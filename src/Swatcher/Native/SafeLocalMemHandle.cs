using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
#pragma warning disable 1591

namespace BraveLantern.Swatcher.Native
{
    [SuppressUnmanagedCodeSecurity]
    public sealed class SafeLocalMemHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public static readonly SafeLocalMemHandle Empty = new SafeLocalMemHandle(IntPtr.Zero, false);

        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        internal SafeLocalMemHandle(IntPtr existingHandle, bool ownsHandle = true) : base(ownsHandle)
        {
            SetHandle(existingHandle);
        }
        
        [DllImport("advapi32", CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
        [ResourceExposure(ResourceScope.None)]
        internal static extern unsafe bool ConvertStringSecurityDescriptorToSecurityDescriptor(
            string stringSecurityDescriptor, int stringSdRevision, out SafeLocalMemHandle pSecurityDescriptor, IntPtr securityDescriptorSize);

        [DllImport("kernel32")]
        [ResourceExposure(ResourceScope.None)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        private static extern IntPtr LocalFree(IntPtr hMem);

        protected override bool ReleaseHandle()
        {
            Console.WriteLine($"[SafeLocalMemHandle] Attempting to release {handle}");
            return LocalFree(handle) == IntPtr.Zero;
        }

    }
}
