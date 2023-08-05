using System;
using DoomWriter;

namespace FontEditor
{
    /// <summary>
    /// Represents a font with mutable properties.
    /// </summary>
    public class MutableFont : Font
    {
        /// <summary>
        /// Gets the height of empty lines.
        /// </summary>
        new public int EmptyLineHeight
        {
            get => base.EmptyLineHeight;
            set => base.EmptyLineHeight = value;
        }

        /// <summary>
        /// Gets the spacing between the letters of the font.
        /// </summary>
        new public short LetterSpacing
        {
            get => base.LetterSpacing;
            set => base.LetterSpacing = value;
        }

        /// <summary>
        /// Gets the distance between lines.
        /// </summary>
        new public short LineHeight
        {
            get => base.LineHeight;
            set => base.LineHeight = value;
        }

        /// <summary>
        /// Gets the width of the space character.
        /// </summary>
        new public ushort SpaceWidth
        {
            get => base.SpaceWidth;
            set => base.SpaceWidth = value;
        }

        /// <summary>
        /// Gets the number of spaces that the tab character represents.
        /// </summary>
        new public byte TabWidth
        {
            get => base.TabWidth;
            set => base.TabWidth = value;
        }

        /// <summary>
        /// Gets the base image containing all the glyphs of the font.
        /// </summary>
        new public Image Image
        {
            get => base.Image;
            set => base.Image = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MutableFont"/> class.
        /// </summary>
        public MutableFont()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MutableFont"/> class, copying the properties from the specified font.
        /// </summary>
        /// <param name="font">The font to clone.</param>
        public MutableFont(Font font)
        {
            OnLoadFontData(font);
        }
    }
}
