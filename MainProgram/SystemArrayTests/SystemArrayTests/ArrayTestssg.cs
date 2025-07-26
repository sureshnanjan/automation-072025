using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace SystemArrayTests
{
    public class AscendingIntegerComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            int a = (int)x;
            int b = (int)y;
            return a.CompareTo(b); // Ascending
        }
    }
    //BinarySearch(Array, Int32, Int32, Object, IComparer)
    [TestClass]
    public class ArrayTestssg
    {
        [TestMethod]
        public void BinarySearch_AscendingComparer_FindsCorrectIndex()
        {
            // Arrange
            int[] numbers = { 10, 20, 30, 40, 50, 60 }; 

            //Action
            Array.Sort(numbers, new AscendingIntegerComparer());

            int index = Array.BinarySearch(numbers, 0, numbers.Length, 40, new AscendingIntegerComparer());

            //Assert
            Assert.AreEqual(3, index);
        }

        [TestMethod]
        public void BinarySearch_AscendingComparer_ReturnsNegativeIfNotFound()
        {
            //Action
            int[] numbers = { 10, 20, 30, 40, 50, 60 };
            
            //Action
            Array.Sort(numbers, new AscendingIntegerComparer());

            int index = Array.BinarySearch(numbers, 0, numbers.Length, 25, new AscendingIntegerComparer());

            //Assert
            Assert.IsTrue(index < 0);
        }
        [TestMethod]
        public void BinarySearch_WithCustomComparer_FindsCorrectIndex()
        {
            string[] words = { "Apple", "Banana", "Cherry", "Date", "Fig", "Grape" };

            // Custom comparer for case-insensitive string comparison
            IComparer caseInsensitiveComparer = StringComparer.OrdinalIgnoreCase;

            // Search for "banana" in the full array using the custom comparer
            int index = Array.BinarySearch(words, 0, words.Length, "banana", caseInsensitiveComparer);

            // "Banana" is at index 1
            Assert.AreEqual(1, index);
        }
        [TestMethod]
        public void BinarySearch_WithCustomComparer_ReturnsNegativeIfNotFound()
        {
            string[] words = { "Apple", "Banana", "Cherry", "Date", "Fig", "Grape" };
            IComparer caseInsensitiveComparer = StringComparer.OrdinalIgnoreCase;

            int index = Array.BinarySearch(words, 0, words.Length, "Orange", caseInsensitiveComparer);

            Assert.IsTrue(index < 0);
        }
        //BinarySearch(Array, int32,int 32,Object)
        [TestMethod]
        public void BinarySearch_Range_NoComparer_FindsNumber()
        {
            int[] numbers = { 10, 20, 30, 40, 50 };
            int index = Array.BinarySearch(numbers, 1, 3, 30); // Search between index 1-3
            Assert.AreEqual(2, index); // 30 is at index 2
        }

        [TestMethod]
        public void BinarySearch_Range_NoComparer_NumberNotFound()
        {
            int[] numbers = { 10, 20, 30, 40, 50 };
            int index = Array.BinarySearch(numbers, 1, 3, 100);
            Assert.IsTrue(index < 0); // 100 not in range
        }
        //BinarySearch(Array, Object, IComparer)
        public class DescendingComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                return ((IComparable)y).CompareTo(x); // Reverse comparison
            }
        }

        [TestMethod]
        public void BinarySearch_CustomComparer_FindsNumber()
        {
            int[] numbers = { 100, 80, 60, 40, 20 };
            int index = Array.BinarySearch(numbers, 60, new DescendingComparer());
            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void BinarySearch_CustomComparer_NumberNotFound()
        {
            int[] numbers = { 100, 80, 60, 40, 20 };
            int index = Array.BinarySearch(numbers, 75, new DescendingComparer());
            Assert.IsTrue(index < 0);
        }
        // BinarySearch<T>(T[], Int32, Int32, T, IComparer<T>)
        public class ReverseComparer<T> : IComparer<T> where T : IComparable<T>
        {
            public int Compare(T x, T y) => y.CompareTo(x);
        }

        [TestMethod]
        public void BinarySearch_GenericRange_CustomComparer_FindsNumber()
        {
            int[] numbers = { 100, 80, 60, 40, 20 };
            int index = Array.BinarySearch(numbers, 0, numbers.Length, 40, new ReverseComparer<int>());
            Assert.AreEqual(3, index);
        }

        [TestMethod]
        public void BinarySearch_GenericRange_CustomComparer_NumberNotFound()
        {
            int[] numbers = { 100, 80, 60, 40, 20 };
            int index = Array.BinarySearch(numbers, 0, numbers.Length, 75, new ReverseComparer<int>());
            Assert.IsTrue(index < 0);
        }
        [TestMethod]
        public void BinarySearch_GenericRange_CustomComparer_FindsString()
        {
            string[] words = { "Zebra", "Monkey", "Apple" };
            Array.Sort(words, StringComparer.OrdinalIgnoreCase);
            int index = Array.BinarySearch(words, 0, words.Length, "Monkey", StringComparer.OrdinalIgnoreCase);
            Assert.IsTrue(index >= 0);
        }

        [TestMethod]
        public void BinarySearch_GenericRange_CustomComparer_StringNotFound()
        {
            string[] words = { "Zebra", "Monkey", "Apple" };
            Array.Sort(words, StringComparer.OrdinalIgnoreCase);
            int index = Array.BinarySearch(words, 0, words.Length, "Banana", StringComparer.OrdinalIgnoreCase);
            Assert.IsTrue(index < 0);
        }

    }
}
