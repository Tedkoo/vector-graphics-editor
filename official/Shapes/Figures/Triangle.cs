using Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace official
{
    [Serializable]
    public class Triangle : Shape
    {

        public Point[] points = new Point[3];

        private int _height;
        private int _width;
        public override double Perimeter => 3 * Width;
        public int Width
        {
            get { return _width; }
            set
            {
                if (value < 0)
                    throw new Exception("Invalid value");

                _width = value;
            }
        }

        public int Height
        {
            get { return _height; }
            set
            {
                if (value < 0)
                    throw new Exception("Invalid value");
                else
                    _height = value;
            }
        }

        private Point[] GetTrianglePoints()
        {
            return new Point[]
                {
                    new Point(Location.X - Width / 2, Location.Y + Height),
                    new Point(Location.X + Width / 2, Location.Y + Height),
                    new Point(Location.X, Location.Y)
                };
        }
        public override void Draw(IDrawable drawable)
        {
            drawable.DrawTriangle(this);
        }
        public override bool PointInShape(Point point)
        {
            var p = GetTrianglePoints();
            int[] signs = new int[3];
            signs[0] = (point.X - p[1].X) * (p[0].Y - p[1].Y) - (point.Y - p[1].Y) * (p[0].X - p[1].X);
            signs[1] = (point.X - p[2].X) * (p[1].Y - p[2].Y) - (point.Y - p[2].Y) * (p[1].X - p[2].X);
            signs[2] = (point.X - p[0].X) * (p[2].Y - p[0].Y) - (point.Y - p[0].Y) * (p[2].X - p[0].X);

            return signs.All(s => s > 0) || signs.All(s => s < 0);
        }

        public override bool Intersect(Rectangle rectangle)
        {
            var points = GetTrianglePoints();

            int rectLeft = rectangle.Location.X;
            int rectTop = rectangle.Location.Y;
            int rectRight = rectangle.Location.X + rectangle.Width;
            int rectBottom = rectangle.Location.Y + rectangle.Height;

            foreach (var point in GetTrianglePoints())
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
                new Triangle
                {
                    Location = this.Location,
                    Width = this.Width,
                    Height = this.Height,
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
