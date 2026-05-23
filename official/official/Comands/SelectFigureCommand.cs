using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace official.Comands
{
    public class SelectFigureCommand : ICommand
    {
        private FormMain _scene;

        public SelectFigureCommand(FormMain scene)
        {
            _scene = scene;
        }
        public void MouseDown(MouseEventArgs e) 
        {
            if (e.Button == MouseButtons.Left && !_scene.IsMoving)
            {
                //_scene.PushUndoState();
                bool isCtrlPressed = (Control.ModifierKeys & Keys.Control) != 0;

                if (_scene._selectedShapes != null && !isCtrlPressed)
                {
                    for (int s = 0; s < _scene._selectedShapes.Count; s++)
                        _scene.SelectShape(_scene._selectedShapes[s], false);

                    _scene._selectedShapes.Clear();
                }

                for (int s = _scene._shapes.Count - 1; s >= 0; s--)
                    if (_scene._shapes[s].PointInShape(e.Location))
                    {
                        _scene.SelectShape(_scene._shapes[s], true);
                        break;
                    }

                _scene.LocationMouseDown = e.Location;
                _scene.MouseDownFlag = true;
            }
        }
        public void MouseMove(MouseEventArgs e)
        {
            if (_scene.IsMoving)
                return;

            _scene.LocationMouseMove = e.Location;
            var LocationMouseMove = _scene.LocationMouseMove;
            var LocationMouseDown = _scene.LocationMouseDown;

            Rectangle rectangle = new Rectangle
            {
                Location = new Point(
                    Math.Min(LocationMouseDown.X, LocationMouseMove.X),
                    Math.Min(LocationMouseDown.Y, LocationMouseMove.Y)
                ),
                Width = Math.Abs(LocationMouseMove.X - LocationMouseDown.X),
                Height = Math.Abs(LocationMouseMove.Y - LocationMouseDown.Y)
            };


            if (_scene.MouseDownFlag)
            {
                
                for (int s = 0; s < _scene._shapes.Count; s++)
                {
                    if (_scene._shapes[s].Intersect(rectangle))
                        _scene._selectedShapes.Add(_scene._shapes[s]);
                }
                _scene.Invalidate();
            }
        }
        public void MouseUp(MouseEventArgs e) 
        {
            if (_scene.MouseDownFlag)
                _scene.Invalidate();

            _scene.MouseDownFlag = false;
        }
        public void KeyDown(KeyEventArgs e) { }
        public void DoubleClick(EventArgs e) { }
    }
}
