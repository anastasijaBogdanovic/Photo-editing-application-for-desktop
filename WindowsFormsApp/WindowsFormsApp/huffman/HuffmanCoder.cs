using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.huffman
{
    class HuffmanCoder
    {
        public static HuffmanTree GetTree(int[] pixels, int range)
        {
            return HuffmanCompression.GenerateHuffmanTree(pixels, range);
        }

        public static BitArray Encode(int[] pixels, HuffmanTree tree)
        {
            BitArray result = new BitArray((int)tree.CalculateEncodedSize());
            int k = 0;
            for (int i = 0; i < pixels.Length; i++)
            {
                string code = tree.CodeDict[pixels[i]];
                for (int j = 0; j < code.Length; j++)

                    result[k++] = code[j] == '1' ? true : false;
            }
            return result;
        }

        public static int[] Decode(BitArray encoded, HuffmanTree tree)
        {
            List<int> pixels = new List<int>();
            int k = 0;
            while (k < encoded.Length)
            {
                int index = 0;
                while (!tree.IsLeaf(index))
                {
                    bool current = encoded[k++];
                    if (!current)
                        index = tree.GetLeftIndex(index);
                    else
                        index = tree.GetRightIndex(index);
                }
                int value = tree.Get(index);
                pixels.Add(value);
            }
            return pixels.ToArray();
        }
    }
}
