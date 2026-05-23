using Shapes;
using System;
using System.Drawing;
using System.Linq;

namespace official
{
    [Serializable]
    public class Romb : Shape
    {
        private int _width;   
        private int _height;
        
        private Point[] GetRombPoints()
        {
            return new Point[]
            {
               new Point(Location.X, Location.Y - Height / 2),
               new Point(Location.X + Width / 2, Location.Y),
               new Point(Location.X, Location.Y + Height / 2),
               new Point(Location.X - Width / 2, Location.Y),
            };
        }
        public int Width
        {
            get { return _width; }
            set
            {
                if (value <= 0)
                    throw new Exception("Invalid value");

                _width = value;
            }
        }

        public int Height
        {
            get { return _height; }
            set
            {
                if (value <= 0)
                    throw new Exception("Invalid value");

                _height = value;
            }
        }

        public override void Draw(IDrawable drawable)
        {
            drawable.DrawRomb(this);
        }

        public override bool PointInShape(Point point)
        {
            var pts = GetRombPoints();
            int[] signs = new int[4];

            signs[0] = (point.X - pts[1].X) * (pts[0].Y - pts[1].Y) - (point.Y - pts[1].Y) * (pts[0].X - pts[1].X);
            signs[1] = (point.X - pts[2].X) * (pts[1].Y - pts[2].Y) - (point.Y - pts[2].Y) * (pts[1].X - pts[2].X);
            signs[2] = (point.X - pts[3].X) * (pts[2].Y - pts[3].Y) - (point.Y - pts[3].Y) * (pts[2].X - pts[3].X);
            signs[3] = (point.X - pts[0].X) * (pts[3].Y - pts[0].Y) - (point.Y - pts[0].Y) * (pts[3].X - pts[0].X);

            return signs.All(s => s > 0) || signs.All(s => s < 0);
        }
        
        public override bool Intersect(Rectangle rectangle)
        {
            var points = GetRombPoints();

            int rectLeft = rectangle.Location.X;
            int rectTop = rectangle.Location.Y;
            int rectRight = rectangle.Location.X + rectangle.Width;
            int rectBottom = rectangle.Location.Y + rectangle.Height;

            foreach (var point in GetRombPoints())
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
                new Romb
                {
                    Location = this.Location,
                    Height = this.Height,
                    Width = this.Width,
                    InsideColor = this.InsideColor,
                    BorderColor = this.BorderColor,
                };
        }

        public override void Move(int dx, int dy)
        {
            Location = new Point(Location.X + dx, Location.Y + dy);
        }
    }

}