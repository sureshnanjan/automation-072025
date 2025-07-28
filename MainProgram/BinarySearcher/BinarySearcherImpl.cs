using System;
using System.Collections;
namespace BinarySearcher
{
    public class DefiningComparer : IComparer
    {  
        public int Compare(object x, object y)
        {
            // If both are int
            if (x is int && y is int)
                return ((int)x).CompareTo((int)y);

            // If both are string
            if (x is string && y is string)
                return string.Compare((string)x, (string)y, StringComparison.Ordinal);

            // If types differ or are not expected, compare by ToString (safe fallback)
            return string.Compare(x.ToString(), y.ToString(), StringComparison.Ordinal);
        }
    }    
    public class BinarySearcherImpl
    {
        //default binary search
        public int doBinaryDearch(Array input, Object key) {
            return Array.BinarySearch(input, key);
        }
        //using BinarySearch(Array, Int32, Int32, Object, IComparer)
        public int doBinarySearchWithComparer(Array input, int startIndex, int count, object key, IComparer comparer)
        {
            return Array.BinarySearch(input, startIndex, count, key, comparer);
        }

        //BinarySearch(Array, Int32, Int32, Object)
        public int DoBinarySearchWithRange(Array array, int startIndex, int count, object key)
        {
            return Array.BinarySearch(array, startIndex, count, key);
        }

        //BinarySearch(Array, Object, IComparer)
        public int DoBinarySearchWithComparerWithoutRange(Array array, object key, IComparer comparer)
        {
            return Array.BinarySearch(array, key, comparer);
        }

        //BinarySearch<T>(T[], T)
        public int DoGenericBinarySearch<T>(T[] array, T key)
        {
            return Array.BinarySearch<T>(array, key);
        }

        //BinarySearch<T>(T[], T, IComparer<T>)
        public int DoGenericBinarySearchWithComparer<T>(T[] array, T key, IComparer<T> comparer)
        {
            return Array.BinarySearch<T>(array, key, comparer);
        }

        //BinarySearch<T>(T[], int, int, T)
        public int DoGenericBinarySearchWithRange<T>(T[] array, int startIndex, int count, T key)
        {
            return Array.BinarySearch<T>(array, startIndex, count, key);
        }

        //BinarySearch<T>(T[], int, int, T, IComparer<T>)
        public int DoGenericBinarySearchWithRangeComparer<T>(T[] array, int startIndex, int count, T key, IComparer<T> comparer)
        {
            return Array.BinarySearch<T>(array, startIndex, count, key, comparer);
        }


    }
}
