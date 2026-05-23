using Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace official
{
    [Serializable]
    public class Trapezoid : Shape
    {
        public int BaseBot;
        public int BaseUp;
        public int Height;
        public override double Perimeter => BaseBot + BaseUp + 2 * Math.Sqrt((BaseBot - BaseUp) / 2 + Height);
        private Point[] GetTrapPoints()
        {
            return new Point[]
            {
                new Point(Location.X, Location.Y),
                new Point(Location.X + BaseUp, Location.Y),
                new Point(Location.X + (BaseBot - BaseUp) / 2 + BaseBot, Location.Y + Height),
                new Point(Location.X + (BaseBot - BaseUp) / 2, Location.Y + Height),
        };
        }

        public override void Draw(IDrawable drawable)
        {
            drawable.DrawTrapezoid(this);
        }

        public override bool PointInShape(Point point)
        {
            var p = GetTrapPoints();
            int[] signs = new int[4];
            signs[0] = (point.X - p[1].X) * (p[0].Y - p[1].Y) - (point.Y - p[1].Y) * (p[0].X - p[1].X);
            signs[1] = (point.X - p[2].X) * (p[1].Y - p[2].Y) - (point.Y - p[2].Y) * (p[1].X - p[2].X);
            signs[2] = (point.X - p[3].X) * (p[2].Y - p[3].Y) - (point.Y - p[3].Y) * (p[2].X - p[3].X);
            signs[3] = (point.X - p[0].X) * (p[3].Y - p[0].Y) - (point.Y - p[0].Y) * (p[3].X - p[0].X);

            return signs.All(s => s > 0) || signs.All(s => s < 0);
        }

        public override bool Intersect(Rectangle rectangle)
        {
            var points = GetTrapPoints();

            int rectLeft = rectangle.Location.X;
            int rectTop = rectangle.Location.Y;
            int rectRight = rectangle.Location.X + rectangle.Width;
            int rectBottom = rectangle.Location.Y + rectangle.Height;

            foreach (var point in GetTrapPoints())
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
                new Trapezoid
                {
                    Location = this.Location,
                    BaseBot = this.BaseBot,
                    BaseUp = this.BaseUp,
                    Height = this.Height,
                    InsideColor = this.InsideColor,
                    BorderColor = this.BorderColor,
                };
        }
    }
}
