using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace official
{
    public partial class LinQForm : Form
    {
        private List<Shape> _shapes;
        public LinQForm(List<Shape> shapes)
        {
            InitializeComponent();
            _shapes = shapes;

            LoadColors();
            LoadShapeType();
            LoadSizeRange();
            LoadMainType();

            cmbMainType.SelectedIndex = 0;
        }

        private void LoadMainType() 
        {
            cmbMainType.DataSource = new List<string>
            {
        "Всички",
        "Триъгълник",
        "Четириъгълник",
        "Кръгли",
        "Многоъгълник"
            };
        }
        private void LoadShapeType()
        {
            var types = _shapes
                .Select(t => t.GetType().Name)
                .Distinct()
                .OrderBy(name => name)
                .ToList();

            types.Insert(0, "Всички");
            cmbShapes.DataSource = types;
        }

        private void LoadColors()
        {
            var colors = _shapes
                .Select(c => c.InsideColor.Name)
                .Distinct()
                .OrderBy(name => name)
                .ToList();

            colors.Insert(0, "Всички");
            cmbColors.DataSource = colors;
        }

        private void LoadSizeRange()
        {
            double maxSize = _shapes.Max(s => s.Perimeter);
            int step = 100;

            int maxRange = ((int)(maxSize / step) + 1) * step;

            List<string> ranges = new List<string>();
            ranges.Add("Всички");

            for (int i = step; i <= maxRange; i += step)
            {
                int lower = i - step;
                ranges.Add($"{lower} – {i}");
            }

            cmbSizes.DataSource = ranges;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var filtered = _shapes.AsEnumerable();

            string selectedMainType = cmbMainType.SelectedItem.ToString();
            if (selectedMainType == "Всички")
                filtered = filtered.Where(s => s is Shape);
            else if (selectedMainType == "Триъгълник")
                filtered = filtered.Where(s => s is Triangle);
            else if (selectedMainType == "Четириъгълник")
                filtered = filtered.Where(s => s is Rectangle || s is Romb || s is Trapezoid);
            else if (selectedMainType == "Многоъгълник")
                filtered = filtered.Where(s => s is Hexagon || s is Pentagon);
            else if (selectedMainType == "Кръгли")
                filtered = filtered.Where(s => s is Circle || s is Ellipse);

            string selectType = cmbShapes.SelectedItem.ToString();
            if (selectType != "Всички")
            {
                filtered = filtered.Where(s => s.GetType().Name == selectType);
            }

            string selectColor = cmbColors.SelectedItem.ToString();
            if (selectColor != "Всички")
            {
                filtered = filtered.Where(s => s.InsideColor.Name == selectColor);
            }

            string selectedRange = cmbSizes.SelectedItem.ToString();
            if (selectedRange != "Всички")
            {
                var parts = selectedRange.Split('–');

                if (parts.Length == 2 &&
                    double.TryParse(parts[0].Trim(), out double lowerLimit) &&
                    double.TryParse(parts[1].Trim(), out double upperLimit))
                {
                    filtered = filtered.Where(s => s.Perimeter > lowerLimit && s.Perimeter <= upperLimit);
                }
            }

            var result = filtered
                .GroupBy(s => new { TypeName = s.GetType().Name, ColorName = s.InsideColor.Name })
                .Select(g => new
                {
                    Тип = g.Key.TypeName,
                    Цвят = g.Key.ColorName,
                    Бройка = g.Count()
                })
                .ToList();
            dgvResult.DataSource = result;
        }

        private void LinQForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cmbShapes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbMainType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = cmbMainType.SelectedItem.ToString();

            var filteredTypes = _shapes
                .Where(shape =>
                    selectedCategory == "Всички" ||
                    (selectedCategory == "Триъгълник" && shape is Triangle) ||
                    (selectedCategory == "Четириъгълник" && (shape is Rectangle || shape is Romb || shape is Trapezoid))||
                    (selectedCategory == "Кръгли" && (shape is Circle || shape is Ellipse)) ||
                    (selectedCategory == "Многоъгълник" && (shape is Pentagon || shape is Hexagon))
                )
                .Select(s => s.GetType().Name)
                .Distinct()
                .OrderBy(name => name)
                .ToList();

            filteredTypes.Insert(0, "Всички");
            cmbShapes.DataSource = filteredTypes;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvResult.DataSource = null;
        }
    }
}
