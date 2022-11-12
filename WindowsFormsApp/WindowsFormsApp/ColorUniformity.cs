using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    struct PointT
    {
        public int i;
        public int j;
        public PointT(int i, int j)
        {
            this.i = i;
            this.j = j;
        }
    }

    class ColorUniformity
    {
        Color X;
        PointT T;
        CIEColor Y;
        double S;

        public ColorUniformity(Bitmap source, int i, int j)
        {
            Bitmap img = new Bitmap(source.Width, source.Height);
            Color y = img.GetPixel(i, j);
            Y = CIE.RGBToCIE(y);
            T.i = i;
            T.j = j;

            ColorDialog colorDlg = new ColorDialog();
            colorDlg.AllowFullOpen = false;
            colorDlg.AnyColor = true;
            X = Color.Red;

            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
               X  = colorDlg.Color;
            }

            S = SIM(X, Y);
            Filter(img, T, S, X, Y);
        }

        public static double SIM(Color X, CIEColor Y)
        {
            CIEColor nova = CIE.RGBToCIE(X);
            return Math.Sqrt(Math.Pow((nova.X - Y.X + nova.Y - Y.Y + nova.Z - Y.Z), 2));
        }

        public static Bitmap Filter(Bitmap source, PointT t, double S, Color X, CIEColor Y)
        {
            Bitmap dist = new Bitmap(source.Width, source.Height);
            for (int i = 0; i < source.Width; i++)
                for (int j = 0; j < source.Height; j++)
                {
                    if(t.i == i && t.j == j)
                    {
                        dist.SetPixel(i, j, X);
                    }
                    else
                    {
                        Color pixel = source.GetPixel(i, j);
                        double s = SIM(pixel, Y);
                        if (s <= S)
                        {
                            dist.SetPixel(i, j, X);
                        }
                    }
                }
            return dist;
        }
    }
}
