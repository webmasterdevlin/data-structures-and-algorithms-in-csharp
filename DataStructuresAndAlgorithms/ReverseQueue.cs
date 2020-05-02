using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    internal class ReverseQueue : Queue
    {
        private static Queue<int> _queue = new Queue<int>();

        public void Reverse()
        {
            var stack = new Stack<int>();

            while (!IsEmpty())
                stack.Push(_queue.Dequeue());

            while (stack.Count != 0)
                _queue.Enqueue(stack.Pop());
        }

        public void Add(int item) => _queue.Enqueue(item);

        public int Remove() => _queue.Dequeue();

        public bool IsEmpty() => _queue.Count == 0;

        public Queue<int> Show() => _queue;
    }
}