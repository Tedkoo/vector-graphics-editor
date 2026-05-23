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
    public class Rectangle : Shape
    {
        private int _width;
        private int _height;
        public override double Perimeter => 2 * Width + 2 * Height;

        public int Width
        {
            get { return _width; }
            set { _width = value;
            }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value;
            }
        }
        public override void Draw(IDrawable drawable)
        {
            drawable.DrawRectangle(this);
        }

        public override bool PointInShape(Point point)
        {
            return
                point.X > Location.X &&
                point.Y > Location.Y &&
                point.X < Location.X + Width &&
                point.Y < Location.Y + Height;
        }

        public override bool Intersect(Rectangle rectangle)
        {
            return
                 rectangle.Location.X < Location.X + Width &&
                 Location.X < rectangle.Location.X + rectangle.Width &&
                 rectangle.Location.Y < Location.Y + Height &&
                 Location.Y < rectangle.Location.Y + rectangle.Height;

        }

        public override Shape Clone()
        {
            return
                new Rectangle
                {
                    Location = this.Location,
                    Width = this.Width,
                    Height = this.Height,
                    InsideColor = this.InsideColor,
                    BorderColor = this.BorderColor,
                };
        }
    }
}
