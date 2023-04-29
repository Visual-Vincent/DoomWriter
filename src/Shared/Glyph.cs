using System;

namespace DoomWriter
{
    /// <summary>
    /// Encapsulates a font glyph.
    /// </summary>
    public sealed class Glyph : IGlyph
    {
        /// <inheritdoc/>
        public int X { get; }

        /// <inheritdoc/>
        public int Y { get; }

        /// <inheritdoc/>
        public int Width { get; }

        /// <inheritdoc/>
        public int Height { get; }

        /// <inheritdoc/>
        public int Descender { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Glyph"/> class.
        /// </summary>
        /// <param name="x">The x-coordinate of the glyph in the source image/texture.</param>
        /// <param name="y">The y-coordinate of the glyph in the source image/texture.</param>
        /// <param name="width">The width of the glyph.</param>
        /// <param name="height">The height of the glyph.</param>
        /// <param name="descender">The descender of the glyph.</param>
        public Glyph(int x, int y, int width, int height, int descender)
        {
            if(x < 0 || y < 0)
                throw new ArgumentException("X and Y coordinate of the glyph must be greater than or equal to zero");

            if(width <= 0 || height <= 0)
                throw new ArgumentException("Width and height of the glyph must be greater than zero");

            if(descender < 0)
                throw new ArgumentException("The descender of the glyph must be greater than or equal to zero", nameof(descender));

            X = x;
            Y = y;
            Width = width;
            Height = height;
            Descender = descender;
        }
    }
}
