using System;
using System.Drawing;

namespace DoomWriter.FontEditor
{
    public static class DrawingExtensions
    {
        /// <summary>
        /// Ensures that the size is positive and not zero. If the width or height are less than 1, they will be clamped to 1.
        /// </summary>
        /// <param name="size">The size to clamp.</param>
        public static Size NotZero(this Size size)
        {
            if(size.Width > 0 && size.Height > 0)
                return size;

            return new Size(
                size.Width > 0 ? size.Width : 1,
                size.Height > 0 ? size.Height : 1
            );
        }
    }
}
