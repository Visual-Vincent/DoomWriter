using System;
using System.Collections.Generic;
using System.IO;
using SixLabors.ImageSharp.PixelFormats;

namespace DoomWriter
{
    /// <summary>
    /// The default Doom Writer text renderer.
    /// </summary>
    public class TextRenderer : TextRendererBase
    {
        /// <inheritdoc/>
        public override Image Render(string text)
        {
            var measurement = Measure(text);
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

        private TextMeasurementResult<ImageGlyph, Image> Measure(string text)
        {
            int width = 0;
            int height = 0;

            var lines = new List<TextMeasuredLine<ImageGlyph, Image>>();
            Font currentFont = null;

            using(StringReader reader = new StringReader(text))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    int x = 0;
                    int lineHeight = 0;
                    int fontLineHeight = currentFont.LineHeight;

                    var glyphs = new List<RenderedGlyph<ImageGlyph, Image>>();

                    foreach(char c in line)
                    {
                        switch(c)
                        {
                            case ' ':
                                x += currentFont.SpaceWidth;
                                continue;

                            case '\t':
                                x += currentFont.TabWidth;
                                continue;
                        }

                        if(!currentFont.Glyphs.TryGetValue(c, out var glyph))
                        {
                            x += currentFont.SpaceWidth;
                            continue;
                        }

                        glyphs.Add(new RenderedGlyph<ImageGlyph, Image>(c, glyph, x, 0)); // y is calculated when rendering

                        x += glyph.Width;

                        if(glyph.Height > lineHeight)
                            lineHeight = glyph.Height;

                        if(currentFont.LineHeight > fontLineHeight)
                            fontLineHeight = currentFont.LineHeight;
                    }

                    if(x > width)
                        width = x;

                    lines.Add(new TextMeasuredLine<ImageGlyph, Image>(glyphs, x, lineHeight, fontLineHeight));
                }
            }

            return new TextMeasurementResult<ImageGlyph, Image>(lines, width, height);
        }
    }
}
