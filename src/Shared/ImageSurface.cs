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
    public sealed class ImageSurface<TPixel> : ISurface<Image>, IDisposable
        where TPixel : unmanaged, IPixel<TPixel>
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

        /// <summary>
        /// Gets the final, rendered image. The caller is responsible for disposing it.
        /// </summary>
        public Image<TPixel> GetImage()
        {
            return baseImage.Clone();
        }

        /// <inheritdoc/>
        public void DrawImage(Image image, int x, int y)
        {
            // Out of bounds check
            if(x > baseImage.Width || y > baseImage.Height || x + image.Width < 0 || y + image.Height < 0)
                return;

            baseImage.Mutate(c => c.DrawImage(image.BaseImage, new Point(x, y), 1.0f));
        }

        /// <inheritdoc/>
        public void DrawImage(Image image, int x, int y, Rectangle srcRect)
        {
            // Out of bounds check
            if(x > baseImage.Width || y > baseImage.Height || x + srcRect.Width < 0 || y + srcRect.Height < 0)
                return;

            baseImage.Mutate(c => c.DrawImage(image.BaseImage, new Point(x, y), srcRect));
        }

        /// <inheritdoc/>
        public void DrawImage(Image image, int x, int y, Rectangle srcRect, ColorTranslation translation)
        {
            // Out of bounds check
            if(x > baseImage.Width || y > baseImage.Height || x + srcRect.Width < 0 || y + srcRect.Height < 0)
                return;

            baseImage.Mutate(c => c.DrawImage(image.BaseImage, new Point(x, y), srcRect, translation));
        }

        #region IDisposable Support
        private bool disposedValue;

        private void Dispose(bool disposing)
        {
            if(!disposedValue)
            {
                if(disposing)
                {
                    // Dispose managed resources
                    baseImage?.Dispose();
                }

                // Free unmanaged resources

                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ImageSurface()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
