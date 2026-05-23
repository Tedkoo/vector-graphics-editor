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
    public partial class PentagonForm : Form
    {

        private Pentagon _pentagon;

        public Pentagon Pentagon
        {
            get { return _pentagon; }
            set
            {
                _pentagon = value;

                textBoxRadius.Text = _pentagon.Radius.ToString();
                textBoxSide.Text = _pentagon.Side.ToString();
            }
        }
        public PentagonForm()
        {
            InitializeComponent();

            this.KeyPreview = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxRadius.Text, out int radius))
                _pentagon.Radius = radius;
            if (int.TryParse(textBoxSide.Text, out int side))   
                _pentagon.Side = side;

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void PentagonForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel.PerformClick();

            if (e.KeyCode == Keys.Enter)
                btnOk.PerformClick();

            if(e.KeyCode == Keys.Down)
                textBoxRadius.Focus();

            if (e.KeyCode == Keys.Up)
                textBoxSide.Focus();
        }
    }
}
