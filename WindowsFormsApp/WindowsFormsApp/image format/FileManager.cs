using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsFormsApp.image_format
{
    class FileManager
    {
        public static void SaveBitmapToFile(String fileName, Bitmap bm, DownsamplingMode dmode)
        {
            Image img = Converter.BitmapToMyImage(bm, dmode);
            Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, img);
            stream.Close();
        }

        public static Bitmap LoadBitmapFromFile(String fileName)
        {
            Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            IFormatter formatter = new BinaryFormatter();
            Image img = (Image)formatter.Deserialize(stream);
            return Converter.MyImageToBitmap(img);
        }
    }
}
