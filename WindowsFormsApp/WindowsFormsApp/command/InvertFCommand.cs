using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp.command
{
    class InvertFCommand : FilterCommand
    {
        public InvertFCommand(Bitmap source, bool isSafe) : base(source, isSafe)
        {


        }

        public override Bitmap Operate()
        {
            if (this.unSafe)
            {
                return UnsafeFilters.Invert(this.pic);

            }
            else
            {
                return Filters.Invert(this.pic);
            }
        }
    }
}
