using System;
using System.Windows.Forms;

#pragma warning disable IDE0003 // Remove 'this'

namespace FontEditor.Forms
{
    public partial class FontPropertiesForm : Form
    {
        public FontPropertiesForm()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

#pragma warning restore IDE0003 // Remove 'this'
