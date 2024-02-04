using System;

namespace DoomWriter
{
    /// <summary>
    /// Represents a glyph that is rendered (or about to be rendered) onto a surface.
    /// </summary>
    public readonly struct RenderedGlyph
    {
        /// <summary>
        /// Gets the font glyph represented by this structure.
        /// </summary>
        public IGlyph Glyph { get; }

        /// <summary>
        /// Gets the glyph represented by this structure.
        /// </summary>
        public char GlyphChar { get; }

        /// <summary>
        /// Gets the x-coordinate of the top-left corner where the glyph will be rendered.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Gets the y-coordinate of the top-left corner where the glyph will be rendered.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RenderedGlyph"/> structure.
        /// </summary>
        /// <param name="glyphChar">The glyph represented by this structure.</param>
        /// <param name="glyph">The font glyph represented by this structure.</param>
        /// <param name="x">The x-coordinate of the top-left corner of the glyph.</param>
        /// <param name="y">The y-coordinate of the top-left corner of the glyph.</param>
        public RenderedGlyph(char glyphChar, IGlyph glyph, int x, int y)
        {
            GlyphChar = glyphChar;
            Glyph = glyph;
            X = x;
            Y = y;
        }
    }
}
