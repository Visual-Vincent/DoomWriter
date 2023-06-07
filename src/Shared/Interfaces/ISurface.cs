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

        /// <summary>
        /// Draws a portion of an image onto the surface.
        /// </summary>
        /// <param name="image">The image to draw.</param>
        /// <param name="x">The x-coordinate of the upper-left corner of the drawn image.</param>
        /// <param name="y">The y-coordinate of the upper-left corner of the drawn image.</param>
        /// <param name="srcRect">The portion of the specified image to draw.</param>
        void DrawImage(TImage image, int x, int y, Rectangle srcRect);

        /// <summary>
        /// Draws a portion of an image onto the surface, applying the specified color translation in the process.
        /// </summary>
        /// <param name="image">The image to draw.</param>
        /// <param name="x">The x-coordinate of the upper-left corner of the drawn image.</param>
        /// <param name="y">The y-coordinate of the upper-left corner of the drawn image.</param>
        /// <param name="srcRect">The portion of the specified image to draw.</param>
        /// <param name="translation">The color translation to apply when drawing.</param>
        void DrawImage(TImage image, int x, int y, Rectangle srcRect, ColorTranslation translation);
    }
}
