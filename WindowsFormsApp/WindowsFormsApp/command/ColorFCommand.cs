using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WindowsFormsApp.command
{
    class ColorFCommand : FilterCommand
    {
        private int r;
        private int g;
        private int b;

        public ColorFCommand(Bitmap source, bool isSafe, int r, int g, int b) : base(source, isSafe)
        {

            this.r = r;
            this.g = g;
            this.b = b;
        }

        public override Bitmap Operate()
        {
            if (this.unSafe)
            {
               return UnsafeFilters.Color(this.pic, r, g, b);

            }
            else
            {
               return Filters.Color(this.pic, r, g, b);
            }
        }
      

    }
}
