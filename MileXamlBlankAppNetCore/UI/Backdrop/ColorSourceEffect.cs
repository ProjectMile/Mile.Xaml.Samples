﻿using MileXamlBlankAppNetCoreModern.Backdrop;
using MileXamlBlankAppNetCoreModern.WindowsAPI.ComTypes;
using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
using Windows.Graphics.Effects;
using Windows.UI;

namespace MileXamlBlankAppNetCoreModern.UI.Backdrop
{
    [Guid("61C23C20-AE69-4D8E-94CF-50078DF638F2")]
    public sealed partial class ColorSourceEffect : IGraphicsEffect, IGraphicsEffectSource, IGraphicsEffectD2D1Interop
    {
        public D2D1_BUFFER_PRECISION BufferPrecision { get; set; }

        public bool CacheOutput { get; set; }

        public Color Color { get; set; } = Color.FromArgb(255, 255, 255, 255);

        private string _name = string.Empty;

        public string Name
        {
            get { return _name; }

            set { _name = value; }
        }

        public Vector4 ColorHdr
        {
            get { return new(Color.R * 255.0f, Color.G * 255.0f, Color.B * 255.0f, Color.A * 255.0f); }

            set { Color = Color.FromArgb((byte)(value.W / 255.0f), (byte)(value.X / 255.0f), (byte)(value.Y / 255.0f), (byte)(value.Z / 255.0f)); }
        }

        public int GetEffectId(out Guid id)
        {
            id = typeof(ColorSourceEffect).GUID;
            return 0;
        }

        public int GetNamedPropertyMapping(IntPtr name, out uint index, out GRAPHICS_EFFECT_PROPERTY_MAPPING mapping)
        {
            switch (Marshal.PtrToStringUni(name))
            {
                case nameof(Color):
                    {
                        index = 0;
                        mapping = GRAPHICS_EFFECT_PROPERTY_MAPPING.GRAPHICS_EFFECT_PROPERTY_MAPPING_COLOR_TO_VECTOR4;
                        break;
                    }
                default:
                    {
                        index = 0xFF;
                        mapping = (GRAPHICS_EFFECT_PROPERTY_MAPPING)0xFF;
                        break;
                    }
            }

            return 0;
        }

        public int GetProperty(uint index, out IntPtr source)
        {
            if (index is 0)
            {
                BackdropHelper.PropertyValueStatics.Value.CreateSingleArray(4, [Color.R / 255.0f, Color.G / 255.0f, Color.B / 255.0f, Color.A / 255.0f], out IntPtr ptr);
                if (ptr != IntPtr.Zero)
                {
                    source = ptr;
                    return 0;
                }
            }

            source = IntPtr.Zero;
            return -2147483637;
        }

        public int GetPropertyCount(out uint count)
        {
            count = 1;
            return 0;
        }

        public int GetSource(uint index, out IGraphicsEffectSource source)
        {
            source = default;
            return 0;
        }

        public int GetSourceCount(out uint count)
        {
            count = 0;
            return 0;
        }
    }
}
