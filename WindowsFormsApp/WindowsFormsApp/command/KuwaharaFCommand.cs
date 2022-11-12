using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp.command
{
    class KuwaharaFCommand : FilterCommand
    {
        int filterSize;
        Bitmap source;

        public KuwaharaFCommand(Bitmap source, int filterSize) : base(source, true)
        {
            this.filterSize = filterSize;
            this.source = source;
        }

        public override Bitmap Operate()
        {
            return KuwaharaFilter.Filter(this.pic, this.filterSize);
        }
    }
}
