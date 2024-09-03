using System;
using MileXamlBlankAppNetCoreModern.WindowsAPI.PInvoke.User32;

namespace MileXamlBlankAppNetCoreModern.WindowsAPI.PInvoke.Comctl32
{
    public delegate IntPtr SUBCLASSPROC(IntPtr hWnd, WindowMessage uMsg, UIntPtr wParam, IntPtr lParam, uint uIdSubclass, IntPtr dwRefData);
}
