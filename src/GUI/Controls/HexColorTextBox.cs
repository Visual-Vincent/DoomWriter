using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DoomWriter.GUI.Controls
{
    /// <summary>
    /// Represents a text box control that is only able to take colors formatted in hex as input.
    /// </summary>
    [DefaultEvent(nameof(SelectedColorChanged))]
    public class HexColorTextBox : TextBox
    {
        private static readonly Regex HexRegex = new Regex(@"\A#?[0-9A-F]{6}\z", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

        private string lastValidatedText;
        private Color selectedColor = Color.FromKnownColor(KnownColor.White);

        /// <summary>
        /// Occurs when the color specified in the text box is changed.
        /// </summary>
        [Browsable(true), Description("Occurs when the color specified in the text box is changed.")]
        public event EventHandler SelectedColorChanged;

        /// <inheritdoc/>
        [DefaultValue(7)]
        public override int MaxLength
        {
            get {
                return base.MaxLength;
            }
            set {
                // No-op
            }
        }

        /// <summary>
        /// Gets or sets the color specified in the text box.
        /// </summary>
        [Browsable(true), Description("The color specified in the text box."), DefaultValue(typeof(Color), "0xFFFFFF")]
        public Color SelectedColor
        {
            get {
                return selectedColor;
            }
            set {
                bool isSame = selectedColor == value;

                selectedColor = value;
                base.Text = $"#{value.R:X2}{value.G:X2}{value.B:X2}";

                if(!isSame)
                    OnSelectedColorChanged(EventArgs.Empty);
            }
        }

        /// <inheritdoc/>
        [Browsable(false)]
        public override string Text
        {
            get {
                return base.Text;
            }
            set {
                // No-op
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HexColorTextBox"/> class.
        /// </summary>
        public HexColorTextBox()
            : base()
        {
            base.MaxLength = 7;
            base.Text = lastValidatedText = "#FFFFFF";
            CausesValidation = true;
        }

        /// <summary>
        /// Raises the <see cref="SelectedColorChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected void OnSelectedColorChanged(EventArgs e)
        {
            SelectedColorChanged?.Invoke(this, e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if(e.Handled)
                return;

            if(e.KeyCode == Keys.Escape && e.Modifiers == Keys.None)
            {
                base.Text = lastValidatedText ?? "";
                SelectionStart = Text.Length;
                SelectionLength = 0;

                e.Handled = true;
                e.SuppressKeyPress = true;

                BackColor = Color.FromKnownColor(KnownColor.Window);
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if(e.Handled)
                return;

            bool isHexNum = (e.KeyChar >= '0' && e.KeyChar <= '9')
                || (e.KeyChar >= 'A' && e.KeyChar <= 'F')
                || (e.KeyChar >= 'a' && e.KeyChar <= 'f');

            if(!char.IsControl(e.KeyChar) && e.KeyChar != '#' && !isHexNum)
            {
                e.Handled = true;
            }
            else if(isHexNum && Text != null && !Text.StartsWith("#") && (Text.Length - SelectionLength) >= 6)
            {
                e.Handled = true;
            }

            if(e.KeyChar == '#')
            {
                if(Text != null && Text.StartsWith("#"))
                {
                    if(SelectionStart > 0 || SelectionStart + SelectionLength == 0)
                        e.Handled = true;
                }
                else if(SelectionStart > 0)
                {
                    e.Handled = true;
                }
            }
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            base.OnValidating(e);

            if(string.IsNullOrEmpty(Text))
                SelectedColor = Color.FromKnownColor(KnownColor.White);

            e.Cancel = !HexRegex.IsMatch(Text ?? "");
            BackColor = e.Cancel
                ? Color.FromArgb(255, 128, 128)
                : Color.FromKnownColor(KnownColor.Window);

            if(e.Cancel)
                return;

            if(!Text.StartsWith("#"))
                base.Text = $"#{base.Text}";

            var rgba = ColorTranslator.ColorFromHex(base.Text);
            SelectedColor = Color.FromArgb(rgba.A, rgba.R, rgba.G, rgba.B);

            lastValidatedText = Text;
        }
    }
}
