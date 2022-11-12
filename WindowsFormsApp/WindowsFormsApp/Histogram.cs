using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    class Histogram
    {
        public static void DrawHistogram(Graphics gr, int[] values, int width, int height, int range, Point offset)
        {
            double heightUnit = height / (double)GetMax(values);
            double widthUnit = width / (double)range;
            Pen thin_pen = new Pen(Color.Black, 0);
            for (int i = 0; i < values.Length; i++)
            {
                double widthOffset = i * widthUnit;
                double rectH = heightUnit * values[i];
                Rectangle r = new Rectangle(offset.X + (int)widthOffset, offset.Y + (int)(height - rectH), (int)widthUnit, (int)rectH);
                gr.DrawRectangle(thin_pen, r);
                gr.FillRectangle(Brushes.Black, r);
            }
        }

        public static int GetMax(int[] values)
        {
            int max = 0;

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > max)
                    max = values[i];
            }
            return max;
        }

        public static Bitmap DrawCorrdinateSysrem(int xMax, int yMax, int w, int h)
        {
            Bitmap result = new Bitmap(w, h);
            var gr = Graphics.FromImage(result);
            PointF origin = new PointF(40, h - 30);
            //PointF offset = new PointF(, 20);
            using (Pen thin_pen = new Pen(Color.Black, 0))
            {
                //drawing x-axis
                int arrowWidth = 20;
                int arrowHeight = 10;
                gr.DrawLine(thin_pen, origin, new PointF(w - 10, origin.Y));
                PointF[] triangleX = { new PointF(w - 10 - arrowHeight, origin.Y - arrowWidth / 2), new PointF(w - 10 - arrowHeight, origin.Y + arrowWidth / 2), new PointF(w - 10, origin.Y) };
                gr.DrawPolygon(thin_pen, triangleX);
                //drawing y-axis
                gr.DrawLine(thin_pen, origin, new PointF(origin.X, 10));
                PointF[] triangleY = { new PointF(origin.X - arrowWidth / 2, 10 + arrowHeight), new PointF(origin.X + arrowWidth / 2, 10 + arrowHeight), new PointF(origin.X, 10) };
                gr.DrawPolygon(thin_pen, triangleY);
                //maxvx
                Font font1 = new Font("Times New Roman", 16, FontStyle.Regular, GraphicsUnit.Pixel);
                gr.DrawString(xMax.ToString(), font1, Brushes.Black, w - 10 - font1.Size * xMax.ToString().Length, origin.Y + 10);
                //maxvy

                GraphicsState state = gr.Save();
                gr.TranslateTransform(0, h / 2);
                gr.RotateTransform(-90);

                Font font2 = new Font("Times New Roman", 20, FontStyle.Regular, GraphicsUnit.Pixel);
                gr.DrawString("Pixel number", font2, Brushes.Black, 0, 0);
                gr.Restore(state);
                //drawing zero
                gr.DrawString(0.ToString(), font1, Brushes.Black, origin.X - 20, origin.Y);

                //histogram
                int[] values = new int[100];
                for (int i = 0; i < 100; i++)
                {
                    values[i] = i;
                }
                DrawHistogram(gr, values, w - 10 - (int)origin.X - arrowWidth, (int)origin.Y - 10 - arrowHeight, 100, new Point((int)origin.X, 10 + arrowHeight));
            }
            return result;
        }
    }
}
