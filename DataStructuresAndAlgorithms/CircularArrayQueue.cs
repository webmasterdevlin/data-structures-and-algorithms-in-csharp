using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    internal class CircularArrayQueue
    {
        private int _front;
        private int _rear;
        private int _count;
        public int[] Collection;

        public CircularArrayQueue(int size)
        {
            Collection = new int[size];
        }

        /*
         * [10,  20,  30,  40,  #]   delete the 1st two
         *  front                rear
         *
         * [#,  #,  30,  40,  #]     add 50 at the end
         *          front      rear
         *
         * [#,  #,  30,  40,  50]    then move the rear
         *  rear    front
         * */

        public void Enqueue(int input)
        {
            if (IsFull())
                throw new ArgumentException("FULL");

            Collection[_rear] = input;
            _rear = (_rear + 1) % Collection.Length;
            _count++;
        }

        public int Dequeue()
        {
            var item = Collection[_front];
            Collection[_front] = 0;
            _front = (_front + 1) % Collection.Length;
            _count--;
            return item;
        }

        public int Peek() => Collection[_front];

        public bool IsEmpty() => _count == 0;

        public bool IsFull() => _count == Collection.Length;
    }
}