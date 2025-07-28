using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearchTestProject
{
    [TestClass]
    public class BinarySearchTests
    {
        // 1. BinarySearch(Array, Object)
        [TestMethod]
        public void Test_BinarySearch_Array_Object()
        {
            string[] names = { "Alice", "Bob", "Charlie", "David" };
            int index = Array.BinarySearch(names, "Charlie");
            Assert.AreEqual(2, index);
        }

        // 2. BinarySearch(Array, Object, IComparer)
        public class ReverseComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                return Comparer.Default.Compare(y, x);
            }
        }

        [TestMethod]
        public void Test_BinarySearch_Array_Object_IComparer()
        {
            string[] names = { "David", "Charlie", "Bob", "Alice" }; // reverse sorted
            int index = Array.BinarySearch(names, "Charlie", new ReverseComparer());
            Assert.AreEqual(1, index);
        }

        // 3. BinarySearch(Array, Int32, Int32, Object)
        [TestMethod]
        public void Test_BinarySearch_Array_Range_Object()
        {
            int[] numbers = { 1, 3, 5, 7, 9, 11 };
            int index = Array.BinarySearch(numbers, 1, 4, 7);
            Assert.AreEqual(3, index);
        }

        // 4. BinarySearch(Array, Int32, Int32, Object, IComparer)
        [TestMethod]
        public void Test_BinarySearch_Array_Range_Object_IComparer()
        {
            int[] numbers = { 11, 9, 7, 5, 3, 1 }; // reverse sorted
            int index = Array.BinarySearch(numbers, 1, 4, 7, new ReverseComparer());
            Assert.AreEqual(2, index);
        }

        // 5. BinarySearch<T>(T[], T)
        [TestMethod]
        public void Test_BinarySearch_Generic_TArray_T()
        {
            double[] values = { 1.1, 2.2, 3.3, 4.4 };
            int index = Array.BinarySearch(values, 3.3);
            Assert.AreEqual(2, index);
        }

        // 6. BinarySearch<T>(T[], T, IComparer<T>)
        public class ReverseComparerGeneric : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return string.Compare(y, x);
            }
        }

        [TestMethod]
        public void Test_BinarySearch_Generic_TArray_T_IComparer()
        {
            string[] items = { "z", "y", "x", "w" }; // reverse sorted
            int index = Array.BinarySearch(items, "y", new ReverseComparerGeneric());
            Assert.AreEqual(1, index);
        }

        // 7. BinarySearch<T>(T[], Int32, Int32, T)
        [TestMethod]
        public void Test_BinarySearch_Generic_TArray_Range_T()
        {
            int[] nums = { 10, 20, 30, 40, 50 };
            int index = Array.BinarySearch(nums, 1, 3, 30); // search in [20, 30, 40]
            Assert.AreEqual(2, index);
        }

        // 8. BinarySearch<T>(T[], Int32, Int32, T, IComparer<T>)
        [TestMethod]
        public void Test_BinarySearch_Generic_TArray_Range_T_IComparer()
        {
            string[] words = { "zebra", "yak", "xenon", "wolf", "vulture" }; // reverse sorted
            int index = Array.BinarySearch(words, 0, 5, "xenon", new ReverseComparerGeneric());
            Assert.AreEqual(2, index);
        }
    }
}
