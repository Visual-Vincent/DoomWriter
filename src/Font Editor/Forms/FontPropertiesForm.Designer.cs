namespace FontEditor.Forms
{
    partial class FontPropertiesForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FontPropertiesForm));
            this.MainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelFormButton = new System.Windows.Forms.Button();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.MetricsTabPage = new System.Windows.Forms.TabPage();
            this.MetricsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.LetterSpacingLabel = new System.Windows.Forms.Label();
            this.LetterSpacingNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.LetterSpacingDescriptionLabel = new System.Windows.Forms.Label();
            this.SpaceWidthLabel = new System.Windows.Forms.Label();
            this.SpaceWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.SpaceWidthDescriptionLabel = new System.Windows.Forms.Label();
            this.TabWidthLabel = new System.Windows.Forms.Label();
            this.TabWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TabWidthDescriptionLabel = new System.Windows.Forms.Label();
            this.LineHeightLabel = new System.Windows.Forms.Label();
            this.LineHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.LineHeightDescriptionLabel = new System.Windows.Forms.Label();
            this.EmptyLineHeightLabel = new System.Windows.Forms.Label();
            this.EmptyLineHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.EmptyLineHeightDescriptionLabel = new System.Windows.Forms.Label();
            this.MetricsPreviewGroupBox = new System.Windows.Forms.GroupBox();
            this.MetricsPreviewPanel = new System.Windows.Forms.Panel();
            this.MetricsPreviewErrorLabel = new System.Windows.Forms.Label();
            this.MetricsPreviewPictureBox = new System.Windows.Forms.PictureBox();
            this.KerningTabPage = new System.Windows.Forms.TabPage();
            this.KerningTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.KerningSplitContainer = new System.Windows.Forms.SplitContainer();
            this.KerningPreviewGroupBox = new System.Windows.Forms.GroupBox();
            this.KerningPreviewPanel = new System.Windows.Forms.Panel();
            this.KerningPreviewErrorLabel = new System.Windows.Forms.Label();
            this.KerningPreviewPictureBox = new System.Windows.Forms.PictureBox();
            this.KerningDataGridView = new System.Windows.Forms.DataGridView();
            this.LeftCharColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RightCharColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KerningColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KerningDescriptionLabel = new System.Windows.Forms.Label();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.MainTableLayoutPanel.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.MetricsTabPage.SuspendLayout();
            this.MetricsTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LetterSpacingNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpaceWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineHeightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmptyLineHeightNumericUpDown)).BeginInit();
            this.MetricsPreviewGroupBox.SuspendLayout();
            this.MetricsPreviewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MetricsPreviewPictureBox)).BeginInit();
            this.KerningTabPage.SuspendLayout();
            this.KerningTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KerningSplitContainer)).BeginInit();
            this.KerningSplitContainer.Panel1.SuspendLayout();
            this.KerningSplitContainer.Panel2.SuspendLayout();
            this.KerningSplitContainer.SuspendLayout();
            this.KerningPreviewGroupBox.SuspendLayout();
            this.KerningPreviewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KerningPreviewPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KerningDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 3;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainTableLayoutPanel.Controls.Add(this.OKButton, 0, 1);
            this.MainTableLayoutPanel.Controls.Add(this.CancelFormButton, 1, 1);
            this.MainTableLayoutPanel.Controls.Add(this.MainTabControl, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.ApplyButton, 2, 1);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.RowCount = 2;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(374, 562);
            this.MainTableLayoutPanel.TabIndex = 0;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.OKButton.Location = new System.Drawing.Point(131, 533);
            this.OKButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 16;
            this.OKButton.Text = "&OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelFormButton
            // 
            this.CancelFormButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CancelFormButton.Location = new System.Drawing.Point(212, 533);
            this.CancelFormButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.CancelFormButton.Name = "CancelFormButton";
            this.CancelFormButton.Size = new System.Drawing.Size(75, 23);
            this.CancelFormButton.TabIndex = 17;
            this.CancelFormButton.Text = "Cancel";
            this.CancelFormButton.UseVisualStyleBackColor = true;
            this.CancelFormButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // MainTabControl
            // 
            this.MainTableLayoutPanel.SetColumnSpan(this.MainTabControl, 3);
            this.MainTabControl.Controls.Add(this.MetricsTabPage);
            this.MainTabControl.Controls.Add(this.KerningTabPage);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Location = new System.Drawing.Point(6, 6);
            this.MainTabControl.Margin = new System.Windows.Forms.Padding(6, 6, 6, 3);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(362, 521);
            this.MainTabControl.TabIndex = 1;
            // 
            // MetricsTabPage
            // 
            this.MetricsTabPage.Controls.Add(this.MetricsTableLayoutPanel);
            this.MetricsTabPage.Location = new System.Drawing.Point(4, 22);
            this.MetricsTabPage.Name = "MetricsTabPage";
            this.MetricsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MetricsTabPage.Size = new System.Drawing.Size(354, 495);
            this.MetricsTabPage.TabIndex = 0;
            this.MetricsTabPage.Text = "Metrics";
            this.MetricsTabPage.UseVisualStyleBackColor = true;
            // 
            // MetricsTableLayoutPanel
            // 
            this.MetricsTableLayoutPanel.AutoScroll = true;
            this.MetricsTableLayoutPanel.ColumnCount = 2;
            this.MetricsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MetricsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MetricsTableLayoutPanel.Controls.Add(this.LetterSpacingLabel, 0, 0);
            this.MetricsTableLayoutPanel.Controls.Add(this.LetterSpacingNumericUpDown, 1, 0);
            this.MetricsTableLayoutPanel.Controls.Add(this.LetterSpacingDescriptionLabel, 0, 1);
            this.MetricsTableLayoutPanel.Controls.Add(this.SpaceWidthLabel, 0, 2);
            this.MetricsTableLayoutPanel.Controls.Add(this.SpaceWidthNumericUpDown, 1, 2);
            this.MetricsTableLayoutPanel.Controls.Add(this.SpaceWidthDescriptionLabel, 0, 3);
            this.MetricsTableLayoutPanel.Controls.Add(this.TabWidthLabel, 0, 4);
            this.MetricsTableLayoutPanel.Controls.Add(this.TabWidthNumericUpDown, 1, 4);
            this.MetricsTableLayoutPanel.Controls.Add(this.TabWidthDescriptionLabel, 0, 5);
            this.MetricsTableLayoutPanel.Controls.Add(this.LineHeightLabel, 0, 6);
            this.MetricsTableLayoutPanel.Controls.Add(this.LineHeightNumericUpDown, 1, 6);
            this.MetricsTableLayoutPanel.Controls.Add(this.LineHeightDescriptionLabel, 0, 7);
            this.MetricsTableLayoutPanel.Controls.Add(this.EmptyLineHeightLabel, 0, 8);
            this.MetricsTableLayoutPanel.Controls.Add(this.EmptyLineHeightNumericUpDown, 1, 8);
            this.MetricsTableLayoutPanel.Controls.Add(this.EmptyLineHeightDescriptionLabel, 0, 9);
            this.MetricsTableLayoutPanel.Controls.Add(this.MetricsPreviewGroupBox, 0, 10);
            this.MetricsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MetricsTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.MetricsTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MetricsTableLayoutPanel.Name = "MetricsTableLayoutPanel";
            this.MetricsTableLayoutPanel.RowCount = 11;
            this.MetricsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MetricsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MetricsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MetricsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MetricsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MetricsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MetricsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MetricsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MetricsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MetricsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MetricsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MetricsTableLayoutPanel.Size = new System.Drawing.Size(348, 489);
            this.MetricsTableLayoutPanel.TabIndex = 0;
            // 
            // LetterSpacingLabel
            // 
            this.LetterSpacingLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LetterSpacingLabel.AutoSize = true;
            this.LetterSpacingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LetterSpacingLabel.Location = new System.Drawing.Point(3, 4);
            this.LetterSpacingLabel.Margin = new System.Windows.Forms.Padding(3);
            this.LetterSpacingLabel.Name = "LetterSpacingLabel";
            this.LetterSpacingLabel.Size = new System.Drawing.Size(104, 18);
            this.LetterSpacingLabel.TabIndex = 0;
            this.LetterSpacingLabel.Text = "Letter spacing:";
            // 
            // LetterSpacingNumericUpDown
            // 
            this.LetterSpacingNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LetterSpacingNumericUpDown.Location = new System.Drawing.Point(255, 3);
            this.LetterSpacingNumericUpDown.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.LetterSpacingNumericUpDown.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.LetterSpacingNumericUpDown.Name = "LetterSpacingNumericUpDown";
            this.LetterSpacingNumericUpDown.Size = new System.Drawing.Size(90, 20);
            this.LetterSpacingNumericUpDown.TabIndex = 1;
            this.LetterSpacingNumericUpDown.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // LetterSpacingDescriptionLabel
            // 
            this.LetterSpacingDescriptionLabel.AutoSize = true;
            this.MetricsTableLayoutPanel.SetColumnSpan(this.LetterSpacingDescriptionLabel, 2);
            this.LetterSpacingDescriptionLabel.Location = new System.Drawing.Point(3, 26);
            this.LetterSpacingDescriptionLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 12);
            this.LetterSpacingDescriptionLabel.Name = "LetterSpacingDescriptionLabel";
            this.LetterSpacingDescriptionLabel.Size = new System.Drawing.Size(285, 13);
            this.LetterSpacingDescriptionLabel.TabIndex = 2;
            this.LetterSpacingDescriptionLabel.Text = "The spacing, in pixels, between each character of the font.";
            // 
            // SpaceWidthLabel
            // 
            this.SpaceWidthLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SpaceWidthLabel.AutoSize = true;
            this.SpaceWidthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpaceWidthLabel.Location = new System.Drawing.Point(3, 55);
            this.SpaceWidthLabel.Margin = new System.Windows.Forms.Padding(3);
            this.SpaceWidthLabel.Name = "SpaceWidthLabel";
            this.SpaceWidthLabel.Size = new System.Drawing.Size(92, 18);
            this.SpaceWidthLabel.TabIndex = 3;
            this.SpaceWidthLabel.Text = "Space width:";
            // 
            // SpaceWidthNumericUpDown
            // 
            this.SpaceWidthNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SpaceWidthNumericUpDown.Location = new System.Drawing.Point(255, 54);
            this.SpaceWidthNumericUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.SpaceWidthNumericUpDown.Name = "SpaceWidthNumericUpDown";
            this.SpaceWidthNumericUpDown.Size = new System.Drawing.Size(90, 20);
            this.SpaceWidthNumericUpDown.TabIndex = 4;
            this.SpaceWidthNumericUpDown.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // SpaceWidthDescriptionLabel
            // 
            this.SpaceWidthDescriptionLabel.AutoSize = true;
            this.MetricsTableLayoutPanel.SetColumnSpan(this.SpaceWidthDescriptionLabel, 2);
            this.SpaceWidthDescriptionLabel.Location = new System.Drawing.Point(3, 77);
            this.SpaceWidthDescriptionLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 12);
            this.SpaceWidthDescriptionLabel.Name = "SpaceWidthDescriptionLabel";
            this.SpaceWidthDescriptionLabel.Size = new System.Drawing.Size(213, 13);
            this.SpaceWidthDescriptionLabel.TabIndex = 5;
            this.SpaceWidthDescriptionLabel.Text = "The width, in pixels, of the space character.";
            // 
            // TabWidthLabel
            // 
            this.TabWidthLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TabWidthLabel.AutoSize = true;
            this.TabWidthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabWidthLabel.Location = new System.Drawing.Point(3, 106);
            this.TabWidthLabel.Margin = new System.Windows.Forms.Padding(3);
            this.TabWidthLabel.Name = "TabWidthLabel";
            this.TabWidthLabel.Size = new System.Drawing.Size(75, 18);
            this.TabWidthLabel.TabIndex = 6;
            this.TabWidthLabel.Text = "Tab width:";
            // 
            // TabWidthNumericUpDown
            // 
            this.TabWidthNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.TabWidthNumericUpDown.Location = new System.Drawing.Point(255, 105);
            this.TabWidthNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.TabWidthNumericUpDown.Name = "TabWidthNumericUpDown";
            this.TabWidthNumericUpDown.Size = new System.Drawing.Size(90, 20);
            this.TabWidthNumericUpDown.TabIndex = 7;
            this.TabWidthNumericUpDown.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // TabWidthDescriptionLabel
            // 
            this.TabWidthDescriptionLabel.AutoSize = true;
            this.MetricsTableLayoutPanel.SetColumnSpan(this.TabWidthDescriptionLabel, 2);
            this.TabWidthDescriptionLabel.Location = new System.Drawing.Point(3, 128);
            this.TabWidthDescriptionLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 12);
            this.TabWidthDescriptionLabel.Name = "TabWidthDescriptionLabel";
            this.TabWidthDescriptionLabel.Size = new System.Drawing.Size(246, 13);
            this.TabWidthDescriptionLabel.TabIndex = 8;
            this.TabWidthDescriptionLabel.Text = "How many spaces make up a single tab character.";
            // 
            // LineHeightLabel
            // 
            this.LineHeightLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LineHeightLabel.AutoSize = true;
            this.LineHeightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LineHeightLabel.Location = new System.Drawing.Point(3, 157);
            this.LineHeightLabel.Margin = new System.Windows.Forms.Padding(3);
            this.LineHeightLabel.Name = "LineHeightLabel";
            this.LineHeightLabel.Size = new System.Drawing.Size(82, 18);
            this.LineHeightLabel.TabIndex = 9;
            this.LineHeightLabel.Text = "Line height:";
            // 
            // LineHeightNumericUpDown
            // 
            this.LineHeightNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LineHeightNumericUpDown.Location = new System.Drawing.Point(255, 156);
            this.LineHeightNumericUpDown.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.LineHeightNumericUpDown.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.LineHeightNumericUpDown.Name = "LineHeightNumericUpDown";
            this.LineHeightNumericUpDown.Size = new System.Drawing.Size(90, 20);
            this.LineHeightNumericUpDown.TabIndex = 10;
            this.LineHeightNumericUpDown.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // LineHeightDescriptionLabel
            // 
            this.LineHeightDescriptionLabel.AutoSize = true;
            this.MetricsTableLayoutPanel.SetColumnSpan(this.LineHeightDescriptionLabel, 2);
            this.LineHeightDescriptionLabel.Location = new System.Drawing.Point(3, 179);
            this.LineHeightDescriptionLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 12);
            this.LineHeightDescriptionLabel.Name = "LineHeightDescriptionLabel";
            this.LineHeightDescriptionLabel.Size = new System.Drawing.Size(240, 13);
            this.LineHeightDescriptionLabel.TabIndex = 8;
            this.LineHeightDescriptionLabel.Text = "The distance, in pixels, between each line of text.";
            // 
            // EmptyLineHeightLabel
            // 
            this.EmptyLineHeightLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EmptyLineHeightLabel.AutoSize = true;
            this.EmptyLineHeightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmptyLineHeightLabel.Location = new System.Drawing.Point(3, 208);
            this.EmptyLineHeightLabel.Margin = new System.Windows.Forms.Padding(3);
            this.EmptyLineHeightLabel.Name = "EmptyLineHeightLabel";
            this.EmptyLineHeightLabel.Size = new System.Drawing.Size(123, 18);
            this.EmptyLineHeightLabel.TabIndex = 11;
            this.EmptyLineHeightLabel.Text = "Empty line height:";
            // 
            // EmptyLineHeightNumericUpDown
            // 
            this.EmptyLineHeightNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.EmptyLineHeightNumericUpDown.Location = new System.Drawing.Point(255, 207);
            this.EmptyLineHeightNumericUpDown.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.EmptyLineHeightNumericUpDown.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.EmptyLineHeightNumericUpDown.Name = "EmptyLineHeightNumericUpDown";
            this.EmptyLineHeightNumericUpDown.Size = new System.Drawing.Size(90, 20);
            this.EmptyLineHeightNumericUpDown.TabIndex = 12;
            this.EmptyLineHeightNumericUpDown.ValueChanged += new System.EventHandler(this.NumericUpDown_ValueChanged);
            // 
            // EmptyLineHeightDescriptionLabel
            // 
            this.EmptyLineHeightDescriptionLabel.AutoSize = true;
            this.MetricsTableLayoutPanel.SetColumnSpan(this.EmptyLineHeightDescriptionLabel, 2);
            this.EmptyLineHeightDescriptionLabel.Location = new System.Drawing.Point(3, 230);
            this.EmptyLineHeightDescriptionLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 12);
            this.EmptyLineHeightDescriptionLabel.Name = "EmptyLineHeightDescriptionLabel";
            this.EmptyLineHeightDescriptionLabel.Size = new System.Drawing.Size(246, 13);
            this.EmptyLineHeightDescriptionLabel.TabIndex = 13;
            this.EmptyLineHeightDescriptionLabel.Text = "The height, in pixels, of a line that contains no text.";
            // 
            // MetricsPreviewGroupBox
            // 
            this.MetricsTableLayoutPanel.SetColumnSpan(this.MetricsPreviewGroupBox, 2);
            this.MetricsPreviewGroupBox.Controls.Add(this.MetricsPreviewPanel);
            this.MetricsPreviewGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MetricsPreviewGroupBox.ForeColor = System.Drawing.Color.Blue;
            this.MetricsPreviewGroupBox.Location = new System.Drawing.Point(3, 258);
            this.MetricsPreviewGroupBox.Name = "MetricsPreviewGroupBox";
            this.MetricsPreviewGroupBox.Size = new System.Drawing.Size(342, 228);
            this.MetricsPreviewGroupBox.TabIndex = 14;
            this.MetricsPreviewGroupBox.TabStop = false;
            this.MetricsPreviewGroupBox.Text = "Preview";
            // 
            // MetricsPreviewPanel
            // 
            this.MetricsPreviewPanel.AutoScroll = true;
            this.MetricsPreviewPanel.BackColor = System.Drawing.Color.Cyan;
            this.MetricsPreviewPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MetricsPreviewPanel.Controls.Add(this.MetricsPreviewErrorLabel);
            this.MetricsPreviewPanel.Controls.Add(this.MetricsPreviewPictureBox);
            this.MetricsPreviewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MetricsPreviewPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MetricsPreviewPanel.Location = new System.Drawing.Point(3, 16);
            this.MetricsPreviewPanel.Name = "MetricsPreviewPanel";
            this.MetricsPreviewPanel.Size = new System.Drawing.Size(336, 209);
            this.MetricsPreviewPanel.TabIndex = 15;
            // 
            // MetricsPreviewErrorLabel
            // 
            this.MetricsPreviewErrorLabel.BackColor = System.Drawing.SystemColors.Control;
            this.MetricsPreviewErrorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MetricsPreviewErrorLabel.Location = new System.Drawing.Point(0, 0);
            this.MetricsPreviewErrorLabel.Name = "MetricsPreviewErrorLabel";
            this.MetricsPreviewErrorLabel.Size = new System.Drawing.Size(332, 205);
            this.MetricsPreviewErrorLabel.TabIndex = 1;
            this.MetricsPreviewErrorLabel.Text = "Loading preview...";
            this.MetricsPreviewErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MetricsPreviewPictureBox
            // 
            this.MetricsPreviewPictureBox.Location = new System.Drawing.Point(0, 0);
            this.MetricsPreviewPictureBox.Name = "MetricsPreviewPictureBox";
            this.MetricsPreviewPictureBox.Size = new System.Drawing.Size(32, 32);
            this.MetricsPreviewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.MetricsPreviewPictureBox.TabIndex = 0;
            this.MetricsPreviewPictureBox.TabStop = false;
            // 
            // KerningTabPage
            // 
            this.KerningTabPage.Controls.Add(this.KerningTableLayoutPanel);
            this.KerningTabPage.Location = new System.Drawing.Point(4, 22);
            this.KerningTabPage.Name = "KerningTabPage";
            this.KerningTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.KerningTabPage.Size = new System.Drawing.Size(354, 495);
            this.KerningTabPage.TabIndex = 1;
            this.KerningTabPage.Text = "Kerning";
            this.KerningTabPage.UseVisualStyleBackColor = true;
            // 
            // KerningTableLayoutPanel
            // 
            this.KerningTableLayoutPanel.ColumnCount = 1;
            this.KerningTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.KerningTableLayoutPanel.Controls.Add(this.KerningSplitContainer, 0, 0);
            this.KerningTableLayoutPanel.Controls.Add(this.KerningDescriptionLabel, 0, 1);
            this.KerningTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KerningTableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.KerningTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.KerningTableLayoutPanel.Name = "KerningTableLayoutPanel";
            this.KerningTableLayoutPanel.RowCount = 2;
            this.KerningTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.KerningTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.KerningTableLayoutPanel.Size = new System.Drawing.Size(348, 489);
            this.KerningTableLayoutPanel.TabIndex = 0;
            // 
            // KerningSplitContainer
            // 
            this.KerningSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KerningSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.KerningSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.KerningSplitContainer.Name = "KerningSplitContainer";
            this.KerningSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // KerningSplitContainer.Panel1
            // 
            this.KerningSplitContainer.Panel1.Controls.Add(this.KerningPreviewGroupBox);
            // 
            // KerningSplitContainer.Panel2
            // 
            this.KerningSplitContainer.Panel2.Controls.Add(this.KerningDataGridView);
            this.KerningSplitContainer.Size = new System.Drawing.Size(348, 467);
            this.KerningSplitContainer.SplitterDistance = 100;
            this.KerningSplitContainer.TabIndex = 1;
            // 
            // KerningPreviewGroupBox
            // 
            this.KerningPreviewGroupBox.Controls.Add(this.KerningPreviewPanel);
            this.KerningPreviewGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KerningPreviewGroupBox.ForeColor = System.Drawing.Color.Blue;
            this.KerningPreviewGroupBox.Location = new System.Drawing.Point(0, 0);
            this.KerningPreviewGroupBox.Name = "KerningPreviewGroupBox";
            this.KerningPreviewGroupBox.Size = new System.Drawing.Size(348, 100);
            this.KerningPreviewGroupBox.TabIndex = 16;
            this.KerningPreviewGroupBox.TabStop = false;
            this.KerningPreviewGroupBox.Text = "Preview";
            // 
            // KerningPreviewPanel
            // 
            this.KerningPreviewPanel.AutoScroll = true;
            this.KerningPreviewPanel.BackColor = System.Drawing.Color.Cyan;
            this.KerningPreviewPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.KerningPreviewPanel.Controls.Add(this.KerningPreviewErrorLabel);
            this.KerningPreviewPanel.Controls.Add(this.KerningPreviewPictureBox);
            this.KerningPreviewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KerningPreviewPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.KerningPreviewPanel.Location = new System.Drawing.Point(3, 16);
            this.KerningPreviewPanel.Name = "KerningPreviewPanel";
            this.KerningPreviewPanel.Size = new System.Drawing.Size(342, 81);
            this.KerningPreviewPanel.TabIndex = 15;
            // 
            // KerningPreviewErrorLabel
            // 
            this.KerningPreviewErrorLabel.BackColor = System.Drawing.SystemColors.Control;
            this.KerningPreviewErrorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KerningPreviewErrorLabel.Location = new System.Drawing.Point(0, 0);
            this.KerningPreviewErrorLabel.Name = "KerningPreviewErrorLabel";
            this.KerningPreviewErrorLabel.Size = new System.Drawing.Size(338, 77);
            this.KerningPreviewErrorLabel.TabIndex = 1;
            this.KerningPreviewErrorLabel.Text = "Please select a kerning pair";
            this.KerningPreviewErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // KerningPreviewPictureBox
            // 
            this.KerningPreviewPictureBox.Location = new System.Drawing.Point(0, 0);
            this.KerningPreviewPictureBox.Name = "KerningPreviewPictureBox";
            this.KerningPreviewPictureBox.Size = new System.Drawing.Size(32, 32);
            this.KerningPreviewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.KerningPreviewPictureBox.TabIndex = 0;
            this.KerningPreviewPictureBox.TabStop = false;
            // 
            // KerningDataGridView
            // 
            this.KerningDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.KerningDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LeftCharColumn,
            this.RightCharColumn,
            this.KerningColumn});
            this.KerningDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KerningDataGridView.Location = new System.Drawing.Point(0, 0);
            this.KerningDataGridView.Name = "KerningDataGridView";
            this.KerningDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.KerningDataGridView.Size = new System.Drawing.Size(348, 363);
            this.KerningDataGridView.TabIndex = 0;
            this.KerningDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.KerningDataGridView_CellEndEdit);
            this.KerningDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.KerningDataGridView_CellValueChanged);
            this.KerningDataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.KerningDataGridView_RowsRemoved);
            this.KerningDataGridView.SelectionChanged += new System.EventHandler(this.KerningDataGridView_SelectionChanged);
            this.KerningDataGridView.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.KerningDataGridView_SortCompare);
            // 
            // LeftCharColumn
            // 
            this.LeftCharColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LeftCharColumn.HeaderText = "Left char";
            this.LeftCharColumn.MaxInputLength = 1;
            this.LeftCharColumn.Name = "LeftCharColumn";
            this.LeftCharColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LeftCharColumn.ToolTipText = "Left character";
            // 
            // RightCharColumn
            // 
            this.RightCharColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RightCharColumn.HeaderText = "Right char";
            this.RightCharColumn.MaxInputLength = 1;
            this.RightCharColumn.Name = "RightCharColumn";
            this.RightCharColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RightCharColumn.ToolTipText = "Right character";
            // 
            // KerningColumn
            // 
            this.KerningColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.KerningColumn.HeaderText = "Kerning";
            this.KerningColumn.MaxInputLength = 6;
            this.KerningColumn.Name = "KerningColumn";
            this.KerningColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.KerningColumn.ToolTipText = "Kerning";
            // 
            // KerningDescriptionLabel
            // 
            this.KerningDescriptionLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.KerningDescriptionLabel.AutoSize = true;
            this.KerningDescriptionLabel.Location = new System.Drawing.Point(15, 473);
            this.KerningDescriptionLabel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 3);
            this.KerningDescriptionLabel.Name = "KerningDescriptionLabel";
            this.KerningDescriptionLabel.Size = new System.Drawing.Size(317, 13);
            this.KerningDescriptionLabel.TabIndex = 0;
            this.KerningDescriptionLabel.Text = "Kerning adjusts the spacing between a specific pair of characters.";
            this.KerningDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ApplyButton.Enabled = false;
            this.ApplyButton.Location = new System.Drawing.Point(293, 533);
            this.ApplyButton.Margin = new System.Windows.Forms.Padding(3, 3, 6, 6);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 18;
            this.ApplyButton.Text = "&Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // FontPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 562);
            this.Controls.Add(this.MainTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FontPropertiesForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Font Properties";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FontPropertiesForm_FormClosing);
            this.Load += new System.EventHandler(this.FontPropertiesForm_Load);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.MainTabControl.ResumeLayout(false);
            this.MetricsTabPage.ResumeLayout(false);
            this.MetricsTableLayoutPanel.ResumeLayout(false);
            this.MetricsTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LetterSpacingNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpaceWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineHeightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmptyLineHeightNumericUpDown)).EndInit();
            this.MetricsPreviewGroupBox.ResumeLayout(false);
            this.MetricsPreviewPanel.ResumeLayout(false);
            this.MetricsPreviewPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MetricsPreviewPictureBox)).EndInit();
            this.KerningTabPage.ResumeLayout(false);
            this.KerningTableLayoutPanel.ResumeLayout(false);
            this.KerningTableLayoutPanel.PerformLayout();
            this.KerningSplitContainer.Panel1.ResumeLayout(false);
            this.KerningSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KerningSplitContainer)).EndInit();
            this.KerningSplitContainer.ResumeLayout(false);
            this.KerningPreviewGroupBox.ResumeLayout(false);
            this.KerningPreviewPanel.ResumeLayout(false);
            this.KerningPreviewPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KerningPreviewPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KerningDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelFormButton;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage MetricsTabPage;
        private System.Windows.Forms.TabPage KerningTabPage;
        private System.Windows.Forms.TableLayoutPanel MetricsTableLayoutPanel;
        private System.Windows.Forms.Label SpaceWidthLabel;
        private System.Windows.Forms.NumericUpDown SpaceWidthNumericUpDown;
        private System.Windows.Forms.Label SpaceWidthDescriptionLabel;
        private System.Windows.Forms.Label TabWidthLabel;
        private System.Windows.Forms.Label TabWidthDescriptionLabel;
        private System.Windows.Forms.NumericUpDown TabWidthNumericUpDown;
        private System.Windows.Forms.Label LetterSpacingLabel;
        private System.Windows.Forms.NumericUpDown LetterSpacingNumericUpDown;
        private System.Windows.Forms.Label LetterSpacingDescriptionLabel;
        private System.Windows.Forms.Label LineHeightLabel;
        private System.Windows.Forms.NumericUpDown LineHeightNumericUpDown;
        private System.Windows.Forms.Label LineHeightDescriptionLabel;
        private System.Windows.Forms.Label EmptyLineHeightLabel;
        private System.Windows.Forms.NumericUpDown EmptyLineHeightNumericUpDown;
        private System.Windows.Forms.Label EmptyLineHeightDescriptionLabel;
        private System.Windows.Forms.GroupBox MetricsPreviewGroupBox;
        private System.Windows.Forms.Panel MetricsPreviewPanel;
        private System.Windows.Forms.PictureBox MetricsPreviewPictureBox;
        private System.Windows.Forms.Label MetricsPreviewErrorLabel;
        private System.Windows.Forms.TableLayoutPanel KerningTableLayoutPanel;
        private System.Windows.Forms.SplitContainer KerningSplitContainer;
        private System.Windows.Forms.GroupBox KerningPreviewGroupBox;
        private System.Windows.Forms.Panel KerningPreviewPanel;
        private System.Windows.Forms.Label KerningPreviewErrorLabel;
        private System.Windows.Forms.PictureBox KerningPreviewPictureBox;
        private System.Windows.Forms.Label KerningDescriptionLabel;
        private System.Windows.Forms.DataGridView KerningDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn LeftCharColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RightCharColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn KerningColumn;
        private System.Windows.Forms.Button ApplyButton;
    }
}