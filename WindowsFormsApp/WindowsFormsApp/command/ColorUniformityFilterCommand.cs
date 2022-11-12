using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp.command
{
    class ColorUniformityFilterCommand : FilterCommand
    {
        Bitmap source;
        PointT t;
        double S;
        Color X;
        CIEColor Y;

        public ColorUniformityFilterCommand(Bitmap source, PointT t, double S, Color X, CIEColor Y) : base(source, true)
        {
            this.source = source;
            this.t = t;
            this.S = S;
            this.X = X;
            this.Y = Y;
        }

        public override Bitmap Operate()
        {
            return ColorUniformity.Filter(this.source, this.t, this.S, this.X, this.Y);
        }
    }
}
