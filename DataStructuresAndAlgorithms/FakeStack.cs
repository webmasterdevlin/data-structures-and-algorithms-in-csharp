using System;

namespace DataStructuresAndAlgorithms
{
    internal class FakeStack
    {
        private int _count;
        private int[] _collection = new int[4];

        public void Push(int input)
        {
            if (_collection.Length == _count)
            {
                var newCollection = new int[_count * 2];
                for (var i = 0; i < _count; i++)
                    newCollection[i] = _collection[i];

                _collection = newCollection;
            }

            _collection[_count++] = input;
        }

        public int Pop()
        {
            if (IsEmpty())
                throw new ArgumentException("empty collection");

            return _collection[--_count];
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new ArgumentException("empty collection");

            return _collection[_count - 1];
        }

        public bool IsEmpty() => _count == 0;

        public override string ToString()
        {
            var array = new string[_count];

            for (var i = 0; i < _count; i++)
                array[i] = _collection[i].ToString();

            return $"[{string.Join(", ", array)}]";
        }
    }
}