﻿using System;

namespace DoomWriter
{
    /// <summary>
    /// Defines properties and methods for a generic text renderer.
    /// </summary>
    /// <typeparam name="TImage">The type of images generated by the text renderer.</typeparam>
    /// <typeparam name="TGlyph">The type of glyphs supported by the text renderer.</typeparam>
    /// <typeparam name="TGlyphImage">The type of image used by the glyphs.</typeparam>
    public interface ITextRenderer<TImage, TGlyph, TGlyphImage>
        where TImage : IImage
        where TGlyphImage : IImage
        where TGlyph : IGlyph<TGlyphImage>
    {
        /// <summary>
        /// Renders the specified text as an image using the specified bitmap font.
        /// </summary>
        /// <param name="text">The text to render.</param>
        /// <param name="font">The font to use to render the text.</param>
        TImage Render(string text, Font<TGlyph, TGlyphImage> font);
    }
}