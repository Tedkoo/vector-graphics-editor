using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace official
{
    public partial class RectangleForm : Form
    {
        private Rectangle _rectangle;

        public Rectangle Rectangle
        {
            get { return _rectangle; }
            set 
            {
                _rectangle = value;

                textBoxHeight.Text = _rectangle.Height.ToString();
                textBoxWidth.Text = _rectangle.Width.ToString();
            }
        }
        public RectangleForm()
        {
            InitializeComponent();

            this.KeyPreview = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxHeight.Text, out int height)) 
                _rectangle.Height = height;

            if (int.TryParse(textBoxWidth.Text, out int width))
                _rectangle.Width = width;

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void RectangleForm_Load(object sender, EventArgs e)
        {

        }

        private void RectangleForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                btnCancel.PerformClick();

            if(e.KeyCode == Keys.Enter)
                btnOK.PerformClick();

            if(e.KeyCode == Keys.Down)
                textBoxWidth.Focus();

            if(e.KeyCode == Keys.Up)
                textBoxHeight.Focus();
        }
    }
}
