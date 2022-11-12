using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.huffman
{
    class HuffmanNode : IComparable
    {
        public int Frequency { get; set; }
        public int Value { get; set; }
        public HuffmanNode Left { get; set; }

        public HuffmanNode Right { get; set; }
        public string Code { get; set; }

        public HuffmanNode(int frequency, int value)
        {
            this.Frequency = frequency;
            this.Value = value;
        }

        public int CompareTo(object obj)
        {
            HuffmanNode other = (HuffmanNode)obj;
            if (this.Frequency < other.Frequency)
                return -1;
            else if (this.Frequency > other.Frequency)
                return +1;
            else return 0;
        }
    }
}
