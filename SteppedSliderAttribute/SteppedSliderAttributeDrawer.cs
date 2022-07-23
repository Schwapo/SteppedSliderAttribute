#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;

namespace Sirenix.OdinInspector.Editor.Drawers
{
    public class SteppedSliderAttributeByteDrawer : OdinAttributeDrawer<SteppedSliderAttribute, byte>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            ValueEntry.SmartValue = (byte)SteppedSlider.IntSlider(label, ValueEntry.SmartValue, (int)Attribute.Min, (int)Attribute.Max, (int)Attribute.Step, byte.MinValue, byte.MaxValue);
        }
    }

    public class SteppedSliderAttributeSByteDrawer : OdinAttributeDrawer<SteppedSliderAttribute, sbyte>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            ValueEntry.SmartValue = (sbyte)SteppedSlider.IntSlider(label, ValueEntry.SmartValue, (int)Attribute.Min, (int)Attribute.Max, (int)Attribute.Step, sbyte.MinValue, sbyte.MaxValue);
        }
    }

    public class SteppedSliderAttributeShortDrawer : OdinAttributeDrawer<SteppedSliderAttribute, short>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            ValueEntry.SmartValue = (short)SteppedSlider.IntSlider(label, ValueEntry.SmartValue, (int)Attribute.Min, (int)Attribute.Max, (int)Attribute.Step, short.MinValue, short.MaxValue);
        }
    }
    
    public class SteppedSliderAttributeUShortDrawer : OdinAttributeDrawer<SteppedSliderAttribute, ushort>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            ValueEntry.SmartValue = (ushort)SteppedSlider.IntSlider(label, ValueEntry.SmartValue, (int)Attribute.Min, (int)Attribute.Max, (int)Attribute.Step, ushort.MinValue, ushort.MaxValue);
        }
    }

    public class SteppedSliderAttributeIntDrawer : OdinAttributeDrawer<SteppedSliderAttribute, int>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            ValueEntry.SmartValue = SteppedSlider.IntSlider(label, ValueEntry.SmartValue, (int)Attribute.Min, (int)Attribute.Max, (int)Attribute.Step, int.MinValue, int.MaxValue);
        }
    }
    
    public class SteppedSliderAttributeUIntDrawer : OdinAttributeDrawer<SteppedSliderAttribute, uint>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            ValueEntry.SmartValue = (uint)SteppedSlider.IntSlider(label, (int)ValueEntry.SmartValue, (int)Attribute.Min, (int)Attribute.Max, (int)Attribute.Step, (int)uint.MinValue, int.MaxValue);
        }
    }
    
    public class SteppedSliderAttributeLongDrawer : OdinAttributeDrawer<SteppedSliderAttribute, long>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            ValueEntry.SmartValue = SteppedSlider.IntSlider(label, (int)ValueEntry.SmartValue, (int)Attribute.Min, (int)Attribute.Max, (int)Attribute.Step, int.MinValue, int.MaxValue);
        }
    }
    
    public class SteppedSliderAttributeULongDrawer : OdinAttributeDrawer<SteppedSliderAttribute, ulong>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            ValueEntry.SmartValue = (ulong)SteppedSlider.IntSlider(label, (int)ValueEntry.SmartValue, (int)Attribute.Min, (int)Attribute.Max, (int)Attribute.Step, int.MinValue, int.MaxValue);
        }
    }
   
    public class SteppedSliderAttributeFloatDrawer : OdinAttributeDrawer<SteppedSliderAttribute, float>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            ValueEntry.SmartValue = SteppedSlider.FloatSlider(label, ValueEntry.SmartValue, Attribute.Min, Attribute.Max, Attribute.Step, float.MinValue, float.MaxValue);
        }
    }
    
    public class SteppedSliderAttributeDoubleDrawer : OdinAttributeDrawer<SteppedSliderAttribute, double>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            ValueEntry.SmartValue = SteppedSlider.FloatSlider(label, (float)ValueEntry.SmartValue, Attribute.Min, Attribute.Max, Attribute.Step, float.MinValue, float.MaxValue);
        }
    }
    
    public class SteppedSliderAttributeDecimalDrawer : OdinAttributeDrawer<SteppedSliderAttribute, decimal>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            ValueEntry.SmartValue = (decimal)SteppedSlider.FloatSlider(label, (float)ValueEntry.SmartValue, Attribute.Min, Attribute.Max, Attribute.Step, float.MinValue, float.MaxValue);
        }
    }

    public static class SteppedSlider
    {
        public static int IntSlider(GUIContent label, int value, int min, int max, int step, int typeMin, int typeMax)
        {
            min = Mathf.Max(min, typeMin);
            max = Mathf.Min(max, typeMax);

            var rect = EditorGUILayout.GetControlRect(label != null);

            if (label != null)
            {
                rect = EditorGUI.PrefixLabel(rect, label);
            }

            value = EditorGUI.IntSlider(rect, value, min, max);

            return (int)SteppedValue(value, step);
        }

        public static float FloatSlider(GUIContent label, float value, float min, float max, float step, float typeMin, float typeMax)
        {
            min = Mathf.Max(min, typeMin);
            max = Mathf.Min(max, typeMax);

            var rect = EditorGUILayout.GetControlRect(label != null);

            if (label != null)
            {
                rect = EditorGUI.PrefixLabel(rect, label);
            }

            value = EditorGUI.Slider(rect, value, min, max);

            return SteppedValue(value, step);
        }
        
        private static float SteppedValue(float value, float step)
        {
            var absValue = Mathf.Abs(value);
            var absStep = Mathf.Abs(step);

            var low = absValue - (absValue % absStep);
            var high = low + absStep;

            var result = absValue - low < high - absValue ? low : high;

            return result * Math.Sign(value);
        }
    }
}
#endif
