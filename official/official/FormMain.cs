using official.Forms;
using official.Macros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using official.Comands;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Shapes;
using System.Security.Policy;

namespace official
{
    public partial class FormMain : Form, IDrawable
    {
        public List<Shape> _shapes = new List<Shape>();
        public Color _currentColor = Color.Red;
        public List<Shape> _selectedShapes = new List<Shape>();
        public string currentShape = " ";

        public bool MouseDownFlag = false;
        public Point LocationMouseDown;
        public Point LocationMouseMove;
        public bool IsMoving = false;

        public List<ICommand> commands = new List<ICommand>();
        public List<Shape> CloneShapeList(List<Shape> originalList)
        {
            return originalList.Select(shape => shape.Clone()).ToList();
        }

        public Stack<List<Shape>> _undoStack = new Stack<List<Shape>>();
        public Stack<List<Shape>> _redoStack = new Stack<List<Shape>>();
        private Stack<Color> _colorStack = new Stack<Color>();
        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                _redoStack.Push(CloneShapeList(_shapes));
                _shapes = _undoStack.Pop();
                _selectedShapes.Clear();

                if (_shapes.Count > 0)
                {
                    _currentColor = _shapes.Last().InsideColor;
                    btnColor.BackColor = _currentColor;
                }

                Invalidate();
            }
        }

        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                _undoStack.Push(CloneShapeList(_shapes));
                _shapes = _redoStack.Pop();
                _selectedShapes.Clear();

                if (_shapes.Count > 0)
                {
                    _currentColor = _shapes.Last().InsideColor;
                    btnColor.BackColor = _currentColor;
                }

                Invalidate();
            }
        }

        public void PushUndoState()
        {
            _undoStack.Push(CloneShapeList(_shapes));
            _redoStack.Clear();
        }
        public void SelectShape(Shape shape, bool selected)
        {
            if (selected)
            {
                shape.BorderColor = Color.Black;
                _selectedShapes.Add(shape);
            }
            else
            {
                shape.BorderColor = shape.InsideColor;
                _selectedShapes.Remove(shape);
            }
        }
        public FormMain()
        {
            InitializeComponent();
            btnColor.BackColor = _currentColor;

            this.KeyPreview = true;

            this.DoubleBuffered = true;

            commands.Add(new CreateFigureCommand(this));
            commands.Add(new SelectFigureCommand(this));
            commands.Add(new ChangeSizeFigureCommand(this));
            commands.Add(new KeysFigureCommand(this));
            commands.Add(new MoveFigureCommand(this));
        }

        public void DrawPentagon(Pentagon pentagon)
        {
            Point[] points = new Point[5];
            Color colorRed = Color.FromArgb(255, 0, 0);
            using (SolidBrush brush = new SolidBrush(pentagon.InsideColor))
            {
                using (Pen pen = new Pen(pentagon.BorderColor, 10))
                {
                    points[0] = new Point(pentagon.Location.X + pentagon.Side / 2, pentagon.Location.Y);
                    points[1] = new Point(pentagon.Location.X + pentagon.Side, pentagon.Location.Y + pentagon.Radius / 3);
                    points[2] = new Point(pentagon.Location.X + 3 * pentagon.Side / 4, pentagon.Location.Y + pentagon.Radius);
                    points[3] = new Point(pentagon.Location.X + pentagon.Side / 4, pentagon.Location.Y + pentagon.Side);
                    points[4] = new Point(pentagon.Location.X, pentagon.Location.Y + pentagon.Side / 3);
                    _OnPaintGraphics.DrawPolygon(pen, points);
                    _OnPaintGraphics.FillPolygon(brush, points);
                }
            }
        }
        public void DrawHexagon(Hexagon hexagon)
        {
            Point[] points = new Point[6];
            Color colorRed = Color.FromArgb(255, 0, 0);
            using (SolidBrush brush = new SolidBrush(hexagon.InsideColor))
            {
                using (Pen pen = new Pen(hexagon.BorderColor, 10))
                {
                    points[0] = new Point(hexagon.Location.X + hexagon.Side / 2, hexagon.Location.Y);
                    points[1] = new Point(hexagon.Location.X + hexagon.Side, hexagon.Location.Y + hexagon.Radius / 4);
                    points[2] = new Point(hexagon.Location.X + hexagon.Side, hexagon.Location.Y + 3 * hexagon.Radius / 4);
                    points[3] = new Point(hexagon.Location.X + hexagon.Side / 2, hexagon.Location.Y + hexagon.Radius);
                    points[4] = new Point(hexagon.Location.X, hexagon.Location.Y + 3 * hexagon.Radius / 4);
                    points[5] = new Point(hexagon.Location.X, hexagon.Location.Y + hexagon.Radius / 4);

                    _OnPaintGraphics.DrawPolygon(pen, points);
                    _OnPaintGraphics.FillPolygon(brush, points);
                }
            }
        }
        public void DrawTrapezoid(Trapezoid trapezoid)
        {
            Point[] points = new Point[4];
            Color colorRed = Color.FromArgb(255, 0, 0);
            using (SolidBrush brush = new SolidBrush(trapezoid.InsideColor))
            {
                using (Pen pen = new Pen(trapezoid.BorderColor, 10))
                {
                    int offset = Math.Abs(trapezoid.BaseBot - trapezoid.BaseUp) / 2;
                    int topX = trapezoid.BaseUp >= trapezoid.BaseBot ? trapezoid.Location.X : trapezoid.Location.X + offset;
                    int bottomX = trapezoid.BaseUp >= trapezoid.BaseBot ? trapezoid.Location.X + offset : trapezoid.Location.X;

                    points[0] = new Point(topX, trapezoid.Location.Y);
                    points[1] = new Point(topX + trapezoid.BaseUp, trapezoid.Location.Y);
                    points[2] = new Point(bottomX + trapezoid.BaseBot, trapezoid.Location.Y + trapezoid.Height);
                    points[3] = new Point(bottomX, trapezoid.Location.Y + trapezoid.Height);

                    _OnPaintGraphics.DrawPolygon(pen, points);
                    _OnPaintGraphics.FillPolygon(brush, points);
                }
            }
        }
        public void DrawTriangle(Triangle triangle)
        {
            Point[] points = new Point[3];
            Color colorRed = Color.FromArgb(255, 0, 0);
            using (SolidBrush brush = new SolidBrush(triangle.InsideColor))
            {
                using (Pen pen = new Pen(triangle.BorderColor, 10))
                {
                    points[0] = new Point(triangle.Location.X - triangle.Width / 2, triangle.Location.Y + triangle.Height);
                    points[1] = new Point(triangle.Location.X + triangle.Width / 2, triangle.Location.Y + triangle.Height);
                    points[2] = new Point(triangle.Location.X, triangle.Location.Y);

                    _OnPaintGraphics.DrawPolygon(pen, points);
                    _OnPaintGraphics.FillPolygon(brush, points);
                }
            }
        }
        public void DrawRomb(Romb romb)
        {
            Point[] points = new Point[4];
            using (SolidBrush brush = new SolidBrush(romb.InsideColor))
            {
                using (Pen pen = new Pen(romb.BorderColor, 10))
                {
                    points[0] = new Point(romb.Location.X, romb.Location.Y - romb.Height / 2);
                    points[1] = new Point(romb.Location.X + romb.Width / 2, romb.Location.Y);
                    points[2] = new Point(romb.Location.X, romb.Location.Y + romb.Height / 2);
                    points[3] = new Point(romb.Location.X - romb.Width / 2, romb.Location.Y);

                    _OnPaintGraphics.FillPolygon(brush, points);
                    _OnPaintGraphics.DrawPolygon(pen, points);
                }
            }
        }
        public void DrawCircle(Circle circle)
        {
            Color colorRed = Color.FromArgb(255, 0, 0);
            using (SolidBrush brush = new SolidBrush(circle.InsideColor))
                _OnPaintGraphics.FillEllipse(brush, circle.Location.X - circle.Radius, circle.Location.Y - circle.Radius, circle.Radius * 2, circle.Radius * 2);
            using (Pen pen = new Pen(circle.BorderColor, 10))
                _OnPaintGraphics.DrawEllipse(pen, circle.Location.X - circle.Radius, circle.Location.Y - circle.Radius, circle.Radius * 2, circle.Radius * 2);
        }
        public void DrawEllipse(Ellipse ellipse)
        {
            Color colorRed = Color.FromArgb(255, 0, 0);
            using (SolidBrush brush = new SolidBrush(ellipse.InsideColor))
                _OnPaintGraphics.FillEllipse(brush, ellipse.Location.X - ellipse.SmallRadius / 2, ellipse.Location.Y - ellipse.LargeRadius / 2, ellipse.SmallRadius, ellipse.LargeRadius);
            using (Pen pen = new Pen(ellipse.BorderColor, 10))
                _OnPaintGraphics.DrawEllipse(pen, ellipse.Location.X - ellipse.SmallRadius / 2, ellipse.Location.Y - ellipse.LargeRadius / 2, ellipse.SmallRadius, ellipse.LargeRadius);
        }
        public void DrawRectangle(Rectangle rectangle)
        {
            Color colorRed = Color.FromArgb(255, 0, 0);
            using (SolidBrush brush = new SolidBrush(rectangle.InsideColor))
                _OnPaintGraphics.FillRectangle(brush, rectangle.Location.X, rectangle.Location.Y, rectangle.Width, rectangle.Height);
            using (Pen pen = new Pen(rectangle.BorderColor, 10))
                _OnPaintGraphics.DrawRectangle(pen, rectangle.Location.X, rectangle.Location.Y, rectangle.Width, rectangle.Height);
        }

        private Graphics _OnPaintGraphics;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var middle = Width / 2;
            e.Graphics.DrawLine(Pens.Gray, middle, 0, middle, Height);
            _OnPaintGraphics = e.Graphics;

            for (int r = 0; r < _shapes.Count; r++)
            {
                if (_selectedShapes.Contains(_shapes[r]))
                {
                    _shapes[r].BorderColor = Color.Black;
                }
                else
                {
                    _shapes[r].BorderColor = _shapes[r].InsideColor;
                }
                _shapes[r].Draw(this);
            }

            int x = Math.Min(LocationMouseDown.X, LocationMouseMove.X);
            int y = Math.Min(LocationMouseDown.Y, LocationMouseMove.Y);
            int width = Math.Abs(LocationMouseMove.X - LocationMouseDown.X);
            int height = Math.Abs(LocationMouseMove.Y - LocationMouseDown.Y);

            if (MouseDownFlag)
                e.Graphics.DrawRectangle(Pens.Black, x, y, width, height);

            _OnPaintGraphics = null;
        }


        private void FormMain_DoubleClick(object sender, EventArgs e)
        {
            foreach (var comands in commands)
                comands.DoubleClick(e);
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (var comands in commands)
                comands.KeyDown(e);
        }
        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (var comands in commands)
                comands.MouseDown(e);
        }
        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (var comands in commands)
                comands.MouseMove(e);
        }

        private void FormMain_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (var comands in commands)
                comands.MouseUp(e);
        }
        private void btnColor_Click(object sender, EventArgs e)
        {
           

            ColorDialog cd = new ColorDialog();

            if (cd.ShowDialog() == DialogResult.OK)
            {
                PushUndoState();
                _currentColor = cd.Color;
                btnColor.BackColor = cd.Color;

                foreach (var shape in _selectedShapes)
                {
                    shape.InsideColor = _currentColor;
                }

                Invalidate();
            }
        }
        private void selectLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (_selectedShapes.Count > 0)
                SelectShape(_selectedShapes[0], false);

            var middle = Width / 2;

            for (int s = 0; s < _shapes.Count; s++)
                if (_shapes[s].Location.X <= middle)
                    SelectShape(_shapes[s], true);

            Invalidate();
        }

        private void selectRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            while (_selectedShapes.Count > 0)
                SelectShape(_selectedShapes[0], false);

            var middle = Width / 2;

            for (int s = 0; s < _shapes.Count; s++)
            {
                if (_shapes[s] is Rectangle rectangle)
                {
                    if (rectangle.Location.X + rectangle.Width >= middle)
                        SelectShape(rectangle, true);
                }
                else if (_shapes[s] is Circle circle)
                {
                    if (circle.Location.X + circle.Radius >= middle)
                        SelectShape(circle, true);
                }
                else if (_shapes[s] is Triangle triangle)
                {
                    if (triangle.Location.X + triangle.Width >= middle)
                        SelectShape(triangle, true);
                }
                else if (_shapes[s] is Pentagon pentagon)
                {
                    if (pentagon.Location.X + pentagon.Radius >= middle)
                        SelectShape(pentagon, true);
                }
                else if (_shapes[s] is Ellipse ellipse)
                {
                    if (ellipse.Location.X + ellipse.SmallRadius >= middle)
                        SelectShape(ellipse, true);
                }
                else if (_shapes[s] is Romb romb)
                {
                    if (romb.Location.X + romb.Width >= middle)
                        SelectShape(romb, true);
                }
                else if (_shapes[s] is Trapezoid trapezoid)
                {
                    if (trapezoid.Location.X + trapezoid.BaseBot >= middle)
                        SelectShape(trapezoid, true);
                }
                else if (_shapes[s] is Hexagon hexagon)
                {
                    if (hexagon.Location.X + hexagon.Radius >= middle)
                        SelectShape(hexagon, true);
                }
            }
            Invalidate();
        }
        private void btnRectangle_Click(object sender, EventArgs e) { currentShape = "Rectangle"; }
        private void btnEllipse_Click(object sender, EventArgs e) { currentShape = "Ellipse"; }
        private void btnTriangle_Click(object sender, EventArgs e) { currentShape = "Triangle"; }
        private void btnHexagon_Click(object sender, EventArgs e) { currentShape = "Hexagon"; }
        private void btnPentagon_Click(object sender, EventArgs e) { currentShape = "Pentagon"; }
        private void btnCircle_Click(object sender, EventArgs e) { currentShape = "Circle"; }
        private void btnRomb_Click(object sender, EventArgs e) { currentShape = "Romb"; }
        private void btnTrapezoid_Click(object sender, EventArgs e) { currentShape = "Trapezoid"; }
        private void btnUndo_Click(object sender, EventArgs e) { Undo(); }
        private void btnRedo_Click(object sender, EventArgs e) { Redo(); }

        private RecordMacro _macroRecorder = new RecordMacro();
        private bool _isRecording = false;

        public void IsRecording(Shape shape)
        {
            if(_isRecording)
                _macroRecorder.Record(shape);
        }
        private void btnStartRec_Click(object sender, EventArgs e)
        {
            _macroRecorder.Clear();
            _isRecording = true;
            MessageBox.Show("Recording started");
        }

        private void btnStopRec_Click(object sender, EventArgs e)
        {
            _isRecording = false;
            MessageBox.Show("Rectording stopped");
        }

        private void btnReplayRec_Click(object sender, EventArgs e)
        {
            ReplayMacro replay = new ReplayMacro(_macroRecorder);
            replay.Execute(_shapes);

            Invalidate();

            MessageBox.Show("The macro was replayed!");
        }

        private void SelectShapeOfType<T>() where T : Shape
        {
            while (_selectedShapes.Count > 0)
                SelectShape(_selectedShapes[0], false);

            var filteredShapes = _shapes.OfType<T>();

            foreach (var shape in filteredShapes)
                SelectShape(shape, true);

            Invalidate();
        }

        private void сToolStripMenuItem_Click(object sender, EventArgs e) {SelectShapeOfType<Rectangle>();}
        private void selectCirclesToolStripMenuItem_Click(object sender, EventArgs e) {SelectShapeOfType<Circle>();}
        private void selectRombsToolStripMenuItem_Click(object sender, EventArgs e) {SelectShapeOfType<Romb>();}
        private void selectPentagonsToolStripMenuItem_Click(object sender, EventArgs e) {SelectShapeOfType<Pentagon>();}
        private void selectHexagonsToolStripMenuItem_Click(object sender, EventArgs e) {SelectShapeOfType<Hexagon>();}
        private void selectTrianglesToolStripMenuItem_Click(object sender, EventArgs e) {SelectShapeOfType<Triangle>();}
        private void seectEllipsesToolStripMenuItem_Click(object sender, EventArgs e) {SelectShapeOfType<Ellipse>();}
        private void seectTrapezoidsToolStripMenuItem_Click(object sender, EventArgs e) {SelectShapeOfType<Trapezoid>();}

        private void Calculations(Shape shape)
        {
            CalculationsForm cf = new CalculationsForm(shape);
            cf.ShowDialog();
        }
        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var triangle = _selectedShapes.OfType<Triangle>().FirstOrDefault();
            if (triangle != null)
                Calculations(triangle);
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var circle = _selectedShapes.OfType<Circle>().FirstOrDefault();
            if (circle != null)
                Calculations(circle);
        }

        private void hexagonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var hexagon = _selectedShapes.OfType<Hexagon>().FirstOrDefault();
            if (hexagon != null)
                Calculations(hexagon);
        }

        private void pentagonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pentagon = _selectedShapes.OfType<Pentagon>().FirstOrDefault();
            if (pentagon != null)
                Calculations(pentagon);
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rectangle = _selectedShapes.OfType<Rectangle>().FirstOrDefault();
            if (rectangle != null)
                Calculations(rectangle);
        }

        private void rombToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var romb = _selectedShapes.OfType<Romb>().FirstOrDefault();
            if (romb != null)
                Calculations(romb);
        }

        private void trapezoidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var trapezoid = _selectedShapes.OfType<Trapezoid>().FirstOrDefault();
            if (trapezoid != null)
                Calculations(trapezoid);
        }
        private void btnLinQform_Click(object sender, EventArgs e)
        {
            LinQForm linQForm = new LinQForm(_shapes);
            linQForm.ShowDialog();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (!File.Exists("data.bin"))
            {
                throw new Exception("invalid filename");
            }
            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream fs = new FileStream("data.bin", FileMode.Open, FileAccess.Read)) 
            {
                _shapes = (List<Shape>)bf.Deserialize(fs);
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream fs = new FileStream("data.bin", FileMode.Create, FileAccess.Write)) 
            {
                bf.Serialize(fs, _shapes);
            }
        }

        private void asPNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                sfd.Title = "Запази рисунката като изображение";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Bitmap bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(this.BackColor);

                        _OnPaintGraphics = g;

                        foreach (var shape in _shapes)
                        {
                            shape.Draw(this);
                        }

                        _OnPaintGraphics = null;
                    }

                    bmp.Save(sfd.FileName);
                    MessageBox.Show("Изображението беше успешно запазено!");
                }
            }
        }
    }
}

