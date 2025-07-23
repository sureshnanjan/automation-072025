using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BinaryOverload
{
    [TestClass]
    public class BinarySearchTests
    {
        // -------------------------------
        // Overload 1: Array.BinarySearch(Array, Object)
        // Searches the entire array for a specific object
        // -------------------------------

        [TestMethod]
        public void BinarySearch_Array_Object_Found()
        {
            int[] arr = { 10, 20, 30 };
            // Searching for 20 in the whole array
            int index = Array.BinarySearch(arr, 20);
            Assert.AreEqual(1, index); // 20 is at index 1
        }

        [TestMethod]
        public void BinarySearch_Array_Object_NotFound()
        {
            int[] arr = { 10, 20, 30 };
            // Searching for 25 which doesn't exist
            int index = Array.BinarySearch(arr, 25);
            Assert.IsTrue(index < 0); // Not found => negative index
        }

        // -------------------------------
        // Overload 2: Array.BinarySearch(Array, Int32, Int32, Object)
        // Searches a portion of the array (from a specific index and count)
        // -------------------------------

        [TestMethod]
        public void BinarySearch_Array_Partial_Found()
        {
            int[] arr = { 5, 10, 15, 20, 25 };
            // Search for 15 in subarray {10, 15, 20}
            int index = Array.BinarySearch(arr, 1, 3, 15);
            Assert.AreEqual(2, index); // 15 is at index 2 in original array
        }

        [TestMethod]
        public void BinarySearch_Array_Partial_NotFound()
        {
            int[] arr = { 5, 10, 15, 20, 25 };
            // Search for 100 in subarray {10, 15, 20}
            int index = Array.BinarySearch(arr, 1, 3, 100);
            Assert.IsTrue(index < 0); // Not found
        }

        // -------------------------------
        // Overload 3: BinarySearch<T>(T[], T)
        // Type-safe search on generic array
        // -------------------------------

        [TestMethod]
        public void BinarySearch_Generic_Found()
        {
            string[] arr = { "a", "b", "c" };
            // Search for "b"
            int index = Array.BinarySearch(arr, "b");
            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void BinarySearch_Generic_NotFound()
        {
            string[] arr = { "a", "b", "c" };
            // Search for "z" (not found)
            int index = Array.BinarySearch(arr, "z");
            Assert.IsTrue(index < 0);
        }

        // -------------------------------
        // Overload 4: Array.BinarySearch(Array, Object, IComparer)
        // Non-generic version with custom comparer
        // -------------------------------

        [TestMethod]
        public void BinarySearch_WithComparer_Found()
        {
            string[] arr = { "Apple", "banana", "Cherry" };
            // Case-insensitive search for "BANANA"
            int index = Array.BinarySearch(arr, "BANANA", StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void BinarySearch_WithComparer_NotFound()
        {
            string[] arr = { "Apple", "banana", "Cherry" };
            // Search for "zebra", not in array
            int index = Array.BinarySearch(arr, "zebra", StringComparer.OrdinalIgnoreCase);
            Assert.IsTrue(index < 0);
        }

        // -------------------------------
        // Overload 5: BinarySearch<T>(T[], T, IComparer<T>)
        // Type-safe version with custom comparer
        // -------------------------------

        [TestMethod]
        public void BinarySearch_GenericComparer_Found()
        {
            string[] arr = { "dog", "Elephant", "fox" };
            // Case-insensitive search for "elephant"
            int index = Array.BinarySearch(arr, "elephant", StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void BinarySearch_GenericComparer_NotFound()
        {
            string[] arr = { "dog", "Elephant", "fox" };
            // Search for "goat" which doesn't exist
            int index = Array.BinarySearch(arr, "goat", StringComparer.OrdinalIgnoreCase);
            Assert.IsTrue(index < 0);
        }

        // -------------------------------
        // Overload 6: BinarySearch<T>(T[], Int32, Int32, T)
        // Type-safe partial search (no custom comparer)
        // -------------------------------

        [TestMethod]
        public void BinarySearch_GenericPartial_Found()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            // Search for 3 in subarray {2,3,4}
            int index = Array.BinarySearch(arr, 1, 3, 3);
            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void BinarySearch_GenericPartial_NotFound()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            // Search for 10 in subarray {2,3,4}
            int index = Array.BinarySearch(arr, 1, 3, 10);
            Assert.IsTrue(index < 0);
        }

        // -------------------------------
        // Overload 7: BinarySearch<T>(T[], Int32, Int32, T, IComparer<T>)
        // Most flexible version: partial + generic + custom comparer
        // -------------------------------

        [TestMethod]
        public void BinarySearch_GenericPartialComparer_Found()
        {
            string[] arr = { "a", "Beta", "charlie", "Delta" };
            // Case-insensitive search for "CHARLIE" in subarray {Beta, charlie}
            int index = Array.BinarySearch(arr, 1, 2, "CHARLIE", StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void BinarySearch_GenericPartialComparer_NotFound()
        {
            string[] arr = { "a", "Beta", "charlie", "Delta" };
            // Search for "ZULU" in subarray {Beta, charlie}
            int index = Array.BinarySearch(arr, 1, 2, "ZULU", StringComparer.OrdinalIgnoreCase);
            Assert.IsTrue(index < 0);
        }
    }
}