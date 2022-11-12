using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    class KuwaharaFilter
    {
        public static Bitmap Filter(Bitmap OriginalImage, int FilterSize)
        {
            Bitmap image = OriginalImage;
            Bitmap image2 = new Bitmap(image.Width, image.Height);

            if (FilterSize % 2 == 0)
            {
                throw new Exception("Mora biti neparan broj");
            }

            if (FilterSize < 3)
            {
                throw new Exception("Mora biti veci od 2");
            }

            int size = 2 * FilterSize - 1;
            int range = (int)Math.Floor(Convert.ToDouble(size / 2));

            for (int m = range; m < image.Width - range; m++)
            {
                for (int n = range; n < image.Height - range; n++)
                {
                    int[,,] roi = new int[3, size, size];

                    int tmpj = 0;
                    int tmpi = 0;

                    int newValueR = 0;
                    int newValueG = 0;
                    int newValueB = 0;

                    Color CPixel = image.GetPixel(m, n);

                    for (int i = m - range; i < m + range + 1; i++)
                    {
                        for (int j = n - range; j < n + range + 1; j++)
                        {
                            Color pixel = image.GetPixel(i, j);
                            Double pr = Convert.ToDouble(pixel.R);
                            Double pg = Convert.ToDouble(pixel.G);
                            Double pb = Convert.ToDouble(pixel.B);

                            roi[0, tmpi, tmpj] = (int)pr;
                            roi[1, tmpi, tmpj] = (int)pg;
                            roi[2, tmpi, tmpj] = (int)pb;

                            tmpj++;
                        }

                        tmpi++;
                        tmpj = 0;
                    }

                    int[,] roivector1 = new int[3, FilterSize * FilterSize];
                    int[,] roivector2 = new int[3, FilterSize * FilterSize];
                    int[,] roivector3 = new int[3, FilterSize * FilterSize];
                    int[,] roivector4 = new int[3, FilterSize * FilterSize];

                    int tmp1 = 0;
                    for (int i = 0; i < FilterSize; i++)
                    {
                        for (int j = 0; j < FilterSize; j++)
                        {
                            roivector1[0, tmp1] = roi[0, i, j];
                            roivector1[1, tmp1] = roi[1, i, j];
                            roivector1[2, tmp1] = roi[2, i, j];
                            tmp1++;
                        }
                    }

                    int tmp2 = 0;
                    for (int i = 0; i < FilterSize; i++)
                    {
                        for (int j = (FilterSize - 1); j < roi.GetLength(1); j++)
                        {
                            roivector2[0, tmp2] = roi[0, i, j];
                            roivector2[1, tmp2] = roi[1, i, j];
                            roivector2[2, tmp2] = roi[2, i, j];
                            tmp2++;
                        }
                    }

                    int tmp3 = 0;
                    for (int i = (FilterSize - 1); i < roi.GetLength(0); i++)
                    {
                        for (int j = 0; j < FilterSize; j++)
                        {
                            roivector3[0, tmp3] = roi[0, i, j];
                            roivector3[1, tmp3] = roi[1, i, j];
                            roivector3[2, tmp3] = roi[2, i, j];
                            tmp3++;
                        }
                    }

                    int tmp4 = 0;
                    for (int i = (FilterSize - 1); i < roi.GetLength(0); i++)
                    {
                        for (int j = (FilterSize - 1); j < roi.GetLength(1); j++)
                        {
                            roivector4[0, tmp4] = roi[0, i, j];
                            roivector4[1, tmp4] = roi[1, i, j];
                            roivector4[2, tmp4] = roi[2, i, j];
                            tmp4++;
                        }
                    }

                    Double[] avgR = new Double[4] { 0, 0, 0, 0 };
                    Double[] avgG = new Double[4] { 0, 0, 0, 0 };
                    Double[] avgB = new Double[4] { 0, 0, 0, 0 };

                    Double[] varR = new Double[4] { 0, 0, 0, 0 };
                    Double[] varG = new Double[4] { 0, 0, 0, 0 };
                    Double[] varB = new Double[4] { 0, 0, 0, 0 };

                    for (int i = 0; i < FilterSize * FilterSize; i++)
                    {

                        avgR[0] += Convert.ToDouble(roivector1[0, i]) / (FilterSize * FilterSize);
                        avgR[1] += Convert.ToDouble(roivector2[0, i]) / (FilterSize * FilterSize);
                        avgR[2] += Convert.ToDouble(roivector3[0, i]) / (FilterSize * FilterSize);
                        avgR[3] += Convert.ToDouble(roivector4[0, i]) / (FilterSize * FilterSize);

                        avgG[0] += Convert.ToDouble(roivector1[1, i]) / (FilterSize * FilterSize);
                        avgG[1] += Convert.ToDouble(roivector2[1, i]) / (FilterSize * FilterSize);
                        avgG[2] += Convert.ToDouble(roivector3[1, i]) / (FilterSize * FilterSize);
                        avgG[3] += Convert.ToDouble(roivector4[1, i]) / (FilterSize * FilterSize);

                        avgB[0] += Convert.ToDouble(roivector1[2, i]) / (FilterSize * FilterSize);
                        avgB[1] += Convert.ToDouble(roivector2[2, i]) / (FilterSize * FilterSize);
                        avgB[2] += Convert.ToDouble(roivector3[2, i]) / (FilterSize * FilterSize);
                        avgB[3] += Convert.ToDouble(roivector4[2, i]) / (FilterSize * FilterSize);
                    }

                    for (int i = 0; i < FilterSize * FilterSize; i++)
                    {
                        varR[0] += Math.Pow((Convert.ToDouble(roivector1[0, i]) - avgR[0]), 2) / (FilterSize * FilterSize);
                        varR[1] += Math.Pow((Convert.ToDouble(roivector2[0, i]) - avgR[1]), 2) / (FilterSize * FilterSize);
                        varR[2] += Math.Pow((Convert.ToDouble(roivector3[0, i]) - avgR[2]), 2) / (FilterSize * FilterSize);
                        varR[3] += Math.Pow((Convert.ToDouble(roivector4[0, i]) - avgR[3]), 2) / (FilterSize * FilterSize);

                        varG[0] += Math.Pow((Convert.ToDouble(roivector1[1, i]) - avgG[0]), 2) / (FilterSize * FilterSize);
                        varG[1] += Math.Pow((Convert.ToDouble(roivector2[1, i]) - avgG[1]), 2) / (FilterSize * FilterSize);
                        varG[2] += Math.Pow((Convert.ToDouble(roivector3[1, i]) - avgG[2]), 2) / (FilterSize * FilterSize);
                        varG[3] += Math.Pow((Convert.ToDouble(roivector4[1, i]) - avgG[3]), 2) / (FilterSize * FilterSize);

                        varB[0] += Math.Pow((Convert.ToDouble(roivector1[2, i]) - avgB[0]), 2) / (FilterSize * FilterSize);
                        varB[1] += Math.Pow((Convert.ToDouble(roivector2[2, i]) - avgB[1]), 2) / (FilterSize * FilterSize);
                        varB[2] += Math.Pow((Convert.ToDouble(roivector3[2, i]) - avgB[2]), 2) / (FilterSize * FilterSize);
                        varB[3] += Math.Pow((Convert.ToDouble(roivector4[2, i]) - avgB[3]), 2) / (FilterSize * FilterSize);
                    }

                    int minIndexR = Array.IndexOf(varR, varR.Min());
                    int minIndexG = Array.IndexOf(varG, varG.Min());
                    int minIndexB = Array.IndexOf(varB, varB.Min());

                    newValueR = (int)avgR[minIndexR];

                    if (newValueR > 255) newValueR = 255;
                    if (newValueR < 0) newValueR = 0;

                    newValueG = (int)avgG[minIndexG];

                    if (newValueG > 255) newValueG = 255;
                    if (newValueG < 0) newValueG = 0;

                    newValueB = (int)avgB[minIndexB];

                    if (newValueB > 255) newValueB = 255;
                    if (newValueB < 0) newValueB = 0;

                    image2.SetPixel(m, n, Color.FromArgb(255, newValueR, newValueG, newValueB));
                }
            }
            return image2;
        }
    }
}
