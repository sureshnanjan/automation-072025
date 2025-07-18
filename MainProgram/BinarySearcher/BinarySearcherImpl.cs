using System;

namespace BinarySearcher
{
    public class BinarySearcherImpl
    {
        public int DoBinarySearch(Array? input, object key)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (input.Rank != 1)
                throw new RankException("Only one-dimensional arrays are supported.");

            Type? elementType = input.GetType().GetElementType();
            if (elementType == null || !typeof(IComparable).IsAssignableFrom(elementType))
                throw new InvalidOperationException("Array elements must implement IComparable.");

            return Array.BinarySearch(input, key);
        }
    }
}
