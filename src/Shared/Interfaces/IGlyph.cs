using System;

namespace DoomWriter
{
    /// <summary>
    /// Encapsulates properties and methods that describe a font glyph.
    /// </summary>
    public interface IGlyph
    {
        /// <summary>
        /// Gets the x-coordinate of the glyph in the source image/texture.
        /// </summary>
        int X { get; }

        /// <summary>
        /// Gets the y-coordinate of the glyph in the source image/texture.
        /// </summary>
        int Y { get; }

        /// <summary>
        /// Gets the width of the glyph.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Gets the width of the glyph.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Gets the glyph's descender.
        /// </summary>
        int Descender { get; }
    }
}
