using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

#pragma warning disable IDE0003 // Remove 'this'

namespace FontEditor
{
    public partial class CharacterMappingControl : UserControl
    {
        /// <summary>
        /// Occurs when the selected character mapping changes.
        /// </summary>
        [Description("Occurs when the selected character mapping changes.")]
        public event EventHandler SelectionChanged;

        public CharacterMappingControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the currently edited character.
        /// </summary>
        public char? CurrentCharacter
        {
            get {
                if(this.InvokeRequired)
                    return (char?)this.Invoke((Func<char?>)(() => CurrentCharacter));

                if(CurrentCharacterTextBox.Text.Length <= 0)
                    return null;

                return CurrentCharacterTextBox.Text[0];
            }
            set {
                if(this.InvokeRequired)
                {
                    this.Invoke((Action)(() => CurrentCharacter = value));
                    return;
                }

                CurrentCharacterTextBox.Text = value.ToString();
                CurrentCharacterTextBox.SelectionStart = CurrentCharacterTextBox.Text.Length;
                CurrentCharacterTextBox.SelectionLength = 0;
            }
        }

        /// <summary>
        /// Gets the bounds of the currently selected character mapping, if any.
        /// </summary>
        public Rectangle? SelectedCharacterMapping
        {
            get {
                if(MappingsDataGridView.SelectedRows.Count <= 0)
                    return null;

                var row = MappingsDataGridView.SelectedRows[0];
                var xVal = row.Cells[1].Value?.ToString();
                var yVal = row.Cells[2].Value?.ToString();
                var wVal = row.Cells[3].Value?.ToString();
                var hVal = row.Cells[4].Value?.ToString();

                if(xVal == null || yVal == null || wVal == null || hVal == null)
                    return null;

                if(!int.TryParse(xVal, out var x) || !int.TryParse(yVal, out var y) ||
                   !int.TryParse(wVal, out var w) || !int.TryParse(hVal, out var h))
                    return null;

                if(x < 0 || y < 0 || w < 0 || h < 0)
                    return null;

                return new Rectangle(x, y, w, h);
            }
        }

        /// <summary>
        /// Gets the descender of the currently selected character mapping, if any.
        /// </summary>
        public int? SelectedCharacterMappingDescender
        {
            get {
                if(MappingsDataGridView.SelectedRows.Count <= 0)
                    return null;

                var row = MappingsDataGridView.SelectedRows[0];
                var value = row.Cells[5].Value?.ToString();

                if(value == null)
                    return 0;

                if(!int.TryParse(value, out var descender))
                    return 0;

                if(descender < 0)
                    return 0;

                return descender;
            }
        }

        /// <summary>
        /// Sets the bounds of the current character.
        /// </summary>
        /// <param name="bounds">The bounds of the character.</param>
        /// <param name="advance">Whether or not to advance to the next character.</param>
        public void SetCurrentCharacterBounds(Rectangle bounds, bool advance)
        {
            if(this.InvokeRequired)
            {
                this.Invoke((Action)(() => SetCurrentCharacterBounds(bounds, advance)));
                return;
            }

            var c = CurrentCharacter;
            if(!c.HasValue)
                return;

            var row = MappingsDataGridView.SelectedRows.Count > 0
                ? MappingsDataGridView.SelectedRows[0]
                : null;

            bool hasChar = 
                row != null &&
                row.Cells[0].Value != null && 
                (!(row.Cells[0].Value is string selectedValue) || !string.IsNullOrWhiteSpace(selectedValue));

            if(row == null || row.IsNewRow || hasChar)
            {
                row = MappingsDataGridView.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => {
                    return r.Cells[0].Value is string value && value != null && (value == c.Value.ToString() || string.IsNullOrWhiteSpace(value));
                });
            }

            if(row != null)
            {
                row.Cells[0].Value = CurrentCharacter.ToString();
                row.Cells[1].Value = bounds.X;
                row.Cells[2].Value = bounds.Y;
                row.Cells[3].Value = bounds.Width;
                row.Cells[4].Value = bounds.Height;
                row.Cells[5].Value = row.Cells[5].Value ?? 0;
            }
            else
            {
                int index = MappingsDataGridView.Rows.Add(CurrentCharacter.ToString(), bounds.X, bounds.Y, bounds.Width, bounds.Height, 0);
                row = MappingsDataGridView.Rows[index];
            }

            if(advance)
            {
                if(row.Index + 1 <= MappingsDataGridView.Rows.Count - 1)
                    MappingsDataGridView.Rows[row.Index + 1].Selected = true;

                MappingsDataGridView.Sort(MappingsDataGridView.Columns[0], ListSortDirection.Ascending);
                MappingsDataGridView_SelectionChanged(MappingsDataGridView, EventArgs.Empty);
            }

            // Handled by SelectionChanged event
            /*if(advance && CurrentCharacter.Value < char.MaxValue)
                CurrentCharacter = (char)(CurrentCharacter.Value + 1);*/

            CurrentCharacterTextBox.Focus();
        }

        private void CurrentCharacterTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsControl(e.KeyChar))
                return;

            if(char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            CurrentCharacter = e.KeyChar;
            e.Handled = true;
        }

        private void CurrentCharacterTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            DataGridViewRow selectedRow;

            switch(e.KeyCode)
            {
                case Keys.Down:
                    e.SuppressKeyPress = true;
                    e.Handled = true;

                    if(MappingsDataGridView.SelectedRows.Count <= 0)
                        break;

                    selectedRow = MappingsDataGridView.SelectedRows[0];

                    if(selectedRow.Index >= MappingsDataGridView.Rows.Count - 1)
                        break;

                    MappingsDataGridView.Rows[selectedRow.Index + 1].Selected = true;
                    break;

                case Keys.Up:
                    e.SuppressKeyPress = true;
                    e.Handled = true;

                    if(MappingsDataGridView.SelectedRows.Count <= 0)
                        break;

                    selectedRow = MappingsDataGridView.SelectedRows[0];

                    if(selectedRow.Index <= 0)
                        break;

                    MappingsDataGridView.Rows[selectedRow.Index - 1].Selected = true;
                    break;

                case Keys.Delete:
                    e.SuppressKeyPress = true;
                    e.Handled = true;

                    if(MappingsDataGridView.SelectedRows.Count <= 0)
                        break;

                    selectedRow = MappingsDataGridView.SelectedRows[0];

                    if(selectedRow.IsNewRow)
                        break;

                    MappingsDataGridView.Rows.RemoveAt(selectedRow.Index);
                    break;
            }
        }

        private void MappingsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            SelectionChanged?.Invoke(this, EventArgs.Empty);

            if(MappingsDataGridView.SelectedRows.Count <= 0)
                return;

            var selectedRow = MappingsDataGridView.SelectedRows[0];
            var value = selectedRow.Cells[0].Value as string;

            if(!string.IsNullOrWhiteSpace(value))
            {
                CurrentCharacter = value[0];
                return;
            }
            
            // If empty row selected, advance from previous character
            if(selectedRow.Index <= 0)
                return;

            value = MappingsDataGridView.Rows[selectedRow.Index - 1].Cells[0].Value as string;

            if(string.IsNullOrWhiteSpace(value) || value[0] >= char.MaxValue)
                return;

            CurrentCharacter = (char)(value[0] + 1);
        }

        private void MappingsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var cell = MappingsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if(cell.Value == null)
                return;

            if(e.ColumnIndex == 0)
            {
                if(cell.Value == null || cell.Value is string)
                    goto sort;

                if(cell.Value is char)
                {
                    cell.Value = cell.Value.ToString();
                    goto sort;
                }

                MessageBox.Show("Invalid value", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cell.Value = null;

            sort:
                this.BeginInvoke((Action)(() => MappingsDataGridView.Sort(MappingsDataGridView.Columns[0], ListSortDirection.Ascending)));
                return;
            }

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
        }
    }
}

#pragma warning restore IDE0003 // Remove 'this'
