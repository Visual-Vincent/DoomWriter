using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SixLabors.ImageSharp.PixelFormats;

namespace DoomWriter
{
    /// <summary>
    /// The default Doom Writer text renderer.
    /// </summary>
    public class TextRenderer : TextRendererBase, ITextRenderer<Image, Glyph>
    {
        private readonly Font DefaultFont = LoadDefaultFont<Font>();

        private readonly Dictionary<string, ColorTranslation> translations = new Dictionary<string, ColorTranslation>();

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
                DefaultFont.AddTranslation(kvp.Value);
                translations.Add(kvp.Key, kvp.Value.Clone());
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

            int y = 0;

            foreach(var line in measurement.Lines)
            {
                foreach(var g in line.Glyphs)
                {
                    font.DrawGlyph((Glyph)g.Glyph, surface, g.X, y + (line.Height - line.TallestDescender - g.Glyph.Height + g.Glyph.Descender), g.Translation);
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

            Font<Image, Glyph> currentFont = font;
            ColorTranslation currentTranslation = null;

            using(StringReader reader = new StringReader(text))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    int x = 0;
                    int lineHeight = line.Length <= 0 ? currentFont.EmptyLineHeight : 0;
                    int tallestDescender = 0;

                    var fontLineHeight = currentFont.LineHeight;
                    var letterSpacing = currentFont.LetterSpacing;
                    var spaceWidth = currentFont.SpaceWidth + currentFont.LetterSpacing;
                    var tabWidth = currentFont.TabWidth;

                    var glyphs = new List<RenderedGlyph>();

                    // Ensure spaces are always the same size
                    if(line.Length > 0 && (line[0] == ' ' || line[0] == '\t'))
                    {
                        x += letterSpacing;
                    }

                    for(int i = 0; i < line.Length; i++)
                    {
                        char c = line[i];
                        char pc = i > 0 ? line[i-1] : (char)0;

                        // Ensure spaces are always the same size
                        if((pc == ' ' || pc == '\t') && (c != ' ' && c != '\t'))
                        {
                            x -= letterSpacing;
                        }

                        switch(c)
                        {
                            case ' ':
                                x += spaceWidth;
                                continue;

                            case '\t':
                                x += tabWidth * spaceWidth;
                                continue;

                            case '\\':
                                if(i + 2 >= line.Length || line[i+1] != 'c')
                                    break;

                                char colorCode = char.ToUpperInvariant(line[i+2]);

                                if(colorCode >= 'A' && colorCode <= 'Z')
                                {
                                    translations.TryGetValue(colorCode.ToString(), out currentTranslation);
                                    i += 2;
                                    continue;
                                }
                                else if(colorCode == '-')
                                {
                                    currentTranslation = null;
                                    i += 2;
                                    continue;
                                }
                                break;
                        }

                        if(!currentFont.Glyphs.TryGetValue(c, out var glyph))
                        {
                            x += spaceWidth;
                            continue;
                        }

                        if(i > 0)
                            x += currentFont.KernTable[pc, c];

                        glyphs.Add(new RenderedGlyph(c, glyph, x, 0, currentTranslation)); // y is calculated when rendering

                        x += glyph.Width + letterSpacing;

                        if(glyph.Height > lineHeight)
                            lineHeight = glyph.Height;

                        if(glyph.Descender > tallestDescender)
                            tallestDescender = glyph.Descender;

                        if(currentFont.LineHeight > fontLineHeight)
                            fontLineHeight = currentFont.LineHeight;
                    }

                    if(x - letterSpacing > width)
                        width = x - letterSpacing;

                    height += lineHeight + fontLineHeight;

                    lines.Add(new TextMeasuredLine(glyphs, x, lineHeight, fontLineHeight, tallestDescender));
                }

                height -= lines.Last().LineHeight;
            }

            return new TextMeasurementResult(lines, width, height);
        }
    }
}
