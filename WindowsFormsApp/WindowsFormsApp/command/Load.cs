using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WindowsFormsApp.command
{
    class Load:Command
    {
        private string fileName;

        public Load(string fileName)
        {
            this.fileName = fileName;
        }
        Bitmap Command.Operate()
        {
            return (Bitmap)Bitmap.FromFile(fileName, false);
        }
    }
}
