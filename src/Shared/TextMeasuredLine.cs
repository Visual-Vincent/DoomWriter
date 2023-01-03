using System;
using System.Collections.Generic;

namespace DoomWriter
{
    /// <summary>
    /// Represents the result of calculating the location and bounds of a rendered representation of the glyphs in a line of text.
    /// </summary>
    /// <typeparam name="TGlyph">The type of rendered glyph.</typeparam>
    /// <typeparam name="TImage">The type of image used by the glyphs.</typeparam>
    public class TextMeasuredLine<TGlyph, TImage>
        where TGlyph : IGlyph<TImage>
        where TImage : IImage
    {
        /// <summary>
        /// Gets the rendered glyphs and their bounds.
        /// </summary>
        public IEnumerable<RenderedGlyph<TGlyph, TImage>> Glyphs { get; }

        /// <summary>
        /// Gets the width of the rendered line of text.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Gets the height of the rendered line of text.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Gets the distance between the current line and the next.
        /// </summary>
        public int LineHeight { get; }

        /// <summary>
        /// Gets the height of the tallest descender found in this line of text.
        /// </summary>
        public int TallestDescender { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextMeasuredLine{TGlyph, TImage}"/> class.
        /// </summary>
        /// <param name="glyphs">The rendered glyphs and their bounds.</param>
        /// <param name="width">The width of the rendered text.</param>
        /// <param name="height">The height of the rendered text.</param>
        /// <param name="lineHeight">The distance between the current line and the next.</param>
        /// <param name="tallestDescender">The height of the tallest descender found in this line of text.</param>
        public TextMeasuredLine(IEnumerable<RenderedGlyph<TGlyph, TImage>> glyphs, int width, int height, int lineHeight, int tallestDescender)
        {
            if(glyphs == null)
                throw new ArgumentNullException(nameof(glyphs));

            if(width < 0 || height < 0)
                throw new ArgumentException("Width and height of the line must be greater than or equal to zero");

            if(lineHeight < 0)
                throw new ArgumentException("Line height must be greater than or equal to zero", nameof(lineHeight));

            if(tallestDescender < 0)
                throw new ArgumentException("Tallest descender must be greater than or equal to zero", nameof(tallestDescender));

            Glyphs = glyphs;
            Width = width;
            Height = height;
            LineHeight = lineHeight;
            TallestDescender = tallestDescender;
        }
    }
}
