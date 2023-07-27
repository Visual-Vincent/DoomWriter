namespace FontEditor
{
    partial class CharacterMappingControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.CurrentCharacterInfoLabel = new System.Windows.Forms.Label();
            this.CurrentCharacterTextBox = new System.Windows.Forms.TextBox();
            this.MappingsDataGridView = new System.Windows.Forms.DataGridView();
            this.CharacterColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WidthColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeightColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescenderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MappingsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 2;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.TitleLabel, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.CurrentCharacterInfoLabel, 0, 1);
            this.MainTableLayoutPanel.Controls.Add(this.CurrentCharacterTextBox, 1, 1);
            this.MainTableLayoutPanel.Controls.Add(this.MappingsDataGridView, 0, 2);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.RowCount = 3;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(285, 400);
            this.MainTableLayoutPanel.TabIndex = 0;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TitleLabel.AutoSize = true;
            this.MainTableLayoutPanel.SetColumnSpan(this.TitleLabel, 2);
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(62, 6);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(6);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(161, 20);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Character Mapping";
            // 
            // CurrentCharacterInfoLabel
            // 
            this.CurrentCharacterInfoLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CurrentCharacterInfoLabel.AutoSize = true;
            this.CurrentCharacterInfoLabel.Location = new System.Drawing.Point(6, 40);
            this.CurrentCharacterInfoLabel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 5);
            this.CurrentCharacterInfoLabel.Name = "CurrentCharacterInfoLabel";
            this.CurrentCharacterInfoLabel.Size = new System.Drawing.Size(92, 13);
            this.CurrentCharacterInfoLabel.TabIndex = 1;
            this.CurrentCharacterInfoLabel.Text = "Current character:";
            // 
            // CurrentCharacterTextBox
            // 
            this.CurrentCharacterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentCharacterTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentCharacterTextBox.Location = new System.Drawing.Point(107, 35);
            this.CurrentCharacterTextBox.MaxLength = 1;
            this.CurrentCharacterTextBox.Name = "CurrentCharacterTextBox";
            this.CurrentCharacterTextBox.Size = new System.Drawing.Size(175, 22);
            this.CurrentCharacterTextBox.TabIndex = 2;
            this.CurrentCharacterTextBox.Text = "A";
            this.CurrentCharacterTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CurrentCharacterTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CurrentCharacterTextBox_KeyDown);
            this.CurrentCharacterTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CurrentCharacterTextBox_KeyPress);
            // 
            // MappingsDataGridView
            // 
            this.MappingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MappingsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CharacterColumn,
            this.XColumn,
            this.YColumn,
            this.WidthColumn,
            this.HeightColumn,
            this.DescenderColumn});
            this.MainTableLayoutPanel.SetColumnSpan(this.MappingsDataGridView, 2);
            this.MappingsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MappingsDataGridView.Location = new System.Drawing.Point(0, 60);
            this.MappingsDataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.MappingsDataGridView.MultiSelect = false;
            this.MappingsDataGridView.Name = "MappingsDataGridView";
            this.MappingsDataGridView.RowHeadersWidth = 20;
            this.MappingsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MappingsDataGridView.Size = new System.Drawing.Size(285, 340);
            this.MappingsDataGridView.TabIndex = 3;
            this.MappingsDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.MappingsDataGridView_CellEndEdit);
            this.MappingsDataGridView.SelectionChanged += new System.EventHandler(this.MappingsDataGridView_SelectionChanged);
            // 
            // CharacterColumn
            // 
            this.CharacterColumn.HeaderText = "Char";
            this.CharacterColumn.MaxInputLength = 1;
            this.CharacterColumn.Name = "CharacterColumn";
            this.CharacterColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CharacterColumn.ToolTipText = "Character/Glyph";
            this.CharacterColumn.Width = 50;
            // 
            // XColumn
            // 
            this.XColumn.HeaderText = "X";
            this.XColumn.MaxInputLength = 6;
            this.XColumn.Name = "XColumn";
            this.XColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.XColumn.ToolTipText = "X position";
            this.XColumn.Width = 42;
            // 
            // YColumn
            // 
            this.YColumn.HeaderText = "Y";
            this.YColumn.MaxInputLength = 6;
            this.YColumn.Name = "YColumn";
            this.YColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.YColumn.ToolTipText = "Y position";
            this.YColumn.Width = 42;
            // 
            // WidthColumn
            // 
            this.WidthColumn.HeaderText = "W";
            this.WidthColumn.MaxInputLength = 6;
            this.WidthColumn.Name = "WidthColumn";
            this.WidthColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.WidthColumn.ToolTipText = "Width";
            this.WidthColumn.Width = 42;
            // 
            // HeightColumn
            // 
            this.HeightColumn.HeaderText = "H";
            this.HeightColumn.MaxInputLength = 6;
            this.HeightColumn.Name = "HeightColumn";
            this.HeightColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HeightColumn.ToolTipText = "Height";
            this.HeightColumn.Width = 42;
            // 
            // DescenderColumn
            // 
            this.DescenderColumn.HeaderText = "Desc.";
            this.DescenderColumn.MaxInputLength = 6;
            this.DescenderColumn.Name = "DescenderColumn";
            this.DescenderColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DescenderColumn.ToolTipText = "Descender";
            this.DescenderColumn.Width = 42;
            // 
            // CharacterMappingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainTableLayoutPanel);
            this.MinimumSize = new System.Drawing.Size(180, 160);
            this.Name = "CharacterMappingControl";
            this.Size = new System.Drawing.Size(285, 400);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.MainTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MappingsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label CurrentCharacterInfoLabel;
        private System.Windows.Forms.TextBox CurrentCharacterTextBox;
        private System.Windows.Forms.DataGridView MappingsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn CharacterColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn XColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn YColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn WidthColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeightColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescenderColumn;
    }
}
