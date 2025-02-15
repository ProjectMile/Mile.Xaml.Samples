using System;
using System.Runtime.InteropServices;

namespace MileXamlControlsDemoNetCore.WindowsAPI.PInvoke.Combase
{
    public static partial class CombaseLibrary
    {
        private const string Combase = "combase.dll";

        [LibraryImport(Combase, EntryPoint = "RoGetActivationFactory", SetLastError = false), PreserveSig]
        public static partial int RoGetActivationFactory(IntPtr activatableClassId, in Guid iid, out IntPtr factory);

        [LibraryImport(Combase, EntryPoint = "WindowsCreateString", SetLastError = false, StringMarshalling = StringMarshalling.Utf16), PreserveSig]
        public static partial int WindowsCreateString([MarshalAs(UnmanagedType.LPWStr)] string sourceString, int length, out IntPtr hstring);

        [LibraryImport(Combase, EntryPoint = "WindowsDeleteString", SetLastError = false), PreserveSig]
        public static partial int WindowsDeleteString(IntPtr hstring);

        [LibraryImport(Combase, EntryPoint = "WindowsGetStringRawBuffer", SetLastError = false), PreserveSig]
        public static partial IntPtr WindowsGetStringRawBuffer(IntPtr hstring, out int length);
    }
}
