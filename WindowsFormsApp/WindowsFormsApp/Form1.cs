using WindowsFormsApp.command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using WindowsFormsApp.command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    enum View2Mode
    {
        Channel,
        Histogram
    }

    public partial class Form1 : Form
    {
      
        private CManager cManager;
        private Bitmap x_Bitmap;
        private Bitmap y_Bitmap;
        private Bitmap z_Bitmap;
        private CIE cie;
        private View2Mode view2mode;

        private bool unnsafe ;
        private bool isInplace;
        private int view = 1;
        public Form1()
        {
            InitializeComponent();

            cManager = new CManager(100);
            x_Bitmap = new Bitmap(2, 2);
            y_Bitmap = new Bitmap(2, 2);
            z_Bitmap = new Bitmap(2, 2);
            this.cie = new CIE(cManager.bitmap);
            this.unnsafe = false;
            this.isInplace = false;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "d:\\";
            openFileDialog.Filter = "Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|GIF files(*.gif)|*.gif|PNG files(*.png)|*.png|All valid files|*.bmp/*.jpg/*.gif/*.png";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                cManager.Execute(new Load(openFileDialog.FileName));
                if (this.view == 2)
                    this.UpdateView2();
                this.Invalidate();
            }
        }

        private void UpdateView2()
        {
            this.cie = new CIE(cManager.bitmap);
            if (view2mode == View2Mode.Channel)
                SetChannels();
            else
                SetHistograms();
        }

        private void SetChannels()
        {

            if (cie.pixels == null)
                return;
            this.x_Bitmap = cie.DisplayX();
            this.y_Bitmap = cie.DisplayY();
            this.z_Bitmap = cie.DisplayZ();
        }

        private void SetHistograms()
        {
            if (cie.pixels == null)
                return;
            this.x_Bitmap = HistogramChart.DrawData(cie.pixels.Select(p => p.X).ToArray(), 359, "X histogram", 1000, 500);
            this.y_Bitmap = HistogramChart.DrawData(cie.pixels.Select(p => p.Y).ToArray(), 100, "Y histogram", 1000, 500);
            this.z_Bitmap = HistogramChart.DrawData(cie.pixels.Select(p => (double)p.Z).ToArray(), 255, "Z histogram", 1000, 500);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if(view==1)
            {
                int ceiling = this.menuStrip1.Height;
                int offsetX = this.Width / 40;
                int offsetY = this.Height / 40;
                g.DrawImage(cManager.bitmap, new Rectangle(offsetX, offsetY + ceiling, this.Width - 2 * offsetX - 20, this.Height - 2 * offsetY - ceiling - 40));
            }
            else if(view==2)
            {
                CIE cie = new CIE(cManager.bitmap);
                this.x_Bitmap = cie.DisplayX();
                this.y_Bitmap = cie.DisplayY();
                this.z_Bitmap = cie.DisplayZ();
                g.Clear(Color.Black);
                int offsetX = this.Width / 40;
                int offsetY = this.Height / 40;
                int ceiling = this.menuStrip1.Height;
                int width = (this.Width - 3 * offsetX - 10) / 2;
                int height = (this.Height - ceiling - 3 * offsetY - 40) / 2;
                g.DrawImage(cManager.bitmap, new Rectangle(offsetX, offsetY + ceiling, width, height));
                g.DrawImage(x_Bitmap, new Rectangle(width + 2 * offsetX, offsetY + ceiling, width, height));
                g.DrawImage(y_Bitmap, new Rectangle(offsetX, height + 2 * offsetY + ceiling, width, height));
                g.DrawImage(z_Bitmap, new Rectangle(width + 2 * offsetX, height + 2 * offsetY + ceiling, width, height));
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.InitialDirectory = "d:\\";
            saveFileDialog.Filter = "Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|All valid files (*.bmp/*.jpg)|*.bmp/*.jpg";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (DialogResult.OK == saveFileDialog.ShowDialog())
            {
                cManager.bitmap.Save(saveFileDialog.FileName);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cIEToolStripMenuItem_Click(object sender, EventArgs e){}

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cManager.Execute(new InvertFCommand(this.cManager.bitmap,unnsafe));
            Invalidate();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cManager.Undo();
            if (this.view == 2)
                UpdateView2();
            Invalidate();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cManager.Redo();
            if (this.view == 2)
                UpdateView2();
            Invalidate();
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputColors dlg = new InputColors();
            dlg.red = dlg.green = dlg.blue = 0;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                cManager.Execute(new ColorFCommand(this.cManager.bitmap, this.unnsafe, dlg.red, dlg.green, dlg.blue));
                Invalidate();
            }
        }

        private void view1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view = 1;
            this.Invalidate();
        }

        private void view2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view = 2;
            this.UpdateView2();
            this.Invalidate();
        }

        private void turnOnUnsafeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.unnsafe = true;
        }

        private void turnOfUnsafeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.unnsafe = false;
        }

        private void edgeDetectHomogenityToolStripMenuItem_Click(object sender, EventArgs e)
        {
             Parameter dlg = new Parameter();
              dlg.Value = 0;

            if (DialogResult.OK == dlg.ShowDialog())
            {

                cManager.Execute(new EdgeDetectFCommandcs(cManager.bitmap, false, (byte)dlg.Value));
                this.Invalidate();
            }
        }

        private void timeWarpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cManager.Execute(new TimeWarpCommand(cManager.bitmap, false, (byte)15));
            this.Invalidate();
        }

        private void x3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cManager.Execute(new MeanRemovalCommand(this.cManager.bitmap,false, 3, 9, this.isInplace));
            Invalidate();
        }

        private void x5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cManager.Execute(new MeanRemovalCommand(this.cManager.bitmap, false, 5, 9, this.isInplace));
            Invalidate();
        }

        private void x7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cManager.Execute(new MeanRemovalCommand(this.cManager.bitmap, false, 7, 9, this.isInplace));
            Invalidate();
        }

        private void inplaceConvolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.isInplace = !this.isInplace;
            Invalidate();
        }

        private void channelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.view = 2;
            this.view2mode = View2Mode.Channel;
            UpdateView2();
            Invalidate();
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.view = 2;
            this.view2mode = View2Mode.Histogram;
            UpdateView2();
            Invalidate();
        }

        private void histogramCuttingToolStripMenuItem_Click(object sender, EventArgs e)
        {
           cManager.Execute(new HistogramCuttingCommand(this.cManager.bitmap, new Values(75, 0)));
            if (this.view == 2)
                UpdateView2();
            Invalidate();
        }

        private void simpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cManager.Execute(new ColorizeFilterCommand(cManager.bitmap, ColorizeMode.Simple));
            if (this.view == 2)
                UpdateView2();
            Invalidate();
        }

        private void similiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Bitmap files (*.bmp)|*.bmp|Jpeg files (*.jpg)|*.jpg|GIF files(*.gif)|*.gif|PNG files(*.png)|*.png|All valid files|*.bmp/*.jpg/*.gif/*.png";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                Bitmap similiar = new Bitmap(openFileDialog.FileName);
                cManager.Execute(new ColorizeFilterCommand(cManager.bitmap, ColorizeMode.Similiar, similiar));
                if (this.view == 2)
                    UpdateView2();
                Invalidate();
            }
        }

        private void orderedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cManager.Execute(new DitheringFilterCommand(cManager.bitmap, DitheringMode.Ordering));
            if (this.view == 2)
                UpdateView2();
            Invalidate();
        }

        private void burkesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cManager.Execute(new DitheringFilterCommand(cManager.bitmap, DitheringMode.Burkes));
            if (this.view == 2)
                UpdateView2();
            Invalidate();
        }

        private void kuwaharaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cManager.Execute(new KuwaharaFCommand(this.cManager.bitmap, 3));
            Invalidate();
        }

        private void colorUniformityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorUniformity x = new ColorUniformity(this.cManager.bitmap, 3, 3);
            //cManager.Execute(new ColorUniformityFilterCommand(this.cManager.bitmap, 3));
            Invalidate();
        }
    }
}
