using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;

namespace DataStructuresAndAlgorithms
{
    internal class HashTable
    {
        private class Entry
        {
            public readonly int Key;
            public string Value;

            public Entry(int key, string value)
            {
                Key = key;
                Value = value;
            }
        }

        private readonly LinkedList<Entry>[] _entries = new LinkedList<Entry>[5];

        public void Put(int key, string value)
        {
            var entry = GetEntry(key);
            if (entry != null)
            {
                entry.Value = value;
                return;
            }
            GetOrCreateBucket(key, value).AddLast(new Entry(key, value));
        }

        public void Remove(int key)
        {
            var entry = GetEntry(key);
            if (entry == null)
                throw new InvalidOperationException("not existing");

            GetBucket(key).Remove(entry);
        }

        public string Get(int key)
        {
            var entry = GetEntry(key);
            return entry?.Value;
        }

        private Entry GetEntry(int key)
        {
            var index = Hash(key);
            var bucket = _entries[index];
            /*
            if (bucket != null)
                {
                    foreach (var entry in bucket)
                    {
                        return entry;
                    }
                }
            return null;
            ##SAME AS BELOW##
            */
            return bucket?.FirstOrDefault();
        }

        private LinkedList<Entry> GetOrCreateBucket(int key, string value)
        {
            var index = Hash(key);
            var bucket = _entries[index];
            if (bucket == null)
                _entries[index] = new LinkedList<Entry>();

            bucket = _entries[index];
            /*
            foreach (var entry in bucket)
                if (entry.Key == key)
                    entry.Value = value;
            ##SAME AS BELOW##
            */

            foreach (var entry in bucket.Where(entry => entry.Key == key))
                entry.Value = value;

            bucket.AddLast(new Entry(key, value));
            return bucket;
        }

        private LinkedList<Entry> GetBucket(int key) => _entries[Hash(key)];

        private int Hash(int key) => key % _entries.Length;
    }
}