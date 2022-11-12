using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WindowsFormsApp.command
{
    class TimeWarpCommand:FilterCommand
    {
        private byte val;
        public TimeWarpCommand(Bitmap source, bool isSafe, byte val) : base(source, isSafe)
        {

            this.val = val;
        }

        public override Bitmap Operate()
        {
            return Filters.TimeWarp(this.pic, val);
        }
    }
}
