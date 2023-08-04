using System;
using SixLaborsRectangle = SixLabors.ImageSharp.Rectangle;

namespace DoomWriter
{
    /// <summary>
    /// Stores a set of four integers that represent the location and size of a rectangle.
    /// </summary>
    public readonly struct Rectangle
    {
        /// <summary>
        /// Represents a rectangle at (0, 0) with no size.
        /// </summary>
        public static readonly Rectangle Zero = new Rectangle();

        /// <summary>
        /// Gets the position of the rectangle.
        /// </summary>
        public Point Position { get; }

        /// <summary>
        /// Gets the size of the rectangle.
        /// </summary>
        public Size Size { get; }

        /// <summary>
        /// Gets the x-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public int X => Position.X;

        /// <summary>
        /// Gets the y-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public int Y => Position.Y;

        /// <summary>
        /// Gets the width of the rectangle.
        /// </summary>
        public int Width => Size.Width;

        /// <summary>
        /// Gets the height of the rectangle.
        /// </summary>
        public int Height => Size.Height;

        /// <summary>
        /// Gets the x-coordinate of the left edge of the rectangle.
        /// </summary>
        public int Left => Position.X;

        /// <summary>
        /// Gets the y-coordinate of the top edge of the rectangle.
        /// </summary>
        public int Top => Position.Y;

        /// <summary>
        /// Gets the x-coordinate of the right edge of the rectangle.
        /// </summary>
        public int Right => Position.X + Size.Width;

        /// <summary>
        /// Gets the y-coordinate of the bottom edge of the rectangle.
        /// </summary>
        public int Bottom => Position.Y + Size.Height;

        /// <summary>
        /// Gets whether or not the width or height of the rectangle are zero.
        /// </summary>
        public bool IsZero => Size.Width <= 0 || Size.Height <= 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> struct.
        /// </summary>
        /// <param name="position">The position of the rectangle.</param>
        /// <param name="size">The size of the rectangle.</param>
        public Rectangle(Point position, Size size)
        {
            if(size.Width < 0 || size.Height < 0)
                throw new ArgumentOutOfRangeException(nameof(size), "Rectangle cannot have a negative size");

            Position = position;
            Size = size;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> struct.
        /// </summary>
        /// <param name="x">The x-coordinate of the upper-left corner of the rectangle.</param>
        /// <param name="y">The y-coordinate of the upper-left corner of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        public Rectangle(int x, int y, int width, int height)
            : this(new Point(x, y), new Size(width, height))
        {
        }

        public static bool operator ==(Rectangle a, Rectangle b) => a.Equals(b);
        public static bool operator !=(Rectangle a, Rectangle b) => !a.Equals(b);

        public static implicit operator SixLaborsRectangle(Rectangle rect)
        {
            return new SixLaborsRectangle(rect.X, rect.Y, rect.Width, rect.Height);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if(obj is null)
                return false;

            if(!(obj is Rectangle))
                return false;

            return Equals((Rectangle)obj);
        }

        /// <summary>
        /// Determines whether the specified rectangle is equal to the current rectangle.
        /// </summary>
        /// <param name="rect">The rectangle to compare against.</param>
        public bool Equals(Rectangle rect)
        {
            return rect.Position == Position && rect.Size == Size;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Position.X, Position.Y, Size.Width, Size.Height);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{{{Position.X}, {Position.Y}, {Width}, {Height}}}";
        }
    }
}
