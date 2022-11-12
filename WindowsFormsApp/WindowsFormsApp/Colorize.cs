using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp
{
    class Colorize
    {
        private static Color[] collorMapping;
        static Colorize()
        {
            collorMapping = new Color[256];
            //dark
            for (int i = 0; i < 50; i++)
                collorMapping[i] = Color.FromArgb(i, i, i);
            //collorMapping[i] = Color.FromArgb(2*i,(int) (2*i*0.66), (int)(2*0.33*i));
            //brown
            for (int i = 50; i < 120; i++)
                collorMapping[i] = Color.FromArgb(2 * i, (int)(0.66 * 2 * i), (int)(0.33 * 2 * i));
            // collorMapping[i] = Color.FromArgb(101+(int)(1.3*i),67+ (int)(0.32 * i), 33+(int)(1.225 * i));
            //pink
            for (int i = 120; i < 160; i++)
                collorMapping[i] = Color.FromArgb((int)Math.Min(255, i * 1.5), i, (int)Math.Min(255, 2 * i * 0.7));
            //collorMapping[i] = Color.FromArgb((int)1.7*i, (int)(0.875*i), (int)(1.4*i));
            //collorMapping[i] = Color.FromArgb(255 , 105 + (int)(0.937 * i), 180 + (int)(0.46 * i));
            //white
            for (int i = 160; i < 256; i++)
                collorMapping[i] = Color.FromArgb(255, 255, 255);
        }

        public static Bitmap Filter(Bitmap source)
        {
            Bitmap dist = new Bitmap(source.Width, source.Height);
            var arr = collorMapping;
            for (int i = 0; i < source.Width; i++)
                for (int j = 0; j < source.Height; j++)
                {
                    int grey = source.GetPixel(i, j).R;
                    dist.SetPixel(i, j, collorMapping[grey]);
                }
            return dist;
        }

        public static Bitmap FilterSimiliar(Bitmap source, Bitmap similiarImg)
        {
            var mapping = SimiliarMapping(similiarImg);
            Bitmap dist = new Bitmap(source.Width, source.Height);
            var arr = collorMapping;
            for (int i = 0; i < source.Width; i++)
                for (int j = 0; j < source.Height; j++)
                {
                    int grey = source.GetPixel(i, j).R;
                    dist.SetPixel(i, j, mapping[grey]);
                }
            return dist;
        }

        public static Color[] SimiliarMapping(Bitmap img)
        {
            Color[] mapping = new Color[256];
            Bitmap greyscale = Grayscale(img);
            for (int i = 0; i < img.Width; i++)
                for (int j = 0; j < img.Height; j++)
                {
                    mapping[greyscale.GetPixel(i, j).R] = img.GetPixel(i, j);
                }
            return mapping;
        }

        public static Bitmap Grayscale(Bitmap source)
        {
            Bitmap dist = new Bitmap(source.Width, source.Height);
            for (int i = 0; i < source.Width; i++)
                for (int j = 0; j < source.Height; j++)
                {
                    Color pixel = source.GetPixel(i, j);
                    int grey = (int)(.299 * pixel.R + .587 * pixel.G + .114 * pixel.B);

                    dist.SetPixel(i, j, Color.FromArgb(grey, grey, grey));
                }
            return dist;
        }
    }
}
