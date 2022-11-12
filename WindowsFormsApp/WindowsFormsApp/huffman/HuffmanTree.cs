using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.huffman
{
    class HuffmanTree
    {
        public int[] Array;
        private Dictionary<int, int> Frequencies = new Dictionary<int, int>();
        public Dictionary<int, string> CodeDict = new Dictionary<int, string>();

        public HuffmanTree(int[] arr)
        {
            this.Array = arr;
            GenerateCodes();
        }

        public HuffmanTree(HuffmanNode root)
        {
            GenerateTreeArray(root);
            GenerateCodes();
        }

        public long CalculateEncodedSize()
        {
            long result = 0;
            foreach (var entry in CodeDict)
            {
                result += entry.Value.Length * Frequencies[entry.Key];
            }
            return result;
        }

        private static int GetHeight(HuffmanNode root)
        {
            if (root == null)
                return 0;
            return 1 + Math.Max(GetHeight(root.Left), GetHeight(root.Right));
        }

        private void GenerateTreeArray(HuffmanNode root)
        {
            Array = new int[(int)Math.Pow(2, GetHeight(root)) - 1];
            for (int i = 0; i < Array.Length; i++)
                Array[i] = -2; //specijalna vrednost za prazno mesto u nizu

            SetValues(root, 0);
        }

        private void SetValues(HuffmanNode node, int index)
        {
            if (node == null)
                return;
            Array[index] = node.Value;
            if (node.Left == null && node.Right == null)
                Frequencies.Add(node.Value, node.Frequency);
            SetValues(node.Left, 2 * index + 1);
            SetValues(node.Right, 2 * index + 2);
        }

        public int Get(int index)
        {
            if (index >= Array.Length)
                return -2;
            return Array[index];
        }

        public bool IsLeaf(int index)
        {
            if (index >= Array.Length)
                return false;
            return Array[index] >= 0;
        }

        public int GetLeftIndex(int index)
        {
            return 2 * index + 1;
        }

        public int GetRightIndex(int index)
        {
            return 2 * index + 2;
        }

        private void GenerateCodes()
        {
            AssignCodes(0, CodeDict, "");
        }

        private bool IsLeftChildNull(int index)
        {
            return 2 * index + 1 >= Array.Length || 2 * index + 1 == -2;
        }

        private bool IsRightChildNull(int index)
        {
            return 2 * index + 2 >= Array.Length || 2 * index + 2 == -2;
        }

        private void AssignCodes(int index, Dictionary<int, string> codeDict, string code)
        {
            if (IsLeaf(index))
            {
                codeDict.Add(Array[index], code);
                return;
            }
            if (!IsLeftChildNull(index))
            {
                AssignCodes(2 * index + 1, codeDict, code + "0");
            }
            if (!IsRightChildNull(index))
            {
                AssignCodes(2 * index + 2, codeDict, code + "1");
            }
        }
    }
}
