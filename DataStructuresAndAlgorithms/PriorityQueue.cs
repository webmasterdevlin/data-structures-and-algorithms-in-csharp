using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    internal class PriorityQueue
    {
        public readonly int[] Items;
        private int _count;

        public PriorityQueue(int size)
        {
            Items = new int[size];
        }

        public void Add(int input)
        {
            if (IsFull())
                throw new InvalidOperationException("FULL");

            /*
             * [1, 3, 4, #]   (2)
             * [1, 2, 3, 4]   (full)
            */

            var i = ShiftItemsToInsert(input);
            Items[i] = input;
            _count++;
        }

        public int Remove() => Items[--_count];

        private bool IsFull() => Items.Length == _count;

        private int ShiftItemsToInsert(int input)
        {
            //1st cycle    5               4
            //2nd cycle    4               3
            //and so on..
            int i;
            for (i = _count - 1; i >= 0; i--)
                if (Items[i] > input)
                    Items[i + 1] = Items[i];
                else
                    break;

            return i + 1;
        }
    }
}