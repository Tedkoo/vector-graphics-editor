using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace official
{
    public class Pencil
    {
        public List<Point> Points { get; private set; } = new List<Point>();
        public Pen Pen { get; set; } = new Pen(Color.Black, 2);

        public bool IsDrawing { get; private set; } = false;

        public void Start(Point start)
        {
            Points.Clear();
            Points.Add(start);
            IsDrawing = true;
        }

        public void AddPoint(Point p)
        {
            if(IsDrawing)   
                Points.Add(p);
        }

        public void Stop()
        {
            IsDrawing = false;
        }

        public void Draw(Graphics g)
        {
            if (Points.Count > 1)
            {
                g.DrawLines(Pen, Points.ToArray());
            }
        }
    }
}
