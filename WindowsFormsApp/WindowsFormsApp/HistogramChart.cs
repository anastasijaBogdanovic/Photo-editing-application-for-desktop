using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace WindowsFormsApp
{
    class HistogramChart
    {
        public static Bitmap DrawData(double[] pixels, int maxValue, string title, int width, int height)
        {
            Chart chart = new Chart();
            chart.Palette = ChartColorPalette.SeaGreen;
            var t = chart.Titles.Add(title);
            t.Font = new Font("Times New Roman", 20.0f);
            t.ForeColor = Color.FromArgb(255, 0, 255);
            chart.Width = width;
            chart.Height = height;
            var chartArea = new ChartArea();
            chartArea.AxisX.Title = "value";

            chartArea.AxisX.TitleFont = chartArea.AxisY.TitleFont = new Font("Times New Roman", 16.0f);
            chartArea.AxisY.Title = "Number of pixels";
            var values = GetValues(pixels, maxValue);
            chartArea.AxisY.Maximum = GetMedianValue(values) * 3;
            chartArea.AxisX.Maximum = maxValue;
            //  chartArea.AxisY.Interval = 1;
            //  chartArea.AxisY.Maximum = 400;

            chart.ChartAreas.Add(chartArea);
            var series = chart.Series.Add("n");
            series.ChartType = SeriesChartType.Area;

            //series.Points.
            for (int i = 0; i < values.Length; i++)
                series.Points.Add(values[i]);
            Bitmap bm = new Bitmap(width, height);
            chart.DrawToBitmap(bm, new Rectangle(0, 0, width, height));

            return bm;
        }

        public static int[] GetValues(double[] pixels, int maxValue)
        {
            int[] values = new int[maxValue + 1];
            for (int i = 0; i < pixels.Length; i++)
                values[pixels[i] > maxValue ? maxValue : (int)pixels[i]]++;
            return values;
        }

        private static int GetMedianValue(int[] values)
        {
            var valuesC = values.Where(v => v > 10).ToArray();
            Array.Sort(valuesC);
            return valuesC[valuesC.Length / 2];
        }
    }
}
