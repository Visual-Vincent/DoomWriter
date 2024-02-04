using System;

namespace DoomWriter
{
    /// <summary>
    /// A render modifier that changes the color translation of the rendered text.
    /// </summary>
    public sealed class ColorTranslationModifier : TextRenderModifier
    {
        /// <summary>
        /// Gets the color translation that will be applied by the text renderer. If null, the text colors will be untranslated.
        /// </summary>
        public ColorTranslation Translation { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorTranslationModifier"/> class.
        /// </summary>
        /// <param name="position">The character position at which this modifier should be applied.</param>
        /// <param name="translation">The color translation that will be applied by the text renderer. If null, the text colors will be untranslated.</param>
        public ColorTranslationModifier(int position, ColorTranslation translation)
            : base(position)
        {
            Translation = translation;
        }
    }
}
