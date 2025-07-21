using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BinarySearcherTests
{
    [TestClass]
    public class BinarySearchExceptionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BinarySearch_ArrayIsNull_ThrowsArgumentNullException()
        {
            int[] array = null;
            Array.BinarySearch(array, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(RankException))]
        public void BinarySearch_MultiDimensionalArray_ThrowsRankException()
        {
            int[,] array = new int[2, 2] { { 1, 2 }, { 3, 4 } };
            Array.BinarySearch(array, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]

        public void BinarySearch_IncompatibleValueType_ThrowsArgumentException()
        {
            int[] array = { 1, 2, 3 };
            Array.BinarySearch(array, "string"); // incompatible type
        }

        public class NoComparer { public int Value { get; set; } }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BinarySearch_ValueWithoutComparer_ThrowsInvalidOperationException()
        {
            NoComparer[] array = { new NoComparer { Value = 1 }, new NoComparer { Value = 2 } };
            var searchValue = new NoComparer { Value = 1 };
            Array.BinarySearch(array, searchValue); // NoComparer does not implement IComparable
        }
    }
}
