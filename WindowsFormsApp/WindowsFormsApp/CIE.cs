using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp
{
    struct CIEColor
    {
        public double X;
        public double Y;
        public double Z;


        public CIEColor(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
    class CIE
    {
        public CIEColor[] pixels;
        private int width;
        private int height;
        private Bitmap bm;

        public CIE(Bitmap source)
        {
            bm = source;
            this.pixels = new CIEColor[source.Width * source.Height];
            this.width = source.Width;
            this.height = source.Height;
            int count = 0;
            for (int i = 0; i < source.Width; i++)
                for (int j = 0; j < source.Height; j++)
                    this.pixels[count++] = RGBToCIE(source.GetPixel(i, j));
        }

        public static CIEColor RGBToCIE(Color rgb)
        {
            double rLinear = (double)rgb.R / 255.0;
            double gLinear = (double)rgb.G / 255.0;
            double bLinear = (double)rgb.B / 255.0;

            CIEColor result = new CIEColor(0, 0, 0);
            double r = (rLinear > 0.4045) ? Math.Pow((rLinear + 0.055) / (1 + 0.055), 2.4) : (rLinear/12.92);
            double g = (gLinear > 0.4045) ? Math.Pow((gLinear + 0.055) / (1 + 0.055), 2.4) : (gLinear / 12.92);
            double b = (bLinear > 0.4045) ? Math.Pow((bLinear + 0.055) / (1 + 0.055), 2.4) : (bLinear / 12.92);

            result.X = r * 0.4124 + g * 0.3576 + b * 0.1805;
            result.Y = r * 0.2126 + g * 0.7152 + b * 0.0722;
            result.Z = r * 0.0193 + g * 0.1192 + b * 0.9505;
            
            return result;
        }

        public static Color CIEToRGB(CIEColor pixel)
        {
            double R = (pixel.X * 3.2404 - pixel.Y * 1.5371 - pixel.Z * 0.4985);
            double G = (pixel.Y * 1.8760 - pixel.X * 0.9692 + pixel.Z * 0.0415);
            double B = (pixel.X * 0.0556 - pixel.Y * 2.0402 + pixel.Z * 1.0572);

            int r = (int)((R > 0.0031) ? (1.055 * Math.Pow(R, 1/2.4) - 0.055) : (R * 12.92));
            int g = (int)((G > 0.4045) ? (1.055 * Math.Pow(G, 1 / 2.4) - 0.055) : (G * 12.92));
            int b = (int)((B > 0.4045) ? (1.055 * Math.Pow(B, 1 / 2.4) - 0.055) : (B * 12.92));

            return Color.FromArgb(r, g, b);
        }

        public Bitmap DisplayX()
        {
            Bitmap result = new Bitmap(this.width, this.height);
           for (int i = 0; i < result.Width; i++)
                for (int j = 0; j < result.Height; j++)
                {
                    Color c = bm.GetPixel(i, j);
                    CIEColor cl = RGBToCIE(c);
                    int x = (int)(cl.X >= 0 && cl.X <= 1 ? cl.X * 255:255  );
                    result.SetPixel(i, j, Color.FromArgb(x,0,0));
                }

            return result;
        }

        public Bitmap DisplayY()
        {
            Bitmap result = new Bitmap(this.width, this.height);
            for (int i = 0; i < result.Width; i++)
                for (int j = 0; j < result.Height; j++)
                {
                    Color c = bm.GetPixel(i, j);
                    CIEColor cl = RGBToCIE(c);
                    int y = (int)(cl.Y>=0&&cl.Y<=1?cl.Y * 255:255);
                    result.SetPixel(i, j, Color.FromArgb(0, y, 0));
                }
            return result;
        }

        public Bitmap DisplayZ()
        {
            Bitmap result = new Bitmap(this.width, this.height);
            for (int i = 0; i < result.Width; i++)
                for (int j = 0; j < result.Height; j++)
                {
                    Color c = bm.GetPixel(i, j);
                    CIEColor cl = RGBToCIE(c);
                    int z = (int)(cl.Z >= 0 && cl.Z <= 1 ? cl.Z * 255 : 255);
                    result.SetPixel(i, j, Color.FromArgb(0, 0, z));
                }
            return result;
        }
    }
}
