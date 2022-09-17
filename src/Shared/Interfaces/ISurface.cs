using System;

namespace DoomWriter
{
    /// <summary>
    /// Encapsulates properties and methods for a drawable surface.
    /// </summary>
    /// <typeparam name="TImage">The type of image accepted by the surface.</typeparam>
    public interface ISurface<TImage> where TImage : IImage
    {
        /// <summary>
        /// Draws an image onto the surface.
        /// </summary>
        /// <param name="image">The image to draw.</param>
        /// <param name="x">The x-coordinate of the upper-left corner of the drawn image.</param>
        /// <param name="y">The y-coordinate of the upper-left corner of the drawn image.</param>
        void DrawImage(TImage image, int x, int y);
    }
}
