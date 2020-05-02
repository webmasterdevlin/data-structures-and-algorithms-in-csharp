using System;

namespace DataStructuresAndAlgorithms
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var finder = new CharacterFinder();
            Console.WriteLine(finder.NonRepeatingLetter("a green apple"));
        }
    }
}