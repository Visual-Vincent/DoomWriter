using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

using SixLaborsImage = SixLabors.ImageSharp.Image;

namespace DoomWriter
{
    public static class ImageExtensions
    {
        /// <summary>
        /// Draws a portion of an image to the specified location in the current image.
        /// </summary>
        /// <param name="source">The source image being drawn to.</param>
        /// <param name="image">The image to draw.</param>
        /// <param name="point">The destination point where to draw the image.</param>
        /// <param name="srcRect">The portion of the specified image to draw.</param>
        public static IImageProcessingContext DrawImage(this IImageProcessingContext source, SixLaborsImage image, Point point, Rectangle srcRect)
        {
            GraphicsOptions options = source.GetGraphicsOptions();
            return source.ApplyProcessor(new DrawImageAlternateProcessor(image, point, options.ColorBlendingMode, options.AlphaCompositionMode, 1.0f), srcRect);
        }
    }
}
