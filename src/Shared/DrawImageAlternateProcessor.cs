using System;
using System.Runtime.CompilerServices;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Memory;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing.Processors;
using SixLabors.ImageSharp.Processing.Processors.Drawing;

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
    //   Modifications description :  Rewrote method OnFrameApply() and struct RowOperation in class DrawImageAlternateProcessor<TPixelBg, TPixelFg>
    //                                to properly handle drawing portions of one image onto another (reference: https://github.com/SixLabors/ImageSharp/issues/2447).
    //
    //                                Additionally some minor changes were made, such as reordering certain properties and removing "this." where applicable.
    //

    /// <summary>
    /// Combines two images together by blending the pixels. Differs from <see cref="DrawImageProcessor"/> in that this correctly draws portions of one image onto another.
    /// </summary>
    public class DrawImageAlternateProcessor : IImageProcessor
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
        /// Gets the opacity of the image to blend.
        /// </summary>
        public float Opacity { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawImageProcessor"/> class.
        /// </summary>
        /// <param name="image">The image to blend.</param>
        /// <param name="location">The location to draw the blended image.</param>
        /// <param name="colorBlendingMode">The blending mode to use when drawing the image.</param>
        /// <param name="alphaCompositionMode">The Alpha blending mode to use when drawing the image.</param>
        /// <param name="opacity">The opacity of the image to blend.</param>
        public DrawImageAlternateProcessor(
            SixLaborsImage image,
            SixLaborsPoint location,
            PixelColorBlendingMode colorBlendingMode,
            PixelAlphaCompositionMode alphaCompositionMode,
            float opacity)
        {
            Image = image;
            Location = location;
            ColorBlendingMode = colorBlendingMode;
            AlphaCompositionMode = alphaCompositionMode;
            Opacity = opacity;
        }

        /// <inheritdoc/>
        public IImageProcessor<TPixelBg> CreatePixelSpecificProcessor<TPixelBg>(Configuration configuration, Image<TPixelBg> source, SixLaborsRectangle sourceRectangle)
            where TPixelBg : unmanaged, IPixel<TPixelBg>
        {
            var visitor = new ProcessorFactoryVisitor<TPixelBg>(configuration, this, source, sourceRectangle);
            Image.AcceptVisitor(visitor);
            return visitor.Result;
        }

        private class ProcessorFactoryVisitor<TPixelBg> : IImageVisitor
            where TPixelBg : unmanaged, IPixel<TPixelBg>
        {
            private readonly Configuration configuration;
            private readonly DrawImageAlternateProcessor definition;
            private readonly Image<TPixelBg> source;
            private readonly SixLaborsRectangle sourceRectangle;

            public ProcessorFactoryVisitor(Configuration configuration, DrawImageAlternateProcessor definition, Image<TPixelBg> source, SixLaborsRectangle sourceRectangle)
            {
                this.configuration = configuration;
                this.definition = definition;
                this.source = source;
                this.sourceRectangle = sourceRectangle;
            }

            public IImageProcessor<TPixelBg> Result { get; private set; }

            public void Visit<TPixelFg>(Image<TPixelFg> image)
                where TPixelFg : unmanaged, IPixel<TPixelFg>
            {
                Result = new DrawImageAlternateProcessor<TPixelBg, TPixelFg>(
                    configuration,
                    image,
                    source,
                    sourceRectangle,
                    definition.Location,
                    definition.ColorBlendingMode,
                    definition.AlphaCompositionMode,
                    definition.Opacity
                );
            }
        }
    }

    /// <summary>
    /// Combines two images together by blending the pixels.
    /// </summary>
    /// <typeparam name="TPixelBg">The pixel format of destination image.</typeparam>
    /// <typeparam name="TPixelFg">The pixel format of source image.</typeparam>
    internal class DrawImageAlternateProcessor<TPixelBg, TPixelFg> : ImageProcessor<TPixelBg>
        where TPixelBg : unmanaged, IPixel<TPixelBg>
        where TPixelFg : unmanaged, IPixel<TPixelFg>
    {
        /// <summary>
        /// Gets the pixel blender
        /// </summary>
        public PixelBlender<TPixelBg> Blender { get; }

        /// <summary>
        /// Gets the image to blend
        /// </summary>
        public Image<TPixelFg> Image { get; }

        /// <summary>
        /// Gets the location to draw the blended image
        /// </summary>
        public SixLaborsPoint Location { get; }

        /// <summary>
        /// Gets the opacity of the image to blend
        /// </summary>
        public float Opacity { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawImageAlternateProcessor{TPixelBg, TPixelFg}"/> class.
        /// </summary>
        /// <param name="configuration">The configuration which allows altering default behaviour or extending the library.</param>
        /// <param name="image">The foreground <see cref="Image{TPixelFg}"/> to blend with the currently processing image.</param>
        /// <param name="source">The source <see cref="Image{TPixelBg}"/> for the current processor instance.</param>
        /// <param name="sourceRectangle">The source area to process for the current processor instance.</param>
        /// <param name="location">The location to draw the blended image.</param>
        /// <param name="colorBlendingMode">The blending mode to use when drawing the image.</param>
        /// <param name="alphaCompositionMode">The Alpha blending mode to use when drawing the image.</param>
        /// <param name="opacity">The opacity of the image to blend. Must be between 0 and 1.</param>
        public DrawImageAlternateProcessor(
            Configuration configuration,
            Image<TPixelFg> image,
            Image<TPixelBg> source,
            SixLaborsRectangle sourceRectangle,
            SixLaborsPoint location,
            PixelColorBlendingMode colorBlendingMode,
            PixelAlphaCompositionMode alphaCompositionMode,
            float opacity)
            : base(configuration, source, sourceRectangle)
        {
#pragma warning disable IDE0016 // Use 'throw' expression
            if(image == null)
                throw new ArgumentNullException(nameof(image));
#pragma warning restore IDE0016

            if(opacity < 0.0f || opacity > 1.0f)
                throw new ArgumentOutOfRangeException(nameof(opacity));

            Blender = PixelOperations<TPixelBg>.Instance.GetPixelBlender(colorBlendingMode, alphaCompositionMode);
            Image = image;
            Location = location;
            Opacity = opacity;
        }

        /// <inheritdoc/>
        protected override void OnFrameApply(ImageFrame<TPixelBg> source)
        {
            SixLaborsPoint location = Location;
            SixLaborsRectangle sourceRectangle = SourceRectangle;
            Configuration configuration = Configuration;

            Image<TPixelFg> targetImage = Image;
            PixelBlender<TPixelBg> blender = Blender;

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

            var operation = new RowOperation(source.PixelBuffer, targetImage.Frames.RootFrame.PixelBuffer, blender, configuration, workingRect.X, workingRect.Y, workingRect.Width, sourceRectangle.X, sourceRectangle.Y, Opacity);

            ParallelRowIterator.IterateRows(
                configuration,
                workingRect,
                in operation
            );
        }

        /// <summary>
        /// A <see langword="struct"/> implementing the draw logic for <see cref="DrawImageAlternateProcessor{TPixelBg, TPixelFg}"/>.
        /// </summary>
        private readonly struct RowOperation : IRowOperation
        {
            private readonly Buffer2D<TPixelBg> source;
            private readonly Buffer2D<TPixelFg> target;
            private readonly PixelBlender<TPixelBg> blender;
            private readonly Configuration configuration;
            private readonly int srcX;
            private readonly int srcY;
            private readonly int width;
            private readonly int targetY;
            private readonly int targetX;
            private readonly float opacity;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public RowOperation(
                Buffer2D<TPixelBg> source,
                Buffer2D<TPixelFg> target,
                PixelBlender<TPixelBg> blender,
                Configuration configuration,
                int srcX,
                int srcY,
                int width,
                int targetX,
                int targetY,
                float opacity)
            {
                this.source = source;
                this.target = target;
                this.blender = blender;
                this.configuration = configuration;
                this.srcX = srcX;
                this.srcY = srcY;
                this.width = width;
                this.targetX = targetX;
                this.targetY = targetY;
                this.opacity = opacity;
            }

            /// <inheritdoc/>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Invoke(int y)
            {
                Span<TPixelBg> background = source.DangerousGetRowSpan(y).Slice(srcX, width);
                Span<TPixelFg> foreground = target.DangerousGetRowSpan(y - srcY + targetY).Slice(targetX, width);
                blender.Blend<TPixelFg>(configuration, background, background, foreground, opacity);
            }
        }
    }
}
