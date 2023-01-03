using System;
using SixLabors.ImageSharp.Processing;

namespace DoomWriter
{
    /// <summary>
    /// Encapsulates an in-memory image-based glyph.
    /// </summary>
    public class ImageGlyph : IGlyph<Image>, IDisposable
    {
        /// <summary>
        /// Gets the image containing the glyph.
        /// </summary>
        public Image Image { get; }

        /// <inheritdoc/>
        public int Width { get; }

        /// <inheritdoc/>
        public int Height { get; }

        /// <inheritdoc/>
        public int Descender { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageGlyph"/> class.
        /// </summary>
        /// <param name="image">The image containing the glyph.</param>
        /// <param name="width">The width of the glyph.</param>
        /// <param name="height">The height of the glyph.</param>
        /// <param name="descender">The descender of the glyph.</param>
        public ImageGlyph(Image image, int width, int height, int descender)
        {
            if(image == null)
                throw new ArgumentNullException(nameof(image));

            if(width <= 0 || height <= 0)
                throw new ArgumentException("Width and height of the glyph must be greater than zero");

            if(descender < 0)
                throw new ArgumentException("The descender of the glyph must be greater than or equal to zero", nameof(descender));

            Image = image;
            Width = width;
            Height = height;
            Descender = descender;
        }

        /// <summary>
        /// Makes a deep copy of the <see cref="ImageGlyph"/>.
        /// </summary>
        public ImageGlyph Clone()
        {
            Image clonedImage = new Image(Image.BaseImage.Clone((img) => { }));
            return new ImageGlyph(clonedImage, Width, Height, Descender);
        }

        /// <inheritdoc/>
        public void Draw(ISurface<Image> destination, int x, int y)
        {
            destination.DrawImage(Image, x, y);
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
                    Image?.Dispose();
                }

                // Free unmanaged resources

                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ImageGlyph()
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
