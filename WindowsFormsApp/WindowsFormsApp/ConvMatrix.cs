using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace WindowsFormsApp
{
    class ConvMatrix:ConvFIilters
    {

        public ConvMatrix(int size,int n)
        {
            double factor = 0;
            if (size != 3 && size != 5 && size != 7)
                size = 3;
            int[,] kernel = new int[size, size];

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    if (i == size / 2 && j == size / 2)
                        kernel[i, j] = n;
                    else
                        kernel[i, j] = -1;
                    
                }
            if (size == 7)
                kernel[0, 2] = kernel[0, 5] = kernel[1, 0] = kernel[4, 0] = kernel[6, 1] = kernel[6, 4] = kernel[2, 6] = kernel[5, 6] = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    factor += kernel[i, j];
                }
            }
                   base.Kernel = kernel;
            base.Factor = factor;
        }
    }
}
