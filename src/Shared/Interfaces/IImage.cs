using System;

namespace DoomWriter
{
    /// <summary>
    /// Encapsulates properties and methods that describe an image.
    /// </summary>
    public interface IImage
    {
        /// <summary>
        /// Gets the width of the image.
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Gets the width of the image.
        /// </summary>
        int Height { get; }
    }
}
