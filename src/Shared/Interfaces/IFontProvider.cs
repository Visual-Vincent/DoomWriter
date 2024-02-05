using System;

namespace DoomWriter.Interfaces
{
    /// <summary>
    /// Defines methods for an object that can be used to retrieve fonts.
    /// </summary>
    /// <typeparam name="TImage">The type of image used by the font.</typeparam>
    /// <typeparam name="TGlyph">The type of glyphs used by the font.</typeparam>
    public interface IFontProvider<TImage, TGlyph>
        where TImage : IImage
        where TGlyph : IGlyph
    {
        /// <summary>
        /// Returns a font with the specified name, or null if none was found.
        /// </summary>
        /// <param name="fontName">The name of the font to fetch.</param>
        Font<TImage, TGlyph> FromName(string fontName);
    }
}
