using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WindowsFormsApp
{
    class Buffer
    {
        private List<Bitmap> buffer;
        private int max; //buffer capacity in megabytes

        public Buffer(int m)
        {
            buffer = new List<Bitmap>(m);
            this.max = m;
        }

        public void Push(Bitmap pic)
        {
            if (this.buffer.Count > this.max)
            {
                //obrisacemo polovinu
                for(int i=0; i < max/2; i++)
                {
                    this.buffer.RemoveAt(i);
                }
            }
            this.buffer.Add(pic);
        }

        public Bitmap Pop()
        {
            if (this.buffer.Count == 0)
                throw new Exception("Buffer is empty");
            Bitmap pic= this.buffer[this.buffer.Count - 1];
            this.buffer.RemoveAt(this.buffer.Count - 1);
            return pic;
        }

        public void EmptyBuffer()
        {
            while (this.buffer.Count != 0)
            {
                this.buffer.RemoveAt(0);
            }
        }
    }
}
