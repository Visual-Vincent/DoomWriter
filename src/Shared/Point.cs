using System;
using SixLaborsPoint = SixLabors.ImageSharp.Point;

namespace DoomWriter
{
    /// <summary>
    /// Represents an x- and y-coordinate pair in two-dimensional space.
    /// </summary>
    public readonly struct Point
    {
        /// <summary>
        /// Gets a <see cref="Point"/> structure that has an X and Y coordinate of 0.
        /// </summary>
        public static readonly Point Zero = new Point();

        private readonly int x;
        private readonly int y;

        /// <summary>
        /// Gets the x-coordinate of this <see cref="Point"/>.
        /// </summary>
        public int X => x;

        /// <summary>
        /// Gets the y-coordinate of this <see cref="Point"/>.
        /// </summary>
        public int Y => y;

        /// <summary>
        /// Gets whether or not the x and y coordinates are zero.
        /// </summary>
        public bool IsZero => x == 0 || y == 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> struct.
        /// </summary>
        /// <param name="x">The x-coordinate of the new <see cref="Point"/>.</param>
        /// <param name="y">The y-coordinate of the new <see cref="Point"/>.</param>
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static bool operator ==(Point a, Point b) => a.Equals(b);
        public static bool operator !=(Point a, Point b) => !a.Equals(b);

        public static implicit operator SixLaborsPoint(Point point)
        {
            return new SixLaborsPoint(point.X, point.Y);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if(obj == null)
                return false;

            if(!(obj is Point))
                return false;

            return Equals((Point)obj);
        }

        /// <summary>
        /// Determines whether the specified point is equal to the current point.
        /// </summary>
        /// <param name="point">The point to compare against.</param>
        public bool Equals(Point point)
        {
            return point.x == x && point.y == y;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{{{x}, {y}}}";
        }
    }
}
