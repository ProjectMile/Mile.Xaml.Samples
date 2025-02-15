using System;
using System.Runtime.InteropServices;

namespace MileXamlControlsDemoNetFramework.WindowsAPI.PInvoke.Combase
{
    public static class CombaseLibrary
    {
        private const string Combase = "combase.dll";

        [DllImport(Combase, CharSet = CharSet.Unicode, ExactSpelling = true, EntryPoint = "RoGetActivationFactory", SetLastError = false)]
        public static extern int RoGetActivationFactory([MarshalAs(UnmanagedType.HString)] string activatableClassId, [MarshalAs(UnmanagedType.LPStruct)] Guid iid, out IntPtr factory);
    }
}
