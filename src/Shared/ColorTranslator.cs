using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

using SixLaborsImage = SixLabors.ImageSharp.Image;

namespace DoomWriter
{
    /// <summary>
    /// A static class for translating colors in images.
    /// </summary>
    public static class ColorTranslator
    {
        /// <summary>
        /// The default color translation ranges.
        /// </summary>
        public static readonly ReadOnlyDictionary<string, ColorTranslation> DefaultTranslations;

        static ColorTranslator()
        {
            DefaultTranslations = new ReadOnlyDictionary<string, ColorTranslation>(
                new Dictionary<string, ColorTranslation>() {
                    { "A", CreateTranslation(new[] { ("#470000", "#FFB8B8", 0, 256) }) },
                    { "B", CreateTranslation(new[] { ("#332B13", "#FFEBDF", 0, 256) }) },
                    { "C", CreateTranslation(new[] { ("#272727", "#EFEFEF", 0, 256) }) },
                    { "D", CreateTranslation(new[] { ("#0B1707", "#77FF6F", 0, 256) }) },
                    { "E", CreateTranslation(new[] { ("#533F2F", "#BFA78F", 0, 256) }) },
                    { "F", CreateTranslation(new[] { ("#732B00", "#FFFF73", 0, 256) }) },
                    { "G", CreateTranslation(new[] { ("#3F0000", "#FF0000", 0, 256) }) },
                    { "H", CreateTranslation(new[] { ("#000027", "#0000FF", 0, 256) }) },
                    { "I", CreateTranslation(new[] { ("#200000", "#FF8000", 0, 256) }) },
                    { "J", CreateTranslation(new[] { ("#242424", "#FFFFFF", 0, 256) }) },
                    { "K", CreateTranslation(new[] { ("#272727", "#515151",   0,  64),
                                                     ("#784918", "#F3A718",  65, 207),
                                                     ("#F3A82A", "#FCD043", 208, 256) }) },
                    { "L", ColorTranslation.Untranslated },
                    { "M", CreateTranslation(new[] { ("#131313", "#505050", 0, 256) }) },
                    { "N", CreateTranslation(new[] { ("#000073", "#B4B4FF", 0, 256) }) },
                    { "O", CreateTranslation(new[] { ("#CF8353", "#FFD7BB", 0, 256) }) },
                    { "P", CreateTranslation(new[] { ("#2F371F", "#7B7F50", 0, 256) }) },
                    { "Q", CreateTranslation(new[] { ("#0B1707", "#439337", 0, 256) }) },
                    { "R", CreateTranslation(new[] { ("#2B0000", "#AF2B2B", 0, 256) }) },
                    { "S", CreateTranslation(new[] { ("#1F170B", "#A36B3F", 0, 256) }) },
                    { "T", CreateTranslation(new[] { ("#230023", "#CF00CF", 0, 256) }) },
                    { "U", CreateTranslation(new[] { ("#232323", "#8B8B8B", 0, 256) }) },
                    { "V", CreateTranslation(new[] { ("#001F1F", "#00F0F0", 0, 256) }) },
                    { "W", CreateTranslation(new[] { ("#343450", "#7C7C98",   0,  94),
                                                     ("#7C7C98", "#E0E0E0",  95, 256) }) },
                    { "X", CreateTranslation(new[] { ("#660000", "#D57604",   0, 104),
                                                     ("#D57604", "#FFFF00", 105, 256) }) },
                    { "Y", CreateTranslation(new[] { ("#000468", "#506CFC",   0,  94),
                                                     ("#506CFC", "#50ECFC",  95, 256) }) },
                    { "Z", CreateTranslation(new[] { ("#001F1F", "#236773",   0,  90),
                                                     ("#236773", "#7BB3C3",  91, 256) }) },
                }
            );
        }

        private static ColorTranslation CreateTranslation((string ColorStart, string ColorEnd, int LuminanceStart, int LuminanceEnd)[] ranges)
        {
            ColorTranslation translation = new ColorTranslation();

            foreach(var range in ranges)
                translation.Add(new TranslationRange((ushort)range.LuminanceStart, (ushort)range.LuminanceEnd, ColorFromHex(range.ColorStart), ColorFromHex(range.ColorEnd)));

            return translation;
        }

        private static int Lerp(int a, int b, int v)
        {
            return ((a << 8) + (b - a) * v) >> 8;
        }

        private static double Luminance(Rgba32 pixel)
        {
            return pixel.R * 0.299 + pixel.G * 0.587 + pixel.B * 0.114;
        }

        /// <summary>
        /// Parses the specified string as a hex color and returns the resulting <see cref="Rgba32"/>.
        /// </summary>
        /// <param name="hex">The hex color string to parse.</param>
        public static Rgba32 ColorFromHex(string hex)
        {
            if(hex == null)
                throw new ArgumentNullException(nameof(hex));

            if(hex.Length != 7 || !hex.StartsWith("#"))
                throw new ArgumentException($"\"{hex}\" is not a valid hex color", nameof(hex));

            hex = hex.TrimStart('#');

            if(hex.Length != 6)
                throw new ArgumentException($"\"{hex}\" is not a valid hex color", nameof(hex));

            string sR = hex.Substring(0, 2);
            string sG = hex.Substring(2, 2);
            string sB = hex.Substring(4, 2);

            byte r = Convert.ToByte(sR, 16);
            byte g = Convert.ToByte(sG, 16);
            byte b = Convert.ToByte(sB, 16);

            return new Rgba32(r, g, b);
        }

        /// <summary>
        /// Reads an image from disk and applies the specified color translation it.
        /// </summary>
        /// <param name="image">The image to translate.</param>
        /// <param name="translation">The color translation to use.</param>
        public static Image<Rgba32> Translate(string image, ColorTranslation translation)
        {
            if(image == null)
                throw new ArgumentNullException(nameof(image));

            using(var result = SixLaborsImage.Load<Rgba32>(image))
            {
                return Translate(result, translation);
            }
        }

        /// <summary>
        /// Clones the specified image and applies the specified color translation.
        /// </summary>
        /// <param name="image">The image to translate.</param>
        /// <param name="translation">The color translation to use.</param>
        public static Image<Rgba32> Translate(Image<Rgba32> image, ColorTranslation translation)
        {
            if(image == null)
                throw new ArgumentNullException(nameof(image));

            var result = image.Clone();

            if(translation.IsUntranslated)
                return result;
            
            double minLum = double.MaxValue;
            double maxLum = double.MinValue;

            for(int x = 0; x < result.Width; x++)
            {
                for(int y = 0; y < result.Height; y++)
                {
                    var pixel = result[x, y];

                    if(pixel.A == 0)
                        continue;

                    var luminance = Luminance(pixel);

                    if(luminance > maxLum)
                        maxLum = luminance;
                    else if(luminance < minLum)
                        minLum = luminance;
                }
            }

            double diffLum = maxLum - minLum;
            var cache = new Dictionary<int, TranslationRange>();

            for(int x = 0; x < result.Width; x++)
            {
                for(int y = 0; y < result.Height; y++)
                {
                    var pixel = result[x, y];

                    if(pixel.A == 0)
                        continue;

                    var luminance = Luminance(pixel);
                    int lum = (int)((luminance - minLum) / diffLum * 256.0);

                    if(!cache.TryGetValue(lum, out var range))
                    {
                        range = translation.FindRange(lum);
                        cache.Add(lum, range);
                    }

                    if(range == null)
                        continue;

                    var start = range.ColorStart;
                    var end = range.ColorEnd;

                    int v = ((lum - range.LuminanceStart) << 8) / (range.LuminanceEnd - range.LuminanceStart);
                    int r = Lerp(start.R, end.R, v).Clamp(0, 255);
                    int g = Lerp(start.G, end.G, v).Clamp(0, 255);
                    int b = Lerp(start.B, end.B, v).Clamp(0, 255);

                    result[x, y] = new Rgba32((byte)r, (byte)g, (byte)b, 255);
                }
            }

            return result;
        }
    }
}
