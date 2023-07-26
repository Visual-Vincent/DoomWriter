using System;
using System.Drawing;

namespace FontEditor
{
    /// <summary>
    /// Provides data for the <see cref="EditorPictureBox.BeginPan"/>, <see cref="EditorPictureBox.Panning"/> and <see cref="EditorPictureBox.EndPan"/> events.
    /// </summary>
    public class PanEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the mouse location of the event.
        /// <list type="bullet">
        ///     <item>For <see cref="EditorPictureBox.BeginPan"/>, this is the same as <see cref="StartLocation"/>.</item>
        ///     <item>For <see cref="EditorPictureBox.Panning"/>, this is the current location of the mouse.</item>
        ///     <item>For <see cref="EditorPictureBox.EndPan"/>, this is the location where the mouse was released.</item>
        /// </list>
        /// </summary>
        public Point Location { get; }

        /// <summary>
        /// Gets the location where the mouse was originally clicked in the <see cref="EditorPictureBox.BeginPan"/> event.
        /// </summary>
        public Point StartLocation { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PanEventArgs"/> class.
        /// </summary>
        /// <param name="location">The mouse location of the event.</param>
        /// <param name="startLocation">The location where the mouse was originally clicked in the <see cref="EditorPictureBox.BeginPan"/> event.</param>
        public PanEventArgs(Point location, Point startLocation)
        {
            Location = location;
            StartLocation = startLocation;
        }
    }
}
