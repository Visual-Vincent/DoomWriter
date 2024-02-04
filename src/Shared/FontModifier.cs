using System;

namespace DoomWriter
{
    /// <summary>
    /// A render modifier that changes the font of the rendered text.
    /// </summary>
    /// <typeparam name="TFont">The type of font used by the text renderer.</typeparam>
    public sealed class FontModifier<TFont> : TextRenderModifier
        where TFont : FontBase
    {
        /// <summary>
        /// Gets the font that will be applied by the text renderer. If null, the default font will be used.
        /// </summary>
        public TFont Font { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorTranslationModifier"/> class.
        /// </summary>
        /// <param name="position">The character position at which this modifier should be applied.</param>
        /// <param name="font">The font that will be applied by the text renderer. If null, the default font will be used.</param>
        public FontModifier(int position, TFont font)
            : base(position)
        {
            Font = font;
        }
    }
}
