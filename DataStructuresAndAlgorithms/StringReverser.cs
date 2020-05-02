using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
    internal class StringReverser
    {
        public string Reverse(string input)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException();

            var stack = new Stack<char>();

            foreach (var chr in input.ToCharArray())
                stack.Push(chr);

            return string.Concat(stack.ToArray());
        }
    }
}