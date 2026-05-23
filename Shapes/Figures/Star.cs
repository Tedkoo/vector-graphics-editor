using official;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace official
{
    [Serializable]
    public class Star : Shape
    {
        public int Radius;
        public int Side;

        private Point[] GetStarPoints()
        {
            return new Point[]
            {
                new Point(Location.X + Side / 2, Location.Y),                       // 0 - Top
    new Point(Location.X + (int)(0.62 * Side), Location.Y + (int)(0.38 * Radius)),  // 1 - Upper right indent
    new Point(Location.X + Side, Location.Y + (int)(0.38 * Radius)),    // 2 - Right tip
    new Point(Location.X + (int)(0.69 * Side), Location.Y + (int)(0.62 * Radius)),  // 3 - Lower right indent
    new Point(Location.X + (int)(0.81 * Side), Location.Y + Radius),    // 4 - Bottom right tip
    new Point(Location.X + Side / 2, Location.Y + (int)(0.76 * Radius)),// 5 - Bottom center indent
    new Point(Location.X + (int)(0.19 * Side), Location.Y + Radius),    // 6 - Bottom left tip
    new Point(Location.X + (int)(0.31 * Side), Location.Y + (int)(0.62 * Radius)),  // 7 - Lower left indent
    new Point(Location.X, Location.Y + (int)(0.38 * Radius)),           // 8 - Left tip
    new Point(Location.X + (int)(0.38 * Side), Location.Y + (int)(0.38 * Radius)),  // 9 - Upper left indent
            };
        }

        public override void Draw(IDrawable drawable)
        {
           drawable.DrawStar(this);
        }

        public override bool PointInShape(Point point)
        {
            //var poly = GetStarPoints();
            //int n = poly.Length;
            //bool inside = false;

            //for (int i = 0, j = n - 1; i < n; j = i++)
            //{
            //    // Проверяваме дали хоризонтален лъч надясно от точката пресича реброто [poly[j], poly[i]]
            //    if (((poly[i].Y > point.Y) != (poly[j].Y > point.Y)) &&
            //        (point.X < (poly[j].X - poly[i].X) * (point.Y - poly[i].Y) /
            //         (double)(poly[j].Y - poly[i].Y) + poly[i].X))
            //    {
            //        inside = !inside;
            //    }
            //}

            //return inside;
            var p = GetStarPoints();
            int[] signs = new int[10];

            signs[0] = (point.X - p[1].X) * (p[0].Y - p[1].Y) - (point.Y - p[1].Y) * (p[0].X - p[1].X);
            signs[1] = (point.X - p[2].X) * (p[1].Y - p[2].Y) - (point.Y - p[2].Y) * (p[1].X - p[2].X);
            signs[2] = (point.X - p[3].X) * (p[2].Y - p[3].Y) - (point.Y - p[3].Y) * (p[2].X - p[3].X);
            signs[3] = (point.X - p[4].X) * (p[3].Y - p[4].Y) - (point.Y - p[4].Y) * (p[3].X - p[4].X);
            signs[4] = (point.X - p[5].X) * (p[4].Y - p[5].Y) - (point.Y - p[5].Y) * (p[4].X - p[5].X);
            signs[5] = (point.X - p[6].X) * (p[5].Y - p[6].Y) - (point.Y - p[6].Y) * (p[5].X - p[6].X);
            signs[6] = (point.X - p[7].X) * (p[6].Y - p[7].Y) - (point.Y - p[7].Y) * (p[6].X - p[7].X);
            signs[7] = (point.X - p[8].X) * (p[7].Y - p[8].Y) - (point.Y - p[8].Y) * (p[7].X - p[8].X);
            signs[8] = (point.X - p[9].X) * (p[8].Y - p[9].Y) - (point.Y - p[9].Y) * (p[8].X - p[9].X);
            signs[9] = (point.X - p[0].X) * (p[9].Y - p[0].Y) - (point.Y - p[0].Y) * (p[9].X - p[0].X);

            return signs.All(s => s >= 0) || signs.All(s => s <= 0);
        }

        public override bool Intersect(Rectangle rectangle)
        {
            var points = GetStarPoints();

            int rectLeft = rectangle.Location.X;
            int rectTop = rectangle.Location.Y;
            int rectRight = rectangle.Location.X + rectangle.Width;
            int rectBottom = rectangle.Location.Y + rectangle.Height;

            foreach (var point in GetStarPoints())
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
                new Star
                {
                    Location = this.Location,
                    Radius = this.Radius,
                    Side = this.Side,
                    BorderColor = this.BorderColor,
                    InsideColor = this.InsideColor
                };
        }
    }
}
