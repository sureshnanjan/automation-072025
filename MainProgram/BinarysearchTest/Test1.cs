/*
* ----------------------------------------------------------------------------
* Title     : BinarySearch Overloads Test Cases (MSBuild Compatible)
* Author    : Keyur Nagvekar
* Created   : July 28, 2025
* License   : MIT License
* ----------------------------------------------------------------------------
* Description:
* This test class demonstrates the use of all 7 overloads of Array.BinarySearch in C#.
* Each test method validates one overload, confirming the index of a searched element.
* ----------------------------------------------------------------------------
*/

using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearchTests
{
    [TestClass]
    public class BinarySearchTestCases
    {
        // 1. BinarySearch(Array, Object)
        // Searches entire array using IComparable
        [TestMethod]
        public void Test_BinarySearch_Array_Object()
        {
            int[] numbers = { 10, 20, 30, 40, 50 };
            int index = Array.BinarySearch(numbers, 30);
            Assert.AreEqual(2, index); // Index 2 holds value 30
        }

        // 2. BinarySearch(Array, Object, IComparer)
        // Searches entire array using a custom IComparer (case-insensitive search)
        [TestMethod]
        public void Test_BinarySearch_Array_Object_IComparer()
        {
            string[] names = { "Alice", "Bob", "Charlie" };
            int index = Array.BinarySearch(names, "bob", StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(1, index); // 'bob' matches 'Bob' at index 1
        }

        // 3. BinarySearch(Array, Int32, Int32, Object)
        // Searches a specific range within the array using IComparable
        [TestMethod]
        public void Test_BinarySearch_Array_Int_Int_Object()
        {
            int[] values = { 5, 10, 15, 20, 25, 30 };
            int index = Array.BinarySearch(values, 1, 4, 20);
            Assert.AreEqual(3, index); // Searches values[1..4] => index 3 has 20
        }

        // 4. BinarySearch(Array, Int32, Int32, Object, IComparer)
        // Searches a range within the array using a custom IComparer (case-insensitive)
        [TestMethod]
        public void Test_BinarySearch_Array_Int_Int_Object_IComparer()
        {
            string[] fruits = { "Apple", "Banana", "Grape", "Orange", "Peach" };
            int index = Array.BinarySearch(fruits, 1, 3, "grape", StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(2, index); // Searches fruits[1..3] => 'Grape' is at index 2
        }

        // 5. BinarySearch<T>(T[], T)
        // Generic method using IComparable<T> to search entire array
        [TestMethod]
        public void Test_BinarySearch_Generic_TArray_T() //This marks a unit test using the MSTest framework.
//The name indicates that we’re testing the BinarySearch<T>(T[], T) overload.
//The test is public, takes no parameters, and returns void.//
        {
            double[] values = { 1.1, 2.2, 3.3, 4.4 };
            int index = Array.BinarySearch(values, 3.3);
            Assert.AreEqual(2, index); // 3.3 is at index 2
        }

        // 6. BinarySearch<T>(T[], T, IComparer<T>)
        // Generic method using IComparer<T> to search entire array
        [TestMethod]
        public void Test_BinarySearch_Generic_TArray_T_IComparer()
        {
            string[] planets = { "Earth", "Mars", "Venus" };
            int index = Array.BinarySearch(planets, "venus", StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(2, index); // 'venus' matches 'Venus' at index 2
        }

        // 7. BinarySearch<T>(T[], Int32, Int32, T)
        // Generic method using IComparable<T> to search a specific range
        [TestMethod]
        public void Test_BinarySearch_Generic_TArray_Int_Int_T()
        {
            char[] letters = { 'a', 'b', 'c', 'd', 'e' };
            int index = Array.BinarySearch(letters, 1, 3, 'c');
            Assert.AreEqual(2, index); // Searches letters[1..3] => 'c' is at index 2
        }
    }
}