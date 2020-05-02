using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    internal class DevLinkedList
    {
        private Node _firstNode;
        private Node _lastNode;
        private int _size;

        public void AddFirst(int item)
        {
            var node = new Node(item);
            if (IsEmpty())
                _firstNode = _lastNode = node;
            else
            {
                node.Next = _firstNode;
                _firstNode = node;
            }

            _size++;
        }

        public void AddLast(int item)
        {
            var node = new Node(item);

            if (IsEmpty())
                _lastNode = _firstNode = node;
            else
            {
                _lastNode.Next = node;
                _lastNode = node;
            }

            _size++;
        }

        public void DeleteFirst()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cannot delete an empty element");

            if (_firstNode == _lastNode)
                _firstNode = _lastNode = null;
            else
            {
                var secondNode = _firstNode.Next;
                _firstNode.Next = null;
                _firstNode = secondNode;
            }

            _size--;
        }

        public void DeleteLast()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cannot delete an empty element");

            if (_lastNode == _firstNode)
                _lastNode = _firstNode = null;
            else
            {
                var previous = GetPrevious(_lastNode);
                _lastNode = previous;
                _lastNode.Next = null;
            }

            _size--;
        }

        public string ToArrayString()
        {
            var array = new string[_size];
            var index = 0;
            foreach (var i in ToArray())
            {
                array[index] = i.ToString();
                index++;
            }

            var joinedStrings = string.Join(",", array);

            return $"[{joinedStrings}]";
        }

        public bool Contains(int input)
        {
            if (IsEmpty())
                throw new InvalidOperationException("Empty list");

            var current = _firstNode;

            while (current != null)
            {
                if (current.Value == input)
                    return true;

                current = current.Next;
            }

            return false;
        }

        public int IndexOf(int item)
        {
            var index = 0;
            var current = _firstNode;

            while (current != null)
            {
                if (current.Value == item)
                    return index;

                current = current.Next;
                index++;
            }

            return -1;
        }

        public void Reverse()
        {
            if (IsEmpty())
                return;

            var previous = _firstNode;
            var current = _firstNode.Next;
            while (current != null)
            {
                var next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            _lastNode = _firstNode;
            _lastNode.Next = null;
            _firstNode = previous;
        }

        public int GetKthFromTheEnd(int key)
        {
            if (key > _size || key < 0)
                throw new ArgumentOutOfRangeException();

            var current = _firstNode;
            for (var i = key; i < _size; i++)
            {
                current = current.Next;
            }

            return current.Value;
        }

        private int[] ToArray()
        {
            int[] array = new int[_size];
            var current = _firstNode;
            var index = 0;
            while (current != null)
            {
                array[index++] = current.Value;
                current = current.Next;
            }

            return array;
        }

        private Node GetPrevious(Node node)
        {
            var current = _firstNode;
            while (current != null)
            {
                if (current.Next == node)
                {
                    return current;
                }
                current = current.Next;
            }

            return null;
        }

        private bool IsEmpty() => _firstNode == null;
    }

    internal class Node
    {
        public int Value;
        public Node Next;

        public Node(int input)
        {
            Value = input;
        }
    }
}