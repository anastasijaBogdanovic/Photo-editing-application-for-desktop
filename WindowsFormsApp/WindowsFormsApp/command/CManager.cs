using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WindowsFormsApp.command
{
    class CManager
    {
        private Buffer undoBuffer;
        private Buffer redoBuffer;
        public Bitmap bitmap { get; set; }

        public CManager(int max)
        {
            undoBuffer = new Buffer(max);
            redoBuffer = new Buffer(max);
            bitmap = new Bitmap(2, 2);
        }

        public void Execute(Command command)
        {
            undoBuffer.Push(bitmap);
            redoBuffer.EmptyBuffer();
            bitmap = command.Operate();
        }

        public void Undo()
        {

            redoBuffer.Push(bitmap);
            bitmap = undoBuffer.Pop();
        }

        public void Redo()
        {
            undoBuffer.Push(bitmap);
            bitmap = redoBuffer.Pop();

        }
    }
}
