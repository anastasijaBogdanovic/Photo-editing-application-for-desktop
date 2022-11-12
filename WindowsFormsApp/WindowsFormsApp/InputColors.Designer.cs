namespace WindowsFormsApp
{
    partial class InputColors
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
            this.Blue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Green = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Red = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Blue
            // 
            this.Blue.Location = new System.Drawing.Point(74, 75);
            this.Blue.Name = "Blue";
            this.Blue.Size = new System.Drawing.Size(201, 20);
            this.Blue.TabIndex = 25;
            this.Blue.Text = "textBox3";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = "Blue";
            // 
            // Green
            // 
            this.Green.Location = new System.Drawing.Point(74, 48);
            this.Green.Name = "Green";
            this.Green.Size = new System.Drawing.Size(201, 20);
            this.Green.TabIndex = 23;
            this.Green.Text = "textBox2";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 22;
            this.label3.Text = "Green";
            // 
            // Red
            // 
            this.Red.Location = new System.Drawing.Point(74, 18);
            this.Red.Name = "Red";
            this.Red.Size = new System.Drawing.Size(201, 20);
            this.Red.TabIndex = 21;
            this.Red.Text = "textBox1";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Red";
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(74, 117);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(57, 25);
            this.OK.TabIndex = 19;
            this.OK.Text = "OK";
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(218, 117);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(57, 25);
            this.Cancel.TabIndex = 18;
            this.Cancel.Text = "Cancel";
            // 
            // InputColors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 160);
            this.Controls.Add(this.Blue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Green);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Red);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Cancel);
            this.Name = "InputColors";
            this.Text = "InputColors";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Blue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Green;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Red;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
    }
}