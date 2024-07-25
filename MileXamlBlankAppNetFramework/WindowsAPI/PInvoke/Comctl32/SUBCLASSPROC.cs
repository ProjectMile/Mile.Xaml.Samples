using System;
using MileXamlBlankAppNetFrameworkModern.WindowsAPI.PInvoke.User32;

namespace MileXamlBlankAppNetFrameworkModern.WindowsAPI.PInvoke.Comctl32
{
    public delegate IntPtr SUBCLASSPROC(IntPtr hWnd, WindowMessage uMsg, UIntPtr wParam, IntPtr lParam, uint uIdSubclass, IntPtr dwRefData);
}
