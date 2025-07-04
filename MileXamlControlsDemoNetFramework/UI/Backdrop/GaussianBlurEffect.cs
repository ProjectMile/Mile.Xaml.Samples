﻿using MileXamlControlsDemoNetFramework.Helpers;
using MileXamlControlsDemoNetFramework.WindowsAPI.ComTypes;
using System;
using System.Runtime.InteropServices;
using Windows.Graphics.Effects;

namespace MileXamlControlsDemoNetFramework.UI.Backdrop
{
    [Guid("1FEB6D69-2FE6-4AC9-8C58-1D7F93E7A6A5")]
    public class GaussianBlurEffect : IGraphicsEffect, IGraphicsEffectSource, IGraphicsEffectD2D1Interop
    {
        private Guid clsid = new("1FEB6D69-2FE6-4AC9-8C58-1D7F93E7A6A5");

        public D2D1_BUFFER_PRECISION BufferPrecision { get; set; }

        public bool CacheOutput { get; set; }

        public IGraphicsEffectSource Source { get; set; }

        public float BlurAmount { get; set; } = 3.0f;

        public EffectOptimization Optimization { get; set; } = EffectOptimization.Balanced;

        public EffectBorderMode BorderMode { get; set; } = EffectBorderMode.Soft;

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
                case nameof(BlurAmount):
                    {
                        index = 0;
                        mapping = GRAPHICS_EFFECT_PROPERTY_MAPPING.GRAPHICS_EFFECT_PROPERTY_MAPPING_DIRECT;
                        break;
                    }
                case nameof(Optimization):
                    {
                        index = 1;
                        mapping = GRAPHICS_EFFECT_PROPERTY_MAPPING.GRAPHICS_EFFECT_PROPERTY_MAPPING_DIRECT;
                        break;
                    }
                case nameof(BorderMode):
                    {
                        index = 2;
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
                BackdropHelper.PropertyValueStatics.CreateSingle(BlurAmount, out IntPtr ptr);

                if (ptr != IntPtr.Zero)
                {
                    source = ptr;
                    return 0;
                }
            }
            else if (index is 1)
            {
                BackdropHelper.PropertyValueStatics.CreateUInt32((uint)Optimization, out IntPtr ptr);

                if (ptr != IntPtr.Zero)
                {
                    source = ptr;
                    return 0;
                }
            }
            else if (index is 2)
            {
                BackdropHelper.PropertyValueStatics.CreateUInt32((uint)BorderMode, out IntPtr ptr);

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
            count = 3;
            return 0;
        }

        public int GetSource(uint index, out IntPtr source)
        {
            if (index is 0)
            {
                source = Marshal.GetComInterfaceForObject(Source, typeof(IGraphicsEffectSource));
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
            count = 1;
            return 0;
        }
    }
}
