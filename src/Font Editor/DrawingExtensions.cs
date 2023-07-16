using System;
using System.Drawing;

namespace FontEditor
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

        /// <summary>
        /// Clamps the rectangle within the specified bounds.
        /// </summary>
        /// <param name="rect">The rectangle to clamp.</param>
        /// <param name="bounds">The bounds within which the rectangle will be clamped.</param>
        public static Rectangle Clamp(this Rectangle rect, Rectangle bounds)
        {
            if(bounds.Contains(rect))
                return rect;

            if(!rect.IntersectsWith(bounds))
                throw new ArgumentException("Rectangle does not overlap the specified bounds", nameof(rect));

            int x = rect.X;
            int y = rect.Y;
            int w = rect.Width;
            int h = rect.Height;

            if(x < bounds.X)
            {
                w -= bounds.X - x;
                x = bounds.X;
            }

            if(y < bounds.Y)
            {
                h -= bounds.Y - y;
                y = bounds.Y;
            }

            if(x + w > bounds.Right)
            {
                w = bounds.Width - x;
            }

            if(y + h > bounds.Bottom)
            {
                h = bounds.Height - y;
            }

            return new Rectangle(x, y, w, h);
        }
    }
}
