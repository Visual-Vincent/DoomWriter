using System;

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
