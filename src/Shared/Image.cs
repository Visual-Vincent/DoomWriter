using System;
using SixLaborsImage = SixLabors.ImageSharp.Image;

namespace DoomWriter
{
    /// <summary>
    /// Represents an in-memory image.
    /// </summary>
    public class Image : IImage
    {
        internal SixLaborsImage BaseImage { get; }

        public int Width => BaseImage.Width;
        public int Height => BaseImage.Height;

        /// <summary>
        /// Initializes a new instance of the <see cref="Image"/> class.
        /// </summary>
        /// <param name="image">The underlying image that this image wraps.</param>
        public Image(SixLaborsImage image)
        {
            BaseImage = image ?? throw new ArgumentNullException(nameof(image));
        }
    }
}
