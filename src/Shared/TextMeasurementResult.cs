using System;
using System.Collections.Generic;

namespace DoomWriter
{
    /// <summary>
    /// Represents the result of calculating the location and bounds of a rendered representation of the glyphs in a text.
    /// </summary>
    /// <typeparam name="TGlyph">The type of rendered glyph.</typeparam>
    /// <typeparam name="TImage">The type of image used by the glyphs.</typeparam>
    public class TextMeasurementResult<TGlyph, TImage>
        where TGlyph : IGlyph<TImage>
        where TImage : IImage
    {
        /// <summary>
        /// Gets the measured text lines.
        /// </summary>
        public IEnumerable<TextMeasuredLine<TGlyph, TImage>> Lines { get; }

        /// <summary>
        /// Gets the width of the rendered text.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Gets the height of the rendered text.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextMeasurementResult{TGlyph, TImage}"/> class.
        /// </summary>
        /// <param name="lines">The measured text lines.</param>
        /// <param name="width">The width of the rendered text.</param>
        /// <param name="height">The height of the rendered text.</param>
        public TextMeasurementResult(IEnumerable<TextMeasuredLine<TGlyph, TImage>> lines, int width, int height)
        {
            Lines = lines ?? throw new ArgumentNullException(nameof(lines));
            Width = width;
            Height = height;
        }
    }
}
