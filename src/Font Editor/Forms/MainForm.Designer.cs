namespace FontEditor.Forms
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainFormMenu = new System.Windows.Forms.MainMenu(this.components);
            this.FileMenuItem = new System.Windows.Forms.MenuItem();
            this.NewMenuItem = new System.Windows.Forms.MenuItem();
            this.OpenMenuItem = new System.Windows.Forms.MenuItem();
            this.SaveMenuItem = new System.Windows.Forms.MenuItem();
            this.SaveAsMenuItem = new System.Windows.Forms.MenuItem();
            this.ExitMenuItem = new System.Windows.Forms.MenuItem();
            this.EditMenuItem = new System.Windows.Forms.MenuItem();
            this.SetFontImageMenuItem = new System.Windows.Forms.MenuItem();
            this.FontPropertiesMenuItem = new System.Windows.Forms.MenuItem();
            this.HelpMenuItem = new System.Windows.Forms.MenuItem();
            this.AboutMenuItem = new System.Windows.Forms.MenuItem();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.MainToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.ImageContainerTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.MainPictureBox = new FontEditor.EditorPictureBox();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.FileToolStrip = new System.Windows.Forms.ToolStrip();
            this.NewToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.OpenToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.SaveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.CopyToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.PasteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.HelpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.EditingToolStrip = new System.Windows.Forms.ToolStrip();
            this.PanToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.CharacterSelectionToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.ColorPaletteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.OpenFontFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ImageImportFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ToolStripStatusFiller = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ZoomToolStripDropDownButton = new System.Windows.Forms.ToolStripSplitButton();
            this.ZoomLevelToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.SaveFontFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            this.MainToolStripContainer.ContentPanel.SuspendLayout();
            this.MainToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.MainToolStripContainer.SuspendLayout();
            this.ImageContainerTableLayoutPanel.SuspendLayout();
            this.FileToolStrip.SuspendLayout();
            this.EditingToolStrip.SuspendLayout();
            this.MainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainFormMenu
            // 
            this.MainFormMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.FileMenuItem,
            this.EditMenuItem,
            this.HelpMenuItem});
            // 
            // FileMenuItem
            // 
            this.FileMenuItem.Index = 0;
            this.FileMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.NewMenuItem,
            this.OpenMenuItem,
            this.SaveMenuItem,
            this.SaveAsMenuItem,
            this.ExitMenuItem});
            this.FileMenuItem.Text = "&File";
            // 
            // NewMenuItem
            // 
            this.NewMenuItem.Index = 0;
            this.NewMenuItem.Text = "&New";
            this.NewMenuItem.Click += new System.EventHandler(this.NewMenuItem_Click);
            // 
            // OpenMenuItem
            // 
            this.OpenMenuItem.Index = 1;
            this.OpenMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.OpenMenuItem.Text = "&Open";
            this.OpenMenuItem.Click += new System.EventHandler(this.OpenMenuItem_Click);
            // 
            // SaveMenuItem
            // 
            this.SaveMenuItem.Index = 2;
            this.SaveMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.SaveMenuItem.Text = "&Save";
            this.SaveMenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // SaveAsMenuItem
            // 
            this.SaveAsMenuItem.Index = 3;
            this.SaveAsMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftS;
            this.SaveAsMenuItem.Text = "Save &As...";
            this.SaveAsMenuItem.Click += new System.EventHandler(this.SaveAsMenuItem_Click);
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Index = 4;
            this.ExitMenuItem.Text = "E&xit";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // EditMenuItem
            // 
            this.EditMenuItem.Index = 1;
            this.EditMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.SetFontImageMenuItem,
            this.FontPropertiesMenuItem});
            this.EditMenuItem.Text = "&Edit";
            // 
            // SetFontImageMenuItem
            // 
            this.SetFontImageMenuItem.Index = 0;
            this.SetFontImageMenuItem.Text = "Set Font &Image...";
            this.SetFontImageMenuItem.Click += new System.EventHandler(this.SetFontImageMenuItem_Click);
            // 
            // FontPropertiesMenuItem
            // 
            this.FontPropertiesMenuItem.Enabled = false;
            this.FontPropertiesMenuItem.Index = 1;
            this.FontPropertiesMenuItem.Text = "Font &Properties";
            this.FontPropertiesMenuItem.Click += new System.EventHandler(this.FontPropertiesMenuItem_Click);
            // 
            // HelpMenuItem
            // 
            this.HelpMenuItem.Index = 2;
            this.HelpMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.AboutMenuItem});
            this.HelpMenuItem.Text = "&Help";
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.Index = 0;
            this.AboutMenuItem.Text = "&About";
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.MainToolStripContainer);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.AutoScroll = true;
            this.MainSplitContainer.Panel2Collapsed = true;
            this.MainSplitContainer.Size = new System.Drawing.Size(784, 540);
            this.MainSplitContainer.SplitterDistance = 755;
            this.MainSplitContainer.TabIndex = 0;
            // 
            // MainToolStripContainer
            // 
            // 
            // MainToolStripContainer.BottomToolStripPanel
            // 
            this.MainToolStripContainer.BottomToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // MainToolStripContainer.ContentPanel
            // 
            this.MainToolStripContainer.ContentPanel.Controls.Add(this.ImageContainerTableLayoutPanel);
            this.MainToolStripContainer.ContentPanel.Controls.Add(this.InfoLabel);
            this.MainToolStripContainer.ContentPanel.Size = new System.Drawing.Size(784, 513);
            this.MainToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // MainToolStripContainer.LeftToolStripPanel
            // 
            this.MainToolStripContainer.LeftToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MainToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.MainToolStripContainer.Name = "MainToolStripContainer";
            // 
            // MainToolStripContainer.RightToolStripPanel
            // 
            this.MainToolStripContainer.RightToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MainToolStripContainer.Size = new System.Drawing.Size(784, 540);
            this.MainToolStripContainer.TabIndex = 0;
            // 
            // MainToolStripContainer.TopToolStripPanel
            // 
            this.MainToolStripContainer.TopToolStripPanel.Controls.Add(this.FileToolStrip);
            this.MainToolStripContainer.TopToolStripPanel.Controls.Add(this.EditingToolStrip);
            this.MainToolStripContainer.TopToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // ImageContainerTableLayoutPanel
            // 
            this.ImageContainerTableLayoutPanel.AutoScroll = true;
            this.ImageContainerTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ImageContainerTableLayoutPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ImageContainerTableLayoutPanel.ColumnCount = 1;
            this.ImageContainerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ImageContainerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ImageContainerTableLayoutPanel.Controls.Add(this.MainPictureBox, 0, 0);
            this.ImageContainerTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageContainerTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.ImageContainerTableLayoutPanel.Name = "ImageContainerTableLayoutPanel";
            this.ImageContainerTableLayoutPanel.RowCount = 1;
            this.ImageContainerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ImageContainerTableLayoutPanel.Size = new System.Drawing.Size(784, 513);
            this.ImageContainerTableLayoutPanel.TabIndex = 0;
            // 
            // MainPictureBox
            // 
            this.MainPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MainPictureBox.BackgroundImage = global::FontEditor.Properties.Resources.Checkerboard;
            this.MainPictureBox.Location = new System.Drawing.Point(384, 248);
            this.MainPictureBox.Margin = new System.Windows.Forms.Padding(6);
            this.MainPictureBox.Name = "MainPictureBox";
            this.MainPictureBox.Size = new System.Drawing.Size(16, 16);
            this.MainPictureBox.TabIndex = 0;
            this.MainPictureBox.Text = "zoomablePictureBox1";
            this.MainPictureBox.BeginPan += new System.EventHandler<FontEditor.PanEventArgs>(this.MainPictureBox_BeginPan);
            this.MainPictureBox.BeginSelection += new System.EventHandler(this.MainPictureBox_BeginSelection);
            this.MainPictureBox.EditModeChanged += new System.EventHandler(this.MainPictureBox_EditModeChanged);
            this.MainPictureBox.EndPan += new System.EventHandler<FontEditor.PanEventArgs>(this.MainPictureBox_EndPan);
            this.MainPictureBox.EndSelection += new System.EventHandler<FontEditor.SelectionEventArgs>(this.MainPictureBox_EndSelection);
            this.MainPictureBox.Panning += new System.EventHandler<FontEditor.PanEventArgs>(this.MainPictureBox_Panning);
            this.MainPictureBox.SelectionChanged += new System.EventHandler<FontEditor.SelectionEventArgs>(this.MainPictureBox_SelectionChanged);
            this.MainPictureBox.ImageChanged += new System.EventHandler(this.MainPictureBox_ImageChanged);
            this.MainPictureBox.ZoomChanged += new System.EventHandler(this.MainPictureBox_ZoomChanged);
            this.MainPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPictureBox_Paint);
            // 
            // InfoLabel
            // 
            this.InfoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoLabel.Location = new System.Drawing.Point(0, 0);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(784, 513);
            this.InfoLabel.TabIndex = 1;
            this.InfoLabel.Text = "Use the menu to open a font, or\r\nimport an image into the current one.";
            this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.InfoLabel.Visible = false;
            // 
            // FileToolStrip
            // 
            this.FileToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.FileToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolStripButton,
            this.OpenToolStripButton,
            this.SaveToolStripButton,
            this.ToolStripSeparator1,
            this.CutToolStripButton,
            this.CopyToolStripButton,
            this.PasteToolStripButton,
            this.ToolStripSeparator2,
            this.HelpToolStripButton});
            this.FileToolStrip.Location = new System.Drawing.Point(3, 0);
            this.FileToolStrip.Name = "FileToolStrip";
            this.FileToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.FileToolStrip.Size = new System.Drawing.Size(192, 27);
            this.FileToolStrip.TabIndex = 0;
            // 
            // NewToolStripButton
            // 
            this.NewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NewToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("NewToolStripButton.Image")));
            this.NewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewToolStripButton.Name = "NewToolStripButton";
            this.NewToolStripButton.Padding = new System.Windows.Forms.Padding(2);
            this.NewToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.NewToolStripButton.Text = "&New";
            this.NewToolStripButton.Click += new System.EventHandler(this.NewToolStripButton_Click);
            // 
            // OpenToolStripButton
            // 
            this.OpenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OpenToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenToolStripButton.Image")));
            this.OpenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenToolStripButton.Name = "OpenToolStripButton";
            this.OpenToolStripButton.Padding = new System.Windows.Forms.Padding(2);
            this.OpenToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.OpenToolStripButton.Text = "&Open";
            this.OpenToolStripButton.Click += new System.EventHandler(this.OpenToolStripButton_Click);
            // 
            // SaveToolStripButton
            // 
            this.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveToolStripButton.Image")));
            this.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToolStripButton.Name = "SaveToolStripButton";
            this.SaveToolStripButton.Padding = new System.Windows.Forms.Padding(2);
            this.SaveToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.SaveToolStripButton.Text = "&Save";
            this.SaveToolStripButton.Click += new System.EventHandler(this.SaveToolStripButton_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // CutToolStripButton
            // 
            this.CutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("CutToolStripButton.Image")));
            this.CutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CutToolStripButton.Name = "CutToolStripButton";
            this.CutToolStripButton.Padding = new System.Windows.Forms.Padding(2);
            this.CutToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.CutToolStripButton.Text = "C&ut";
            // 
            // CopyToolStripButton
            // 
            this.CopyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CopyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("CopyToolStripButton.Image")));
            this.CopyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CopyToolStripButton.Name = "CopyToolStripButton";
            this.CopyToolStripButton.Padding = new System.Windows.Forms.Padding(2);
            this.CopyToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.CopyToolStripButton.Text = "&Copy";
            // 
            // PasteToolStripButton
            // 
            this.PasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("PasteToolStripButton.Image")));
            this.PasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PasteToolStripButton.Name = "PasteToolStripButton";
            this.PasteToolStripButton.Padding = new System.Windows.Forms.Padding(2);
            this.PasteToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.PasteToolStripButton.Text = "&Paste";
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // HelpToolStripButton
            // 
            this.HelpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HelpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("HelpToolStripButton.Image")));
            this.HelpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HelpToolStripButton.Name = "HelpToolStripButton";
            this.HelpToolStripButton.Padding = new System.Windows.Forms.Padding(2);
            this.HelpToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.HelpToolStripButton.Text = "He&lp";
            // 
            // EditingToolStrip
            // 
            this.EditingToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.EditingToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PanToolStripButton,
            this.CharacterSelectionToolStripButton,
            this.ColorPaletteToolStripButton});
            this.EditingToolStrip.Location = new System.Drawing.Point(195, 0);
            this.EditingToolStrip.Name = "EditingToolStrip";
            this.EditingToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.EditingToolStrip.Size = new System.Drawing.Size(114, 27);
            this.EditingToolStrip.TabIndex = 1;
            // 
            // PanToolStripButton
            // 
            this.PanToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PanToolStripButton.Image = global::FontEditor.Properties.Resources.Pan;
            this.PanToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PanToolStripButton.Name = "PanToolStripButton";
            this.PanToolStripButton.Padding = new System.Windows.Forms.Padding(2);
            this.PanToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.PanToolStripButton.Text = "Pan";
            this.PanToolStripButton.Click += new System.EventHandler(this.PanToolStripButton_Click);
            // 
            // CharacterSelectionToolStripButton
            // 
            this.CharacterSelectionToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CharacterSelectionToolStripButton.Image = global::FontEditor.Properties.Resources.Select;
            this.CharacterSelectionToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CharacterSelectionToolStripButton.Name = "CharacterSelectionToolStripButton";
            this.CharacterSelectionToolStripButton.Padding = new System.Windows.Forms.Padding(2);
            this.CharacterSelectionToolStripButton.Size = new System.Drawing.Size(24, 24);
            this.CharacterSelectionToolStripButton.Text = "Character selection";
            this.CharacterSelectionToolStripButton.Click += new System.EventHandler(this.CharacterSelectionToolStripButton_Click);
            // 
            // ColorPaletteToolStripButton
            // 
            this.ColorPaletteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ColorPaletteToolStripButton.Image = global::FontEditor.Properties.Resources.Palette;
            this.ColorPaletteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ColorPaletteToolStripButton.Name = "ColorPaletteToolStripButton";
            this.ColorPaletteToolStripButton.Size = new System.Drawing.Size(23, 24);
            this.ColorPaletteToolStripButton.Text = "Color palette";
            this.ColorPaletteToolStripButton.Click += new System.EventHandler(this.ColorPaletteToolStripButton_Click);
            // 
            // OpenFontFileDialog
            // 
            this.OpenFontFileDialog.Filter = "Doom Writer fonts (*.dwfont)|*.dwfont";
            this.OpenFontFileDialog.RestoreDirectory = true;
            // 
            // ImageImportFileDialog
            // 
            this.ImageImportFileDialog.Filter = "Images files (*.png; *.bmp; *.jpg; *.jpeg; *.gif; *.tif; *.tiff; *.tga)|*.png;*.b" +
    "mp;*.jpg;*.jpeg;*.gif;*.tif;*.tiff;*.tga";
            this.ImageImportFileDialog.RestoreDirectory = true;
            // 
            // ToolStripStatusFiller
            // 
            this.ToolStripStatusFiller.Name = "ToolStripStatusFiller";
            this.ToolStripStatusFiller.Size = new System.Drawing.Size(663, 17);
            this.ToolStripStatusFiller.Spring = true;
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.ToolStripStatusFiller,
            this.ZoomToolStripDropDownButton});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 540);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(784, 22);
            this.MainStatusStrip.TabIndex = 1;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(39, 17);
            this.StatusLabel.Text = "Status";
            // 
            // ZoomToolStripDropDownButton
            // 
            this.ZoomToolStripDropDownButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ZoomToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZoomLevelToolStripTextBox});
            this.ZoomToolStripDropDownButton.Image = global::FontEditor.Properties.Resources.MagnifyingGlass;
            this.ZoomToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomToolStripDropDownButton.Name = "ZoomToolStripDropDownButton";
            this.ZoomToolStripDropDownButton.Size = new System.Drawing.Size(67, 20);
            this.ZoomToolStripDropDownButton.Text = "100%";
            this.ZoomToolStripDropDownButton.ToolTipText = "Zoom level";
            this.ZoomToolStripDropDownButton.ButtonClick += new System.EventHandler(this.ZoomToolStripDropDownButton_ButtonClick);
            // 
            // ZoomLevelToolStripTextBox
            // 
            this.ZoomLevelToolStripTextBox.MaxLength = 4;
            this.ZoomLevelToolStripTextBox.Name = "ZoomLevelToolStripTextBox";
            this.ZoomLevelToolStripTextBox.Size = new System.Drawing.Size(100, 23);
            this.ZoomLevelToolStripTextBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ZoomLevelToolStripTextBox.LostFocus += new System.EventHandler(this.ZoomLevelToolStripTextBox_LostFocus);
            this.ZoomLevelToolStripTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ZoomLevelToolStripTextBox_KeyDown);
            // 
            // SaveFontFileDialog
            // 
            this.SaveFontFileDialog.Filter = "Doom Writer fonts (*.dwfont)|*.dwfont";
            this.SaveFontFileDialog.RestoreDirectory = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.MainSplitContainer);
            this.Controls.Add(this.MainStatusStrip);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doom Writer Font Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.MainToolStripContainer.ContentPanel.ResumeLayout(false);
            this.MainToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.MainToolStripContainer.TopToolStripPanel.PerformLayout();
            this.MainToolStripContainer.ResumeLayout(false);
            this.MainToolStripContainer.PerformLayout();
            this.ImageContainerTableLayoutPanel.ResumeLayout(false);
            this.FileToolStrip.ResumeLayout(false);
            this.FileToolStrip.PerformLayout();
            this.EditingToolStrip.ResumeLayout(false);
            this.EditingToolStrip.PerformLayout();
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MainMenu MainFormMenu;
        private System.Windows.Forms.MenuItem FileMenuItem;
        private System.Windows.Forms.MenuItem NewMenuItem;
        private System.Windows.Forms.MenuItem OpenMenuItem;
        private System.Windows.Forms.MenuItem SaveMenuItem;
        private System.Windows.Forms.MenuItem SaveAsMenuItem;
        private System.Windows.Forms.MenuItem ExitMenuItem;
        private System.Windows.Forms.MenuItem HelpMenuItem;
        private System.Windows.Forms.MenuItem AboutMenuItem;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.ToolStripContainer MainToolStripContainer;
        private System.Windows.Forms.ToolStrip FileToolStrip;
        private System.Windows.Forms.ToolStripButton NewToolStripButton;
        private System.Windows.Forms.ToolStripButton OpenToolStripButton;
        private System.Windows.Forms.ToolStripButton SaveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        private System.Windows.Forms.ToolStripButton CutToolStripButton;
        private System.Windows.Forms.ToolStripButton CopyToolStripButton;
        private System.Windows.Forms.ToolStripButton PasteToolStripButton;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        private System.Windows.Forms.ToolStripButton HelpToolStripButton;
        private System.Windows.Forms.TableLayoutPanel ImageContainerTableLayoutPanel;
        private EditorPictureBox MainPictureBox;
        private System.Windows.Forms.Label InfoLabel;
        private System.Windows.Forms.MenuItem SetFontImageMenuItem;
        private System.Windows.Forms.OpenFileDialog OpenFontFileDialog;
        private System.Windows.Forms.OpenFileDialog ImageImportFileDialog;
        private System.Windows.Forms.ToolStrip EditingToolStrip;
        private System.Windows.Forms.ToolStripButton PanToolStripButton;
        private System.Windows.Forms.ToolStripButton CharacterSelectionToolStripButton;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusFiller;
        private System.Windows.Forms.ToolStripSplitButton ZoomToolStripDropDownButton;
        private System.Windows.Forms.ToolStripTextBox ZoomLevelToolStripTextBox;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ToolStripButton ColorPaletteToolStripButton;
        private System.Windows.Forms.MenuItem EditMenuItem;
        private System.Windows.Forms.MenuItem FontPropertiesMenuItem;
        private System.Windows.Forms.SaveFileDialog SaveFontFileDialog;
    }
}