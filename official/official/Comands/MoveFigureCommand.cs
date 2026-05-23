using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace official.Comands
{
    public class MoveFigureCommand : ICommand
    {
        private FormMain _scene;
        private Point _prevMouseLocation;
        private bool _isDragging = false;
        bool isMouseOnShape = false;
        public MoveFigureCommand(FormMain scene)
        {
            _scene = scene;
        }
        public void MouseDown(MouseEventArgs e) 
        {
            if (_scene._selectedShapes.Count > 0)
            {
                _scene.PushUndoState();
                _isDragging = true;
                _scene.IsMoving = true;
            }
        }
        public void MouseMove(MouseEventArgs e)
        {
            if (_isDragging && e.Button == MouseButtons.Left)
            {
                foreach (var shape in _scene._selectedShapes)
                {
                    shape.Location = new Point(e.Location.X, e.Location.Y);
                }
                _scene.Invalidate();
            }
        }
        public void MouseUp(MouseEventArgs e) 
        {
            _isDragging = false;
            _scene.IsMoving = false;
        }
        public void KeyDown(KeyEventArgs e) { }
        public void DoubleClick(EventArgs e) { }
    }
}
