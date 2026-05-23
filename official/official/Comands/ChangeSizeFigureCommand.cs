using official.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace official.Comands
{
    public class ChangeSizeFigureCommand : ICommand
    {
        private FormMain _scene;

        public ChangeSizeFigureCommand(FormMain scene)
        {
            _scene = scene;
        }
        public void MouseDown(MouseEventArgs e) { }
        public void MouseMove(MouseEventArgs e) { }
        public void MouseUp(MouseEventArgs e) { }
        public void KeyDown(KeyEventArgs e) { }
        public void DoubleClick(EventArgs e) 
        {
            if (_scene._selectedShapes == null)
                return;
 
            foreach (var shape in _scene._selectedShapes)
            {
                if (shape is Rectangle rectangle)
                {
                    _scene.PushUndoState();

                    RectangleForm rf = new RectangleForm();

                    rf.Rectangle = rectangle;

                    if (rf.ShowDialog() == DialogResult.OK)
                        _scene.Invalidate();
                }
                else if (shape is Circle circle)
                {
                    _scene.PushUndoState();

                    CircleForm cr = new CircleForm();

                    cr.Circle = circle;

                    if (cr.ShowDialog() == DialogResult.OK)
                        _scene.Invalidate();
                }
                else if (shape is Triangle triangle)
                {
                    _scene.PushUndoState();

                    TriangleForm tf = new TriangleForm();

                    tf.Triangle = triangle;

                    if (tf.ShowDialog() == DialogResult.OK)
                        _scene.Invalidate();
                }
                else if (shape is Pentagon pentagon)
                {
                    _scene.PushUndoState();

                    PentagonForm pf = new PentagonForm();

                    pf.Pentagon = pentagon;

                    if (pf.ShowDialog() == DialogResult.OK)
                        _scene.Invalidate();
                }
                else if (shape is Ellipse ellipse)
                {
                    _scene.PushUndoState();

                    EllipseForm ef = new EllipseForm();

                    ef.Ellipse = ellipse;

                    if (ef.ShowDialog() == DialogResult.OK)
                        _scene.Invalidate();
                }
                else if (shape is Trapezoid trapezoid)
                {
                    _scene.PushUndoState();

                    TrapezoidForm trf = new TrapezoidForm();

                    trf.Trapezoid = trapezoid;

                    if (trf.ShowDialog() == DialogResult.OK)
                        _scene.Invalidate();
                }
                else if (shape is Romb romb)
                {
                    _scene.PushUndoState();

                    RombForm rfr = new RombForm();

                    rfr.Romb = romb;

                    if (rfr.ShowDialog() == DialogResult.OK)
                        _scene.Invalidate();
                }
                else if (shape is Hexagon hexagon)
                {
                    _scene.PushUndoState();

                    HexagonForm hf = new HexagonForm();

                    hf.Hexagon = hexagon;

                    if (hf.ShowDialog() == DialogResult.OK)
                        _scene.Invalidate();
                }
            }
        }
    }
}
