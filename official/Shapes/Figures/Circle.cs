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
    public class Circle : Shape
    {
        private int _radius;
        public override double Perimeter => Math.PI * Radius * Radius;

        public int Radius
        {
            get { return _radius; }

            set {if (value <= 0)
                    throw new Exception("Invalid value");

            _radius = value;
            }
        }
        public override void Draw(IDrawable drawable)
        {
            drawable.DrawCircle(this);   
        }

        public override bool PointInShape(Point point)
        {
            return
                ((point.X - Location.X) * (point.X - Location.X) +
                (point.Y - Location.Y) * (point.Y - Location.Y)) <=
                (Radius * Radius);
        }

        public override bool Intersect(Rectangle rectangle)
        {
            return
                rectangle.Location.X < Location.X + Radius &&
                Location.X - Radius < rectangle.Location.X + rectangle.Width &&
                rectangle.Location.Y < Location.Y + Radius &&
                Location.Y - Radius < rectangle.Location.Y + rectangle.Height;
        }

        public override Shape Clone()
        {
            return 
                new Circle
            {
                Location = this.Location,
                Radius = this.Radius,
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
