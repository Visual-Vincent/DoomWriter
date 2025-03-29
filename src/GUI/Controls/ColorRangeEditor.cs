using System;
using System.ComponentModel;
using System.Windows.Forms;
using SixLabors.ImageSharp.PixelFormats;
using GdiColor = System.Drawing.Color;

namespace DoomWriter.GUI.Controls
{
    /// <summary>
    /// Represents a control that edits a color range, consisting of a start color, end color, start luminance and end luminance.
    /// </summary>
    public partial class ColorRangeEditor : UserControl
    {
        /// <summary>
        /// Gets or sets the color translation range edited by the control.
        /// </summary>
        [Browsable(false)]
        public TranslationRange EditedRange
        {
            get {
                var fromColor = FromColorTextBox.SelectedColor;
                var toColor = ToColorTextBox.SelectedColor;

                var colorStart = new Rgba32(fromColor.R, fromColor.G, fromColor.B, fromColor.A);
                var colorEnd = new Rgba32(toColor.R, toColor.G, toColor.B, toColor.A);
                var luminanceStart = (ushort)StartNumericUpDown.Value;
                var luminanceEnd = (ushort)EndNumericUpDown.Value;

                return new TranslationRange(luminanceStart, luminanceEnd, colorStart, colorEnd);
            }
            set {
                if(value == null)
                    throw new ArgumentNullException(nameof(value));

                FromColorTextBox.SelectedColor = GdiColor.FromArgb(value.ColorStart.R, value.ColorStart.G, value.ColorStart.B);
                ToColorTextBox.SelectedColor = GdiColor.FromArgb(value.ColorEnd.R, value.ColorEnd.G, value.ColorEnd.B);
                StartNumericUpDown.Value = value.LuminanceStart;
                EndNumericUpDown.Value = value.LuminanceEnd;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorRangeEditor"/> class.
        /// </summary>
        public ColorRangeEditor()
        {
            InitializeComponent();
        }

        private void FromColorTextBox_SelectedColorChanged(object sender, EventArgs e)
        {
            FromColorButton.BackColor = FromColorTextBox.SelectedColor;
        }

        private void ToColorTextBox_SelectedColorChanged(object sender, EventArgs e)
        {
            ToColorButton.BackColor = ToColorTextBox.SelectedColor;
        }

        private void FromColorButton_Click(object sender, EventArgs e)
        {
            MainColorDialog.Color = FromColorButton.BackColor;

            if(MainColorDialog.ShowDialog() != DialogResult.OK)
                return;

            var color = MainColorDialog.Color;

            FromColorButton.BackColor = color;
            FromColorTextBox.SelectedColor = color;
        }

        private void ToColorButton_Click(object sender, EventArgs e)
        {
            MainColorDialog.Color = ToColorButton.BackColor;

            if(MainColorDialog.ShowDialog() != DialogResult.OK)
                return;

            var color = MainColorDialog.Color;

            ToColorButton.BackColor = color;
            ToColorTextBox.SelectedColor = color;
        }

        private void StartNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            EndNumericUpDown.Minimum = StartNumericUpDown.Value;
        }

        private void EndNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            StartNumericUpDown.Maximum = EndNumericUpDown.Value;
        }
    }
}
