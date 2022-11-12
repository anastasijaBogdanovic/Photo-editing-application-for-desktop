using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp.command
{
    class HistogramCuttingCommand : FilterCommand
    {
        private Values cuttingValues;
        private Bitmap source;

        public HistogramCuttingCommand(Bitmap source, Values cutting) : base(source, true)
        {
            this.source = source;
            this.cuttingValues = cutting;
        }

        public override Bitmap Operate()
        {
            return HistogramCutting.Filter(source, cuttingValues);
        }
    }
}
