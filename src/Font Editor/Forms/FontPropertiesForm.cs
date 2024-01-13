using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoomWriter;
using TextRenderer = DoomWriter.TextRenderer;

#pragma warning disable IDE0003 // Remove 'this'

namespace FontEditor.Forms
{
    public partial class FontPropertiesForm : Form
    {
        private MutableFont editedFont;
        private MutableFont previewFont;
        private bool unsavedChanges = false;
        private bool isUpdatingFont = false;

        private readonly object previewLockObj = new object();

        private Task<Image> renderTask = Task.FromResult<Image>(null);
        private Func<Task<Image>> reRenderTask;
        private TextRenderer renderer = new TextRenderer();

        /// <summary>
        /// Occurs when the user makes changes and saves them.
        /// </summary>
        [Browsable(false)]
        public event EventHandler SavedChanges;

        /// <summary>
        /// Gets or sets the font whose properties are edited by the form.
        /// </summary>
        public MutableFont EditedFont
        {
            get {
                return editedFont;
            }
            set {
                if(editedFont == value)
                    return;

                isUpdatingFont = true;
                editedFont = value;

                if(previewFont != null)
                {
                    previewFont.Image = null; // previewFont.Image points to editedFont.Image. Do not dispose.
                    previewFont.Dispose();
                }

                previewFont = new MutableFont(editedFont);
                previewFont.Image?.Dispose();
                previewFont.Image = editedFont.Image;

                KerningDataGridView.Rows.Clear();

                LetterSpacingNumericUpDown.Value = editedFont?.LetterSpacing ?? 0;
                SpaceWidthNumericUpDown.Value = editedFont?.SpaceWidth ?? 0;
                TabWidthNumericUpDown.Value = editedFont?.TabWidth ?? 0;
                LineHeightNumericUpDown.Value = editedFont?.LineHeight ?? 0;
                EmptyLineHeightNumericUpDown.Value = editedFont?.EmptyLineHeight ?? 0;

                if(editedFont != null)
                {
                    foreach(var pair in editedFont.KernTable.OrderBy(p => p.Left).ThenBy(p => p.Right))
                    {
                        KerningDataGridView.Rows.Add(pair.Left.ToString(), pair.Right.ToString(), pair.Kerning);
                    }
                }

                UnsavedChanges = false;
                isUpdatingFont = false;
            }
        }

        /// <summary>
        /// Gets whether or not the form has unsaved changes.
        /// </summary>
        public bool UnsavedChanges
        {
            get {
                return unsavedChanges;
            }
            private set {
                if(unsavedChanges == value)
                    return;

                unsavedChanges = value;
                ApplyButton.Enabled = unsavedChanges;

                this.Text = this.Text.TrimEnd('*') + (unsavedChanges ? "*" : "");
            }
        }

        public FontPropertiesForm()
        {
            InitializeComponent();
        }

        private System.Drawing.Image ConvertDWImage(Image image)
        {
            System.Drawing.Image result = null;

            try
            {
                result = new System.Drawing.Bitmap(image.Width, image.Height);

                using(var memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, ImageFormat.PNG);
                    memoryStream.Position = 0;

                    using(var img = System.Drawing.Image.FromStream(memoryStream))
                    using(var g = System.Drawing.Graphics.FromImage(result))
                    {
                        g.DrawImage(img, new System.Drawing.Rectangle(System.Drawing.Point.Empty, img.Size));
                        return result;
                    }
                }
            }
            catch
            {
                result?.Dispose();
                throw;
            }
        }

        private void SaveChanges()
        {
            if(editedFont == null)
                return;

            editedFont.LetterSpacing = (short)LetterSpacingNumericUpDown.Value;
            editedFont.SpaceWidth = (ushort)SpaceWidthNumericUpDown.Value;
            editedFont.TabWidth = (byte)TabWidthNumericUpDown.Value;
            editedFont.LineHeight = (short)LineHeightNumericUpDown.Value;
            editedFont.EmptyLineHeight = (int)EmptyLineHeightNumericUpDown.Value;

            var pairs = new List<KerningPair>();

            for(int i = 0; i < KerningDataGridView.Rows.Count; i++)
            {
                var row = KerningDataGridView.Rows[i];

                if(row.IsNewRow)
                    continue;

                var leftValue = row.Cells[LeftCharColumn.Index].Value?.ToString();
                var rightValue = row.Cells[RightCharColumn.Index].Value?.ToString();
                var kerningValue = row.Cells[KerningColumn.Index].Value?.ToString();

                if(leftValue == null || leftValue.Length != 1 || char.IsWhiteSpace(leftValue[0]) ||
                   rightValue == null || rightValue.Length != 1 || char.IsWhiteSpace(rightValue[0]) ||
                   kerningValue == null || !int.TryParse(kerningValue, out var kerning))
                    continue;

                pairs.Add(new KerningPair(leftValue[0], rightValue[0], kerning));
            }

            editedFont.KernTable.Clear();

            foreach(var pair in pairs.OrderBy(p => p.Left).ThenBy(p => p.Right))
            {
                editedFont.KernTable[pair.Key] = pair.Kerning;
            }

            UnsavedChanges = false;
            SavedChanges?.Invoke(this, EventArgs.Empty);
        }

        private async Task UpdateMetricsPreview()
        {
            const string text = "The quick brown fox jumps over the lazy dog.\n\tThis line starts with a tab character.\n\nTHIS IS THE FOURTH LINE.";

            Image image = null;

            lock(previewLockObj)
            {
                if(!renderTask.IsCompleted)
                {
                    reRenderTask = async () => await renderer.RenderAsync(text, previewFont);
                    return;
                }

                renderTask = Task.Run(async () => await renderer.RenderAsync(text, previewFont));
            }

            while(true)
            {
                try
                {
                    image = await renderTask;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Failed to update preview:" + Environment.NewLine + Environment.NewLine + ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MetricsPreviewErrorLabel.Text = "An error occured while updating the preview.";
                    MetricsPreviewErrorLabel.Show();
                    goto complete;
                }

                lock(previewLockObj)
                {
                    if(reRenderTask == null)
                        break;

                    image?.Dispose();

                    renderTask = Task.Run(reRenderTask);
                    reRenderTask = null;
                }
            }

        complete:
            MetricsPreviewPictureBox.Image?.Dispose();
            MetricsPreviewPictureBox.Image = image != null ? ConvertDWImage(image) : null;

            if(image != null)
                MetricsPreviewErrorLabel.Hide();

            image?.Dispose();
        }

        private async Task UpdateKerningPreview(char leftCharacter, char rightCharacter)
        {
            string text = $"{leftCharacter}{rightCharacter}";

            Image image = null;

            lock(previewLockObj)
            {
                if(!renderTask.IsCompleted)
                {
                    reRenderTask = async () => await renderer.RenderAsync(text, previewFont);
                    return;
                }

                renderTask = Task.Run(async () => await renderer.RenderAsync(text, previewFont));
            }

            while(true)
            {
                try
                {
                    image = await renderTask;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Failed to update preview:" + Environment.NewLine + Environment.NewLine + ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    KerningPreviewErrorLabel.Text = "An error occured while updating the preview.";
                    KerningPreviewErrorLabel.Show();
                    goto complete;
                }

                lock(previewLockObj)
                {
                    if(reRenderTask == null)
                        break;

                    image?.Dispose();

                    renderTask = Task.Run(reRenderTask);
                    reRenderTask = null;
                }
            }

        complete:
            KerningPreviewPictureBox.Image?.Dispose();
            KerningPreviewPictureBox.Image = image != null ? ConvertDWImage(image) : null;

            if(image != null)
                KerningPreviewErrorLabel.Hide();

            image?.Dispose();
        }

        private async void FontPropertiesForm_Load(object sender, EventArgs e)
        {
            await UpdateMetricsPreview();
        }

        private void FontPropertiesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult == DialogResult.None)
                this.DialogResult = DialogResult.Cancel;

            if(UnsavedChanges)
            {
                if(this.DialogResult == DialogResult.OK)
                {
                    SaveChanges();
                }
                else if(MessageBox.Show("Are you sure you want to close the properties dialog?" + Environment.NewLine + "All unsaved changes will be lost!", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.None;
                    e.Cancel = true;
                    return;
                }
            }

            if(!renderTask.IsCompleted)
                renderTask.Wait(2000);

            renderer.Dispose();
            renderer = null;

            if(previewFont != null)
            {
                previewFont.Image = null; // previewFont.Image points to editedFont.Image. Do not dispose.
                previewFont.Dispose();
            }

            MetricsPreviewPictureBox.Image?.Dispose();
            MetricsPreviewPictureBox.Image = null;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void KerningDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var cell = KerningDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if(cell.Value == null)
                return;

            if(e.ColumnIndex == KerningColumn.Index)
            {
                if(cell.Value is int || cell.Value is uint ||
                   cell.Value is byte || cell.Value is sbyte ||
                   cell.Value is short || cell.Value is ushort ||
                   cell.Value is long || cell.Value is ulong)
                    return;

                if(!int.TryParse(cell.Value.ToString(), out _))
                {
                    MessageBox.Show("Invalid value", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cell.Value = null;
                }

                return;
            }

            if(cell.Value == null || (cell.Value is string str && (str.Length == 0 || !char.IsWhiteSpace(str[0]))))
                goto sort;

            if(cell.Value is char c && !char.IsWhiteSpace(c))
            {
                cell.Value = cell.Value.ToString();
                goto sort;
            }

            MessageBox.Show("Invalid value", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            cell.Value = null;

        sort:
            this.BeginInvoke((Action)(() => KerningDataGridView.Sort(KerningDataGridView.Columns[0], ListSortDirection.Ascending)));
        }

        private void KerningDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(isUpdatingFont)
                return;

            UnsavedChanges = true;

            KerningDataGridView_SelectionChanged(sender, e);
        }

        private void KerningDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UnsavedChanges = true;
        }

        private async void KerningDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if(isUpdatingFont)
                return;

            if(KerningDataGridView.SelectedRows.Count <= 0)
                goto noPreview;

            var selectedRow = KerningDataGridView.SelectedRows[0];

            if(selectedRow.Cells.Count < 3)
                goto noPreview;

            var leftCharValue = selectedRow.Cells[0].Value?.ToString();
            var rightCharValue = selectedRow.Cells[1].Value?.ToString();
            var kerningValue = selectedRow.Cells[2].Value?.ToString();

            if(string.IsNullOrEmpty(leftCharValue) || string.IsNullOrEmpty(rightCharValue))
                goto noPreview;

            var leftChar = leftCharValue[0];
            var rightChar = rightCharValue[0];

            if(!int.TryParse(kerningValue, out var kerning))
                goto noPreview;

            previewFont.KernTable[leftChar, rightChar] = kerning;

            await UpdateKerningPreview(leftChar, rightChar);

            if(e is DataGridViewCellEventArgs)
                await UpdateMetricsPreview();

            return;

        noPreview:
            KerningPreviewErrorLabel.Show();
            KerningPreviewErrorLabel.Text = "Please select a kerning pair";
        }

        private async void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if(isUpdatingFont)
                return;

            UnsavedChanges = true;

            previewFont.LetterSpacing = (short)LetterSpacingNumericUpDown.Value;
            previewFont.SpaceWidth = (ushort)SpaceWidthNumericUpDown.Value;
            previewFont.TabWidth = (byte)TabWidthNumericUpDown.Value;
            previewFont.LineHeight = (short)LineHeightNumericUpDown.Value;
            previewFont.EmptyLineHeight = (int)EmptyLineHeightNumericUpDown.Value;

            await UpdateMetricsPreview();
        }
    }
}

#pragma warning restore IDE0003 // Remove 'this'
