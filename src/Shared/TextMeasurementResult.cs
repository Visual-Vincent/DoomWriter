using System;
using System.Collections.Generic;

namespace DoomWriter
{
    /// <summary>
    /// Represents the result of calculating the location and bounds of a rendered representation of the glyphs in a text.
    /// </summary>
    public sealed class TextMeasurementResult
    {
        /// <summary>
        /// Gets the measured text lines.
        /// </summary>
        public IEnumerable<TextMeasuredLine> Lines { get; }

        /// <summary>
        /// Gets the width of the rendered text.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Gets the height of the rendered text.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextMeasurementResult"/> class.
        /// </summary>
        /// <param name="lines">The measured text lines.</param>
        /// <param name="width">The width of the rendered text.</param>
        /// <param name="height">The height of the rendered text.</param>
        public TextMeasurementResult(IEnumerable<TextMeasuredLine> lines, int width, int height)
        {
            Lines = lines ?? throw new ArgumentNullException(nameof(lines));
            Width = width;
            Height = height;
        }
    }
}
