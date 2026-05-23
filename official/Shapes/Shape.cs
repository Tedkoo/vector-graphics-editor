using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;

namespace official
{
    [Serializable]   
    public abstract class Shape
    {
        public Point Location;
        public Color BorderColor;
        public Color InsideColor;
        public virtual double Perimeter => 0;

        public abstract void Draw(IDrawable drawable);

        public abstract bool PointInShape(Point point);

        public abstract bool Intersect(Rectangle rectangle);

        public abstract Shape Clone();

        public abstract void Move(int dx, int dy);
    }
}
