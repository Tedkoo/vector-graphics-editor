using Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace official
{
    [Serializable]
    public class Pentagon : Shape
    {
        private int _radius;

        private Point[] GetPentaPoints()
        {
            return new Point[]
            {
                new Point(Location.X + Side / 2, Location.Y),
                new Point(Location.X + Side, Location.Y + Radius / 3),
                new Point(Location.X + 3 * Side / 4, Location.Y + Radius),
                new Point(Location.X + Side / 4, Location.Y + Side),
                new Point(Location.X, Location.Y + Side / 3)
            };
        }
        public override double Perimeter => 5 * Side;
        public int Radius
        {
            get { return _radius; }
            set
            {
                if (value < 0)
                    throw new Exception("Invalid value");

                _radius = value;
            }
        }

        private int _side;
        public int Side

        {
            get { return _side; }
            set
            {
                if (value < 0)
                    throw new Exception("Invalid value");

                _side = value;
            }
        }

        public override void Draw(IDrawable drawable)
        {
            drawable.DrawPentagon(this);
        }

        public override bool PointInShape(Point point)
        {
            var p = GetPentaPoints();
            int[] signs = new int[5];

            signs[0] = (point.X - p[1].X) * (p[0].Y - p[1].Y) - (point.Y - p[1].Y) * (p[0].X - p[1].X);
            signs[1] = (point.X - p[2].X) * (p[1].Y - p[2].Y) - (point.Y - p[2].Y) * (p[1].X - p[2].X);
            signs[2] = (point.X - p[3].X) * (p[2].Y - p[3].Y) - (point.Y - p[3].Y) * (p[2].X - p[3].X);
            signs[3] = (point.X - p[4].X) * (p[3].Y - p[4].Y) - (point.Y - p[4].Y) * (p[3].X - p[4].X);
            signs[4] = (point.X - p[0].X) * (p[4].Y - p[0].Y) - (point.Y - p[0].Y) * (p[4].X - p[0].X);

            return signs.All(s => s > 0) || signs.All(s => s < 0);
        }

        public override bool Intersect(Rectangle rectangle)
        {
            var points = GetPentaPoints();

            int rectLeft = rectangle.Location.X;
            int rectTop = rectangle.Location.Y;
            int rectRight = rectangle.Location.X + rectangle.Width;
            int rectBottom = rectangle.Location.Y + rectangle.Height;

            foreach (var point in GetPentaPoints())
            {
                if (point.X >= rectangle.Location.X && point.X <= rectangle.Location.X + rectangle.Width &&
                    point.Y >= rectangle.Location.Y && point.Y <= rectangle.Location.Y + rectangle.Height)
                    return true;
            }
           
            var rectPoints = new Point[]
            {
                new Point(rectLeft, rectTop),
                new Point(rectRight, rectTop),
                new Point(rectRight, rectBottom),
                new Point(rectLeft, rectBottom)
            };

            foreach (var p in rectPoints)
            {
                if (PointInShape(p))
                    return true;
            }
            return false;
        }

        public override Shape Clone()
        {
            return
                new Pentagon
                {
                    Location = this.Location,
                    Radius = this.Radius,
                    Side = this.Side,
                    InsideColor = this.InsideColor,
                    BorderColor = this.BorderColor,
                };
        }
    }
}
