using System;
using System.Collections.Generic;
using System.IO;
using DoomWriter.Interfaces;

namespace DoomWriter
{
    /// <summary>
    /// A font provider that loads a font from disk only when the font is requested.
    /// </summary>
    /// <remarks>Once a font has been loaded from disk, it's cached in memory. Lookup is either case sensitive or case insensitive depending on the current file system.</remarks>
    public sealed class LazyFontProvider : IFontProvider<Image, Glyph>
    {
        private readonly Dictionary<string, Font> fontCache = new Dictionary<string, Font>(FileSystem.IsCaseSensitive ? StringComparer.Ordinal : StringComparer.OrdinalIgnoreCase);
        private readonly string fontsDirectory;

        /// <summary>
        /// Initializes a new instance of the <see cref="LazyFontProvider"/> class.
        /// </summary>
        /// <param name="fontsDirectory">The path to the directory from which to load font files.</param>
        public LazyFontProvider(string fontsDirectory)
        {
            if(string.IsNullOrWhiteSpace(fontsDirectory))
                throw new ArgumentNullException(nameof(fontsDirectory));

            this.fontsDirectory = fontsDirectory;
        }

        /// <inheritdoc/>
        public Font<Image, Glyph> FromName(string fontName)
        {
            if(fontCache.TryGetValue(fontName, out var font))
                return font;

            if(!Directory.Exists(fontsDirectory))
                return null;

            string filePath = Path.Combine(fontsDirectory, $"{fontName}.dwfont");

            if(!File.Exists(filePath))
                return null;
            
            font = Font.Load<Font>(filePath);
            fontCache.Add(fontName, font);

            return font;
        }
    }
}
