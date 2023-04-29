using System;

namespace DoomWriter
{
    /// <summary>
    /// Defines properties and methods for a generic text renderer.
    /// </summary>
    /// <typeparam name="TImage">The type of images supported by the text renderer.</typeparam>
    /// <typeparam name="TGlyph">The type of glyphs supported by the text renderer.</typeparam>
    public interface ITextRenderer<TImage, TGlyph>
        where TImage : IImage
        where TGlyph : IGlyph
    {
        /// <summary>
        /// Renders the specified text as an image using the specified bitmap font.
        /// </summary>
        /// <param name="text">The text to render.</param>
        /// <param name="font">The font to use to render the text.</param>
        TImage Render(string text, Font<TImage, TGlyph> font);
    }
}
