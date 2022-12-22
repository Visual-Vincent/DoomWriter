﻿using System;

namespace DoomWriter
{
    /// <summary>
    /// The base class for Doom Writer fonts. Inheritors should inherit from <see cref="Font{TGlyph, TGlyphImage}"/> instead.
    /// </summary>
    public abstract class FontBase
    {
        /// <summary>
        /// Gets the distance between lines.
        /// </summary>
        public int LineHeight { get; protected internal set; }

        /// <summary>
        /// Gets the width of the space character.
        /// </summary>
        public int SpaceWidth { get; protected internal set; }

        /// <summary>
        /// Gets the number of spaces that the tab character represents.
        /// </summary>
        public int TabWidth { get; protected internal set; }

        /// <summary>
        /// Called when the font is loaded.
        /// </summary>
        /// <param name="fontData">The data to put into the font. Disposed after the OnLoadFontData method exits. Make sure to clone any data that you copy from this class.</param>
        protected internal abstract void OnLoadFontData(Font fontData);
    }
}
