using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp
{
    struct Values
    {
        public double T;
        public double C;

        public Values(int X, int Y)
        {
            this.T = X;
            this.C = Y;
        }
    }

    class HistogramCutting
    {
        public static Bitmap Filter(Bitmap source, Values cuttingValues)
        {
            Bitmap dist = new Bitmap(source);
            for (int i = 0; i < dist.Width; i++)
                for (int j = 0; j < dist.Height; j++)
                {
                    Color pixel = source.GetPixel(i, j);
                    CIEColor cie = CIE.RGBToCIE(pixel);
                    double newX, newY, newZ;

                    if (cie.X < cuttingValues.T)
                    {
                        newX = 0;
                    }
                    else
                    {
                        double x = cie.X - cuttingValues.C;
                        newX = x < 0 ? 0 : x;
                    }

                    if (cie.Y < cuttingValues.T)
                    {
                        newY = 0;
                    }
                    else
                    {
                        double y = cie.Y - cuttingValues.C;
                        newY = y < 0 ? 0 : y;
                    }

                    if (cie.Z < cuttingValues.T)
                    {
                        newZ = 0;
                    }
                    else
                    {
                        double z = cie.Z - cuttingValues.C;
                        newZ = z < 0 ? 0 : z;
                    }

                    Color nextPixel = CIE.CIEToRGB(new CIEColor(newX, newY, newZ));
                    dist.SetPixel(i, j, nextPixel);
                }
            return dist;
        }
    }
}
