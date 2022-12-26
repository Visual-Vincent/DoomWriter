using System;

namespace DoomWriter
{
    /// <summary>
    /// The base class for Doom Writer fonts. Inheritors should inherit from <see cref="Font{TGlyph, TGlyphImage}"/> instead.
    /// </summary>
    public abstract class FontBase
    {
        /// <summary>
        /// Gets the height of empty lines.
        /// </summary>
        public int EmptyLineHeight { get; protected internal set; }

        /// <summary>
        /// Gets the spacing between the letters of the font.
        /// </summary>
        public short LetterSpacing { get; protected internal set; }

        /// <summary>
        /// Gets the distance between lines.
        /// </summary>
        public short LineHeight { get; protected internal set; }

        /// <summary>
        /// Gets the width of the space character.
        /// </summary>
        public ushort SpaceWidth { get; protected internal set; }

        /// <summary>
        /// Gets the number of spaces that the tab character represents.
        /// </summary>
        public byte TabWidth { get; protected internal set; }

        /// <summary>
        /// Called when the font is loaded.
        /// </summary>
        /// <param name="fontData">The data to put into the font. Disposed after the OnLoadFontData method exits. Make sure to clone any data that you copy from this class.</param>
        protected internal abstract void OnLoadFontData(Font fontData);
    }
}
