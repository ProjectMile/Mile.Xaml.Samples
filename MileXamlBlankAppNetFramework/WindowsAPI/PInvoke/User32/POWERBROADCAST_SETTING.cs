﻿using System;
using System.Runtime.InteropServices;

namespace MileXamlBlankAppNetFrameworkModern.WindowsAPI.PInvoke.User32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct POWERBROADCAST_SETTING
    {
        public Guid PowerSetting;

        public uint DataLength;

        public byte Data;
    }
}
