using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class InputColors : Form
    {
        public InputColors()
        {
            InitializeComponent();
            OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        public int red
        {
            get { return (Convert.ToInt32(Red.Text, 10)); ; }
            set { Red.Text = value.ToString(); }
        }
        public int green
        {
            get { return (Convert.ToInt32(Green.Text, 10)); ; }
            set { Green.Text = value.ToString(); }
        }
        public int blue
        {
            get { return (Convert.ToInt32(Blue.Text, 10)); ; }
            set { Blue.Text = value.ToString(); }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            
        }
    }
}
