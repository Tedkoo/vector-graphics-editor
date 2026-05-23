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
    public class Ellipse : Shape
    {
        private int _smallRadius;
        private int _largeRadius;

        public int LargeRadius
        {
            get { return _largeRadius; }

            set
            {
                if (value <= 0)
                    throw new Exception("Invalid value");

                _largeRadius = value;
            }
        }

        public int SmallRadius
        {
            get { return _smallRadius; }

            set
            {
                if (value <= 0)
                    throw new Exception("Invalid value");

                _smallRadius = value;
            }
        }
        public override void Draw(IDrawable drawable)
        {
            drawable.DrawEllipse(this);
        }

        public override bool PointInShape(Point point)
        {
            return
                (point.X - Location.X) * (point.X - Location.X) * (LargeRadius * LargeRadius ) / 4 +
                (point.Y - Location.Y) * (point.Y - Location.Y) * (SmallRadius *SmallRadius) / 4
                <= (SmallRadius * SmallRadius ) / 4 * (LargeRadius *LargeRadius ) / 4;
        }

        public override bool Intersect(Rectangle rectangle)
        {
            return
               rectangle.Location.X < Location.X + LargeRadius / 2 &&
               rectangle.Location.X + rectangle.Width > Location.X - LargeRadius / 2 &&
               rectangle.Location.Y < Location.Y + SmallRadius / 2 &&
               rectangle.Location.Y + rectangle.Height > Location.Y - SmallRadius / 2;
        }
        public override Shape Clone()
        {
            return
                new Ellipse
                {
                    Location = this.Location,
                    LargeRadius = this.LargeRadius,
                    SmallRadius = this.SmallRadius,
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