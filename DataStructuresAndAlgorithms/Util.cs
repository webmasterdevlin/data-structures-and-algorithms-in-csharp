using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    internal class Util
    {
        public static string CollectionToString(int[] collection)
        {
            var array = new string[collection.Length];

            for (var i = 0; i < collection.Length; i++)
                array[i] = collection[i].ToString();

            return $"[{string.Join(", ", array)}]";
        }

        public static string CollectionToString(Queue<int> collection)
        {
            var array = new string[collection.Count];

            var count = collection.Count;
            for (var i = 0; i < count; i++)
                array[i] = collection.Dequeue().ToString();

            return $"[{string.Join(", ", array)}]";
        }
    }
}