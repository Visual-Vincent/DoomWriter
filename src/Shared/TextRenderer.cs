using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SixLabors.ImageSharp.PixelFormats;

using FontModifier = DoomWriter.FontModifier<DoomWriter.Font<DoomWriter.Image, DoomWriter.Glyph>>;

namespace DoomWriter
{
    /// <summary>
    /// The default Doom Writer text renderer.
    /// </summary>
    public class TextRenderer : TextRendererBase, ITextRenderer<Image, Glyph>, IDisposable
    {
        private readonly Font DefaultFont = LoadDefaultFont<Font>();

        /// <summary>
        /// Gets the table of fonts used by the text renderer.
        /// </summary>
        /// <remarks>If a font has the same key as a translation in the <see cref="Translations"/> table, the font will take precedence.</remarks>
        public Dictionary<string, Font<Image, Glyph>> Fonts { get; } = new Dictionary<string, Font<Image, Glyph>>();

        /// <summary>
        /// Gets the translation table used by the text renderer.
        /// </summary>
        /// <remarks>If a translation has the same key as a font in the <see cref="Fonts"/> table, the font will take precedence.</remarks>
        public Dictionary<string, ColorTranslation> Translations { get; } = new Dictionary<string, ColorTranslation>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Initializes a new instance of the <see cref="TextRenderer"/> class.
        /// </summary>
        public TextRenderer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextRenderer"/> class.
        /// </summary>
        /// <param name="translationsTable">A table containing all color translations that will be made available to the renderer.</param>
        public TextRenderer(IDictionary<string, ColorTranslation> translationsTable)
        {
            foreach(var kvp in translationsTable)
            {
                Translations.Add(kvp.Key, kvp.Value.Clone());
            }
        }

        /// <inheritdoc/>
        public override Image Render(string text)
        {
            return Render(text, DefaultFont);
        }

        /// <inheritdoc/>
        public Image Render(string text, Font<Image, Glyph> font)
        {
            var measurement = Measure(text, font);
            var surface = new ImageSurface<Rgba32>(measurement.Width.Clamp(1, int.MaxValue), measurement.Height.Clamp(1, int.MaxValue));

            ColorTranslation currentTranslation = null;
            Font<Image, Glyph> currentFont = font;

            int y = 0;

            foreach(var line in measurement.Lines)
            {
                int glyphIndex = -1;

                var modifier = line.RenderModifiers.GetEnumerator();
                modifier.MoveNext();

                foreach(var g in line.Glyphs)
                {
                    glyphIndex++;

                    if(modifier.Current != null && modifier.Current.Position == glyphIndex)
                    {
                        switch(modifier.Current)
                        {
                            case ColorTranslationModifier renderModifier:
                                currentTranslation = renderModifier.Translation;

                                // Cache translations for the built-in font type
                                if(currentFont is Font builtInFont && currentTranslation != null && !builtInFont.HasTranslation(currentTranslation))
                                {
                                    builtInFont.AddTranslation(currentTranslation);
                                }
                                break;

                            case FontModifier renderModifier:
                                currentFont = renderModifier.Font ?? font;
                                break;
                        }

                        modifier.MoveNext();
                    }

                    currentFont.DrawGlyph((Glyph)g.Glyph, surface, g.X, y + (line.Height - line.TallestDescender - g.Glyph.Height + g.Glyph.Descender), currentTranslation);
                }

                y += line.Height + line.LineHeight;
            }

            return new Image(surface.GetImage());
        }

        /// <inheritdoc/>
        public async Task<Image> RenderAsync(string text, Font<Image, Glyph> font)
        {
            return await Task.Run(() => Render(text, font));
        }

        private TextMeasurementResult Measure(string text, Font<Image, Glyph> font)
        {
            if(text == null)
                throw new ArgumentNullException(nameof(text));

            if(font == null)
                throw new ArgumentNullException(nameof(font));

            if(text.Length <= 0)
                throw new ArgumentException("No text specified", nameof(text));

            int width = 0;
            int height = 0;

            var lines = new List<TextMeasuredLine>();
            var currentFont = font;

            using(StringReader reader = new StringReader(text))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    int x = 0;
                    int lineHeight = line.Length <= 0 ? currentFont.EmptyLineHeight : 0;
                    int tallestDescender = 0;
                    int backslashCount = 0;
                    int glyphIndex = 0;

                    var fontLineHeight = currentFont.LineHeight;
                    var letterSpacing = currentFont.LetterSpacing;
                    var spaceWidth = currentFont.SpaceWidth + currentFont.LetterSpacing;
                    var tabWidth = currentFont.TabWidth;

                    var glyphs = new List<RenderedGlyph>();
                    var renderModifiers = new List<TextRenderModifier>();

                    // Ensure spaces are always the same size
                    if(line.Length > 0 && (line[0] == ' ' || line[0] == '\t'))
                    {
                        x += letterSpacing;
                    }

                    char c = (char)0;
                    char pc = (char)0;

                    for(int i = 0; i < line.Length; i++)
                    {
                        c = line[i];

                        // Ensure spaces are always the same size
                        if((pc == ' ' || pc == '\t') && (c != ' ' && c != '\t'))
                        {
                            x -= letterSpacing;
                        }

                        backslashCount = (c == '\\') ? backslashCount + 1 : 0;

                        switch(c)
                        {
                            case ' ':
                                x += spaceWidth;
                                continue;

                            case '\t':
                                x += tabWidth * spaceWidth;
                                continue;

                            case '\\':
                                if(backslashCount % 2 == 0)
                                    continue;

                                var renderModifier = ParseEscapeSequence(ref i, line, glyphIndex);

                                if(renderModifier != null)
                                {
                                    if(renderModifier is FontModifier fontModifier)
                                        currentFont = fontModifier.Font ?? font;

                                    renderModifiers.Add(renderModifier);
                                    continue;
                                }

                                break;
                        }

                        if(!currentFont.Glyphs.TryGetValue(c, out var glyph))
                        {
                            x += spaceWidth;
                            continue;
                        }

                        if(glyphIndex > 0)
                            x += currentFont.KernTable[pc, c];

                        glyphIndex++;
                        glyphs.Add(new RenderedGlyph(c, glyph, x, 0)); // y is calculated when rendering

                        x += glyph.Width + letterSpacing;

                        if(glyph.Height > lineHeight)
                            lineHeight = glyph.Height;

                        if(glyph.Descender > tallestDescender)
                            tallestDescender = glyph.Descender;

                        if(currentFont.LineHeight > fontLineHeight)
                            fontLineHeight = currentFont.LineHeight;

                        pc = c;
                    }

                    if(x - letterSpacing > width)
                        width = x - letterSpacing;

                    height += lineHeight + fontLineHeight;

                    lines.Add(new TextMeasuredLine(glyphs, x, lineHeight, fontLineHeight, tallestDescender, renderModifiers));
                }

                height -= lines.Last().LineHeight;
            }

            return new TextMeasurementResult(lines, width, height);
        }

        private TextRenderModifier ParseEscapeSequence(ref int index, string text, int glyphIndex)
        {
            int start = index + 1;

            if(start + 1 >= text.Length)
                return null;

            var character = char.ToLower(text[start++]);

            switch(character)
            {
                case 'c':
                    char colorCode = char.ToUpperInvariant(text[start++]);

                    if(colorCode >= 'A' && colorCode <= 'Z')
                    {
                        if(!Translations.TryGetValue(colorCode.ToString(), out var translation))
                            break;

                        index += 2;
                        return new ColorTranslationModifier(glyphIndex, translation);
                    }
                    else if(colorCode == '-')
                    {
                        index += 2;
                        return new ColorTranslationModifier(glyphIndex, null);
                    }

                    if(colorCode != '[' || start >= text.Length || text[start] == ']')
                        break; // Not the beginning of a named color code, or the name was empty

                    int colorEnd = text.IndexOf(']', start);

                    if(colorEnd < 0)
                        break;

                    string colorName = text.Substring(start, colorEnd - start);

                    if(!Translations.TryGetValue(colorName, out var namedTranslation))
                        break;

                    index = colorEnd;
                    return new ColorTranslationModifier(glyphIndex, namedTranslation);

                case 'f':
                    if(text[start] == '-')
                    {
                        index += 2;
                        return new FontModifier<Font<Image, Glyph>>(glyphIndex, null);
                    }

                    if(text[start] != '[' || start + 1 >= text.Length || text[++start] == ']')
                        break;

                    int fontEnd = text.IndexOf(']', start);

                    if(fontEnd < 0)
                        break;

                    string fontName = text.Substring(start, fontEnd - start);

                    if(!Fonts.TryGetValue(fontName, out var font))
                        break;

                    index = fontEnd;
                    return new FontModifier<Font<Image, Glyph>>(glyphIndex, font);
            }

            return null;
        }

        #region IDisposable Support
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if(!disposedValue)
            {
                if(disposing)
                {
                    // Dispose managed resources
                    DefaultFont.Dispose();
                }

                // Free unmanaged resources

                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~TextRenderer()
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
