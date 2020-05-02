using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    internal class QueueStack
    {
        private readonly Stack<int> _stack = new Stack<int>();
        private readonly Stack<int> _fakeQueue = new Stack<int>();

        public void Enqueue(int input) => _stack.Push(input);

        public int Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("EMPTY");
            MoveStackToFakeQueue();

            return _fakeQueue.Pop();
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("EMPTY");

            MoveStackToFakeQueue();

            return _fakeQueue.Peek();
        }

        private bool IsEmpty() => _stack.Count == 0 && _fakeQueue.Count == 0;

        private void MoveStackToFakeQueue()
        {
            if (_fakeQueue.Count != 0) return;
            while (_stack.Count != 0)
                _fakeQueue.Push(_stack.Pop());
        }

        public int[] GetCollection()
        {
            if (IsEmpty())
                throw new InvalidOperationException("EMPTY");

            while (_stack.Count != 0)
                _fakeQueue.Push(_stack.Pop());

            return _fakeQueue.ToArray();
        }
    }
}