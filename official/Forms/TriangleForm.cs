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
    public partial class TriangleForm : Form
    {

        private Triangle _triangle;

        public Triangle Triangle
        {
            get
            { return _triangle; }

            set
            {
                _triangle = value;

                textBoxWidth.Text = _triangle.Width.ToString();
                textBoxHeight.Text = _triangle.Height.ToString();
            }
        }
        public TriangleForm()
        {
            InitializeComponent();

            this.KeyPreview = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(int.TryParse(textBoxWidth.Text, out int width)) 
                _triangle.Width = width;

            if(int.TryParse(textBoxHeight.Text, out int height))
                _triangle.Height = height;

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TriangleForm_Load(object sender, EventArgs e)
        {

        }

        private void TriangleForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                btnCancel.PerformClick();

            if(e.KeyCode == Keys.Enter) 
                btnOk.PerformClick();

            if(e.KeyCode == Keys.Down)
                textBoxHeight.Focus();

            if(e.KeyCode == Keys.Up)
                textBoxWidth.Focus();
        }
    }
}
