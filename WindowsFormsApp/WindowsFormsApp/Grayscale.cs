using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp
{
    static class Greyscale
    {
        public static Bitmap Arithmetic(Bitmap source)
        {
            return Filter(source, ArithmeticMean);
        }
        public static Bitmap MaxChannel(Bitmap source)
        {
            return Filter(source, Maximum);
        }

        public static Bitmap ThirdChannel(Bitmap source)
        {
           return Filter(source, ThirdAlgorithm);
        }

        private static Bitmap Filter(Bitmap source, Func<Color, int, int> convertFunction)
        {
            Bitmap dist = new Bitmap(source.Width, source.Height);

            int numberOfShades = 0;
            HashSet<Color> colors = new HashSet<Color>();
            
            for (int i = 0; i < source.Width; i++)
                for (int j = 0; j < source.Height; j++)
                {
                    colors.Add(dist.GetPixel(j, i));
                    Color pixel = source.GetPixel(i, j);
                    int grey = convertFunction(pixel, numberOfShades);
                    dist.SetPixel(i, j, Color.FromArgb(grey, grey, grey));
                }
            numberOfShades = colors.Count;
            return dist;
        }

        private static int ArithmeticMean(Color pixel, int numberOfShades)
        {
            return (pixel.R + pixel.G + pixel.B) / 3;
        }

        private static int Maximum(Color pixel, int numberOfShades)
        {
            return Math.Max(Math.Max(pixel.R, pixel.G), pixel.B);
        }

        private static int ThirdAlgorithm(Color pixel, int numberOfShades)
        {
            int conversionFactor = 255 / (numberOfShades - 1);
            // tad dobijem ogroman broj za numberOfShades onda je 255/n priblizan nuli i ne radi nadalje racunica zato da kad je manje od 1 ga automacki namestam da je 1
            if (conversionFactor < 1)
                conversionFactor = 1;

            int averageValue = (pixel.R + pixel.G + pixel.B) / 3;
            return Convert.ToInt32((averageValue / conversionFactor) + 0.5) * conversionFactor;
        }
    }
}
