using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FontEditor
{
    /// <summary>
    /// Represents a control for displaying an image with zoom capabilities.
    /// </summary>
    public class ZoomablePictureBox : Control
    {
        public const double MinZoom = 0.1;
        public const double MaxZoom = 16.0;

        private static readonly Pen DesignerPen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1.0f) { DashStyle = DashStyle.Dash };

        private Image image;
        private double zoom = 1.0f;

        /// <summary>
        /// Occurs when the image displayed in the picture box has been changed.
        /// </summary>
        [Description("Occurs when the image displayed in the picture box has been changed.")]
        public event EventHandler ImageChanged;

        /// <summary>
        /// Occurs when the zoom level of the picture box has been changed.
        /// </summary>
        [Description("Occurs when the zoom level of the picture box has been changed.")]
        public event EventHandler ZoomChanged;

        /// <summary>
        /// Gets or sets the image that is displayed by the <see cref="ZoomablePictureBox"/>.
        /// </summary>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("The image that is displayed by the " + nameof(ZoomablePictureBox) + ".")]
        [DefaultValue((object)null)]
        [RefreshProperties(RefreshProperties.All)]
        public Image Image
        {
            get {
                return image;
            }
            set {
                if(image == value)
                    return;

                image = value;
                InvalidateSize();

                ImageChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the image zoom factor.
        /// </summary>
        [Browsable(true)]
        [Category("Appearance")]
        [Description("The image zoom factor")]
        [DefaultValue(1.0)]
        [RefreshProperties(RefreshProperties.All)]
        public double Zoom
        {
            get {
                return zoom;
            }
            set {
                if(zoom == value)
                    return;

                zoom = value;

                if(zoom < MinZoom)
                    zoom = MinZoom;
                else if(zoom > MaxZoom)
                    zoom = MaxZoom;

                InvalidateSize();

                ZoomChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Bindable(false)]
        public override string Text
        {
            get {
                return base.Text;
            }
            set {
                base.Text = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZoomablePictureBox"/> class.
        /// </summary>
        public ZoomablePictureBox()
        {
            DoubleBuffered = true;
        }

        protected void InvalidateSize()
        {
            if(image == null)
                return;

            SetBoundsCore(Location.X, Location.Y, Width, Height, BoundsSpecified.Size);
            Refresh();
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            if(image == null)
                return new Size(16, 16);

            if(zoom != 1.0)
                return new Size((int)Math.Ceiling(image.Width * zoom), (int)Math.Ceiling(image.Height * zoom)).NotZero();
            else
                return image.Size;
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            if(!specified.HasFlag(BoundsSpecified.Width) && !specified.HasFlag(BoundsSpecified.Height))
            {
                base.SetBoundsCore(x, y, width, height, specified);
                return;
            }

            var size = GetPreferredSize(Size.Empty);

            if(specified.HasFlag(BoundsSpecified.Width))
                width = size.Width;

            if(specified.HasFlag(BoundsSpecified.Height))
                height = size.Height;

            base.SetBoundsCore(x, y, width, height, specified);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if(image != null)
            {
                var size = GetPreferredSize(Size.Empty);

                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
                e.Graphics.DrawImage(image, new Rectangle(Point.Empty, size), new Rectangle(Point.Empty, image.Size), GraphicsUnit.Pixel);
            }

            if(DesignMode)
            {
                if(image != null)
                    e.Graphics.DrawRectangle(DesignerPen, 1, 1, Width - 1, Height - 1);
                else
                    e.Graphics.DrawRectangle(DesignerPen, 0, 0, Width - 1, Height - 1);
            }

            base.OnPaint(e);
        }
    }
}
