namespace FontEditor
{
    partial class PaletteViewer
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
            this.MainFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.ColorLabel = new System.Windows.Forms.Label();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.MainTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayoutPanel
            // 
            this.MainTableLayoutPanel.ColumnCount = 1;
            this.MainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTableLayoutPanel.Controls.Add(this.TitleLabel, 0, 0);
            this.MainTableLayoutPanel.Controls.Add(this.MainFlowLayoutPanel, 0, 3);
            this.MainTableLayoutPanel.Controls.Add(this.ColorLabel, 0, 2);
            this.MainTableLayoutPanel.Controls.Add(this.InfoLabel, 0, 1);
            this.MainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayoutPanel.Name = "MainTableLayoutPanel";
            this.MainTableLayoutPanel.RowCount = 4;
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainTableLayoutPanel.Size = new System.Drawing.Size(240, 240);
            this.MainTableLayoutPanel.TabIndex = 0;
            // 
            // MainFlowLayoutPanel
            // 
            this.MainFlowLayoutPanel.AutoScroll = true;
            this.MainFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainFlowLayoutPanel.Location = new System.Drawing.Point(0, 73);
            this.MainFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainFlowLayoutPanel.Name = "MainFlowLayoutPanel";
            this.MainFlowLayoutPanel.Size = new System.Drawing.Size(240, 167);
            this.MainFlowLayoutPanel.TabIndex = 1;
            // 
            // TitleLabel
            // 
            this.TitleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TitleLabel.AutoSize = true;
            this.MainTableLayoutPanel.SetColumnSpan(this.TitleLabel, 2);
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(63, 6);
            this.TitleLabel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 3);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(113, 20);
            this.TitleLabel.TabIndex = 2;
            this.TitleLabel.Text = "Color Palette";
            // 
            // ColorLabel
            // 
            this.ColorLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ColorLabel.AutoSize = true;
            this.ColorLabel.Location = new System.Drawing.Point(91, 54);
            this.ColorLabel.Margin = new System.Windows.Forms.Padding(6);
            this.ColorLabel.Name = "ColorLabel";
            this.ColorLabel.Size = new System.Drawing.Size(58, 13);
            this.ColorLabel.TabIndex = 3;
            this.ColorLabel.Text = "(Color Info)";
            // 
            // InfoLabel
            // 
            this.InfoLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Location = new System.Drawing.Point(98, 29);
            this.InfoLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(44, 13);
            this.InfoLabel.TabIndex = 4;
            this.InfoLabel.Text = "0 colors";
            // 
            // PaletteViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainTableLayoutPanel);
            this.Name = "PaletteViewer";
            this.Size = new System.Drawing.Size(240, 240);
            this.MainTableLayoutPanel.ResumeLayout(false);
            this.MainTableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel MainFlowLayoutPanel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.Label ColorLabel;
        private System.Windows.Forms.Label InfoLabel;
    }
}
