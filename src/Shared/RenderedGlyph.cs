using System;

namespace DoomWriter
{
    /// <summary>
    /// Represents a glyph that is rendered (or about to be rendered) onto a surface.
    /// </summary>
    /// <typeparam name="TGlyph">The type of rendered glyph.</typeparam>
    /// <typeparam name="TImage">The type of image used by the glyph.</typeparam>
    public struct RenderedGlyph<TGlyph, TImage>
        where TGlyph : IGlyph<TImage>
        where TImage : IImage
    {
        /// <summary>
        /// Gets the font glyph represented by this structure.
        /// </summary>
        public TGlyph Glyph { get; }

        /// <summary>
        /// Gets the glyph represented by this structure.
        /// </summary>
        public char GlyphChar { get; }

        /// <summary>
        /// Gets the x-coordinate of the top-left corner of the glyph.
        /// </summary>
        public int X { get; }

        /// <summary>
        /// Gets the y-coordinate of the top-left corner of the glyph.
        /// </summary>
        public int Y { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RenderedGlyph{TGlyph, TImage}"/> structure.
        /// </summary>
        /// <param name="glyphChar">The glyph represented by this structure.</param>
        /// <param name="glyph">The font glyph represented by this structure.</param>
        /// <param name="x">The x-coordinate of the top-left corner of the glyph.</param>
        /// <param name="y">The y-coordinate of the top-left corner of the glyph.</param>
        public RenderedGlyph(char glyphChar, TGlyph glyph, int x, int y)
        {
            GlyphChar = glyphChar;
            Glyph = glyph;
            X = x;
            Y = y;
        }
    }
}
