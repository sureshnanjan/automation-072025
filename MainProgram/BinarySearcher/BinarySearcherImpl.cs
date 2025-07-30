using System;
using System.Collections.Generic;

namespace BinarySearcher
{
    /// <summary>
    /// This is the implementation of a binary search algorithm.
    /// </summary>
    public class BinarySearcherImpl
    {
        /// <summary>
        /// Performs binary search on an int[] array using manual logic.
        /// Returns the index if found, or the bitwise complement of the insertion point.
        /// </summary>
        public int doBinarySearch(int[] array, int value)
        {
            int low = 0;
            int high = array.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (array[mid] == value) return mid;
                if (array[mid] < value) low = mid + 1;
                else high = mid - 1;
            }

            return ~low;  // If not found, return bitwise complement of insertion point
        }

        /// <summary>
        /// Performs binary search using the built-in Array.BinarySearch method.
        /// </summary>
        public int doBinarySearch(Array input, object key)
        {
            return Array.BinarySearch(input, key);
        }

        /// <summary>
        /// Performs binary search on a List<int> using manual logic.
        /// Returns the index if found, or -1 if not found.
        /// </summary>
        public int doBinarySearch(List<int> input, int key)
        {
            int low = 0;
            int high = input.Count - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (input[mid] == key) return mid;
                else if (input[mid] < key) low = mid + 1;
                else high = mid - 1;
            }

            return -1;  // Key not found
        }
    }
}
