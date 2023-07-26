using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

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

        /// <summary>
        /// Gets the palette of unique colors in the image.
        /// </summary>
        /// <param name="image">The image whose color palette to get.</param>
        /// <param name="ignoreTransparent">Optional. Whether or not to ignore completely transparent colors (where the alpha channel is 0).</param>
        public static Color[] GetColorPalette(this Image image, bool ignoreTransparent = false)
        {
            var palette = new HashSet<Color>();

            using(var bmp = new Bitmap(image))
            {
                for(int y = 0; y < image.Height; y++)
                {
                    for(int x = 0; x < image.Width; x++)
                    {
                        var pixel = bmp.GetPixel(x, y);

                        if(!ignoreTransparent || pixel.A > 0)
                            palette.Add(bmp.GetPixel(x, y));
                    }
                }
            }

            return palette.ToArray();
        }
    }
}
