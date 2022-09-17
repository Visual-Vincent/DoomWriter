using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace DoomWriter
{
    /// <summary>
    /// Represents a drawable image surface.
    /// </summary>
    /// <typeparam name="TPixel">The pixel format of the underlying image surface.</typeparam>
    public sealed class ImageSurface<TPixel> : ISurface<Image> where TPixel : unmanaged, IPixel<TPixel>
    {
        private readonly Image<TPixel> baseImage;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageSurface{TPixel}"/> class with the specified width and height of the drawable surface.
        /// </summary>
        /// <param name="width">The width, in pixels, of the image surface.</param>
        /// <param name="height">The height, in pixels, of the image surface.</param>
        public ImageSurface(int width, int height)
        {
            baseImage = new Image<TPixel>(width, height);
        }

        public void DrawImage(Image image, int x, int y)
        {
            baseImage.Mutate(c => c.DrawImage(image.BaseImage, new Point(x, y), 1.0f));
        }
    }
}
