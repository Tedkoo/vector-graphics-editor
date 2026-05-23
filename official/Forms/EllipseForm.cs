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
    public partial class EllipseForm : Form
    { 

        private Ellipse _ellipse;

        public Ellipse Ellipse

        {
            get { return _ellipse; }
            set
            {
                _ellipse = value;

                textBoxWidth.Text = _ellipse.SmallRadius.ToString();
                textBoxHeight.Text = _ellipse.LargeRadius.ToString();
            }
        }

        public EllipseForm()
        {
            InitializeComponent();

            this.KeyPreview = true;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxWidth.Text, out int width))
                _ellipse.SmallRadius = width;
            if (int.TryParse(textBoxHeight.Text, out int height))
                _ellipse.LargeRadius = height;

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void EllipseForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel.PerformClick();

            if (e.KeyCode == Keys.Enter)
                btnOk.PerformClick();

            if(e.KeyCode == Keys.Down)
                textBoxHeight.Focus();

            if (e.KeyCode == Keys.Up)
                textBoxWidth.Focus();
        }
    }
}
