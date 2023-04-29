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
    /// <typeparam name="TImage">The type of image used by the font.</typeparam>
    /// <typeparam name="TGlyph">The type of glyphs used by the font.</typeparam>
    public abstract class Font<TImage, TGlyph> : FontBase
        where TImage : IImage
        where TGlyph : IGlyph
    {
        private readonly IDictionary<char, TGlyph> glyphs;
        private readonly IReadOnlyDictionary<char, TGlyph> glyphsLookup;

        /// <summary>
        /// Gets the glyphs of the font.
        /// </summary>
        protected internal IDictionary<char, TGlyph> GlyphTable => glyphs;

        /// <summary>
        /// Gets the glyphs of the font.
        /// </summary>
        public IReadOnlyDictionary<char, TGlyph> Glyphs => glyphsLookup;

        /// <summary>
        /// Initializes a new instance of the <see cref="Font{TImage, TGlyph}"/> class.
        /// </summary>
        public Font()
        {
            glyphs = new Dictionary<char, TGlyph>();
            glyphsLookup = new ReadOnlyDictionary<char, TGlyph>(glyphs);
        }

        /// <summary>
        /// Draws a glyph onto the destination surface.
        /// </summary>
        /// <param name="glyph">The glyph to draw.</param>
        /// <param name="destination">The surface to draw the glyph onto.</param>
        /// <param name="x">The x-coordinate of the top-left corner where to draw the image.</param>
        /// <param name="y">The y-coordinate of the top-left corner where to draw the image.</param>
        public abstract void DrawGlyph(TGlyph glyph, ISurface<TImage> destination, int x, int y);
    }

    /// <summary>
    /// Represents the default in-memory font format.
    /// </summary>
    public sealed class Font : Font<Image, Glyph>, IDisposable
    {
        private static readonly byte[] FontFormatVersion = new byte[] { 0, 1 };
        private static readonly byte[] MagicNumber = new byte[] { 0x6, 0x6, 0x6, (byte)'D', (byte)'W', (byte)'F', (byte)'O', (byte)'N' };

        private static readonly Encoding StringEncoding = Encoding.UTF8;

        private static readonly PngEncoder DefaultPngEncoder = new PngEncoder() {
            CompressionLevel = PngCompressionLevel.BestCompression,
            IgnoreMetadata = true,
            TransparentColorMode = PngTransparentColorMode.Clear
        };

        /// <summary>
        /// Gets the base image containing all the glyphs of the font.
        /// </summary>
        public Image Image { get; internal set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Font"/> class.
        /// </summary>
        public Font()
        {
        }

        protected internal override void OnLoadFontData(Font fontData)
        {
            EmptyLineHeight = fontData.EmptyLineHeight;
            LetterSpacing = fontData.LetterSpacing;
            LineHeight = fontData.LineHeight;
            SpaceWidth = fontData.SpaceWidth;
            TabWidth = fontData.TabWidth;

            Image = fontData.Image.Clone();

            foreach(var kvp in fontData.GlyphTable)
            {
                GlyphTable.Add(kvp.Key, kvp.Value);
            }
        }

        /// <inheritdoc/>
        public override void DrawGlyph(Glyph glyph, ISurface<Image> destination, int x, int y)
        {
            destination.DrawImage(Image, x, y, new Rectangle(glyph.X, glyph.Y, glyph.Width, glyph.Height));
        }

        /// <summary>
        /// Writes a font file to the specified stream.
        /// </summary>
        /// <param name="stream">The stream to write the font to.</param>
        /// <param name="font">The font to write.</param>
        public static void Save(Stream stream, Font font)
        {
            if(stream == null)
                throw new ArgumentNullException(nameof(stream));

            if(!stream.CanWrite)
                throw new ArgumentException("Stream is not writable", nameof(stream));

            using(var writer = new BinaryWriter(stream, StringEncoding, true))
            {
                writer.Write(MagicNumber);
                writer.Write(FontFormatVersion);

                using(var settingsStream = new MemoryStream())
                using(var settingsWriter = new BinaryWriter(settingsStream, StringEncoding))
                {
                    settingsWriter.Write(font.LetterSpacing);
                    settingsWriter.Write(font.LineHeight);
                    settingsWriter.Write(font.SpaceWidth);
                    settingsWriter.Write(font.TabWidth);
                    settingsWriter.Write(font.EmptyLineHeight);

                    writer.WriteLengthPrefixed(settingsStream.ToArray());
                }

                using(var imageStream = new MemoryStream())
                {
                    font.Image.BaseImage.SaveAsPng(imageStream, DefaultPngEncoder);
                    writer.WriteLengthPrefixed(imageStream.ToArray());
                }

                using(var glyphStream = new MemoryStream())
                using(var glyphWriter = new BinaryWriter(glyphStream, StringEncoding))
                {
                    foreach(var kvp in font.GlyphTable)
                    {
                        char glyphChar = kvp.Key;
                        Glyph glyph = kvp.Value;

                        glyphWriter.Write(glyphChar);
                        glyphWriter.Write(glyph.X);
                        glyphWriter.Write(glyph.Y);
                        glyphWriter.Write(glyph.Width);
                        glyphWriter.Write(glyph.Height);
                        glyphWriter.Write(glyph.Descender);
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
            if(stream == null)
                throw new ArgumentNullException(nameof(stream));

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
                    fontData.LetterSpacing = settingsReader.ReadInt16();
                    fontData.LineHeight = settingsReader.ReadInt16();
                    fontData.SpaceWidth = settingsReader.ReadUInt16();
                    fontData.TabWidth = settingsReader.ReadByte();
                    fontData.EmptyLineHeight = settingsReader.ReadInt32();
                }

                byte[] imageData = reader.ReadLengthPrefixed(new FormatException("The contents of the stream is not a valid Doom Writer Font file"));

                SixLaborsImage imageSrc = SixLaborsImage.Load(imageData);
                fontData.Image = new Image(imageSrc);

                byte[] glyphs = reader.ReadLengthPrefixed(new FormatException("The contents of the stream is not a valid Doom Writer Font file"));

                using(var glyphStream = new MemoryStream(glyphs))
                using(var glyphReader = new BinaryReader(glyphStream, StringEncoding))
                {
                    while(glyphStream.Position < glyphStream.Length)
                    {
                        char glyphChar = glyphReader.ReadChar();
                        int x = glyphReader.ReadInt32();
                        int y = glyphReader.ReadInt32();
                        int width = glyphReader.ReadInt32();
                        int height = glyphReader.ReadInt32();
                        int descender = glyphReader.ReadInt32();

                        fontData.GlyphTable[glyphChar] = new Glyph(x, y, width, height, descender);
                    }
                }

                var font = new TFont();
                font.OnLoadFontData(fontData);

                return font;
            }
        }

        /// <summary>
        /// Loads a font file.
        /// </summary>
        /// <typeparam name="TFont">The type of font to load.</typeparam>
        /// <param name="file">The path to the font file to load.</param>
        public static TFont Load<TFont>(string file)
            where TFont : FontBase, new()
        {
            if(file == null)
                throw new ArgumentNullException(nameof(file));

            using(var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return Load<TFont>(fileStream);
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
                    Image?.Dispose();
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
