namespace WindowsFormsApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cIEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meanRemovalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeDetectHomogenityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeWarpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramCuttingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simpleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.similiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ditheringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.burkesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kuwaharaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turnOnUnsafeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turnOfUnsafeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inplaceConvolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoRedoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.view1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.view2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorUniformityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.filtersToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.undoRedoToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(498, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cIEToolStripMenuItem,
            this.colorToolStripMenuItem,
            this.meanRemovalToolStripMenuItem,
            this.invertToolStripMenuItem,
            this.edgeDetectHomogenityToolStripMenuItem,
            this.timeWarpToolStripMenuItem,
            this.histogramCuttingToolStripMenuItem,
            this.colorizeToolStripMenuItem,
            this.ditheringToolStripMenuItem,
            this.kuwaharaToolStripMenuItem,
            this.colorUniformityToolStripMenuItem});
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.filtersToolStripMenuItem.Text = "Filters";
            // 
            // cIEToolStripMenuItem
            // 
            this.cIEToolStripMenuItem.Name = "cIEToolStripMenuItem";
            this.cIEToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.cIEToolStripMenuItem.Text = "CIE";
            this.cIEToolStripMenuItem.Click += new System.EventHandler(this.cIEToolStripMenuItem_Click);
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.colorToolStripMenuItem.Text = "Color";
            this.colorToolStripMenuItem.Click += new System.EventHandler(this.colorToolStripMenuItem_Click);
            // 
            // meanRemovalToolStripMenuItem
            // 
            this.meanRemovalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x3ToolStripMenuItem,
            this.x7ToolStripMenuItem,
            this.xToolStripMenuItem});
            this.meanRemovalToolStripMenuItem.Name = "meanRemovalToolStripMenuItem";
            this.meanRemovalToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.meanRemovalToolStripMenuItem.Text = "Mean Removal";
            // 
            // x3ToolStripMenuItem
            // 
            this.x3ToolStripMenuItem.Name = "x3ToolStripMenuItem";
            this.x3ToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.x3ToolStripMenuItem.Text = "3x3";
            this.x3ToolStripMenuItem.Click += new System.EventHandler(this.x3ToolStripMenuItem_Click);
            // 
            // x7ToolStripMenuItem
            // 
            this.x7ToolStripMenuItem.Name = "x7ToolStripMenuItem";
            this.x7ToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.x7ToolStripMenuItem.Text = "5x5";
            this.x7ToolStripMenuItem.Click += new System.EventHandler(this.x5ToolStripMenuItem_Click);
            // 
            // xToolStripMenuItem
            // 
            this.xToolStripMenuItem.Name = "xToolStripMenuItem";
            this.xToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.xToolStripMenuItem.Text = "7x7";
            this.xToolStripMenuItem.Click += new System.EventHandler(this.x7ToolStripMenuItem_Click);
            // 
            // invertToolStripMenuItem
            // 
            this.invertToolStripMenuItem.Name = "invertToolStripMenuItem";
            this.invertToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.invertToolStripMenuItem.Text = "Invert";
            this.invertToolStripMenuItem.Click += new System.EventHandler(this.invertToolStripMenuItem_Click);
            // 
            // edgeDetectHomogenityToolStripMenuItem
            // 
            this.edgeDetectHomogenityToolStripMenuItem.Name = "edgeDetectHomogenityToolStripMenuItem";
            this.edgeDetectHomogenityToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.edgeDetectHomogenityToolStripMenuItem.Text = "EdgeDetectHomogenity";
            this.edgeDetectHomogenityToolStripMenuItem.Click += new System.EventHandler(this.edgeDetectHomogenityToolStripMenuItem_Click);
            // 
            // timeWarpToolStripMenuItem
            // 
            this.timeWarpToolStripMenuItem.Name = "timeWarpToolStripMenuItem";
            this.timeWarpToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.timeWarpToolStripMenuItem.Text = "TimeWarp";
            this.timeWarpToolStripMenuItem.Click += new System.EventHandler(this.timeWarpToolStripMenuItem_Click);
            // 
            // histogramCuttingToolStripMenuItem
            // 
            this.histogramCuttingToolStripMenuItem.Name = "histogramCuttingToolStripMenuItem";
            this.histogramCuttingToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.histogramCuttingToolStripMenuItem.Text = "Histogram cutting";
            this.histogramCuttingToolStripMenuItem.Click += new System.EventHandler(this.histogramCuttingToolStripMenuItem_Click);
            // 
            // colorizeToolStripMenuItem
            // 
            this.colorizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simpleToolStripMenuItem,
            this.similiarToolStripMenuItem});
            this.colorizeToolStripMenuItem.Name = "colorizeToolStripMenuItem";
            this.colorizeToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.colorizeToolStripMenuItem.Text = "Colorize";
            // 
            // simpleToolStripMenuItem
            // 
            this.simpleToolStripMenuItem.Name = "simpleToolStripMenuItem";
            this.simpleToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.simpleToolStripMenuItem.Text = "Simple";
            this.simpleToolStripMenuItem.Click += new System.EventHandler(this.simpleToolStripMenuItem_Click);
            // 
            // similiarToolStripMenuItem
            // 
            this.similiarToolStripMenuItem.Name = "similiarToolStripMenuItem";
            this.similiarToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.similiarToolStripMenuItem.Text = "Similiar";
            this.similiarToolStripMenuItem.Click += new System.EventHandler(this.similiarToolStripMenuItem_Click);
            // 
            // ditheringToolStripMenuItem
            // 
            this.ditheringToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderedToolStripMenuItem,
            this.burkesToolStripMenuItem});
            this.ditheringToolStripMenuItem.Name = "ditheringToolStripMenuItem";
            this.ditheringToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.ditheringToolStripMenuItem.Text = "Dithering";
            // 
            // orderedToolStripMenuItem
            // 
            this.orderedToolStripMenuItem.Name = "orderedToolStripMenuItem";
            this.orderedToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.orderedToolStripMenuItem.Text = "Ordered";
            this.orderedToolStripMenuItem.Click += new System.EventHandler(this.orderedToolStripMenuItem_Click);
            // 
            // burkesToolStripMenuItem
            // 
            this.burkesToolStripMenuItem.Name = "burkesToolStripMenuItem";
            this.burkesToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.burkesToolStripMenuItem.Text = "Burkes";
            this.burkesToolStripMenuItem.Click += new System.EventHandler(this.burkesToolStripMenuItem_Click);
            // 
            // kuwaharaToolStripMenuItem
            // 
            this.kuwaharaToolStripMenuItem.Name = "kuwaharaToolStripMenuItem";
            this.kuwaharaToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.kuwaharaToolStripMenuItem.Text = "Kuwahara";
            this.kuwaharaToolStripMenuItem.Click += new System.EventHandler(this.kuwaharaToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.turnOnUnsafeToolStripMenuItem,
            this.turnOfUnsafeToolStripMenuItem,
            this.inplaceConvolutionToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // turnOnUnsafeToolStripMenuItem
            // 
            this.turnOnUnsafeToolStripMenuItem.Name = "turnOnUnsafeToolStripMenuItem";
            this.turnOnUnsafeToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.turnOnUnsafeToolStripMenuItem.Text = "TurnOn Unsafe";
            this.turnOnUnsafeToolStripMenuItem.Click += new System.EventHandler(this.turnOnUnsafeToolStripMenuItem_Click);
            // 
            // turnOfUnsafeToolStripMenuItem
            // 
            this.turnOfUnsafeToolStripMenuItem.Name = "turnOfUnsafeToolStripMenuItem";
            this.turnOfUnsafeToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.turnOfUnsafeToolStripMenuItem.Text = "TurnOf Unsafe";
            this.turnOfUnsafeToolStripMenuItem.Click += new System.EventHandler(this.turnOfUnsafeToolStripMenuItem_Click);
            // 
            // inplaceConvolutionToolStripMenuItem
            // 
            this.inplaceConvolutionToolStripMenuItem.Name = "inplaceConvolutionToolStripMenuItem";
            this.inplaceConvolutionToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.inplaceConvolutionToolStripMenuItem.Text = "Inplace convolution";
            this.inplaceConvolutionToolStripMenuItem.Click += new System.EventHandler(this.inplaceConvolutionToolStripMenuItem_Click);
            // 
            // undoRedoToolStripMenuItem
            // 
            this.undoRedoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.undoRedoToolStripMenuItem.Name = "undoRedoToolStripMenuItem";
            this.undoRedoToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.undoRedoToolStripMenuItem.Text = "Undo-Redo";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.view1ToolStripMenuItem,
            this.view2ToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // view1ToolStripMenuItem
            // 
            this.view1ToolStripMenuItem.Name = "view1ToolStripMenuItem";
            this.view1ToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.view1ToolStripMenuItem.Text = "View1";
            this.view1ToolStripMenuItem.Click += new System.EventHandler(this.view1ToolStripMenuItem_Click);
            // 
            // view2ToolStripMenuItem
            // 
            this.view2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.channelToolStripMenuItem,
            this.histogramToolStripMenuItem});
            this.view2ToolStripMenuItem.Name = "view2ToolStripMenuItem";
            this.view2ToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.view2ToolStripMenuItem.Text = "View2";
            this.view2ToolStripMenuItem.Click += new System.EventHandler(this.view2ToolStripMenuItem_Click);
            // 
            // channelToolStripMenuItem
            // 
            this.channelToolStripMenuItem.Name = "channelToolStripMenuItem";
            this.channelToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.channelToolStripMenuItem.Text = "Channel";
            this.channelToolStripMenuItem.Click += new System.EventHandler(this.channelToolStripMenuItem_Click);
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.histogramToolStripMenuItem.Text = "Histogram";
            this.histogramToolStripMenuItem.Click += new System.EventHandler(this.histogramToolStripMenuItem_Click);
            // 
            // colorUniformityToolStripMenuItem
            // 
            this.colorUniformityToolStripMenuItem.Name = "colorUniformityToolStripMenuItem";
            this.colorUniformityToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.colorUniformityToolStripMenuItem.Text = "ColorUniformity";
            this.colorUniformityToolStripMenuItem.Click += new System.EventHandler(this.colorUniformityToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 349);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cIEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meanRemovalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoRedoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem view1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem view2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turnOnUnsafeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem turnOfUnsafeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edgeDetectHomogenityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeWarpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inplaceConvolutionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem channelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramCuttingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simpleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem similiarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ditheringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem burkesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kuwaharaToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem colorUniformityToolStripMenuItem;
    }
}

