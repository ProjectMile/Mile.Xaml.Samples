﻿using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace MileXamlBlankAppNetCoreModern.WindowsAPI.ComTypes
{
    [GeneratedComInterface, Guid("29E691FA-4567-4DCA-B319-D0F207EB6807")]
    public partial interface ICompositorDesktopInterop
    {
        [PreserveSig]
        int CreateDesktopWindowTarget(IntPtr hwndTarget, [MarshalAs(UnmanagedType.VariantBool)] bool isTopmost, out IntPtr result);

        [PreserveSig]
        int EnsureOnThread(int threadId);
    }
}
