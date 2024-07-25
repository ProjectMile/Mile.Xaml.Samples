﻿using System;
using System.Runtime.InteropServices;
using Windows.Graphics.Effects;
using MileXamlBlankAppNetFrameworkModern.Backdrop;
using MileXamlBlankAppNetFrameworkModern.WindowsAPI.ComTypes;

namespace MileXamlBlankAppNetFrameworkModern.UI.Backdrop
{
    [Guid("12F575E8-4DB1-485F-9A84-03A07DD3829F")]
    public class CrossFadeEffect : IGraphicsEffect, IGraphicsEffectSource, IGraphicsEffectD2D1Interop
    {
        private Guid clsid = new("12F575E8-4DB1-485F-9A84-03A07DD3829F");

        public D2D1_BUFFER_PRECISION BufferPrecision { get; set; }

        public bool CacheOutput { get; set; }

        public float CrossFade { get; set; } = 0.5f;

        public IGraphicsEffectSource Source1 { get; set; }

        public IGraphicsEffectSource Source2 { get; set; }

        private string _name = string.Empty;

        public string Name
        {
            get { return _name; }

            set { _name = value; }
        }

        public int GetEffectId(out Guid id)
        {
            id = clsid;
            return 0;
        }

        public int GetNamedPropertyMapping(string name, out uint index, out GRAPHICS_EFFECT_PROPERTY_MAPPING mapping)
        {
            switch (name)
            {
                case nameof(CrossFade):
                    {
                        index = 0;
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
                BackdropHelper.PropertyValueStatics.Value.CreateSingle((float)CrossFade, out IntPtr ptr);
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

        public int GetSource(uint index, out IntPtr source)
        {
            if (index is 0)
            {
                source = Marshal.GetComInterfaceForObject(Source1, typeof(IGraphicsEffectSource));
                return 0;
            }
            else if (index is 1)
            {
                source = Marshal.GetComInterfaceForObject(Source2, typeof(IGraphicsEffectSource));
                return 0;
            }
            else
            {
                source = IntPtr.Zero;
                return 2147483637;
            }
        }

        public int GetSourceCount(out uint count)
        {
            count = 2;
            return 0;
        }
    }
}
