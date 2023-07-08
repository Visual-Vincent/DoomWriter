using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DoomWriter.FontEditor
{
    public partial class MainForm : Form
    {
        private static readonly HashSet<Keys> AcceptedNumericKeyCodes = new HashSet<Keys>() {
            Keys.Enter, Keys.Back, Keys.Delete, Keys.Home, Keys.End, Keys.Left, Keys.Right, Keys.Up, Keys.Down,
            Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9,
            Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, Keys.NumPad5,
            Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9
        };

        public MainForm()
        {
            InitializeComponent();
            MainPictureBox_ImageChanged(MainPictureBox, EventArgs.Empty);
        }

        private void SetImageZoom(double ratio)
        {
            if(MainPictureBox.Zoom == ratio)
                return;

            ImageContainerTableLayoutPanel.AutoScroll = false;
            MainPictureBox.Zoom = ratio;
            ImageContainerTableLayoutPanel.AutoScroll = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
#pragma warning disable IDE0003 // Remove 'this'
            this.Menu = MainFormMenu;
#pragma warning restore IDE0003

            ToolStripManager.RenderMode = ToolStripManagerRenderMode.System;
            ToolStripManager.LoadSettings(this);

            foreach(int zoomLevel in new int[] { 25, 50, 75, 100, 150, 200, 300, 400, 800, 1600 })
            {
                var button = new ToolStripMenuItem($"{zoomLevel}%") { Name = $"Zoom{zoomLevel}ToolStripMenuItem" };
                
                button.Click += ZoomToolStripMenuItem_Click;
                button.Tag = zoomLevel / 100.0;

                if(zoomLevel == 100)
                    button.Checked = true;

                ZoomToolStripDropDownButton.DropDownItems.Insert(0, button);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ToolStripManager.SaveSettings(this);
        }

        private void MainPictureBox_ImageChanged(object sender, EventArgs e)
        {
            bool hasImage = MainPictureBox.Image != null;

            ImageContainerTableLayoutPanel.Visible = hasImage;
            InfoLabel.Visible = !hasImage;
            ZoomToolStripDropDownButton.Enabled = hasImage;
        }

        private void MainPictureBox_ZoomChanged(object sender, EventArgs e)
        {
            var zoomLevel = MainPictureBox.Zoom;

            foreach(var menuItem in ZoomToolStripDropDownButton.DropDownItems.OfType<ToolStripMenuItem>().Where(m => m.Tag != null && m.Tag is double))
            {
                menuItem.Checked = (double)menuItem.Tag == zoomLevel;
            }

            ZoomToolStripDropDownButton.Text = $"{Math.Round(zoomLevel * 100.0, 1)}%";
        }

        private void ZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!(sender is ToolStripMenuItem menuItem) || menuItem.Tag == null || !(menuItem.Tag is double))
                return;

            SetImageZoom((double)menuItem.Tag);
        }

        private void ZoomToolStripDropDownButton_ButtonClick(object sender, EventArgs e)
        {
            var menuItems = ZoomToolStripDropDownButton.DropDownItems
                .OfType<ToolStripMenuItem>()
                .Where(m => m.Tag != null && m.Tag is double)
                .ToArray();

            ToolStripMenuItem selectedItem = menuItems.Where(m => m.Checked).FirstOrDefault();
            ToolStripMenuItem nextItem = null;

        retry:
            if(selectedItem == null)
            {
                nextItem = menuItems.Single(m => (double)m.Tag == 1.0);
            }
            else
            {
                int index = Array.IndexOf(menuItems, selectedItem);

                if(index < 1)
                {
                    selectedItem = null;
                    goto retry;
                }

                nextItem = menuItems[index - 1];
            }
            
            SetImageZoom((double)nextItem.Tag);
        }

        private void ZoomLevelToolStripTextBox_LostFocus(object sender, EventArgs e)
        {
            string text = ZoomLevelToolStripTextBox.Text;

            if(string.IsNullOrWhiteSpace(text))
            {
                ZoomLevelToolStripTextBox.Text = "";
                return;
            }

            if(!ushort.TryParse(text, out var zoomLevel) || zoomLevel <= 0)
            {
                ZoomLevelToolStripTextBox.Text = "";
                MessageBox.Show($"'{text}' is not a valid zoom level.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SetImageZoom(zoomLevel / 100.0);
        }

        private void ZoomLevelToolStripTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(!AcceptedNumericKeyCodes.Contains(e.KeyCode))
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }

            if(e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;
            e.Handled = true;

            ZoomLevelToolStripTextBox_LostFocus(sender, e);
        }
    }
}
