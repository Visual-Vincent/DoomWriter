using System;
using SixLaborsSize = SixLabors.ImageSharp.Size;

namespace DoomWriter
{
    /// <summary>
    /// Represents the size of a rectangular region with an ordered pair of width and height.
    /// </summary>
    public readonly struct Size
    {
        /// <summary>
        /// Gets a <see cref="Size"/> structure that has a Width and Height value of 0.
        /// </summary>
        public static readonly Size Zero = new Size();

        private readonly int width;
        private readonly int height;

        /// <summary>
        /// Gets the width of this instance.
        /// </summary>
        public int Width => width;

        /// <summary>
        /// Gets the height of this instance.
        /// </summary>
        public int Height => height;

        /// <summary>
        /// Gets whether or not the width or height are zero.
        /// </summary>
        public bool IsZero => width <= 0 || height <= 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Size"/> struct.
        /// </summary>
        /// <param name="width">The width component of the new <see cref="Size"/>.</param>
        /// <param name="height">The height component of the new <see cref="Size"/>.</param>
        public Size(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public static bool operator ==(Size a, Size b) => a.Equals(b);
        public static bool operator !=(Size a, Size b) => !a.Equals(b);

        public static implicit operator SixLaborsSize(Size size)
        {
            return new SixLaborsSize(size.Width, size.Height);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if(obj is null)
                return false;

            if(!(obj is Size))
                return false;

            return Equals((Size)obj);
        }

        /// <summary>
        /// Determines whether the specified size is equal to the current size.
        /// </summary>
        /// <param name="size">The size to compare against.</param>
        public bool Equals(Size size)
        {
            return size.width == width && size.height == height;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(width, height);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{{{Width}, {Height}}}";
        }
    }
}
