// -----------------------------------------------------------------------------
// Author      : Arpita Neogi
// Date        : 28/07/25
// Description : Interface demonstration with unit tests (IEnumerable, ICollection, etc.)
// -----------------------------------------------------------------------------
// © 2025 Arpita Neogi. All rights reserved.
// -----------------------------------------------------------------------------

using Microsoft.VisualStudio.TestTools.UnitTesting; // MSTest framework
using System;

namespace BinarySearchOverload
{
    [TestClass] // Marks this class as a test container
    public class BinarySearchTests
    {
        // -------------------------------
        // Overload 1: Array.BinarySearch(Array, Object)
        // -------------------------------

        [TestMethod]
        public void BinarySearch_Array_Object_Found()
        {
            int[] arr = { 10, 20, 30 }; // Sorted array of integers
            int index = Array.BinarySearch(arr, 20); // Search for 20
            Assert.AreEqual(1, index); // Assert that 20 is at index 1
        }

        [TestMethod]
        public void BinarySearch_Array_Object_NotFound()
        {
            int[] arr = { 10, 20, 30 }; // Sorted array
            int index = Array.BinarySearch(arr, 25); // 25 not in array
            Assert.IsTrue(index < 0); // Should return a negative index
        }

        // -------------------------------
        // Overload 2: Array.BinarySearch(Array, Int32, Int32, Object)
        // -------------------------------

        [TestMethod]
        public void BinarySearch_Array_Partial_Found()
        {
            int[] arr = { 5, 10, 15, 20, 25 }; // Full array
            int index = Array.BinarySearch(arr, 1, 3, 15); // Search 15 in {10,15,20}
            Assert.AreEqual(2, index); // 15 is at index 2 in full array
        }

        [TestMethod]
        public void BinarySearch_Array_Partial_NotFound()
        {
            int[] arr = { 5, 10, 15, 20, 25 }; // Array to search within
            int index = Array.BinarySearch(arr, 1, 3, 100); // Search 100 in {10,15,20}
            Assert.IsTrue(index < 0); // 100 not found, index should be negative
        }

        // -------------------------------
        // Overload 3: BinarySearch<T>(T[], T)
        // -------------------------------

        [TestMethod]
        public void BinarySearch_Generic_Found()
        {
            string[] arr = { "a", "b", "c" }; // Sorted string array
            int index = Array.BinarySearch(arr, "b"); // Search for "b"
            Assert.AreEqual(1, index); // "b" is at index 1
        }

        [TestMethod]
        public void BinarySearch_Generic_NotFound()
        {
            string[] arr = { "a", "b", "c" }; // Sorted string array
            int index = Array.BinarySearch(arr, "z"); // "z" not found
            Assert.IsTrue(index < 0); // Result should be negative
        }

        // -------------------------------
        // Overload 4: Array.BinarySearch(Array, Object, IComparer)
        // -------------------------------

        [TestMethod]
        public void BinarySearch_WithComparer_Found()
        {
            string[] arr = { "Apple", "banana", "Cherry" }; // Mixed case
            int index = Array.BinarySearch(arr, "BANANA", StringComparer.OrdinalIgnoreCase); // Case-insensitive search
            Assert.AreEqual(1, index); // "banana" found at index 1
        }

        [TestMethod]
        public void BinarySearch_WithComparer_NotFound()
        {
            string[] arr = { "Apple", "banana", "Cherry" }; // Array
            int index = Array.BinarySearch(arr, "zebra", StringComparer.OrdinalIgnoreCase); // "zebra" not in array
            Assert.IsTrue(index < 0); // Should return negative index
        }

        // -------------------------------
        // Overload 5: BinarySearch<T>(T[], T, IComparer<T>)
        // -------------------------------

        [TestMethod]
        public void BinarySearch_GenericComparer_Found()
        {
            string[] arr = { "dog", "Elephant", "fox" }; // Sorted array
            int index = Array.BinarySearch(arr, "elephant", StringComparer.OrdinalIgnoreCase); // Case-insensitive search
            Assert.AreEqual(1, index); // Match at index 1
        }

        [TestMethod]
        public void BinarySearch_GenericComparer_NotFound()
        {
            string[] arr = { "dog", "Elephant", "fox" }; // Array
            int index = Array.BinarySearch(arr, "goat", StringComparer.OrdinalIgnoreCase); // "goat" not in array
            Assert.IsTrue(index < 0); // Not found => negative
        }

        // -------------------------------
        // Overload 6: BinarySearch<T>(T[], Int32, Int32, T)
        // -------------------------------

        [TestMethod]
        public void BinarySearch_GenericPartial_Found()
        {
            int[] arr = { 1, 2, 3, 4, 5 }; // Array
            int index = Array.BinarySearch(arr, 1, 3, 3); // Search 3 in {2,3,4}
            Assert.AreEqual(2, index); // 3 is at index 2 in full array
        }

        [TestMethod]
        public void BinarySearch_GenericPartial_NotFound()
        {
            int[] arr = { 1, 2, 3, 4, 5 }; // Array
            int index = Array.BinarySearch(arr, 1, 3, 10); // Search 10 in {2,3,4}
            Assert.IsTrue(index < 0); // 10 not found
        }

        // -------------------------------
        // Overload 7: BinarySearch<T>(T[], Int32, Int32, T, IComparer<T>)
        // -------------------------------

        [TestMethod]
        public void BinarySearch_GenericPartialComparer_Found()
        {
            string[] arr = { "a", "Beta", "charlie", "Delta" }; // Sorted string array
            int index = Array.BinarySearch(arr, 1, 2, "CHARLIE", StringComparer.OrdinalIgnoreCase); // Search "CHARLIE" in {Be
