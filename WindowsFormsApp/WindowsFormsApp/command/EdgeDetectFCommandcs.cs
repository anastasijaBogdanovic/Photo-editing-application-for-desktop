using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WindowsFormsApp.command
{
    class EdgeDetectFCommandcs:FilterCommand
    {
        private byte val;
        public EdgeDetectFCommandcs(Bitmap source, bool isSafe,byte val) : base(source, isSafe)
        {

            this.val = val;
        }

        public override Bitmap Operate()
        {
            return Filters.EdgeDetectHomogenity(this.pic, this.val);
        }
    }
}
