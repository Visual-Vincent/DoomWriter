using System;

namespace DoomWriter
{
    /// <summary>
    /// Encapsulates properties and methods that describe a font glyph.
    /// </summary>
    /// <typeparam name="TImage">The type of image used by the glyph.</typeparam>
    public interface IGlyph<TImage> where TImage : IImage
    {
        /// <summary>
        /// Gets the width of the glyph.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Gets the width of the glyph.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Draws the glyph onto the destination surface.
        /// </summary>
        /// <param name="destination">The image to draw the glyph onto.</param>
        /// <param name="x">The x-coordinate of the top-left corner of the drawn image.</param>
        /// <param name="y">The y-coordinate of the top-left corner of the drawn image.</param>
        void Draw(ISurface<TImage> destination, int x, int y);
    }
}
