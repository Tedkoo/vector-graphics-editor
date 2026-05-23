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
    public partial class TrapezoidForm : Form
    {

        private Trapezoid _trapezoid;

        public Trapezoid Trapezoid
        {
            get { return _trapezoid; }
            set
            {
                _trapezoid = value;

                textBoxBaseBot.Text = _trapezoid.BaseBot.ToString();
                textBoxBaseUp.Text = _trapezoid.BaseUp.ToString();
                textBoxHeight.Text = _trapezoid.Height.ToString();
            }
        }
        public TrapezoidForm()
        {
            InitializeComponent();

            this.KeyPreview = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(int.TryParse(textBoxBaseBot.Text, out int baseBot))
                _trapezoid.BaseBot = baseBot;

            if(int.TryParse(textBoxBaseUp.Text, out int upBot))
                _trapezoid.BaseUp = upBot;

            if (int.TryParse(textBoxHeight.Text, out int height))
                    _trapezoid.Height = height;

            DialogResult = DialogResult.OK;
        }

        private void TrapezoidForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                btnCancel.PerformClick();

            if (e.KeyCode == Keys.Enter)
                btnOk.PerformClick();

            if(e.KeyCode == Keys.Down)
            {
                if(textBoxBaseUp.Focused)
                    textBoxBaseBot.Focus();
                else
                    textBoxHeight.Focus();
            }

            if(e.KeyCode == Keys.Up)
            {
                if(textBoxHeight.Focused)
                    textBoxBaseBot.Focus();
                else 
                    textBoxBaseUp.Focus();
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
