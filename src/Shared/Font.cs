using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;

using SixLaborsImage = SixLabors.ImageSharp.Image;

namespace DoomWriter
{
    /// <summary>
    /// Represents a font with a specific type of glyph.
    /// </summary>
    /// <typeparam name="TGlyph">The type of glyphs used by the font.</typeparam>
    /// <typeparam name="TGlyphImage">The type of image used by the glyphs.</typeparam>
    public abstract class Font<TGlyph, TGlyphImage> : FontBase
        where TGlyphImage : IImage
        where TGlyph : IGlyph<TGlyphImage>
    {
        private readonly IDictionary<char, TGlyph> glyphs;
        private readonly IReadOnlyDictionary<char, TGlyph> glyphsLookup;

        /// <summary>
        /// Gets the glyphs of the font.
        /// </summary>
        protected IDictionary<char, TGlyph> GlyphTable => glyphs;

        /// <summary>
        /// Gets the glyphs of the font.
        /// </summary>
        public IReadOnlyDictionary<char, TGlyph> Glyphs => glyphsLookup;

        /// <summary>
        /// Initializes a new instance of the <see cref="Font"/> class.
        /// </summary>
        public Font()
        {
            glyphs = new Dictionary<char, TGlyph>();
            glyphsLookup = new ReadOnlyDictionary<char, TGlyph>(glyphs);
        }
    }

    /// <summary>
    /// Represents the default in-memory font format.
    /// </summary>
    public class Font : Font<ImageGlyph, Image>, IDisposable
    {
        private static readonly byte[] FontFormatVersion = new byte[] { 1, 0 };
        private static readonly byte[] MagicNumber = new byte[] { 0x6, 0x6, 0x6, (byte)'D', (byte)'W', (byte)'F', (byte)'O', (byte)'N' };

        private static readonly Encoding StringEncoding = Encoding.UTF8;

        private static readonly PngEncoder DefaultPngEncoder = new PngEncoder() {
            CompressionLevel = PngCompressionLevel.BestCompression,
            IgnoreMetadata = true,
            TransparentColorMode = PngTransparentColorMode.Clear
        };

        protected internal override void OnLoadFontData(Font fontData)
        {
            LineHeight = fontData.LineHeight;
            SpaceWidth = fontData.SpaceWidth;
            TabWidth = fontData.TabWidth;

            foreach(var kvp in fontData.GlyphTable)
            {
                GlyphTable.Add(kvp.Key, kvp.Value.Clone());
            }
        }

        /// <summary>
        /// Writes a font file to the specified stream.
        /// </summary>
        /// <param name="stream">The stream to write the font to.</param>
        /// <param name="font">The font to write.</param>
        public static void Save(Stream stream, Font font)
        {
            if(!stream.CanWrite)
                throw new ArgumentException("Stream is not writable", nameof(stream));

            using(var writer = new BinaryWriter(stream, StringEncoding, true))
            {
                writer.Write(MagicNumber);
                writer.Write(FontFormatVersion);

                using(var settingsStream = new MemoryStream())
                using(var settingsWriter = new BinaryWriter(settingsStream, StringEncoding))
                {
                    settingsWriter.Write(font.LineHeight);
                    settingsWriter.Write(font.SpaceWidth);
                    settingsWriter.Write(font.TabWidth);

                    writer.WriteLengthPrefixed(settingsStream.ToArray());
                }

                using(var glyphStream = new MemoryStream())
                using(var glyphWriter = new BinaryWriter(glyphStream, StringEncoding))
                {
                    foreach(var kvp in font.GlyphTable)
                    {
                        char glyphChar = kvp.Key;
                        ImageGlyph glyph = kvp.Value;

                        glyphWriter.Write(glyphChar);
                        glyphWriter.Write(glyph.Width);
                        glyphWriter.Write(glyph.Height);

                        using(var imageStream = new MemoryStream())
                        {
                            glyph.Image.BaseImage.SaveAsPng(imageStream, DefaultPngEncoder);
                            glyphWriter.WriteLengthPrefixed(imageStream.ToArray());
                        }
                    }

                    writer.WriteLengthPrefixed(glyphStream.ToArray());
                }
            }
        }

        /// <summary>
        /// Loads a font file from the specified stream.
        /// </summary>
        /// <typeparam name="TFont">The type of font to load.</typeparam>
        /// <param name="stream">The stream to load the font file from.</param>
        public static TFont Load<TFont>(Stream stream)
            where TFont : FontBase, new()
        {
            if(!stream.CanRead)
                throw new ArgumentException("Stream is not readable", nameof(stream));

            using(var fontData = new Font())
            using(var reader = new BinaryReader(stream, StringEncoding, true))
            {
                byte[] magicNumber = reader.ReadExact(MagicNumber.Length, new FormatException("The contents of the stream is not a valid Doom Writer Font file"));
                ThrowHelper.Assert(magicNumber.SequenceEqual(MagicNumber), new FormatException("The contents of the stream is not a valid Doom Writer Font file"));

                byte[] formatVersion = reader.ReadExact(FontFormatVersion.Length, new FormatException("The contents of the stream is not a valid Doom Writer Font file"));

                Version fileVersion = new Version(formatVersion[0], formatVersion[1]);
                Version actualVersion = new Version(FontFormatVersion[0], FontFormatVersion[1]);

                ThrowHelper.Assert(fileVersion <= actualVersion, new FormatException("Font file was created for a newer version of Doom Writer"));

                // Handle conversion to a newer font file format here, when applicable

                byte[] settings = reader.ReadLengthPrefixed(new FormatException("The contents of the stream is not a valid Doom Writer Font file"));

                using(var settingsStream = new MemoryStream(settings))
                using(var settingsReader = new BinaryReader(settingsStream, StringEncoding))
                {
                    fontData.LineHeight = settingsReader.ReadInt32();
                    fontData.SpaceWidth = settingsReader.ReadInt32();
                    fontData.TabWidth = settingsReader.ReadInt32();
                }

                byte[] glyphs = reader.ReadLengthPrefixed(new FormatException("The contents of the stream is not a valid Doom Writer Font file"));

                using(var glyphStream = new MemoryStream(glyphs))
                using(var glyphReader = new BinaryReader(glyphStream, StringEncoding))
                {
                    char glyphChar = glyphReader.ReadChar();
                    int width = glyphReader.ReadInt32();
                    int height = glyphReader.ReadInt32();

                    byte[] imageData = glyphReader.ReadLengthPrefixed();

                    SixLaborsImage image = SixLaborsImage.Load(imageData);
                    ImageGlyph glyph = new ImageGlyph(new Image(image), width, height);

                    fontData.GlyphTable[glyphChar] = glyph;
                }

                var font = new TFont();
                font.OnLoadFontData(fontData);

                return font;
            }
        }

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
}
