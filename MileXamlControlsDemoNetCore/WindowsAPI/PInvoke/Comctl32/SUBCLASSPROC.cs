using MileXamlControlsDemoNetCore.WindowsAPI.PInvoke.User32;
using System;

namespace MileXamlControlsDemoNetCore.WindowsAPI.PInvoke.Comctl32
{
    public delegate IntPtr SUBCLASSPROC(IntPtr hWnd, WindowMessage uMsg, UIntPtr wParam, IntPtr lParam, uint uIdSubclass, IntPtr dwRefData);
}
