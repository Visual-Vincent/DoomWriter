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

                if(!ushort.TryParse(xVal, out var x) || !ushort.TryParse(yVal, out var y) ||
                   !ushort.TryParse(wVal, out var w) || !ushort.TryParse(hVal, out var h))
                    return null;

                return new Rectangle(x, y, w, h);
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
            }
            else
            {
                int index = MappingsDataGridView.Rows.Add(CurrentCharacter.ToString(), bounds.X, bounds.Y, bounds.Width, bounds.Height);
                row = MappingsDataGridView.Rows[index];
            }

            if(advance)
            {
                if(row.Index + 1 <= MappingsDataGridView.Rows.Count - 1)
                    MappingsDataGridView.Rows[row.Index + 1].Selected = true;

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
    }
}

#pragma warning restore IDE0003 // Remove 'this'
