using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

using SixLaborsImage = SixLabors.ImageSharp.Image;

namespace DoomWriter
{
    public static class ImageExtensions
    {
        /// <summary>
        /// Gets the pixel's luminance.
        /// </summary>
        /// <param name="pixel">The pixel whose luminance to get.</param>
        public static double Luminance(this Rgba32 pixel)
        {
            return pixel.R * 0.299 + pixel.G * 0.587 + pixel.B * 0.114;
        }

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

        /// <summary>
        /// Draws a portion of an image to the specified location in the current image, applying the specified color translation to it in the process.
        /// </summary>
        /// <param name="source">The source image being drawn to.</param>
        /// <param name="image">The image to draw.</param>
        /// <param name="point">The destination point where to draw the image.</param>
        /// <param name="srcRect">The portion of the specified image to draw.</param>
        /// <param name="translation">The color translation to apply when drawing.</param>
        public static IImageProcessingContext DrawImage(this IImageProcessingContext source, SixLaborsImage image, Point point, Rectangle srcRect, ColorTranslation translation)
        {
            GraphicsOptions options = source.GetGraphicsOptions();
            return source.ApplyProcessor(new DrawTranslatedImageProcessor(image, point, options.ColorBlendingMode, options.AlphaCompositionMode, translation, 1.0f), srcRect);
        }
    }
}
