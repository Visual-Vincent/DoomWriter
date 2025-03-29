using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using SixLabors.ImageSharp.PixelFormats;
using GdiSize = System.Drawing.Size;

namespace DoomWriter.GUI.Controls
{
    /// <summary>
    /// Represents a control that edits a text color translation.
    /// </summary>
    public partial class TextColorEditor : UserControl
    {
        /// <summary>
        /// Gets or sets the name of the edited color translation.
        /// </summary>
        public string ColorName
        {
            get {
                return NameTextBox.Text ?? "";
            }
            set {
                NameTextBox.Text = value ?? "";
            }
        }

        /// <summary>
        /// Gets or sets the color translation edited by the control.
        /// </summary>
        [Browsable(false)]
        public ColorTranslation EditedTranslation
        {
            get {
                var translation = new ColorTranslation();

                foreach (var rangeControl in RangesPanel.Controls.OfType<ColorRangeEditor>())
                {
                    translation.Add(rangeControl.EditedRange);
                }

                return translation;
            }
            set {
                try
                {
                    RangesPanel.SuspendLayout();

                    if(value == null || value.IsUntranslated)
                    {
                        RangesPanel.Controls.Clear();
                        return;
                    }

                    foreach (var range in value.Ranges)
                    {
                        AddColorRange(range);
                    }
                }
                finally
                {
                    RangesPanel.ResumeLayout(true);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextColorEditor"/> class.
        /// </summary>
        public TextColorEditor()
        {
            InitializeComponent();
        }

        private void AddColorRange(TranslationRange range)
        {
            if(range == null)
                throw new ArgumentNullException(nameof(range));

            var rangeEditor = new ColorRangeEditor() {
                EditedRange = range
            };

            var removeButton = new Button() {
                AutoSize = true,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left,
                Image = Properties.Resources.Remove,
                Margin = new Padding(0, 2, 2, 2),
                Size = new GdiSize(1, 1),
            };

            var table = new TableLayoutPanel {
                AutoSize = true,
                Dock = DockStyle.Top,
                RowCount = 1,
                ColumnCount = 2,
                Margin = new Padding(0)
            };

            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

            table.Controls.Add(rangeEditor, 0, 0);
            table.Controls.Add(removeButton, 1, 0);

            removeButton.Click += (bsender, be) => {
                RangesPanel.Controls.Remove(table);

                removeButton.Dispose();
                rangeEditor.Dispose();
                table.Dispose();
            };

            RangesPanel.Controls.Add(table);
        }

        private void EditCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            NameTextBox.Visible = EditCheckBox.Checked;
            RangesPanel.Visible = EditCheckBox.Checked;
            AddButton.Visible = EditCheckBox.Checked;
            RangesPanel.BringToFront();
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(NameTextBox.Text))
                EditCheckBox.Text = NameTextBox.Text;
            else
                EditCheckBox.Text = " ";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                RangesPanel.SuspendLayout();
                AddColorRange(new TranslationRange(0, 256, new Rgba32(0, 0, 0, 255), new Rgba32(255, 255, 255, 255)));
            }
            finally
            {
                RangesPanel.ResumeLayout(true);
            }
        }
    }
}
