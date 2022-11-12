using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp.command
{
    class MeanRemovalCommand :FilterCommand
    {
        private ConvMatrix mat;
        private bool isInplace;
        public MeanRemovalCommand(Bitmap pic,bool isSafe,int kernelDim,int n, bool isInplace):base(pic,isSafe)
        {
            this.mat = new ConvMatrix(kernelDim, n);
            this.isInplace = isInplace;
        }

        public override Bitmap Operate()
        {
            return mat.MeanRemoval(this.pic, this.isInplace);
        }
    }
}
