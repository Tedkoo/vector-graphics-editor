using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace official.Comands
{
    public interface ICommand
    {
        void MouseDown(MouseEventArgs e);
        void MouseMove(MouseEventArgs e);
        void MouseUp(MouseEventArgs e);
        void KeyDown(KeyEventArgs e);
        void DoubleClick(EventArgs e);
    }
}
