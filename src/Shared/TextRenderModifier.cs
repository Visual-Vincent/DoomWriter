using System;

namespace DoomWriter
{
    /// <summary>
    /// The base class for text render modifiers that changes how text rendering is performed, starting at a certain character offset.
    /// </summary>
    public abstract class TextRenderModifier
    {
        /// <summary>
        /// Gets the character position at which this text render modifier should be applied.
        /// </summary>
        public int Position { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextRenderModifier"/> class.
        /// </summary>
        /// <param name="position">The character position at which this modifier should be applied.</param>
        public TextRenderModifier(int position)
        {
            if(position < 0)
                throw new ArgumentOutOfRangeException(nameof(position), position, "Character position cannot be negative");

            Position = position;
        }
    }
}
