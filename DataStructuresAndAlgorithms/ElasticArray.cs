using System;
using System.Collections;
using System.Linq;

namespace DataStructuresAndAlgorithms
{
    internal class ElasticArray
    {
        private int[] _simpleArray;
        private int _count;

        public ElasticArray(int max)
        {
            _simpleArray = new int[max];
        }

        public void Insert(int input)
        {
            if (_simpleArray.Length == _count)
                IncreaseArrayLength();

            _simpleArray[_count] = input;
            _count++;
        }

        public int RemoveAt(int index)
        {
            if (index > _count)
                throw new ArgumentOutOfRangeException();

            var removed = _simpleArray[index];

            FillTheDeletedIndex(index);

            _count--;

            return removed;
        }

        public int IndexOf(int index)
        {
            if (index > _count)
                throw new ArgumentOutOfRangeException();

            return _simpleArray[index];
        }

        public void Print()
        {
            foreach (var i in _simpleArray)
                Console.WriteLine(i);
        }

        private void IncreaseArrayLength()
        {
            var newSimpleArray = new int[_count * 2];
            for (var i = 0; i < _count; i++)
                newSimpleArray[i] = _simpleArray[i];

            _simpleArray = newSimpleArray;
        }

        private void FillTheDeletedIndex(int index)
        {
            for (var i = index; i < _count; i++)
                _simpleArray[i] = _simpleArray[i + 1];
        }
    }
}