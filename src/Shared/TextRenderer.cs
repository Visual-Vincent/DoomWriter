using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace DoomWriter
{
    /// <summary>
    /// The default Doom Writer text renderer.
    /// </summary>
    public class TextRenderer : TextRendererBase, ITextRenderer<Image, ImageGlyph, Image>
    {
        private static readonly Font DefaultFont = LoadDefaultFont<Font>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TextRenderer"/> class.
        /// </summary>
        public TextRenderer()
        {
        }

        /// <inheritdoc/>
        public override Image Render(string text)
        {
            return Render(text, DefaultFont);
        }

        /// <inheritdoc/>
        public Image Render(string text, Font<ImageGlyph, Image> font)
        {
            var measurement = Measure(text, font);
            var surface = new ImageSurface<Rgba32>(measurement.Width, measurement.Height);

            int y = 0;

            foreach(var line in measurement.Lines)
            {
                foreach(var g in line.Glyphs)
                {
                    g.Glyph.Draw(surface, g.X, y + (line.Height - g.Glyph.Height));
                }

                y += line.Height + line.LineHeight;
            }

            return new Image(surface.GetImage());
        }

        private TextMeasurementResult<ImageGlyph, Image> Measure(string text, Font<ImageGlyph, Image> font)
        {
            if(text == null)
                throw new ArgumentNullException(nameof(text));

            if(font == null)
                throw new ArgumentNullException(nameof(font));

            if(text.Length <= 0)
                throw new ArgumentException("No text specified", nameof(text));

            int width = 0;
            int height = 0;

            var lines = new List<TextMeasuredLine<ImageGlyph, Image>>();
            Font<ImageGlyph, Image> currentFont = font;

            using(StringReader reader = new StringReader(text))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    int x = 0;
                    int lineHeight = line.Length <= 0 ? currentFont.EmptyLineHeight : 0;

                    var fontLineHeight = currentFont.LineHeight;
                    var letterSpacing = currentFont.LetterSpacing;
                    var spaceWidth = currentFont.SpaceWidth + currentFont.LetterSpacing;
                    var tabWidth = currentFont.TabWidth;

                    var glyphs = new List<RenderedGlyph<ImageGlyph, Image>>();

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
                        }

                        if(!currentFont.Glyphs.TryGetValue(c, out var glyph))
                        {
                            x += spaceWidth;
                            continue;
                        }

                        glyphs.Add(new RenderedGlyph<ImageGlyph, Image>(c, glyph, x, 0)); // y is calculated when rendering

                        x += glyph.Width + letterSpacing;

                        if(glyph.Height > lineHeight)
                            lineHeight = glyph.Height;

                        if(currentFont.LineHeight > fontLineHeight)
                            fontLineHeight = currentFont.LineHeight;
                    }

                    if(x - letterSpacing > width)
                        width = x - letterSpacing;

                    height += lineHeight + fontLineHeight;

                    lines.Add(new TextMeasuredLine<ImageGlyph, Image>(glyphs, x, lineHeight, fontLineHeight));
                }

                height -= lines.Last().LineHeight;
            }

            return new TextMeasurementResult<ImageGlyph, Image>(lines, width, height);
        }
    }
}
