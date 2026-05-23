using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;

namespace official
{
    public interface IDrawable
    {
        void DrawRectangle(Rectangle rectangle);
        void DrawCircle(Circle cirlce);
        void DrawEllipse(Ellipse ellipse);
        void DrawPentagon(Pentagon pentagon);
        void DrawHexagon(Hexagon hexagon);
        void DrawTrapezoid(Trapezoid trapezoid);
        void DrawTriangle(Triangle triangle);
        void DrawRomb(Romb romb);
    }
}
