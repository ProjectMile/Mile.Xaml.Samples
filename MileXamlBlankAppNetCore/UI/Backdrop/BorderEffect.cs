﻿using MileXamlBlankAppNetCoreModern.Backdrop;
using MileXamlBlankAppNetCoreModern.WindowsAPI.ComTypes;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Windows.Graphics.Effects;

namespace MileXamlBlankAppNetCoreModern.UI.Backdrop
{
    [Guid("2A2D49C0-4ACF-43C7-8C6A-7C4A27874D27")]
    public partial class BorderEffect : IGraphicsEffect, IGraphicsEffectSource, IGraphicsEffectD2D1Interop
    {
        public D2D1_BUFFER_PRECISION BufferPrecision { get; set; }

        public bool CacheOutput { get; set; }

        public CanvasEdgeBehavior ExtendX { get; set; } = CanvasEdgeBehavior.Clamp;

        public CanvasEdgeBehavior ExtendY { get; set; } = CanvasEdgeBehavior.Clamp;

        public IGraphicsEffectSource Source { get; set; }

        private string _name = string.Empty;

        public string Name
        {
            get { return _name; }

            set { _name = value; }
        }

        public int GetEffectId(out Guid id)
        {
            id = typeof(BorderEffect).GUID;
            return 0;
        }

        public int GetNamedPropertyMapping(IntPtr name, out uint index, out GRAPHICS_EFFECT_PROPERTY_MAPPING mapping)
        {
            switch (Marshal.PtrToStringUni(name))
            {
                case nameof(ExtendX):
                    {
                        index = 0;
                        mapping = GRAPHICS_EFFECT_PROPERTY_MAPPING.GRAPHICS_EFFECT_PROPERTY_MAPPING_DIRECT;
                        break;
                    }
                case nameof(ExtendY):
                    {
                        index = 1;
                        mapping = GRAPHICS_EFFECT_PROPERTY_MAPPING.GRAPHICS_EFFECT_PROPERTY_MAPPING_DIRECT;
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
                BackdropHelper.PropertyValueStatics.Value.CreateUInt32((uint)ExtendX, out IntPtr ptr);

                if (ptr != IntPtr.Zero)
                {
                    source = ptr;
                    return 0;
                }
            }
            else if (index is 1)
            {
                BackdropHelper.PropertyValueStatics.Value.CreateUInt32((uint)ExtendY, out IntPtr ptr);

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
            count = 2;
            return 0;
        }

        public int GetSource(uint index, out IGraphicsEffectSource source)
        {
            if (index is 0)
            {
                source = Source;
                return 0;
            }
            else
            {
                source = null;
                return 2147483637;
            }
        }

        public int GetSourceCount(out uint count)
        {
            count = 1;
            return 0;
        }
    }
}
