using System;
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
        private static readonly Cursor HandOpen     = CursorHelper.FromByteArray(Properties.Resources.CursorHandOpen);
        private static readonly Cursor HandGrabbing = CursorHelper.FromByteArray(Properties.Resources.CursorHandGrabbing);

        private static readonly Pen   SelectionPen   = new Pen(Color.Black, 1.0f) { DashStyle = DashStyle.Dash };
        private static readonly Brush SelectionBrush = new SolidBrush(Color.FromArgb(127, 118, 184, 242));
        private static readonly Brush CharacterBrush = new SolidBrush(Color.FromArgb(127, Color.Yellow));

        private static readonly HashSet<Keys> AcceptedNumericKeyCodes = new HashSet<Keys>() {
            Keys.Enter, Keys.Back, Keys.Delete, Keys.Home, Keys.End, Keys.Left, Keys.Right, Keys.Up, Keys.Down,
            Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9,
            Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, Keys.NumPad5,
            Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9
        };

        private EditMode editMode;
        private Point imageMouseLastPosition;
        private Point imageMouseClickPosition;

        private bool selecting = false;
        private Rectangle selectionRectangle;
        private Rectangle? selectedCharacterBounds;

        private CharacterMappingControl characterMappingsControl = new CharacterMappingControl() { Dock = DockStyle.Fill };

        public MainForm()
        {
            InitializeComponent();
            StatusLabel.Text = "";
            MainPictureBox_ImageChanged(MainPictureBox, EventArgs.Empty);
        }

        private void SetEditMode(EditMode mode)
        {
            if(editMode == mode)
                return;

            editMode = mode;

            foreach(var item in EditingToolStrip.Items.OfType<ToolStripButton>())
            {
                item.Checked = false;
            }

            if(WindowState != FormWindowState.Maximized)
                Width -= MainSplitContainer.Panel2.Width;

            MainPictureBox.Cursor = Cursors.Default;
            MainPictureBox.Invalidate();

            MainSplitContainer.Panel2Collapsed = true;
            MainSplitContainer.Panel2.Controls.Clear();

            switch(mode)
            {
                case EditMode.CharacterSelect:
                    CharacterSelectionToolStripButton.Checked = true;
                    MainPictureBox.Cursor = Cursors.Cross;

                    MainSplitContainer.SplitterDistance = ClientSize.Width - characterMappingsControl.Width - MainSplitContainer.SplitterWidth;
                    MainSplitContainer.Panel2Collapsed = false;
                    MainSplitContainer.Panel2.Controls.Add(characterMappingsControl);
                    MainSplitContainer.Refresh();

                    if(WindowState != FormWindowState.Maximized)
                        Width += MainSplitContainer.Panel2.Width;
                    break;

                case EditMode.Pan:
                default:
                    editMode = EditMode.Pan;
                    PanToolStripButton.Checked = true;
                    MainPictureBox.Cursor = HandOpen;
                    break;
            }
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
            if(keyData == Keys.Escape && selecting)
            {
                selecting = false;
                
                StatusLabel.Text = "";
                MainPictureBox.Invalidate();

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

            SetEditMode(EditMode.Pan);
        }

        private void MainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Middle || (editMode == EditMode.Pan && e.Button == MouseButtons.Left))
            {
                if(editMode == EditMode.Pan)
                    MainPictureBox.Cursor = HandGrabbing;

                imageMouseLastPosition = ImageContainerTableLayoutPanel.AutoScrollPosition;
                imageMouseClickPosition = e.Location;
            }
            else if(editMode == EditMode.CharacterSelect && e.Button == MouseButtons.Left)
            {
                selecting = true;
                imageMouseClickPosition = e.Location;
            }
        }

        private void MainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Middle || (editMode == EditMode.Pan && e.Button == MouseButtons.Left))
            {
                ImageContainerTableLayoutPanel.AutoScrollPosition = new Point(
                    imageMouseClickPosition.X - e.X - imageMouseLastPosition.X,
                    imageMouseClickPosition.Y - e.Y - imageMouseLastPosition.Y
                );

                imageMouseLastPosition = ImageContainerTableLayoutPanel.AutoScrollPosition;
            }
            else if(editMode == EditMode.CharacterSelect && selecting)
            {
                double zoomLevel = MainPictureBox.Zoom;

                Point point = new Point(
                    (int)(Math.Floor(e.X / zoomLevel) * zoomLevel),
                    (int)(Math.Floor(e.Y / zoomLevel) * zoomLevel)
                );

                Point clickPoint = new Point(
                    (int)(Math.Floor(imageMouseClickPosition.X / zoomLevel) * zoomLevel),
                    (int)(Math.Floor(imageMouseClickPosition.Y / zoomLevel) * zoomLevel)
                );

                int x = clickPoint.X <= point.X ? clickPoint.X : point.X;
                int y = clickPoint.Y <= point.Y ? clickPoint.Y : point.Y;
                int w = clickPoint.X <= point.X ? point.X - clickPoint.X : clickPoint.X - point.X;
                int h = clickPoint.Y <= point.Y ? point.Y - clickPoint.Y : clickPoint.Y - point.Y;

                x = (int)Math.Round(x / zoomLevel);
                y = (int)Math.Round(y / zoomLevel);
                w = (int)Math.Round(w / zoomLevel) + 1;
                h = (int)Math.Round(h / zoomLevel) + 1;

                StatusLabel.Text = $"Origin: ({x}, {y}). Size: {w} x {h}";
                MainStatusStrip.Refresh();

                selectionRectangle = new Rectangle(x, y, w, h);
                MainPictureBox.Invalidate();
            }
        }

        private void MainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            switch(editMode)
            {
                case EditMode.Pan:
                    MainPictureBox.Cursor = HandOpen;
                    break;

                case EditMode.CharacterSelect:
                    if(e.Button != MouseButtons.Left || !selecting)
                        break;

                    StatusLabel.Text = "";
                    MainPictureBox.Invalidate();

                    var rect = selectionRectangle.Clamp(new Rectangle(Point.Empty, MainPictureBox.Image.Size));

                    characterMappingsControl.SetCurrentCharacterBounds(rect, true);
                    break;
            }

            selecting = false;
        }

        private void MainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if(selectedCharacterBounds.HasValue && editMode == EditMode.CharacterSelect)
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

            if(selecting)
            {
                var zoomLevel = (float)MainPictureBox.Zoom;

                e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
                e.Graphics.FillRectangle(SelectionBrush,
                    zoomLevel * selectionRectangle.X + 0.5f,
                    zoomLevel * selectionRectangle.Y + 0.5f,
                    zoomLevel * selectionRectangle.Width - 0.5f,
                    zoomLevel * selectionRectangle.Height - 0.5f
                );
                e.Graphics.DrawRectangle(SelectionPen, 
                    zoomLevel * selectionRectangle.X + 0.5f,
                    zoomLevel * selectionRectangle.Y + 0.5f,
                    zoomLevel * selectionRectangle.Width - 0.5f,
                    zoomLevel * selectionRectangle.Height - 0.5f
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
            SetEditMode(EditMode.Pan);
        }

        private void CharacterSelectionToolStripButton_Click(object sender, EventArgs e)
        {
            SetEditMode(EditMode.CharacterSelect);
        }
    }
}

#pragma warning restore IDE0003 // Remove 'this'
