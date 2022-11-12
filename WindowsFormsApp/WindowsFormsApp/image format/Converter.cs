using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;
using WindowsFormsApp.huffman;

namespace WindowsFormsApp.image_format
{
    static class Converter
    {
        public static Image BitmapToMyImage(Bitmap bm, DownsamplingMode dmode)
        {
            DownsampledImg dImg = Downsampling.DownsampleImage(bm, dmode);
            var xChannel = GetEncodedChannel(dImg.XArray, 256);
            var yChannel = GetEncodedChannel(dImg.YArray, 256);
            var zChannel = GetEncodedChannel(dImg.ZArray, 256);
            return new Image(bm.Width, bm.Height, dmode, xChannel, yChannel, zChannel);
        }

        public static Bitmap MyImageToBitmap(Image image)
        {
            var x = huffman.HuffmanCoder.Decode(image.XChannel.Bits, new HuffmanTree(image.XChannel.Tree));
            var y = HuffmanCoder.Decode(image.YChannel.Bits, new HuffmanTree(image.YChannel.Tree));
            var z = HuffmanCoder.Decode(image.ZChannel.Bits, new HuffmanTree(image.ZChannel.Tree));
            DownsampledImg img = new DownsampledImg(x, y, z, image.Width, image.Height, image.DownsamplingMode);
            return Downsampling.UpsampleImage(img);
        }

        private static EncodedChannel GetEncodedChannel(int[] pixels, int range)
        {
            var huffmanTree = huffman.HuffmanCoder.GetTree(pixels, range);
            BitArray bits = huffman.HuffmanCoder.Encode(pixels, huffmanTree);
            return new EncodedChannel(bits, huffmanTree.Array);
        }
    }
}
