using System;

namespace DoomWriter
{
    public static class NumericExtensions
    {
        /// <summary>
        /// Clamps the number within the specified range of values.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        public static int Clamp(this int value, int min, int max)
        {
            if(value < min)
                return min;

            if(value > max)
                return max;

            return value;
        }
    }
}
