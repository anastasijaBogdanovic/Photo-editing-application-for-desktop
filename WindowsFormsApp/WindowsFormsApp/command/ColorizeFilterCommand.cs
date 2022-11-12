using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.command
{
    enum ColorizeMode
    {
        Simple,
        Similiar
    }
    class ColorizeFilterCommand : FilterCommand
    {
        private ColorizeMode mode;
        private Bitmap similiarBitmap, source;
        private double newHue;
        private double newSaturation;
        public ColorizeFilterCommand(Bitmap source, ColorizeMode mode, Bitmap similiar = null, double newHue = 0, double newSaturation = 0) : base(source, true)
        {
            this.mode = mode;
            this.source = source;
            this.similiarBitmap = similiar;
            this.newHue = newHue;
            this.newSaturation = newSaturation;
        }

        public override Bitmap Operate()
        {
            switch (mode)
            {
                case ColorizeMode.Simple:
                    return Colorize.Filter(source);
                default:
                    return similiarBitmap == null ? throw new Exception("Similiar bitmap not set") : Colorize.FilterSimiliar(source, similiarBitmap);
            }
        }
    }
}
