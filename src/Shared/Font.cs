using System;
using System.Collections.Generic;

namespace DoomWriter
{
    /// <summary>
    /// Represents the default in-memory font format.
    /// </summary>
    public class Font : Font<ImageGlyph, Image> {}

    /// <summary>
    /// Represents a font with a specific type of glyph.
    /// </summary>
    /// <typeparam name="TGlyph">The type of glyphs used by the font.</typeparam>
    /// <typeparam name="TGlyphImage">The type of image used by the glyphs.</typeparam>
    public class Font<TGlyph, TGlyphImage>
        where TGlyphImage : IImage
        where TGlyph : IGlyph<TGlyphImage>
    {
        private Dictionary<char, TGlyph> glyphs = new Dictionary<char, TGlyph>();
    }
}
