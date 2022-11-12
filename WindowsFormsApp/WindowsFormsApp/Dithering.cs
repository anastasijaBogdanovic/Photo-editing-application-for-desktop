using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp
{
    struct DitheringCoef
    {
        public int i;
        public int j;
        public int val;
        public DitheringCoef(int i, int j, int val)
        {
            this.i = i;
            this.j = j;
            this.val = val;
        }
    }

    static class Dithering
    {
        private static DitheringCoef[] ditheringCoefs = { new DitheringCoef(0, 1, 8), new DitheringCoef(0, 2, 4), new DitheringCoef(1, -2, 2), new DitheringCoef(1, -1, 4), new DitheringCoef(1, 0, 8), new DitheringCoef(1, 1, 4), new DitheringCoef(1, 2, 2) };
        private static int ditheringFactor = 32;

        public static Bitmap OrderedDithering(Bitmap source)
        {
            int[,] ditheringMatrix = new int[3, 3] { { 6, 8, 4 }, { 1, 0, 3 }, { 5, 2, 7 } };
            Bitmap dist = new Bitmap(source.Width, source.Height);
            int k, m;
            k = m = 0;
            for (int i = 0; i < source.Width; i++)
            {
                for (int j = 0; j < source.Height; j++)
                {
                    Color pixel = source.GetPixel(i, j);
                    int R = (pixel.R / 255.0 * 9) > ditheringMatrix[k, m] ? 255 : 0;
                    int G = (pixel.G / 255.0 * 9) > ditheringMatrix[k, m] ? 255 : 0;
                    int B = (pixel.B / 255.0 * 9) > ditheringMatrix[k, m] ? 255 : 0;
                    dist.SetPixel(i, j, Color.FromArgb(R, G, B));
                    m = (m + 1) % 3;
                }
                k = (k + 1) % 3;
            }
            return dist;
        }

        private static int FindClosestColor(int col)
        {
            return col > 127 ? 255 : 0;
        }

        public static Bitmap BurkesDithering(Bitmap source)
        {
            Bitmap dist = new Bitmap(source);
            for (int i = 0; i < dist.Width; i++)
                for (int j = 0; j < dist.Height; j++)
                {
                    Color oldPixel = dist.GetPixel(i, j);
                    int R = FindClosestColor(oldPixel.R);
                    int G = FindClosestColor(oldPixel.G);
                    int B = FindClosestColor(oldPixel.B);
                    dist.SetPixel(i, j, Color.FromArgb(R, G, B));

                    int errorR = oldPixel.R - R;
                    int errorG = oldPixel.G - G;
                    int errorB = oldPixel.B - B;

                    for (int k = 0; k < ditheringCoefs.Length; k++)
                    {
                        int neigborI = i + ditheringCoefs[k].i;
                        int neigborJ = j + ditheringCoefs[k].j;
                        if (neigborI < 0 || neigborI >= dist.Width || neigborJ < 0 || neigborJ >= dist.Height)
                            continue;
                        Color pixel = dist.GetPixel(neigborI, neigborJ);
                        int newR = Math.Max(0, Math.Min(255, pixel.R + errorR * ditheringCoefs[k].val / ditheringFactor));
                        int newG = Math.Max(0, Math.Min(255, pixel.G + errorG * ditheringCoefs[k].val / ditheringFactor));
                        int newB = Math.Max(0, Math.Min(255, pixel.B + errorB * ditheringCoefs[k].val / ditheringFactor));
                        dist.SetPixel(neigborI, neigborJ, Color.FromArgb(newR, newG, newB));

                    }
                }
            return dist;
        }
    }
}
