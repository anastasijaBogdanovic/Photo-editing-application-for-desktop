using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.image_format
{
    [Serializable]
    struct EncodedChannel
    {
        public BitArray Bits { get; set; }
        public int[] Tree { get; set; }
        public EncodedChannel(BitArray bits, int[] tree)
        {
            Bits = bits;
            Tree = tree;
        }
    }

    [Serializable]
    class Image
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public DownsamplingMode DownsamplingMode { get; set; }
        public EncodedChannel XChannel { get; set; }
        public EncodedChannel YChannel { get; set; }
        public EncodedChannel ZChannel { get; set; }

        public Image(int w, int h, DownsamplingMode dmode, EncodedChannel xChannel, EncodedChannel yChannel, EncodedChannel zChannel)
        {
            this.Width = w;
            this.Height = h;
            this.DownsamplingMode = dmode;
            this.XChannel = xChannel;
            this.YChannel = yChannel;
            this.ZChannel = zChannel;
        }
    }
}
