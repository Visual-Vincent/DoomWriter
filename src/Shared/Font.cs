using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
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
        private readonly KernTable kernTable;

        /// <summary>
        /// Gets the glyphs of the font.
        /// </summary>
        public IDictionary<char, TGlyph> Glyphs => glyphs;

        /// <summary>
        /// Gets the table of kerning pairs of the font.
        /// </summary>
        public KernTable KernTable => kernTable;

        /// <summary>
        /// Initializes a new instance of the <see cref="Font{TImage, TGlyph}"/> class.
        /// </summary>
        public Font()
        {
            glyphs = new Dictionary<char, TGlyph>();
            kernTable = new KernTable();
        }

        /// <summary>
        /// Draws a glyph onto the destination surface.
        /// </summary>
        /// <param name="glyph">The glyph to draw.</param>
        /// <param name="destination">The surface to draw the glyph onto.</param>
        /// <param name="x">The x-coordinate of the top-left corner where to draw the image.</param>
        /// <param name="y">The y-coordinate of the top-left corner where to draw the image.</param>
        /// <param name="translation">Optional. Applies the specified color translation when drawing the glyph.</param>
        public abstract void DrawGlyph(TGlyph glyph, ISurface<TImage> destination, int x, int y, ColorTranslation translation = null);
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

        private readonly Dictionary<ColorTranslation, Image> translations = new Dictionary<ColorTranslation, Image>();

        /// <summary>
        /// Gets the base image containing all the glyphs of the font.
        /// </summary>
        public Image Image { get; internal set; }

        /// <summary>
        /// Gets the color translations added to the font.
        /// </summary>
        /// <remarks>Translations are stored at runtime only, and are not part of the font file stored on disk.</remarks>
        public IEnumerable<ColorTranslation> Translations => translations.Keys;

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

            foreach(var kvp in fontData.Glyphs)
            {
                Glyphs.Add(kvp.Key, kvp.Value);
            }

            foreach(var pair in fontData.KernTable)
            {
                KernTable.Add(pair);
            }
        }

        /// <inheritdoc/>
        public override void DrawGlyph(Glyph glyph, ISurface<Image> destination, int x, int y, ColorTranslation translation = null)
        {
            var image = Image;

            if(translation != null && !translations.TryGetValue(translation, out image))
                image = Image;

            destination.DrawImage(image, x, y, new Rectangle(glyph.X, glyph.Y, glyph.Width, glyph.Height));
        }

        /// <summary>
        /// Adds the specified color translation to the font.
        /// </summary>
        /// <param name="translation">The color translation to add.</param>
        /// <remarks>Translations are stored at runtime only, and are not part of the font file stored on disk.</remarks>
        public void AddTranslation(ColorTranslation translation)
        {
            if(translation == null)
                throw new ArgumentNullException(nameof(translation));

            if(HasTranslation(translation))
                throw new ArgumentException("Translation already exists", nameof(translation));

            translation = translation.Clone();
            translation.Freeze();

            var image = Image.Clone();
            ColorTranslator.Translate(image.BaseImage, translation);

            translations.Add(translation, image);
        }

        /// <summary>
        /// Returns whether or not the font has the specified color translation.
        /// </summary>
        /// <param name="translation">The color translation to look for.</param>
        /// <remarks>Translations are stored at runtime only, and are not part of the font file stored on disk.</remarks>
        public bool HasTranslation(ColorTranslation translation)
        {
            if(translation == null)
                throw new ArgumentNullException(nameof(translation));

            return translations.ContainsKey(translation);
        }

        /// <summary>
        /// Removes the specified color translation from the font.
        /// </summary>
        /// <param name="translation">The color translation to remove.</param>
        /// <returns><see langword="true"/> if the color translation was successfully found and removed, otherwise <see langword="false"/>.</returns>
        public bool RemoveTranslation(ColorTranslation translation)
        {
            return translations.Remove(translation);
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
                    foreach(var kvp in font.Glyphs)
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

                using(var kernTableStream = new MemoryStream())
                using(var kernTableWriter = new BinaryWriter(kernTableStream, StringEncoding))
                {
                    foreach(var pair in font.KernTable)
                    {
                        kernTableWriter.Write(pair.Key);
                        kernTableWriter.Write(pair.Kerning);
                    }

                    writer.WriteLengthPrefixed(kernTableStream.ToArray());
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

                Image<Rgba32> imageSrc = SixLaborsImage.Load<Rgba32>(imageData);
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

                        fontData.Glyphs[glyphChar] = new Glyph(x, y, width, height, descender);
                    }
                }

                byte[] kernTable = reader.ReadLengthPrefixed(new FormatException("The contents of the stream is not a valid Doom Writer Font file"));

                using(var kernTableStream = new MemoryStream(kernTable))
                using(var kernTableReader = new BinaryReader(kernTableStream, StringEncoding))
                {
                    while(kernTableStream.Position < kernTableStream.Length)
                    {
                        int key = kernTableReader.ReadInt32();
                        int kerning = kernTableReader.ReadInt32();
                        
                        fontData.KernTable.Add(new KerningPair(key, kerning));
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

                    foreach(var kvp in translations)
                    {
                        kvp.Value.Dispose();
                    }

                    translations.Clear();
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
