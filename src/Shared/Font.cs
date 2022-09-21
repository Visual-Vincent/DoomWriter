using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DoomWriter
{
    /// <summary>
    /// Represents the default in-memory font format.
    /// </summary>
    public class Font : Font<ImageGlyph, Image>, IDisposable
    {
        #region IDisposable Support
        private bool disposedValue;

        private void Dispose(bool disposing)
        {
            if(!disposedValue)
            {
                if(disposing)
                {
                    // Dispose managed resources
                    foreach(var glyph in Glyphs.Values)
                    {
                        glyph.Dispose();
                    }
                }

                // Free unmanaged resources

                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Font()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

    /// <summary>
    /// Represents a font with a specific type of glyph.
    /// </summary>
    /// <typeparam name="TGlyph">The type of glyphs used by the font.</typeparam>
    /// <typeparam name="TGlyphImage">The type of image used by the glyphs.</typeparam>
    public class Font<TGlyph, TGlyphImage>
        where TGlyphImage : IImage
        where TGlyph : IGlyph<TGlyphImage>
    {
        private readonly IDictionary<char, TGlyph> glyphs;
        private readonly IReadOnlyDictionary<char, TGlyph> glyphsLookup;

        /// <summary>
        /// Gets the glyphs of the font.
        /// </summary>
        public IReadOnlyDictionary<char, TGlyph> Glyphs => glyphsLookup;

        /// <summary>
        /// Gets the distance between lines.
        /// </summary>
        public int LineHeight { get; }

        /// <summary>
        /// Gets the width of the space character.
        /// </summary>
        public int SpaceWidth { get; }

        /// <summary>
        /// Gets the width of the tab character.
        /// </summary>
        public int TabWidth { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Font"/> class.
        /// </summary>
        public Font()
        {
            glyphs = new Dictionary<char, TGlyph>();
            glyphsLookup = new ReadOnlyDictionary<char, TGlyph>(glyphs);
        }
    }
}
