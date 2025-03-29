namespace DoomWriter.GUI.Controls
{
    partial class ColorRangeEditor
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
            this.ToColorTextBox = new DoomWriter.GUI.Controls.HexColorTextBox();
            this.FromColorTextBox = new DoomWriter.GUI.Controls.HexColorTextBox();
            this.FromColorButton = new System.Windows.Forms.Button();
            this.ToColorButton = new System.Windows.Forms.Button();
            this.FromLabel = new System.Windows.Forms.Label();
            this.ToLabel = new System.Windows.Forms.Label();
            this.StartLuminanceLabel = new System.Windows.Forms.Label();
            this.StartNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.EndNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.MainColorDialog = new System.Windows.Forms.ColorDialog();
            this.MainTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.AutoSize = true;
            this.MainTableLayoutPanel.ColumnCount = 6;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainTableLayoutPanel.Controls.Add(this.ToColorTextBox, 2, 1);
            this.MainTableLayoutPanel.Controls.Add(this.FromColorTextBox, 0, 1);
            this.MainTableLayoutPanel.Controls.Add(this.FromColorButton, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.ToColorButton, 2, 0);
            this.MainTableLayoutPanel.Controls.Add(this.FromLabel, 1, 0);
            this.MainTableLayoutPanel.Controls.Add(this.ToLabel, 3, 0);
            this.MainTableLayoutPanel.Controls.Add(this.StartLuminanceLabel, 4, 0);
            this.MainTableLayoutPanel.Controls.Add(this.StartNumericUpDown, 4, 1);
            this.MainTableLayoutPanel.Controls.Add(this.EndNumericUpDown, 5, 1);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.RowCount = 2;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(202, 42);
            this.MainTableLayoutPanel.TabIndex = 0;
            // 
            // ToColorTextBox
            // 
            this.MainTableLayoutPanel.SetColumnSpan(this.ToColorTextBox, 2);
            this.ToColorTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToColorTextBox.Location = new System.Drawing.Point(59, 20);
            this.ToColorTextBox.Margin = new System.Windows.Forms.Padding(2, 0, 0, 2);
            this.ToColorTextBox.Name = "ToColorTextBox";
            this.ToColorTextBox.Size = new System.Drawing.Size(55, 20);
            this.ToColorTextBox.TabIndex = 5;
            this.ToColorTextBox.Text = "#FFFFFF";
            this.ToColorTextBox.SelectedColorChanged += new System.EventHandler(this.ToColorTextBox_SelectedColorChanged);
            // 
            // FromColorTextBox
            // 
            this.FromColorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTableLayoutPanel.SetColumnSpan(this.FromColorTextBox, 2);
            this.FromColorTextBox.Location = new System.Drawing.Point(2, 20);
            this.FromColorTextBox.Margin = new System.Windows.Forms.Padding(2, 0, 0, 2);
            this.FromColorTextBox.Name = "FromColorTextBox";
            this.FromColorTextBox.Size = new System.Drawing.Size(55, 20);
            this.FromColorTextBox.TabIndex = 2;
            this.FromColorTextBox.Text = "#FFFFFF";
            this.FromColorTextBox.SelectedColorChanged += new System.EventHandler(this.FromColorTextBox_SelectedColorChanged);
            // 
            // FromColorButton
            // 
            this.FromColorButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FromColorButton.BackColor = System.Drawing.Color.White;
            this.FromColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FromColorButton.Location = new System.Drawing.Point(2, 2);
            this.FromColorButton.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.FromColorButton.Name = "FromColorButton";
            this.FromColorButton.Size = new System.Drawing.Size(16, 16);
            this.FromColorButton.TabIndex = 0;
            this.FromColorButton.UseVisualStyleBackColor = false;
            this.FromColorButton.Click += new System.EventHandler(this.FromColorButton_Click);
            // 
            // ToColorButton
            // 
            this.ToColorButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ToColorButton.BackColor = System.Drawing.Color.White;
            this.ToColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ToColorButton.Location = new System.Drawing.Point(59, 2);
            this.ToColorButton.Margin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.ToColorButton.Name = "ToColorButton";
            this.ToColorButton.Size = new System.Drawing.Size(16, 16);
            this.ToColorButton.TabIndex = 3;
            this.ToColorButton.UseVisualStyleBackColor = false;
            this.ToColorButton.Click += new System.EventHandler(this.ToColorButton_Click);
            // 
            // FromLabel
            // 
            this.FromLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.FromLabel.AutoSize = true;
            this.FromLabel.Location = new System.Drawing.Point(20, 3);
            this.FromLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FromLabel.Name = "FromLabel";
            this.FromLabel.Size = new System.Drawing.Size(30, 13);
            this.FromLabel.TabIndex = 1;
            this.FromLabel.Text = "From";
            // 
            // ToLabel
            // 
            this.ToLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ToLabel.AutoSize = true;
            this.ToLabel.Location = new System.Drawing.Point(77, 3);
            this.ToLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ToLabel.Name = "ToLabel";
            this.ToLabel.Size = new System.Drawing.Size(20, 13);
            this.ToLabel.TabIndex = 4;
            this.ToLabel.Text = "To";
            // 
            // StartLuminanceLabel
            // 
            this.StartLuminanceLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.StartLuminanceLabel.AutoSize = true;
            this.MainTableLayoutPanel.SetColumnSpan(this.StartLuminanceLabel, 2);
            this.StartLuminanceLabel.Location = new System.Drawing.Point(116, 3);
            this.StartLuminanceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StartLuminanceLabel.Name = "StartLuminanceLabel";
            this.StartLuminanceLabel.Size = new System.Drawing.Size(60, 13);
            this.StartLuminanceLabel.TabIndex = 6;
            this.StartLuminanceLabel.Text = "Lum. range";
            // 
            // StartNumericUpDown
            // 
            this.StartNumericUpDown.AutoSize = true;
            this.StartNumericUpDown.Location = new System.Drawing.Point(116, 20);
            this.StartNumericUpDown.Margin = new System.Windows.Forms.Padding(2, 0, 0, 2);
            this.StartNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.StartNumericUpDown.Name = "StartNumericUpDown";
            this.StartNumericUpDown.Size = new System.Drawing.Size(41, 20);
            this.StartNumericUpDown.TabIndex = 7;
            this.StartNumericUpDown.ValueChanged += new System.EventHandler(this.StartNumericUpDown_ValueChanged);
            // 
            // EndNumericUpDown
            // 
            this.EndNumericUpDown.AutoSize = true;
            this.EndNumericUpDown.Location = new System.Drawing.Point(159, 20);
            this.EndNumericUpDown.Margin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.EndNumericUpDown.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.EndNumericUpDown.Name = "EndNumericUpDown";
            this.EndNumericUpDown.Size = new System.Drawing.Size(41, 20);
            this.EndNumericUpDown.TabIndex = 8;
            this.EndNumericUpDown.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.EndNumericUpDown.ValueChanged += new System.EventHandler(this.EndNumericUpDown_ValueChanged);
            // 
            // MainColorDialog
            // 
            this.MainColorDialog.Color = System.Drawing.Color.White;
            this.MainColorDialog.FullOpen = true;
            // 
            // ColorRangeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ColorRangeEditor";
            this.Size = new System.Drawing.Size(202, 42);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.MainTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.Button FromColorButton;
        private System.Windows.Forms.Label FromLabel;
        private System.Windows.Forms.Button ToColorButton;
        private System.Windows.Forms.Label ToLabel;
        private HexColorTextBox FromColorTextBox;
        private HexColorTextBox ToColorTextBox;
        private System.Windows.Forms.Label StartLuminanceLabel;
        private System.Windows.Forms.NumericUpDown StartNumericUpDown;
        private System.Windows.Forms.NumericUpDown EndNumericUpDown;
        private System.Windows.Forms.ColorDialog MainColorDialog;
    }
}
