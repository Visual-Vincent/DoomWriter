using System;

namespace DoomWriter
{
    /// <summary>
    /// Encapsulates an in-memory image-based glyph.
    /// </summary>
    public class ImageGlyph : IGlyph<Image>
    {
        /// <summary>
        /// Gets the image containing the glyph.
        /// </summary>
        public Image Image { get; }

        /// <summary>
        /// Gets the x-coordinate of the top-left corner of the glyph in <see cref="Image"/>.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Gets the y-coordinate of the top-left corner of the glyph in <see cref="Image"/>.
        /// </summary>
        public int Y { get; }

        /// <inheritdoc/>
        public int Width { get; }

        /// <inheritdoc/>
        public int Height { get; }

        /// <inheritdoc/>
        public void Draw(ISurface<Image> destination, int x, int y)
        {
            destination.DrawImage(Image, x, y);
        }
    }
}
