using System;
using System.IO;
using System.Threading.Tasks;

namespace DoomWriter
{
    /// <summary>
    /// Base class for bitmap text renderers.
    /// </summary>
    public abstract class TextRendererBase
    {
        /// <summary>
        /// Gets the path to where the default font is located.
        /// </summary>
        public static string DefaultFontPath => Path.Combine(AppContext.BaseDirectory, "Default.dwfont");

        /// <summary>
        /// Renders the specified text as an image using the default bitmap font.
        /// </summary>
        /// <param name="text">The text to render.</param>
        public abstract Image Render(string text);

        /// <summary>
        /// Asynchronously renders the specified text as an image using the default bitmap font.
        /// </summary>
        /// <param name="text">The text to render.</param>
        public async Task<Image> RenderAsync(string text)
        {
            return await Task.Run(() => Render(text));
        }

        /// <summary>
        /// Loads the default font.
        /// </summary>
        /// <typeparam name="TFont">The type of font to load.</typeparam>
        public static TFont LoadDefaultFont<TFont>()
            where TFont : FontBase, new()
        {
            return Font.Load<TFont>(DefaultFontPath);
        }
    }
}
