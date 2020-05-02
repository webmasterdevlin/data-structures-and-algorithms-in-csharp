using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    internal class BalancedExpressions
    {
        private readonly List<char> _leftBrackets = new List<char> { '(', '{', '[', '<' };
        private readonly List<char> _rightBrackets = new List<char> { ')', '}', ']', '>' };

        public bool IsBalanced(string code)
        {
            var stack = new Stack<char>();

            foreach (var chr in code.ToCharArray())
            {
                if (IsLeftBracket(chr))
                {
                    stack.Push(chr);
                }

                if (!IsRightBracket(chr)) continue;
                if (stack.Count == 0)
                    return false;

                var top = stack.Pop();
                if (!BracketsMatch(top, chr))
                    return false;
            }

            var balanced = stack.Count == 0;
            return balanced;
        }

        private bool IsLeftBracket(char chr) => chr == '(' || chr == '{' || chr == '[' || chr == '<';

        private bool IsRightBracket(char chr) => chr == ')' || chr == '}' || chr == ']' || chr == '>';

        private bool BracketsMatch(char left, char right) => _leftBrackets.IndexOf(left) == _rightBrackets.IndexOf(right);
    }
}