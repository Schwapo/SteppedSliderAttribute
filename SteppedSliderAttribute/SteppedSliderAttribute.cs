using System;

namespace Sirenix.OdinInspector
{
    public class SteppedSliderAttribute : Attribute
    {
        public float Min;
        public float Max;
        public float Step;

        public SteppedSliderAttribute(float min, float max, float step)
            => (Min, Max, Step) = (min, max, step);
    }
}
