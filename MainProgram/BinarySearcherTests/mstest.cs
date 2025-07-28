using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace BinarySearchTests
{
    [TestClass]
    public class BinarySearchOverloadsTest
    {
        // 1. BinarySearch(Array, Object)
        [TestMethod]
        public void Test_ArrayObject()
        {
            string[] arr = { "apple", "banana", "mango", "orange" };
            Array.Sort(arr); // Ensure array is sorted
            int index = Array.BinarySearch(arr, "mango");
            Assert.AreEqual(2, index); // Index of "mango"
        }

        // 2. BinarySearch(Array, Object, IComparer)
        [TestMethod]
        public void Test_ArrayObjectWithComparer()
        {
            string[] arr = { "Apple", "banana", "Mango", "orange" };
            Array.Sort(arr, StringComparer.OrdinalIgnoreCase); // Case-insensitive
            int index = Array.BinarySearch(arr, "mango", StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(2, index);
        }

        // 3. BinarySearch(Array, Int32, Int32, Object)
        [TestMethod]
        public void Test_ArrayRangeObject()
        {
            int[] arr = { 1, 3, 5, 7, 9 };
            int index = Array.BinarySearch(arr, 1, 3, 5); // search in [3, 5, 7]
            Assert.AreEqual(2, index); // 5 is at index 2 in original array
        }

        // 4. BinarySearch(Array, Int32, Int32, Object, IComparer)
        [TestMethod]
        public void Test_ArrayRangeObjectWithComparer()
        {
            string[] arr = { "A", "b", "C", "d", "E" };
            Array.Sort(arr, StringComparer.OrdinalIgnoreCase); // Full sort
            int index = Array.BinarySearch(arr, 1, 3, "c", StringComparer.OrdinalIgnoreCase);
            Assert.IsTrue(index >= 1 && index <= 3);
        }

        // 5. BinarySearch<T>(T[], T)
        [TestMethod]
        public void Test_Generic_T_T()
        {
            int[] arr = { 10, 20, 30, 40, 50 };
            int index = Array.BinarySearch<int>(arr, 30);
            Assert.AreEqual(2, index); // 30 is at index 2
        }

        // 6. BinarySearch<T>(T[], T, IComparer<T>)
        [TestMethod]
        public void Test_Generic_T_T_IComparer()
        {
            string[] arr = { "blue", "Green", "red" };
            Array.Sort(arr, StringComparer.OrdinalIgnoreCase);
            int index = Array.BinarySearch<string>(arr, "green", StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(1, index); // "Green" is at index 1 after sort
        }

        // 7. BinarySearch<T>(T[], Int32, Int32, T)
        [TestMethod]
        public void Test_Generic_T_Range()
        {
            double[] arr = { 1.1, 2.2, 3.3, 4.4, 5.5 };
            int index = Array.BinarySearch<double>(arr, 1, 3, 3.3); // Search in [2.2, 3.3, 4.4]
            Assert.AreEqual(2, index); // 3.3 is at index 2 in full array
        }

        // 8. BinarySearch<T>(T[], Int32, Int32, T, IComparer<T>)
        [TestMethod]
        public void Test_Generic_T_Range_IComparer()
        {
            string[] arr = { "apple", "Banana", "carrot", "Date", "Egg" };
            Array.Sort(arr, StringComparer.OrdinalIgnoreCase); // Case-insensitive sort
            int index = Array.BinarySearch<string>(arr, 1, 3, "date", StringComparer.OrdinalIgnoreCase);
            Assert.IsTrue(index >= 1 && index <= 3); // Index should be within range
        }
    }
}