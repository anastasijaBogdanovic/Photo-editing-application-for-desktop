using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp
{
    class ConvFIilters
    {

        public int[,] Kernel { get; set; }
        public double Factor { get; set; }
        

        public virtual Bitmap MeanRemoval(Bitmap bmp, bool inPlace)
        {
            if (Kernel == null || Factor == 0.0)
                throw new Exception("Parametres not set!");
            Bitmap dist;
            if(!inPlace)
            {
                dist = new Bitmap(bmp.Width, bmp.Height); 
            }
            else
            {
                dist = new Bitmap(bmp);
                bmp = dist;
            }
           
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                    dist.SetPixel(i, j, this.ComputePixel(this.Kernel, this.GetPomMat(bmp, i, j)));
            return dist;
        }
        public Color ComputePixel(int[,] kernel, Color[,] subMatrix)
        {
            int r = 0, g = 0, b = 0;


            for (int i = 0; i < kernel.GetLength(0); i++)
                for (int j = 0; j < kernel.GetLength(1); j++)
                {
                    r += kernel[i, j] * subMatrix[i, j].R;
                    g += kernel[i, j] * subMatrix[i, j].G;
                    b += kernel[i, j] * subMatrix[i, j].B;

                }
            return Color.FromArgb(Math.Min(Math.Abs((int)(r / Factor)), 255), Math.Min(Math.Abs((int)(g / Factor)), 255), Math.Min(Math.Abs((int)(b / Factor)), 255));

        }
        public Color[,] GetPomMat(Bitmap source, int x, int y)
        {
             Color[,] submatrix = new Color[Kernel.GetLength(0), Kernel.GetLength(1)];
             int x0 = x - Kernel.GetLength(0) / 2;
             int y0 = y - Kernel.GetLength(1) / 2;
             for (int i = 0; i < Kernel.GetLength(0); i++)
                 for (int j = 0; j < Kernel.GetLength(1); j++)
                 {
                     int k = y0 + j;
                     int l = x0 + i;
                     if ((l<0 || l>source.Width-1) || (k<0 || k>source.Height-1))
                     {
                        submatrix[i, j] = Color.FromArgb(128, 128, 128);
                        
                     }
                     else
                     {
                        submatrix[i, j] = source.GetPixel(l, k);
                     }
             
                }
            return submatrix;
          
        }
       
    }
}
