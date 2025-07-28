using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace BinarySearchFrameworkTests
{
    [TestClass]
    public sealed class ArrayBinarySearchTests
    {
        // 1. BinarySearch(Array, Object)
        // When to use: You want to search a sorted one-dimensional array using the default comparison logic
        [TestMethod]
        public void Test_BinarySearch_Array_Object_Found()
        {
            string[] fruits = { "Apple", "Banana", "Mango", "Orange" };
            int index = Array.BinarySearch(fruits, "Mango");
            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void Test_BinarySearch_Array_Object_NotFound()
        {
            int[] arr = { 10, 20, 30, 40 };
            int result = Array.BinarySearch(arr, 25);
            Assert.AreEqual(~2, result);  // Would be inserted at index 2
        }

        // 2. BinarySearch(Array, Object, IComparer)
        //When to use: You want to search a sorted one-dimensional array using a custom comparison logic
        [TestMethod]
        public void Test_BinarySearch_Array_Object_CustomComparer()
        {
            string[] arr = { "Orange", "Mango", "Banana", "Apple" };
            int result = Array.BinarySearch(arr, "Banana", new DescComparer());
            Assert.AreEqual(2, result);
        }

        // 3. BinarySearch(Array, Int32, Int32, Object)
        // When to use: You want to search a specific range in a sorted one-dimensional array
        [TestMethod]
        public void Test_BinarySearch_Range_Found()
        {
            string[] arr = { "A", "B", "C", "D", "E" };
            int result = Array.BinarySearch(arr, 1, 3, "D");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Test_BinarySearch_Range_NotFound()
        {
            int[] arr = { 1, 3, 5, 7, 9 };
            int result = Array.BinarySearch(arr, 1, 3, 4);
            Assert.AreEqual(~2, result);
        }

        // 4. BinarySearch(Array, Int32, Int32, Object, IComparer)
        // When to use: You want to search a specific range in a sorted one-dimensional array using a custom comparison logic
        [TestMethod]
        public void Test_BinarySearch_Range_CustomComparer()
        {
            string[] arr = { "Z", "X", "M", "C", "A" };
            int result = Array.BinarySearch(arr, 1, 3, "M", new DescComparer());
            Assert.AreEqual(2, result);
        }

        // 5. BinarySearch<T>(T[], T)
        // When to use: You want to search a sorted one-dimensional array of a specific type using the default comparison logic
        [TestMethod]
        public void Test_BinarySearch_Generic_Found()
        {
            int[] arr = { 10, 20, 30, 40 };
            int result = Array.BinarySearch<int>(arr, 30);
            Assert.AreEqual(2, result);
        }

        // 6. BinarySearch<T>(T[], T, IComparer<T>)
        // When to use: You want to search a sorted one-dimensional array of a specific type using a custom comparison logic
        [TestMethod]
        public void Test_BinarySearch_Generic_CustomComparer()
        {
            int[] arr = { 100, 90, 80, 70 };
            int result = Array.BinarySearch<int>(arr, 90, new DescIntComparer());
            Assert.AreEqual(1, result);
        }

        // 7. BinarySearch<T>(T[], Int32, Int32, T)
        // When to use: You want to search a specific range in a sorted one-dimensional array of a specific type
        [TestMethod]
        public void Test_BinarySearch_Generic_Range()
        {
            int[] arr = { 1, 3, 5, 7, 9 };
            int result = Array.BinarySearch<int>(arr, 1, 3, 5);
            Assert.AreEqual(2, result);
        }

        // 8. BinarySearch<T>(T[], Int32, Int32, T, IComparer<T>)
        // When to use: You want to search a specific range in a sorted one-dimensional array of a specific type using a custom comparison logic
        [TestMethod]
        public void Test_BinarySearch_Generic_Range_CustomComparer()
        {
            int[] arr = { 100, 90, 80, 70, 60 };
            int result = Array.BinarySearch<int>(arr, 1, 3, 80, new DescIntComparer());
            Assert.AreEqual(2, result);
        }

        // Edge Case: Null array
        [TestMethod]
        public void Test_BinarySearch_ThrowsOnNull()
        {
            int[] arr = null;
            Assert.ThrowsException<ArgumentNullException>(() => Array.BinarySearch(arr, 5));
        }

        // Edge Case: Multidimensional Array
        [TestMethod]
        public void Test_BinarySearch_ThrowsOnMultidimensional()
        {
            Array multiArray = Array.CreateInstance(typeof(int), new int[] { 2, 2 });
            Assert.ThrowsException<RankException>(() => Array.BinarySearch(multiArray, 2));
        }

        // Duplicates
        [TestMethod]
        public void Test_BinarySearch_Duplicates()
        {
            int[] arr = { 1, 2, 4, 4, 4, 5, 6 };
            int result = Array.BinarySearch(arr, 4);
            Assert.IsTrue(result >= 2 && result <= 4);
        }
    }

    public class DescComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return Comparer.Default.Compare(y, x); // Descending
        }
    }

    public class DescIntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x); // Descending
        }
    }
}
