﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using DoomWriter;

using Image = System.Drawing.Image;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;
using Rectangle = System.Drawing.Rectangle;

#pragma warning disable IDE0003 // Remove 'this'

namespace FontEditor
{
    public partial class MainForm : Form
    {
        private static readonly Pen SelectionPen = new Pen(Color.Black, 1.0f) { DashStyle = DashStyle.Dash };
        private static readonly Brush CharacterBrush = new SolidBrush(Color.FromArgb(127, Color.Yellow));

        private static readonly HashSet<Keys> AcceptedNumericKeyCodes = new HashSet<Keys>() {
            Keys.Enter, Keys.Back, Keys.Delete, Keys.Home, Keys.End, Keys.Left, Keys.Right, Keys.Up, Keys.Down,
            Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9,
            Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, Keys.NumPad5,
            Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9
        };

        private CharacterMappingControl characterMappingsControl = new CharacterMappingControl() { Dock = DockStyle.Fill };
        private readonly PaletteViewer paletteViewer = new PaletteViewer() { Dock = DockStyle.Fill };

        private Point panMouseLastPosition;
        private Rectangle? selectedCharacterBounds;

        public MainForm()
        {
            InitializeComponent();
            StatusLabel.Text = "";
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Escape && MainPictureBox.IsSelecting)
            {
                MainPictureBox.CancelSelection();
                StatusLabel.Text = "";

                return true;
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Menu = MainFormMenu;

            ToolStripManager.RenderMode = ToolStripManagerRenderMode.System;
            ToolStripManager.LoadSettings(this);

            characterMappingsControl.SelectionChanged += CharacterMappingsControl_SelectionChanged;

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

        private void MainPictureBox_EditModeChanged(object sender, EventArgs e)
        {
            foreach(var item in EditingToolStrip.Items.OfType<ToolStripButton>())
            {
                item.Checked = false;
            }

            if(WindowState != FormWindowState.Maximized)
                Width -= MainSplitContainer.Panel2.Width;

            MainSplitContainer.Panel2Collapsed = true;
            MainSplitContainer.Panel2.Controls.Clear();

            switch(MainPictureBox.EditMode)
            {
                case EditMode.None:
                    break;

                case EditMode.CharacterSelect:
                    CharacterSelectionToolStripButton.Checked = true;

                    MainSplitContainer.SplitterDistance = ClientSize.Width - characterMappingsControl.Width - MainSplitContainer.SplitterWidth;
                    MainSplitContainer.Panel2Collapsed = false;
                    MainSplitContainer.Panel2.Controls.Add(characterMappingsControl);
                    MainSplitContainer.Refresh();

                    if(WindowState != FormWindowState.Maximized)
                        Width += MainSplitContainer.Panel2.Width;
                    break;

                case EditMode.PaletteView:
                    ColorPaletteToolStripButton.Checked = true;

                    MainSplitContainer.SplitterDistance = ClientSize.Width - paletteViewer.Width - MainSplitContainer.SplitterWidth;
                    MainSplitContainer.Panel2Collapsed = false;
                    MainSplitContainer.Panel2.Controls.Add(paletteViewer);
                    MainSplitContainer.Refresh();

                    var palette = MainPictureBox.Image.GetColorPalette(true);
                    paletteViewer.SetPalette(palette, true);

                    if(WindowState != FormWindowState.Maximized)
                        Width += MainSplitContainer.Panel2.Width;
                    break;

                case EditMode.Pan:
                default:
                    PanToolStripButton.Checked = true;
                    break;
            }
        }

        private void MainPictureBox_ImageChanged(object sender, EventArgs e)
        {
            bool hasImage = MainPictureBox.Image != null;

            ImageContainerTableLayoutPanel.Visible = hasImage;
            InfoLabel.Visible = !hasImage;
            ZoomToolStripDropDownButton.Enabled = hasImage;

            foreach(var item in EditingToolStrip.Items.OfType<ToolStripItem>())
            {
                item.Enabled = hasImage;
            }

            MainPictureBox.EditMode = EditMode.Pan;
        }

        private void MainPictureBox_BeginPan(object sender, PanEventArgs e)
        {
            panMouseLastPosition = ImageContainerTableLayoutPanel.AutoScrollPosition;
        }

        private void MainPictureBox_Panning(object sender, PanEventArgs e)
        {
            ImageContainerTableLayoutPanel.AutoScrollPosition = new Point(
                e.StartLocation.X - e.Location.X - panMouseLastPosition.X,
                e.StartLocation.Y - e.Location.Y - panMouseLastPosition.Y
            );

            panMouseLastPosition = ImageContainerTableLayoutPanel.AutoScrollPosition;
        }

        private void MainPictureBox_EndPan(object sender, PanEventArgs e)
        {
            // No-op
        }

        private void MainPictureBox_BeginSelection(object sender, EventArgs e)
        {
            // No-op
        }

        private void MainPictureBox_SelectionChanged(object sender, SelectionEventArgs e)
        {
            StatusLabel.Text = $"Origin: ({e.Selection.X}, {e.Selection.Y}). Size: {e.Selection.Width} x {e.Selection.Height}";
            MainStatusStrip.Refresh();
        }

        private void MainPictureBox_EndSelection(object sender, SelectionEventArgs e)
        {
            StatusLabel.Text = "";
            characterMappingsControl.SetCurrentCharacterBounds(e.Selection, true);
        }

        private void MainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if(selectedCharacterBounds.HasValue && MainPictureBox.EditMode == EditMode.CharacterSelect)
            {
                var rect = selectedCharacterBounds.Value;
                var zoomLevel = (float)MainPictureBox.Zoom;

                e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
                e.Graphics.FillRectangle(CharacterBrush,
                    zoomLevel * rect.X + 0.5f,
                    zoomLevel * rect.Y + 0.5f,
                    zoomLevel * rect.Width - 0.5f,
                    zoomLevel * rect.Height - 0.5f
                );
                e.Graphics.DrawRectangle(SelectionPen,
                    zoomLevel * rect.X + 0.5f,
                    zoomLevel * rect.Y + 0.5f,
                    zoomLevel * rect.Width - 0.5f,
                    zoomLevel * rect.Height - 0.5f
                );
            }
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

        private void CharacterMappingsControl_SelectionChanged(object sender, EventArgs e)
        {
            selectedCharacterBounds = characterMappingsControl.SelectedCharacterMapping;
            MainPictureBox.Invalidate();
        }

        private void NewMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SaveAsMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SetFontImageMenuItem_Click(object sender, EventArgs e)
        {
            if(MainPictureBox.Image != null)
            {
                if(MessageBox.Show("Are you sure you want to replace the current font image?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;
            }

            if(ImageImportFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                MainPictureBox.Image = Image.FromFile(ImageImportFileDialog.FileName);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Failed to load image:" + Environment.NewLine + $"{ex.GetType().FullName}: {ex.Message}", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PanToolStripButton_Click(object sender, EventArgs e)
        {
            MainPictureBox.EditMode = EditMode.Pan;
        }

        private void CharacterSelectionToolStripButton_Click(object sender, EventArgs e)
        {
            MainPictureBox.EditMode = EditMode.CharacterSelect;
        }

        private void ColorPaletteToolStripButton_Click(object sender, EventArgs e)
        {
            MainPictureBox.EditMode = EditMode.PaletteView;
        }
    }
}

#pragma warning restore IDE0003 // Remove 'this'
