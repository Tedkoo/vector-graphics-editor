using Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace official
{
    [Serializable]
    public class Hexagon : Shape
    {
        public int Radius;
        public int Side;
        public override double Perimeter => 6 * Side;
        private Point[] GetPentaPoints()
        {
            return new Point[]
            {
                new Point(Location.X + Side / 2, Location.Y),
                new Point(Location.X + Side, Location.Y + Radius / 4),
                new Point(Location.X + Side, Location.Y + 3 * Radius / 4),
                new Point(Location.X + Side / 2, Location.Y + Radius),
                new Point(Location.X,  Location.Y + 3 * Radius / 4),
                new Point(Location.X,  Location.Y + Radius / 4),
            };
        }


        public override void Draw(IDrawable drawable)
        {
            drawable.DrawHexagon(this);
        }

        public override bool PointInShape(Point point)
        {
            var p = GetPentaPoints();
            int[] signs = new int[6];

            signs[0] = (point.X - p[1].X) * (p[0].Y - p[1].Y) - (point.Y - p[1].Y) * (p[0].X - p[1].X);
            signs[1] = (point.X - p[2].X) * (p[1].Y - p[2].Y) - (point.Y - p[2].Y) * (p[1].X - p[2].X);
            signs[2] = (point.X - p[3].X) * (p[2].Y - p[3].Y) - (point.Y - p[3].Y) * (p[2].X - p[3].X);
            signs[3] = (point.X - p[4].X) * (p[3].Y - p[4].Y) - (point.Y - p[4].Y) * (p[3].X - p[4].X);
            signs[4] = (point.X - p[5].X) * (p[4].Y - p[5].Y) - (point.Y - p[5].Y) * (p[4].X - p[5].X);
            signs[5] = (point.X - p[0].X) * (p[5].Y - p[0].Y) - (point.Y - p[0].Y) * (p[5].X - p[0].X);

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
                new Hexagon
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
