using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    public class CharacterFinder
    {
        public char NonRepeatingLetter(string words)
        {
            var dictionary = new Dictionary<char, int>();

            var chars = words.ToCharArray();
            foreach (var chr in chars)
            {
                /*
                dictionary.ContainsKey(chr) ? dictionary[chr] : 0;
                ##SAME BELOW##
                */
                var value = dictionary.GetValueOrDefault(chr, 0);

                if (dictionary.ContainsKey(chr))
                    dictionary[chr] = value + 1;

                if (!dictionary.ContainsKey(chr))
                    dictionary.Add(chr, value + 1);
            }
            /*
             *
            foreach (var chr in chars)
            {
                if (dictionary[chr] == 1)
                    return chr;
            }
            return char.MinValue;
            ##SAME BELOW##
            */
            return chars.FirstOrDefault(chr => dictionary[chr] == 1);
        }

        public char RepeatingLetter(string words)
        {
            var hashSet = new HashSet<char>();

            foreach (var chr in words.ToCharArray())
            {
                if (hashSet.Contains(chr))
                    return chr;

                hashSet.Add(chr);
            }

            return char.MinValue;
        }
    }
}