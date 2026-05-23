using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace official.Forms
{
    public partial class RombForm : Form
    {
        private Romb _romb;

        public Romb Romb
        {
            get { return _romb; }
            set
            {
                _romb = value;

                textBoxHeight.Text = _romb.Height.ToString();
                textBoxWidth.Text = _romb.Width.ToString();
            }
        }
        public RombForm()
        {
            InitializeComponent();

            this.KeyPreview = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(int.TryParse(textBoxWidth.Text, out int width))
                _romb.Width = width;

            if(int.TryParse(textBoxHeight.Text, out int height))
                _romb.Height = height;

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void RombForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel.PerformClick();

            if (e.KeyCode == Keys.Enter)
                btnOK.PerformClick();

            if(e.KeyCode == Keys.Down)
                textBoxWidth.Focus();

            if(e.KeyCode == Keys.Up)
                textBoxHeight.Focus();
        }
    }
}
