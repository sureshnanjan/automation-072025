/*
* ----------------------------------------------------------------------------
* Title     : BinarySearch Overloads Test Cases (MSBuild Compatible)
* Author    : Keyur Nagvekar
* Created   : July 28, 2025
* License   : MIT License
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
        [TestMethod]
        public void Test_BinarySearch_Array_Object()
        {
            int[] numbers = { 10, 20, 30, 40, 50 };
            int index = Array.BinarySearch(numbers, 30);
            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void Test_BinarySearch_Array_Object_IComparer()
        {
            string[] names = { "Alice", "Bob", "Charlie" };
            int index = Array.BinarySearch(names, "bob", StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void Test_BinarySearch_Array_Int_Int_Object()
        {
            int[] values = { 5, 10, 15, 20, 25, 30 };
            int index = Array.BinarySearch(values, 1, 4, 20);
            Assert.AreEqual(3, index);
        }

        [TestMethod]
        public void Test_BinarySearch_Array_Int_Int_Object_IComparer()
        {
            string[] fruits = { "Apple", "Banana", "Grape", "Orange", "Peach" };
            int index = Array.BinarySearch(fruits, 1, 3, "grape", StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void Test_BinarySearch_Generic_TArray_T()
        {
            double[] values = { 1.1, 2.2, 3.3, 4.4 };
            int index = Array.BinarySearch(values, 3.3);
            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void Test_BinarySearch_Generic_TArray_T_IComparer()
        {
            string[] planets = { "Earth", "Mars", "Venus" };
            int index = Array.BinarySearch(planets, "venus", StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void Test_BinarySearch_Generic_TArray_Int_Int_T()
        {
            char[] letters = { 'a', 'b', 'c', 'd', 'e' };
            int index = Array.BinarySearch(letters, 1, 3, 'c');
            Assert.AreEqual(2, index);
        }
    }
}
