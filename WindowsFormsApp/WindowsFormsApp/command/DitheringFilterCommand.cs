using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp.command
{
    enum DitheringMode
    {
        Ordering,
        Burkes
    }

    class DitheringFilterCommand : FilterCommand
    {
        private DitheringMode mode;
        private Bitmap source;

        public DitheringFilterCommand(Bitmap source, DitheringMode mode) : base(source, true)
        {
            this.source = source;
            this.mode = mode;
        }

        public override Bitmap Operate()
        {
            switch (mode)
            {
                case DitheringMode.Ordering:
                    return Dithering.OrderedDithering(source);
                default:
                    return Dithering.BurkesDithering(source);
            }
        }
    }
}
