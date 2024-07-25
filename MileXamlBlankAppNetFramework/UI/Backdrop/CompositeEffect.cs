﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Windows.Graphics.Effects;
using MileXamlBlankAppNetFrameworkModern.Backdrop;
using MileXamlBlankAppNetFrameworkModern.WindowsAPI.ComTypes;

namespace MileXamlBlankAppNetFrameworkModern.UI.Backdrop
{
    [Guid("48FC9F51-F6AC-48F1-8B58-3B28AC46F76D")]
    public class CompositeEffect : IGraphicsEffect, IGraphicsEffectSource, IGraphicsEffectD2D1Interop
    {
        private Guid clsid = new("48FC9F51-F6AC-48F1-8B58-3B28AC46F76D");

        public D2D1_BUFFER_PRECISION BufferPrecision { get; set; }

        public bool CacheOutput { get; set; }

        public CanvasComposite Mode { get; set; } = CanvasComposite.SourceOver;

        private string _name = string.Empty;

        public string Name
        {
            get { return _name; }

            set { _name = value; }
        }

        public List<IGraphicsEffectSource> Sources { get; set; } = [];

        public int GetEffectId(out Guid id)
        {
            id = clsid;
            return 0;
        }

        public int GetNamedPropertyMapping(string name, out uint index, out GRAPHICS_EFFECT_PROPERTY_MAPPING mapping)
        {
            switch (name)
            {
                case nameof(Mode):
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
                BackdropHelper.PropertyValueStatics.Value.CreateUInt32((uint)Mode, out IntPtr ptr);

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
            if (index < Sources.Count)
            {
                source = Marshal.GetComInterfaceForObject(Sources[(int)index], typeof(IGraphicsEffectSource));
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
            count = (uint)Sources.Count;
            return 0;
        }
    }
}
