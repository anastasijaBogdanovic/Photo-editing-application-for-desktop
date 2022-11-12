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
    public partial class Parameter : Form
    {
        public int Value
        {
            get
            {
                return (Convert.ToInt32(valueTxt.Text, 10));
            }
            set { valueTxt.Text = value.ToString(); }
        }
        public Parameter()
        {
            InitializeComponent();
            OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
