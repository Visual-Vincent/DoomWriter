using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FontEditor
{
    /// <summary>
    /// Represents a control for displaying a color palette.
    /// </summary>
    public partial class PaletteViewer : UserControl
    {
        private List<Color> colors;

        /// <summary>
        /// Occurs when a color is clicked in the palette.
        /// </summary>
        public event EventHandler<Color> ColorClicked;

        /// <summary>
        /// Gets the colors of the palette.
        /// </summary>
        public IEnumerable<Color> Colors => colors;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="PaletteViewer"/> class.
        /// </summary>
        public PaletteViewer()
        {
            InitializeComponent();
            ColorLabel.Text = $"{Environment.NewLine}{Environment.NewLine}";
        }

        private static double Luminance(Color color)
        {
            return color.R * 0.299 + color.G * 0.587 + color.B * 0.114;
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            if(!(sender is Control control) || control.Tag == null || !(control.Tag is Color color))
                return;

            ColorClicked?.Invoke(this, color);
        }

        private void ColorButton_MouseEnter(object sender, EventArgs e)
        {
            if(!(sender is Control control) || control.Tag == null || !(control.Tag is Color color))
                return;

            ColorLabel.Text = 
                $"RGBA: ({color.R}, {color.G}, {color.B}, {color.A})" + Environment.NewLine +
                $"Hex: #{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        private void ColorButton_MouseLeave(object sender, EventArgs e)
        {
            ColorLabel.Text = "\n\n";
        }

        /// <summary>
        /// Displays a new palette in the control.
        /// </summary>
        /// <param name="colors">The colors of the palette. Null clears current the palette.</param>
        /// <param name="sort">Optional. Whether or not the colors will be sorted by their luminance values.</param>
        public void SetPalette(IEnumerable<Color> colors, bool sort = true)
        {
            if(colors != null)
            {
                this.colors = new List<Color>(colors);

                if(sort)
                    this.colors.Sort((a, b) => Luminance(a).CompareTo(Luminance(b)));
            }
            else
            {
                this.colors = null;
            }

            MainFlowLayoutPanel.SuspendLayout();

            foreach(Control control in MainFlowLayoutPanel.Controls)
            {
                control.Click -= ColorButton_Click;
                control.MouseEnter -= ColorButton_MouseEnter;
                control.MouseLeave -= ColorButton_MouseLeave;
                control.Dispose();
            }

            MainFlowLayoutPanel.Controls.Clear();

            int count = 0;

            foreach(Color color in this.colors ?? Enumerable.Empty<Color>())
            {
                var button = new Button() {
                    Text = "",
                    BackColor = color,
                    FlatStyle = FlatStyle.Popup,
                    Margin = new Padding(1),
                    Size = new Size(16, 16),
                    Tag = color
                };

                button.Click += ColorButton_Click;
                button.MouseEnter += ColorButton_MouseEnter;
                button.MouseLeave += ColorButton_MouseLeave;

                MainFlowLayoutPanel.Controls.Add(button);
                count++;

                if(count >= 512)
                    break;
            }

            InfoLabel.Text = $"{this.colors?.Count ?? 0} colors";

            if(this.colors != null && this.colors.Count > count)
                InfoLabel.Text += " (capped at 512)";

            MainFlowLayoutPanel.ResumeLayout();
        }
    }
}
