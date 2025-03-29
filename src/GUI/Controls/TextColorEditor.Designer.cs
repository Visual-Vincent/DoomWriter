namespace DoomWriter.GUI.Controls
{
    partial class TextColorEditor
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
            this.EditCheckBox = new System.Windows.Forms.CheckBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.RangesPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // EditCheckBox
            // 
            this.EditCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.EditCheckBox.AutoSize = true;
            this.EditCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.EditCheckBox.Location = new System.Drawing.Point(0, 0);
            this.EditCheckBox.Name = "EditCheckBox";
            this.EditCheckBox.Size = new System.Drawing.Size(232, 23);
            this.EditCheckBox.TabIndex = 0;
            this.EditCheckBox.Text = " ";
            this.EditCheckBox.UseVisualStyleBackColor = true;
            this.EditCheckBox.CheckedChanged += new System.EventHandler(this.EditCheckBox_CheckedChanged);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.NameTextBox.Location = new System.Drawing.Point(0, 23);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(232, 20);
            this.NameTextBox.TabIndex = 1;
            this.NameTextBox.Visible = false;
            this.NameTextBox.TextChanged += new System.EventHandler(this.NameTextBox_TextChanged);
            // 
            // AddButton
            // 
            this.AddButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AddButton.Image = global::DoomWriter.GUI.Properties.Resources.Add;
            this.AddButton.Location = new System.Drawing.Point(0, 97);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(232, 23);
            this.AddButton.TabIndex = 999999;
            this.AddButton.Visible = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // RangesPanel
            // 
            this.RangesPanel.AutoSize = true;
            this.RangesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RangesPanel.Location = new System.Drawing.Point(0, 43);
            this.RangesPanel.Name = "RangesPanel";
            this.RangesPanel.Size = new System.Drawing.Size(232, 54);
            this.RangesPanel.TabIndex = 1000000;
            // 
            // TextColorEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.RangesPanel);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.EditCheckBox);
            this.Name = "TextColorEditor";
            this.Size = new System.Drawing.Size(232, 120);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox EditCheckBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Panel RangesPanel;
    }
}
