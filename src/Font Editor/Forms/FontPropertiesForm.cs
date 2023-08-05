using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DoomWriter;

#pragma warning disable IDE0003 // Remove 'this'

namespace FontEditor.Forms
{
    public partial class FontPropertiesForm : Form
    {
        private MutableFont editedFont;
        private bool unsavedChanges = false;

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

                editedFont = value;

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
                }
            }
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
            UnsavedChanges = true;
        }

        private void KerningDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UnsavedChanges = true;
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            UnsavedChanges = true;
        }
    }
}

#pragma warning restore IDE0003 // Remove 'this'
