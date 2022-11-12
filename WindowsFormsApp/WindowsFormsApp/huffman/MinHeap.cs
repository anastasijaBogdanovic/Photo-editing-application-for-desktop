using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.huffman
{
    interface HeapNode
    {
        int GetValue();
    }
    class MinHeap<T> where T : IComparable
    {
        private int capacity { get; set; }
        private T[] elements { get; set; }
        public int Count { get; set; }

        public MinHeap(int capacity)
        {
            this.capacity = capacity;
            elements = new T[capacity];
            Count = 0;
        }

        private static void Swap(ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }

        private int ParentKey(int key)
        {
            return (key - 1) / 2;
        }

        private int LeftChildKey(int key)
        {
            return 2 * key + 1;
        }

        private int RightChildKey(int key)
        {
            return 2 * key + 2;
        }

        public bool InsertElement(T element)
        {
            if (Count == capacity)
                return false;
            int i = Count;
            elements[i] = element;
            Count++;
            while (i != 0 && elements[i].CompareTo(elements[ParentKey(i)]) < 0)
            {
                Swap(ref elements[i], ref elements[ParentKey(i)]);
                i = ParentKey(i);
            }
            return true;
        }

        public T GetMin()
        {
            return elements[0];
        }

        public T RemoveMin()
        {
            if (Count == 0)
                throw new Exception("Heap is full");
            if (Count == 1)
            {
                Count = 0;
                return elements[0];
            }
            T root = elements[0];
            elements[0] = elements[Count - 1];
            Count--;
            MinHeapify(0);
            return root;
        }

        private void MinHeapify(int key)
        {
            int l = LeftChildKey(key);
            int r = RightChildKey(key);
            int smallest = key;
            if (l < Count && elements[l].CompareTo(elements[smallest]) < 0)
                smallest = l;
            if (r < Count && elements[r].CompareTo(elements[smallest]) < 0)
                smallest = r;
            if (smallest != key)
            {
                Swap(ref elements[key], ref elements[smallest]);
                MinHeapify(smallest);
            }
        }
    }
}