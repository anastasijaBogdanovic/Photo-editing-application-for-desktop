using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WindowsFormsApp.command
{
    abstract class FilterCommand :Command
    {
        protected Bitmap pic;
        protected bool unSafe;
        public FilterCommand(Bitmap pic, bool unSafe)
        {
            this.pic= pic;
            this.unSafe = unSafe;
        }
        public abstract Bitmap Operate();
    }
}
