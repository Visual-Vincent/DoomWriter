using System;
using System.Threading.Tasks;

namespace DoomWriter
{
    /// <summary>
    /// Base class for bitmap text renderers.
    /// </summary>
    public abstract class TextRendererBase
    {
        /// <summary>
        /// Renders the specified text as an image using a bitmap font.
        /// </summary>
        /// <param name="text">The text to render.</param>
        public abstract Image Render(string text);

        /// <summary>
        /// Asynchronously renders the specified text as an image using a bitmap font.
        /// </summary>
        /// <param name="text">The text to render.</param>
        public async Task<Image> RenderAsync(string text)
        {
            return await Task.Run(() => Render(text));
        }
    }
}
