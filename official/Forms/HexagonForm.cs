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
    public partial class HexagonForm : Form
    {
        private Hexagon _hexagon;

        public Hexagon Hexagon
        {
            get { return _hexagon; }
            set
            {
                _hexagon = value;

                textBoxRadius.Text = _hexagon.Radius.ToString();
                textBoxSide.Text = _hexagon.Side.ToString();
            }
        }
        public HexagonForm()
        {
            InitializeComponent();

            this.KeyPreview = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(int.TryParse (textBoxRadius.Text, out int radius))
                _hexagon.Radius = radius;

            if(int.TryParse (textBoxSide.Text, out int side))
                _hexagon.Side = side;

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void HexagonForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel.PerformClick();

            if (e.KeyCode == Keys.Enter)
                btnOk.PerformClick();

            if (e.KeyCode == Keys.Down)
                textBoxSide.Focus();

            if(e.KeyCode == Keys.Up)
                textBoxRadius.Focus();
        }
    }
}
