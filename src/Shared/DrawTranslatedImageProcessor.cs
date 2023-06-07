using System;
using System.Runtime.CompilerServices;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Memory;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing.Processors;

using SixLaborsImage = SixLabors.ImageSharp.Image;
using SixLaborsPoint = SixLabors.ImageSharp.Point;
using SixLaborsRectangle = SixLabors.ImageSharp.Rectangle;

namespace DoomWriter
{
    //
    // The following code is licensed under these terms:
    //
    //
    //   Copyright (c) Six Labors
    //
    //   Licensed under the Apache License, Version 2.0 (the "License");
    //   you may not use this file except in compliance with the License.
    //   You may obtain a copy of the License at
    //
    //       http://www.apache.org/licenses/LICENSE-2.0
    //
    //   Unless required by applicable law or agreed to in writing, software
    //   distributed under the License is distributed on an "AS IS" BASIS,
    //   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    //   See the License for the specific language governing permissions and
    //   limitations under the License.
    //
    //
    //   With modifications by     :  Visual Vincent
    //   Modifications description :  Rewrote method OnFrameApply() and struct RowOperation in class DrawTranslatedImageProcessorInternal
    //                                to properly handle drawing portions of one image onto another (reference: https://github.com/SixLabors/ImageSharp/issues/2447).
    //
    //                                Adapted code to work with ColorTranslation.
    //
    //                                Additionally some minor changes were made, such as reordering certain properties and removing "this." where applicable.
    //

    /// <summary>
    /// Combines two images together by applying a color translation to the blended image and then blending the pixels.
    /// </summary>
    public class DrawTranslatedImageProcessor : IImageProcessor
    {
        /// <summary>
        /// Gets the image to blend.
        /// </summary>
        public SixLaborsImage Image { get; }

        /// <summary>
        /// Gets the location to draw the blended image.
        /// </summary>
        public SixLaborsPoint Location { get; }

        /// <summary>
        /// Gets the blending mode to use when drawing the image.
        /// </summary>
        public PixelColorBlendingMode ColorBlendingMode { get; }

        /// <summary>
        /// Gets the Alpha blending mode to use when drawing the image.
        /// </summary>
        public PixelAlphaCompositionMode AlphaCompositionMode { get; }

        /// <summary>
        /// Gets the color translation to use when drawing the image.
        /// </summary>
        public ColorTranslation Translation { get; }

        /// <summary>
        /// Gets the opacity of the image to blend.
        /// </summary>
        public float Opacity { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawTranslatedImageProcessor"/> class.
        /// </summary>
        /// <param name="image">The image to blend.</param>
        /// <param name="location">The location to draw the blended image.</param>
        /// <param name="colorBlendingMode">The blending mode to use when drawing the image.</param>
        /// <param name="alphaCompositionMode">The Alpha blending mode to use when drawing the image.</param>
        /// <param name="translation">The color translation to use when drawing the image.</param>
        /// <param name="opacity">The opacity of the image to blend.</param>
        public DrawTranslatedImageProcessor(
            SixLaborsImage image,
            SixLaborsPoint location,
            PixelColorBlendingMode colorBlendingMode,
            PixelAlphaCompositionMode alphaCompositionMode,
            ColorTranslation translation,
            float opacity)
        {
#pragma warning disable IDE0016 // Use 'throw' expression
            if(image == null)
                throw new ArgumentNullException(nameof(image));
#pragma warning restore IDE0016

            Image = image;
            Location = location;
            ColorBlendingMode = colorBlendingMode;
            AlphaCompositionMode = alphaCompositionMode;
            Translation = translation;
            Opacity = opacity;
        }

        /// <inheritdoc/>
        public IImageProcessor<TPixelBg> CreatePixelSpecificProcessor<TPixelBg>(Configuration configuration, Image<TPixelBg> source, SixLaborsRectangle sourceRectangle)
            where TPixelBg : unmanaged, IPixel<TPixelBg>
        {
            if(typeof(TPixelBg) != typeof(Rgba32))
                throw new NotSupportedException($"Failed to draw image: Attempted to draw to an image with pixel format {typeof(TPixelBg).Name}. {nameof(DrawTranslatedImageProcessor)} supports only {nameof(Rgba32)}");

            var visitor = new ProcessorFactoryVisitor(configuration, this, source as Image<Rgba32>, sourceRectangle);
            Image.AcceptVisitor(visitor);
            return visitor.Result as IImageProcessor<TPixelBg>;
        }

        private class ProcessorFactoryVisitor : IImageVisitor
        {
            private readonly Configuration configuration;
            private readonly DrawTranslatedImageProcessor definition;
            private readonly Image<Rgba32> source;
            private readonly SixLaborsRectangle sourceRectangle;

            public ProcessorFactoryVisitor(Configuration configuration, DrawTranslatedImageProcessor definition, Image<Rgba32> source, SixLaborsRectangle sourceRectangle)
            {
                this.configuration = configuration;
                this.definition = definition;
                this.source = source as Image<Rgba32>;
                this.sourceRectangle = sourceRectangle;
            }

            public IImageProcessor<Rgba32> Result { get; private set; }

            public void Visit<TPixelFg>(Image<TPixelFg> image)
                where TPixelFg : unmanaged, IPixel<TPixelFg>
            {
                Result = new DrawTranslatedImageProcessorInternal(
                    configuration,
                    image as Image<Rgba32>,
                    source,
                    sourceRectangle,
                    definition.Location,
                    definition.ColorBlendingMode,
                    definition.AlphaCompositionMode,
                    definition.Translation,
                    definition.Opacity
                );
            }
        }
    }

    /// <summary>
    /// Combines two images together by applying a color translation to the foreground image and then blending the pixels.
    /// </summary>
    internal class DrawTranslatedImageProcessorInternal : ImageProcessor<Rgba32>
    {
        /// <summary>
        /// Gets the pixel blender.
        /// </summary>
        public PixelBlender<Rgba32> Blender { get; }

        /// <summary>
        /// Gets the image to blend.
        /// </summary>
        public Image<Rgba32> Image { get; }

        /// <summary>
        /// Gets the location to draw the blended image.
        /// </summary>
        public SixLaborsPoint Location { get; }

        /// <summary>
        /// Gets the color translation to use when drawing the image.
        /// </summary>
        public ColorTranslation Translation { get; }

        /// <summary>
        /// Gets the opacity of the image to blend.
        /// </summary>
        public float Opacity { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawTranslatedImageProcessorInternal"/> class.
        /// </summary>
        /// <param name="configuration">The configuration which allows altering default behaviour or extending the library.</param>
        /// <param name="image">The foreground <see cref="Image{Rgba32}"/> to blend with the currently processing image.</param>
        /// <param name="source">The source <see cref="Image{Rgba32}"/> for the current processor instance.</param>
        /// <param name="sourceRectangle">The source area to process for the current processor instance.</param>
        /// <param name="location">The location to draw the blended image.</param>
        /// <param name="colorBlendingMode">The blending mode to use when drawing the image.</param>
        /// <param name="alphaCompositionMode">The Alpha blending mode to use when drawing the image.</param>
        /// <param name="translation">The color translation to use when drawing the image.</param>
        /// <param name="opacity">The opacity of the image to blend. Must be between 0 and 1.</param>
        public DrawTranslatedImageProcessorInternal(
            Configuration configuration,
            Image<Rgba32> image,
            Image<Rgba32> source,
            SixLaborsRectangle sourceRectangle,
            SixLaborsPoint location,
            PixelColorBlendingMode colorBlendingMode,
            PixelAlphaCompositionMode alphaCompositionMode,
            ColorTranslation translation,
            float opacity)
            : base(configuration, source, sourceRectangle)
        {
#pragma warning disable IDE0016 // Use 'throw' expression
            if(image == null)
                throw new ArgumentNullException(nameof(image));
#pragma warning restore IDE0016

            if(opacity < 0.0f || opacity > 1.0f)
                throw new ArgumentOutOfRangeException(nameof(opacity));

            Blender = PixelOperations<Rgba32>.Instance.GetPixelBlender(colorBlendingMode, alphaCompositionMode);
            Image = image;
            Location = location;
            Translation = translation;
            Opacity = opacity;
        }

        /// <inheritdoc/>
        protected override void OnFrameApply(ImageFrame<Rgba32> source)
        {
            SixLaborsPoint location = Location;
            SixLaborsRectangle sourceRectangle = SourceRectangle;
            Configuration configuration = Configuration;

            Image<Rgba32> targetImage = Image;
            PixelBlender<Rgba32> blender = Blender;
            ColorTranslation translation = Translation;

            SixLaborsRectangle targetBounds = targetImage.Bounds();

            if(sourceRectangle.X + sourceRectangle.Width > targetBounds.Right || sourceRectangle.Y + sourceRectangle.Height > targetBounds.Bottom)
                throw new ImageProcessingException("Cannot draw image because the source rectangle is outside the bounds of the source image");

            var workingRect = new SixLaborsRectangle(
                Math.Max(location.X, 0), Math.Max(location.Y, 0), Math.Min(source.Width - location.X, sourceRectangle.Width), Math.Min(source.Height - location.Y, sourceRectangle.Height)
            );

            if(location.X < 0)
            {
                sourceRectangle.X -= location.X;
                workingRect.Width += location.X;
            }

            if(location.Y < 0)
            {
                sourceRectangle.Y -= location.Y;
                workingRect.Height += location.Y;
            }

            if(workingRect.Width <= 0 || workingRect.Height <= 0)
                throw new ImageProcessingException("Cannot draw image because the source image does not overlap the target image");

            double minLum = 0.0;
            double maxLum = 0.0;

            if(translation != null)
                (minLum, maxLum) = ColorTranslator.CalculateLuminanceRange(targetImage);

            var operation = new RowOperation(source.PixelBuffer, targetImage.Frames.RootFrame.PixelBuffer, blender, translation, configuration, workingRect.X, workingRect.Y, workingRect.Width, sourceRectangle.X, sourceRectangle.Y, minLum, maxLum, Opacity);

            ParallelRowIterator.IterateRows(
                configuration,
                workingRect,
                in operation
            );
        }

        /// <summary>
        /// A <see langword="struct"/> implementing the draw logic for <see cref="DrawTranslatedImageProcessor"/>.
        /// </summary>
        private readonly struct RowOperation : IRowOperation
        {
            private readonly Buffer2D<Rgba32> source;
            private readonly Buffer2D<Rgba32> target;
            private readonly PixelBlender<Rgba32> blender;
            private readonly ColorTranslation translation;
            private readonly Configuration configuration;
            private readonly int srcX;
            private readonly int srcY;
            private readonly int width;
            private readonly int targetY;
            private readonly int targetX;
            private readonly double minLum;
            private readonly double maxLum;
            private readonly double diffLum;
            private readonly float opacity;

#pragma warning disable IDE0003 // Remove 'this'

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RowOperation(
                Buffer2D<Rgba32> source,
                Buffer2D<Rgba32> target,
                PixelBlender<Rgba32> blender,
                ColorTranslation translation,
                Configuration configuration,
                int srcX,
                int srcY,
                int width,
                int targetX,
                int targetY,
                double minLum,
                double maxLum,
                float opacity)
            {
                this.source = source;
                this.target = target;
                this.blender = blender;
                this.translation = translation;
                this.configuration = configuration;
                this.srcX = srcX;
                this.srcY = srcY;
                this.width = width;
                this.targetX = targetX;
                this.targetY = targetY;
                this.minLum = minLum;
                this.maxLum = maxLum;
                this.diffLum = maxLum - minLum;
                this.opacity = opacity;
            }

#pragma warning restore IDE0003

            /// <inheritdoc/>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Invoke(int y)
            {
                Span<Rgba32> background = source.DangerousGetRowSpan(y).Slice(srcX, width);
                Span<Rgba32> foreground = target.DangerousGetRowSpan(y - srcY + targetY).Slice(targetX, width);

                Span<Rgba32> fgClone = new Rgba32[foreground.Length].AsSpan();

                foreground.CopyTo(fgClone);
                foreground = fgClone;

                if(translation != null && !translation.IsUntranslated)
                {
                    for(int i = 0; i < foreground.Length; i++)
                    {
                        foreground[i] = Translate(foreground[i]);
                    }
                }

                blender.Blend<Rgba32>(configuration, background, background, foreground, opacity);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private Rgba32 Translate(Rgba32 pixel)
            {
                if(pixel.A == 0)
                    return pixel;

                var luminance = pixel.Luminance();
                int lum = (int)((luminance - minLum) / diffLum * 256.0);
                
                var range = translation.FindRange(lum);
                if(range == null)
                    return pixel;

                var start = range.ColorStart;
                var end = range.ColorEnd;

                int v = ((lum - range.LuminanceStart) << 8) / (range.LuminanceEnd - range.LuminanceStart);
                int r = ColorTranslator.Lerp(start.R, end.R, v).Clamp(0, 255);
                int g = ColorTranslator.Lerp(start.G, end.G, v).Clamp(0, 255);
                int b = ColorTranslator.Lerp(start.B, end.B, v).Clamp(0, 255);

                return new Rgba32((byte)r, (byte)g, (byte)b, pixel.A);
            }
        }
    }
}
