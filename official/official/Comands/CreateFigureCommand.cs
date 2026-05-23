using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace official.Comands
{
    class CreateFigureCommand : ICommand
    {
        private FormMain _scene;

        public CreateFigureCommand(FormMain scene)
        {
            _scene = scene;
        }
        public void MouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _scene.PushUndoState();
                if (_scene.currentShape == "Rectangle")
                {
                    Rectangle rectangle = new Rectangle();

                    rectangle.Location = e.Location;
                    rectangle.Width = 100;
                    rectangle.Height = 70;
                    rectangle.InsideColor = _scene._currentColor;
                    rectangle.BorderColor = _scene._currentColor;

                    _scene._shapes.Add(rectangle);
                    _scene.IsRecording(rectangle);
                }
                else if (_scene.currentShape == "Circle")
                {
                    Circle circle = new Circle();

                    circle.Location = e.Location;
                    circle.Radius = 50;
                    circle.InsideColor = _scene._currentColor;
                    circle.BorderColor = _scene._currentColor;

                    _scene._shapes.Add(circle);
                    _scene.IsRecording(circle);
                }
                else if (_scene.currentShape == "Triangle")
                {
                    Triangle triangle = new Triangle();

                    triangle.Location = e.Location;
                    triangle.Height = 100;
                    triangle.Width = 100;
                    triangle.InsideColor = _scene._currentColor;
                    triangle.BorderColor = _scene._currentColor;

                    _scene._shapes.Add(triangle);
                    _scene.IsRecording(triangle);
                }
                else if (_scene.currentShape == "Pentagon")
                {
                    Pentagon pentagon = new Pentagon();

                    pentagon.Location = e.Location;
                    pentagon.Radius = 100;
                    pentagon.Side = 100;
                    pentagon.InsideColor = _scene._currentColor;
                    pentagon.BorderColor = _scene._currentColor;

                    _scene._shapes.Add(pentagon);
                    _scene.IsRecording(pentagon);
                }
                else if (_scene.currentShape == "Romb")
                {
                    Romb romb = new Romb();
                    romb.Location = e.Location;
                    romb.Width = 100;
                    romb.Height = 100;
                    romb.InsideColor = _scene._currentColor;
                    romb.BorderColor = _scene._currentColor;

                    _scene._shapes.Add(romb);
                    _scene.IsRecording(romb);
                }
                else if (_scene.currentShape == "Ellipse")
                {
                    Ellipse ellipse = new Ellipse();
                    ellipse.Location = e.Location;
                    ellipse.SmallRadius = 50;
                    ellipse.LargeRadius = 100;
                    ellipse.InsideColor = _scene._currentColor;
                    ellipse.BorderColor = _scene._currentColor;

                    _scene._shapes.Add(ellipse);
                    _scene.IsRecording(ellipse);
                }
                else if (_scene.currentShape == "Trapezoid")
                {
                    Trapezoid trapezoid = new Trapezoid();
                    trapezoid.Location = e.Location;
                    trapezoid.Height = 70;
                    trapezoid.BaseBot = 100;
                    trapezoid.BaseUp = 40;
                    trapezoid.InsideColor = _scene._currentColor;
                    trapezoid.BorderColor = _scene._currentColor;

                    _scene._shapes.Add(trapezoid);
                    _scene.IsRecording(trapezoid);
                }
                else if (_scene.currentShape == "Hexagon")
                {
                    Hexagon hexagon = new Hexagon();
                    hexagon.Location = e.Location;
                    hexagon.Side = 70;
                    hexagon.Radius = 80;
                    hexagon.BorderColor = _scene._currentColor;
                    hexagon.InsideColor = _scene._currentColor;

                    _scene._shapes.Add(hexagon);
                    _scene.IsRecording(hexagon);
                }
                _scene.Invalidate();
            }
        }
        public void MouseMove(MouseEventArgs e) { }
        public void MouseUp(MouseEventArgs e) { }
        public void KeyDown(KeyEventArgs e) { }
        public void DoubleClick(EventArgs e) { }
    }
}
