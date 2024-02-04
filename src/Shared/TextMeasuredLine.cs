using System;
using System.Collections.Generic;
using System.Linq;

namespace DoomWriter
{
    /// <summary>
    /// Represents the result of calculating the location and bounds of a rendered representation of the glyphs in a line of text.
    /// </summary>
    public sealed class TextMeasuredLine
    {
        /// <summary>
        /// Gets the rendered glyphs and their bounds.
        /// </summary>
        public IEnumerable<RenderedGlyph> Glyphs { get; }

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
        /// Gets the collection of text render modifiers that should be applied by the text renderer.
        /// </summary>
        public IEnumerable<TextRenderModifier> RenderModifiers { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextMeasuredLine"/> class.
        /// </summary>
        /// <param name="glyphs">The rendered glyphs and their bounds.</param>
        /// <param name="width">The width of the rendered text.</param>
        /// <param name="height">The height of the rendered text.</param>
        /// <param name="lineHeight">The distance between the current line and the next.</param>
        /// <param name="tallestDescender">The height of the tallest descender found in this line of text.</param>
        /// <param name="renderModifiers">Optional. The collection of text render modifiers that should be applied by the text renderer.</param>
        public TextMeasuredLine(IEnumerable<RenderedGlyph> glyphs, int width, int height, int lineHeight, int tallestDescender, IEnumerable<TextRenderModifier> renderModifiers = null)
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
            RenderModifiers = renderModifiers ?? Enumerable.Empty<TextRenderModifier>();
        }
    }
}
