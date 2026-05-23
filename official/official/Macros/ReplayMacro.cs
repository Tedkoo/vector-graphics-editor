using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace official.Macros
{
    public class ReplayMacro : MacroAction
    {
        private RecordMacro _recordedMacro;

        public ReplayMacro (RecordMacro macro)
        {
            _recordedMacro = macro;
        }

        public override void Execute(List<Shape> shapes)
        {
            _recordedMacro.Execute(shapes);
        }
    }
}
