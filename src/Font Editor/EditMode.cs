using System;

namespace FontEditor
{
    public enum EditMode
    {
        Pan = 1,
        CharacterSelect,
        PaletteView
    }

    public static class EditModeExtensions
    {
        /// <summary>
        /// Returns whether the main image view can be panned in the current edit mode.
        /// </summary>
        /// <param name="mode">The mode to check.</param>
        public static bool IsPannable(this EditMode mode)
        {
            return mode == EditMode.Pan || mode == EditMode.PaletteView;
        }
    }
}
