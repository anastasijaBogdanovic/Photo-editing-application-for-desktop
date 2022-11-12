using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.huffman
{
    struct HuffmanCode
    {
        public int Value;
        public string Code;
        public HuffmanCode(int v, string c)
        {
            Value = v;
            Code = c;
        }
    }

    class HuffmanCompression
    {
        public HuffmanCompression() {}

        public static HuffmanTree GenerateHuffmanTree(int[] pixels, int range)
        {
            var nodes = CalculateFrequencies(pixels, range);
            var root = GenerateTree(nodes);
            return new HuffmanTree(root);
        }

        public static MinHeap<HuffmanNode> CalculateFrequencies(int[] pixels, int range)
        {
            int[] values = new int[range];
            for (int i = 0; i < values.Length; i++)
                values[i] = 0;
            for (int i = 0; i < pixels.Length; i++)
                values[pixels[i]]++;
            MinHeap<HuffmanNode> nodes = new MinHeap<HuffmanNode>(pixels.Length);

            for (int i = 0; i < values.Length; i++)
                if (values[i] != 0)
                {
                    HuffmanNode n = new HuffmanNode(values[i], i);
                    nodes.InsertElement(n);
                }
            return nodes;
        }

        public static HuffmanNode GenerateTree(MinHeap<HuffmanNode> nodes)
        {
            HuffmanNode parent = new HuffmanNode(0, -1);
            while (nodes.Count != 1)
            {
                //dva cvora sa najmanjom frekvencijom
                var node1 = nodes.RemoveMin();
                var node2 = nodes.RemoveMin();

                //spoji ih u novi cvor
                parent = new HuffmanNode(node1.Frequency + node2.Frequency, -1);
                parent.Left = node1;
                parent.Right = node2;
                nodes.InsertElement(parent);
            }
            return nodes.GetMin();
        }
    }
}
