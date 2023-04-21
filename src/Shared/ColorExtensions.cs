using System;
using SixLabors.ImageSharp.PixelFormats;

namespace DoomWriter
{
    public static class ColorExtensions
    {
        /// <summary>
        /// Returns a string representation of the color in hexadecimal form.
        /// </summary>
        /// <param name="color">The color to convert to a string.</param>
        public static string ToHexString(this Rgba32 color)
        {
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }
    }
}
