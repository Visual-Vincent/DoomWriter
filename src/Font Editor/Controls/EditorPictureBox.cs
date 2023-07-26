using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FontEditor
{
    /// <summary>
    /// Represents a control for displaying and manipulating a font base image.
    /// </summary>
    public class EditorPictureBox : ZoomablePictureBox
    {
        private static readonly Cursor HandOpen     = CursorHelper.FromByteArray(Properties.Resources.CursorHandOpen);
        private static readonly Cursor HandGrabbing = CursorHelper.FromByteArray(Properties.Resources.CursorHandGrabbing);

        private static readonly Pen   SelectionPen   = new Pen(Color.Black, 1.0f) { DashStyle = DashStyle.Dash };
        private static readonly Brush SelectionBrush = new SolidBrush(Color.FromArgb(127, 118, 184, 242));

        private EditMode editMode;

        private bool selecting = false;
        private Point clickPosition;
        private Rectangle selectionRectangle;

        /// <summary>
        /// Occurs when the user has begun panning the control.
        /// </summary>
        [Description("Occurs when the user has begun panning the control.")]
        public event EventHandler<PanEventArgs> BeginPan;

        /// <summary>
        /// Occurs when the user has begun a character selection in the control.
        /// </summary>
        [Description("Occurs when the user has begun a character selection in the control.")]
        public event EventHandler BeginSelection;

        /// <summary>
        /// Occurs when the edit mode has changed.
        /// </summary>
        [Description("Occurs when the edit mode has changed.")]
        public event EventHandler EditModeChanged;

        /// <summary>
        /// Occurs when the user has stopped panning the control.
        /// </summary>
        [Description("Occurs when the user has stopped panning the control.")]
        public event EventHandler<PanEventArgs> EndPan;

        /// <summary>
        /// Occurs when the user has finished the character selection.
        /// </summary>
        [Description("Occurs when the user has finished the character selection.")]
        public event EventHandler<SelectionEventArgs> EndSelection;

        /// <summary>
        /// Occurs when the user is currently panning the control by moving their mouse.
        /// </summary>
        [Description("Occurs when the user is currently panning the control by moving their mouse.")]
        public event EventHandler<PanEventArgs> Panning;

        /// <summary>
        /// Occurs when the character selection rectangle has changed.
        /// </summary>
        [Description("Occurs when the character selection rectangle has changed.")]
        public event EventHandler<SelectionEventArgs> SelectionChanged;

        /// <summary>
        /// Gets or sets the current edit mode of the control.
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public EditMode EditMode
        {
            get {
                return editMode;
            }
            set {
                if(editMode == value)
                    return;

                editMode = value;

                if(!Enum.IsDefined(typeof(EditMode), editMode))
                    editMode = EditMode.Pan;

                Cursor = editMode.IsPannable()
                    ? HandOpen
                    : Cursors.Default;

                if(editMode == EditMode.CharacterSelect)
                    Cursor = Cursors.Cross;

                EditModeChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets whether or not the user is currently selecting a character.
        /// </summary>
        public bool IsSelecting => editMode == EditMode.CharacterSelect && selecting;

        /// <summary>
        /// Cancels the currently active character selection.
        /// </summary>
        public void CancelSelection()
        {
            if(!IsSelecting)
                return;

            selecting = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Middle || (e.Button == MouseButtons.Left && editMode.IsPannable()))
            {
                if(editMode.IsPannable())
                    Cursor = HandGrabbing;

                clickPosition = e.Location;
                BeginPan?.Invoke(this, new PanEventArgs(e.Location, clickPosition));
            }
            else if(editMode == EditMode.CharacterSelect && e.Button == MouseButtons.Left)
            {
                selecting = true;
                clickPosition = e.Location;
                BeginSelection?.Invoke(this, EventArgs.Empty);
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Middle || (e.Button == MouseButtons.Left && editMode.IsPannable()))
            {
                Panning?.Invoke(this, new PanEventArgs(e.Location, clickPosition));
            }
            else if(editMode == EditMode.CharacterSelect && selecting)
            {
                double zoomLevel = Zoom;

                Point point = new Point(
                    (int)(Math.Floor(e.X / zoomLevel) * zoomLevel),
                    (int)(Math.Floor(e.Y / zoomLevel) * zoomLevel)
                );

                Point clickPoint = new Point(
                    (int)(Math.Floor(clickPosition.X / zoomLevel) * zoomLevel),
                    (int)(Math.Floor(clickPosition.Y / zoomLevel) * zoomLevel)
                );

                int x = clickPoint.X <= point.X ? clickPoint.X : point.X;
                int y = clickPoint.Y <= point.Y ? clickPoint.Y : point.Y;
                int w = clickPoint.X <= point.X ? point.X - clickPoint.X : clickPoint.X - point.X;
                int h = clickPoint.Y <= point.Y ? point.Y - clickPoint.Y : clickPoint.Y - point.Y;

                x = (int)Math.Round(x / zoomLevel);
                y = (int)Math.Round(y / zoomLevel);
                w = (int)Math.Round(w / zoomLevel) + 1;
                h = (int)Math.Round(h / zoomLevel) + 1;

                selectionRectangle = new Rectangle(x, y, w, h);
                Invalidate();

                SelectionChanged?.Invoke(this, new SelectionEventArgs(selectionRectangle));
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if(editMode.IsPannable())
            {
                Cursor = HandOpen;
                EndPan?.Invoke(this, new PanEventArgs(e.Location, clickPosition));
            }

            switch(editMode)
            {
                case EditMode.CharacterSelect:
                    if(e.Button != MouseButtons.Left || !selecting)
                        break;

                    var rect = selectionRectangle.Clamp(new Rectangle(Point.Empty, Image.Size));

                    selecting = false;
                    selectionRectangle = Rectangle.Empty;
                    Invalidate();

                    EndSelection?.Invoke(this, new SelectionEventArgs(rect));
                    break;
            }

            base.OnMouseUp(e);
        }

        protected override void OnPaintInternal(PaintEventArgs e)
        {
            base.OnPaintInternal(e);

            if(selecting)
            {
                var zoomLevel = (float)Zoom;

                e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
                e.Graphics.FillRectangle(SelectionBrush,
                    zoomLevel * selectionRectangle.X + 0.5f,
                    zoomLevel * selectionRectangle.Y + 0.5f,
                    zoomLevel * selectionRectangle.Width - 0.5f,
                    zoomLevel * selectionRectangle.Height - 0.5f
                );
                e.Graphics.DrawRectangle(SelectionPen,
                    zoomLevel * selectionRectangle.X + 0.5f,
                    zoomLevel * selectionRectangle.Y + 0.5f,
                    zoomLevel * selectionRectangle.Width - 0.5f,
                    zoomLevel * selectionRectangle.Height - 0.5f
                );
            }
        }
    }
}
