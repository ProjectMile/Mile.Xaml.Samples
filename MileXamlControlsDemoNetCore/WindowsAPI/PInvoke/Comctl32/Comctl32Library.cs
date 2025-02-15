using System;
using System.Runtime.InteropServices;
using MileXamlControlsDemoNetCore.WindowsAPI.PInvoke.User32;

namespace MileXamlControlsDemoNetCore.WindowsAPI.PInvoke.Comctl32
{
    public static partial class Comctl32Library
    {
        private const string Comctl32 = "comctl32.dll";

        [LibraryImport(Comctl32, EntryPoint = "SetWindowSubclass", SetLastError = false), PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool SetWindowSubclass(IntPtr hWnd, IntPtr pfnSubclass, uint uIdSubclass, IntPtr dwRefData);

        [LibraryImport(Comctl32, EntryPoint = "DefSubclassProc", SetLastError = false), PreserveSig]
        public static partial IntPtr DefSubclassProc(IntPtr hWnd, WindowMessage uMsg, UIntPtr wParam, IntPtr lParam);

        [LibraryImport(Comctl32, EntryPoint = "RemoveWindowSubclass", SetLastError = false)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool RemoveWindowSubclass(IntPtr hWnd, IntPtr pfnSubclass, uint uIdSubclass);
    }
}
