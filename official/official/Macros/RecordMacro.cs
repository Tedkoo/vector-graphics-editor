using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace official.Macros
{
    public class RecordMacro : MacroAction
    {
        private List<Shape> _recordedShapes = new List<Shape>();

        public void Record(Shape shape)
        {
            _recordedShapes.Add(shape.Clone());
        }
        public override void Execute(List<Shape> shapes)
        {

            foreach (var shape in _recordedShapes)
            {
                shapes.Add(shape.Clone());
            }
        }
        public void Clear()
        {
            _recordedShapes.Clear();
        }
    }
}
