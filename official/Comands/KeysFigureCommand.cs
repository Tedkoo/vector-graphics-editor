using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace official.Comands
{
    public class KeysFigureCommand : ICommand
    {
        private FormMain _scene;

        public KeysFigureCommand(FormMain scene)
        {
            _scene = scene;
        }
        public void MouseDown(MouseEventArgs e) { }
        public void MouseMove(MouseEventArgs e) { }
        public void MouseUp(MouseEventArgs e) { }
        public void KeyDown(KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.Delete && _scene._selectedShapes.Count > 0)
            {
                _scene.PushUndoState();

                for (int s = 0; s < _scene._selectedShapes.Count; s++)
                    _scene._shapes.Remove(_scene._selectedShapes[s]);

                _scene._selectedShapes.Clear();

                _scene.Invalidate();
            }


            if (e.KeyCode == Keys.Escape)
                this._scene.Close();

            if(e.Control && e.KeyCode == Keys.Z)
                _scene.Undo();

            if(e.Control && e.KeyCode == Keys.Y)
                _scene.Redo();
        }
        public void DoubleClick(EventArgs e) { }
    }
}
