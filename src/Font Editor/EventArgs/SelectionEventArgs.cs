using System;
using System.Drawing;

namespace FontEditor
{
    /// <summary>
    /// Provides data for the <see cref="EditorPictureBox.SelectionChanged"/> and <see cref="EditorPictureBox.EndSelection"/> events.
    /// </summary>
    public class SelectionEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the current selection rectangle.
        /// </summary>
        public Rectangle Selection { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectionEventArgs"/> class.
        /// </summary>
        /// <param name="selection">The current selection rectangle.</param>
        public SelectionEventArgs(Rectangle selection)
        {
            Selection = selection;
        }
    }
}
