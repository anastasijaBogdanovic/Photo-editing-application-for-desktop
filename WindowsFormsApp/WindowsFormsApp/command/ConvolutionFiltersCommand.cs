using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WindowsFormsApp.command
{
   abstract class ConvolutionFiltersCommand : Command
    {
        protected Bitmap pic;
        protected bool inPlace;
        public ConvolutionFiltersCommand(Bitmap pic, bool inPlace)
        {
            this.pic = pic;
            this.inPlace = inPlace;
        }
        public abstract Bitmap Operate();
    }
}
