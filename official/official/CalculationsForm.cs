using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace official
{
    public partial class CalculationsForm : Form
    {
        double area = 0;
        double perimeter = 0;
        public CalculationsForm(Shape shape)
        {
            InitializeComponent();


            if (shape is Triangle triangle)
            {
                area = (Math.Sqrt(3) / 4) * triangle.Width * triangle.Width;
                perimeter = 3 * triangle.Width;

                labelArea.Text = $"S = (√3 / 4) × {triangle.Width * triangle.Width}";
                labelPer.Text = perimeter.ToString();
            }
            else if (shape is Rectangle rectangle)
            {
                area = rectangle.Width * rectangle.Height;
                perimeter = 2 * rectangle.Height + 2 * rectangle.Width;

                labelArea.Text = area.ToString();
                labelPer.Text = perimeter.ToString();
            }
            else if (shape is Circle circle)
            {
                area = Math.PI * circle.Radius * circle.Radius;
                perimeter = 2 - Math.PI * circle.Radius;

                labelArea.Text = $"S = π * {circle.Radius * circle.Radius}";
                labelPer.Text = $"S = 2 - π * {circle.Radius}";
            }
            else if (shape is Hexagon hexagon)
            {
                area = ((3 * Math.Sqrt(3)) / 2) * hexagon.Side * hexagon.Side;
                perimeter = 6 * hexagon.Side;

                labelArea.Text = $"S = (3√3 / 2) * {hexagon.Side * hexagon.Side}";
                labelPer.Text= perimeter.ToString();
            }
            else if (shape is Pentagon pentagon)
            {
                area = ((pentagon.Side * pentagon.Side) / 4) * Math.Sqrt(25 + 10 * Math.Sqrt(5));
                perimeter = 5 * pentagon.Side;

                labelArea.Text = $"√(25 + 10√3) / 4 * {pentagon.Side * pentagon.Side}";
                labelPer.Text = perimeter.ToString() ;
            }
            else if (shape is Romb romb)
            {
                area = romb.Width * romb.Height;
                perimeter = 4 * romb.Width;

                labelArea.Text = area.ToString();
                labelPer.Text = perimeter.ToString();
            }
            else if (shape is Trapezoid trapezoid)
            {
                area = ((trapezoid.BaseBot + trapezoid.BaseUp) / 2.0) * trapezoid.Height;
                int third = (trapezoid.BaseBot - trapezoid.BaseUp) / 2;
                double c = Math.Sqrt(third + trapezoid.Height);
                perimeter = trapezoid.BaseBot + trapezoid.BaseUp + (2 * c);

                labelArea.Text = area.ToString();
                labelPer.Text = perimeter.ToString();
            }
        }
         

        private void CalculationsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAccuracy_Click(object sender, EventArgs e)
        {
            labelAccArea.Text = $"S ≈ {area:F2}";
            labelPer.Text = $"{perimeter:F2}";
        }
    }
}
