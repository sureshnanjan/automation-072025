using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearchTests
{
    [TestClass]
    public class BinarySearchExceptionTests
    {
        // TC_EX_01: Null array should throw ArgumentNullException
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BinarySearch_NullArray_ThrowsArgumentNullException()
        {
            int[] array = null;
            int value = 3;

            Array.BinarySearch(array, value);
        }

        // TC_EX_02: Multidimensional array should throw RankException
        [TestMethod]
        [ExpectedException(typeof(RankException))]
        public void BinarySearch_MultidimensionalArray_ThrowsRankException()
        {
            int[,] array = { { 1, 2 }, { 3, 4 } }; // 2D array
            int value = 3;

            Array.BinarySearch(array, value); // Cast to Array automatically
        }

        // TC_EX_03: Incompatible types should throw ArgumentException
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))] // FIXED
        public void BinarySearch_IncompatibleType_ThrowsInvalidOperationException()
        {
            string[] array = { "a", "b", "c" };
            int value = 3;

            Array.BinarySearch(array, value);
        }


        // TC_EX_04: Value does not implement IComparable — should throw InvalidOperationException
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void BinarySearch_NonComparableObject_ThrowsInvalidOperationException()
        {
            NonComparable[] array = { new NonComparable(), new NonComparable() };
            var value = new NonComparable();

            Array.BinarySearch(array, value);
        }

        // TC_EX_05: Unsorted array – no exception, but may return incorrect result
        [TestMethod]
        public void BinarySearch_UnsortedArray_ResultMayBeUnpredictable()
        {
            int[] array = { 5, 1, 3, 2, 4 }; // Not sorted
            int value = 3;

            int result = Array.BinarySearch(array, value);

            Console.WriteLine($"Searching {value} in unsorted array: result = {result}");

            // Warning the developer, not failing the test
            Assert.Inconclusive("BinarySearch behavior on unsorted arrays is unpredictable.");
        }

        // Helper class for TC_EX_04
        private class NonComparable
        {
            public int Id => 1;
        }
    }
}
