using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    enum DownsamplingMode
    {
        HandS,
        HandV,
        SandV,
        None
    }

    struct DownsampledImg
    {
        public int[] XArray { get; set; }
        public int[] YArray { get; set; }
        public int[] ZArray { get; set; }
        public int width;
        public int heigth;
        public DownsamplingMode mode;

        public DownsampledImg(int[] x, int[] y, int[] z, int w, int h, DownsamplingMode m)
        {
            XArray = x;
            YArray = y;
            ZArray = z;
            width = w;
            heigth = h;
            mode = m;
        }
    }

    class Downsampling
    {
        public static DownsampledImg DownsampleImage(Bitmap bmp, DownsamplingMode mode)
        {
            CIE cie = new CIE(bmp);
            int[] x, y, z;
            switch (mode)
            {
                case DownsamplingMode.HandS:
                    x = DownsampleChannel(cie.pixels.Select(p => (int)p.X).ToArray(), bmp.Width, bmp.Height);
                    y = DownsampleChannel(cie.pixels.Select(p => (int)p.Y).ToArray(), bmp.Width, bmp.Height);
                    z = cie.pixels.Select(p => (int)p.Z).ToArray();
                    break;

                case DownsamplingMode.HandV:
                    x = DownsampleChannel(cie.pixels.Select(p => (int)p.X).ToArray(), bmp.Width, bmp.Height);
                    y = cie.pixels.Select(p => (int)p.Y).ToArray();
                    z = DownsampleChannel(cie.pixels.Select(p => (int)p.Z).ToArray(), bmp.Width, bmp.Height);
                    break;

                case DownsamplingMode.SandV:
                    x = cie.pixels.Select(p => (int)p.X).ToArray();
                    y = DownsampleChannel(cie.pixels.Select(p => (int)p.Y).ToArray(), bmp.Width, bmp.Height);
                    z = DownsampleChannel(cie.pixels.Select(p => (int)p.Z).ToArray(), bmp.Width, bmp.Height);
                    break;

                default:
                    x = cie.pixels.Select(p => (int)p.X).ToArray();
                    y = cie.pixels.Select(p => (int)p.Y).ToArray();
                    z = cie.pixels.Select(p => (int)p.Z).ToArray();
                    break;
            }
            return new DownsampledImg(x, y, z, bmp.Width, bmp.Height, mode);
        }

        public static int[] DownsampleChannel(int[] pixels, int w, int h)
        {
            int evenRowSize = h / 2 + (h % 4 != 0 ? 1 : 0);
            int oddRowSize = h / 2 - (h % 4 == 2 ? 1 : 0);
            int evenRowsNum = w / 2 + (w % 4 != 0 ? 1 : 0);
            int oddRowsNum = w - evenRowsNum;
            int[] result = new int[evenRowSize * evenRowsNum + oddRowSize * oddRowsNum];
            int k = 0;
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                    if ((i % 4 < 2 && j % 4 < 2) || (i % 4 >= 2 && j % 4 >= 2))
                        result[k++] = pixels[i * h + j];
            }
            return result;
        }

        public static Bitmap UpsampleImage(DownsampledImg img)
        {
            Bitmap result = new Bitmap(img.width, img.heigth);
            int[] x;
            int[] y;
            int[] z;

            switch (img.mode)
            {
                case DownsamplingMode.HandS:
                    x = UpsampleChannel(img.XArray, img.width, img.heigth);
                    y = UpsampleChannel(img.YArray, img.width, img.heigth);
                    z = img.ZArray;
                    break;

                case DownsamplingMode.HandV:
                    x = UpsampleChannel(img.XArray, img.width, img.heigth);
                    y = img.YArray;
                    z = UpsampleChannel(img.ZArray, img.width, img.heigth);
                    break;

                case DownsamplingMode.SandV:
                    x = img.XArray;
                    y = UpsampleChannel(img.YArray, img.width, img.heigth);
                    z = UpsampleChannel(img.ZArray, img.width, img.heigth);
                    break;

                default:
                    x = img.XArray;
                    y = img.YArray;
                    z = img.ZArray;
                    break;
            }
            
            CIEColor[] pixels = new CIEColor[img.width * img.heigth];
            for (int i = 0; i < img.width * img.heigth; i++)
            {
                pixels[i] = new CIEColor((int)x[i], (int)y[i], (int)z[i]);
            }

            for (int i = 0; i < img.width; i++)
                for (int j = 0; j < img.heigth; j++)
                    result.SetPixel(i, j, CIE.CIEToRGB(pixels[i * img.heigth + j]));
            return result;
        }

        public static int[] UpsampleChannel(int[] pixels, int w, int h)
        {
            int evenRowSize = h / 2 + (h % 4 != 0 ? 1 : 0);
            int oddRowSize = h / 2 - (h % 4 == 2 ? 1 : 0);
            int evenRowsNum = w / 2 + (w % 4 != 0 ? 1 : 0);
            int oddRowsNum = w - evenRowsNum;
            int[] result = new int[w * h];
            int offset = 0;
            for (int i = 0; i < w; i++)
            {
                bool even = i % 4 < 2;
                if (even)
                {
                    for (int j = 0; j < evenRowSize; j++)
                    {
                        if ((j * 2 + j % 2) < h)
                            result[i * h + j * 2 + j % 2] = pixels[offset + j];
                        if ((j * 2 + j % 2 + 2) < h)
                            result[i * h + j * 2 + j % 2 + 2] = pixels[offset + j];
                    }
                }
                else
                {
                    for (int j = 0; j < oddRowSize; j++)
                    {
                        if ((j * 2 + j % 2) < h)
                            result[i * h + j * 2 + j % 2] = pixels[offset + j];
                        if ((j * 2 + j % 2 + 2) < h)
                            result[i * h + j * 2 + j % 2 + 2] = pixels[offset + j];
                    }
                }
                offset += even ? evenRowSize : oddRowSize;
            }
            return result;
        }
    }
}
