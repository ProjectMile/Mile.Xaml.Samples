using System;
using System.Runtime.InteropServices;
using MileXamlControlsDemoNetFramework.WindowsAPI.PInvoke.User32;

namespace MileXamlControlsDemoNetFramework.WindowsAPI.PInvoke.Comctl32
{
    public static partial class Comctl32Library
    {
        private const string Comctl32 = "comctl32.dll";

        [DllImport(Comctl32, CharSet = CharSet.Unicode, EntryPoint = "SetWindowSubclass", SetLastError = false)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowSubclass(IntPtr hWnd, SUBCLASSPROC pfnSubclass, uint uIdSubclass, IntPtr dwRefData);

        [DllImport(Comctl32, CharSet = CharSet.Unicode, EntryPoint = "DefSubclassProc", SetLastError = false)]
        public static extern IntPtr DefSubclassProc(IntPtr hWnd, WindowMessage uMsg, UIntPtr wParam, IntPtr lParam);

        [DllImport(Comctl32, CharSet = CharSet.Unicode, EntryPoint = "RemoveWindowSubclass", SetLastError = false)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RemoveWindowSubclass(IntPtr hWnd, SUBCLASSPROC pfnSubclass, uint uIdSubclass);
    }
}
