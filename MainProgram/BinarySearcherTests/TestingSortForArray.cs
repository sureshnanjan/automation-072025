/*
* ------------------------------------------------------------------------------
* © 2025 SOWMYA SRIDHAR. All rights reserved.
* 
* This file is part of the TestProject unit test suite.
* It demonstrates various sorting mechanisms and verifies them using MSTest.
* Redistribution and use in source and binary forms, with or without 
* modification, are permitted for educational or internal use only.
* ------------------------------------------------------------------------------
*/

using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static TestProject.Example;

namespace TestProject
{
    /// <summary>
    /// Contains custom comparer classes for sorting operations.
    /// </summary>
    public class Example
    {
        /// <summary>
        /// A custom comparer that performs case-insensitive reverse comparison.
        /// </summary>
        public class ReverserClass : IComparer
        {
            /// <summary>
            /// Compares two objects in reverse (case-insensitive).
            /// </summary>
            /// <param name="x">First object.</param>
            /// <param name="y">Second object.</param>
            /// <returns>Comparison result with reversed parameters.</returns>
            int IComparer.Compare(object x, object y)
            {
                return (new CaseInsensitiveComparer()).Compare(y, x);
            }
        }

        /// <summary>
        /// A custom comparer that compares strings based on their second character.
        /// </summary>
        public class SecondCharCompare : IComparer<string>
        {
            /// <summary>
            /// Compares two strings by their second character.
            /// </summary>
            /// <param name="x">First string.</param>
            /// <param name="y">Second string.</param>
            /// <returns>Comparison result of second characters.</returns>
            public int Compare(string? x, string? y)
            {
                if (x == null || y == null || x.Length < 2 || y.Length < 2)
                    return 0;
                return x[1].CompareTo(y[1]);
            }
        }
    }

    /// <summary>
    /// Test class to validate sorting behavior using MSTest.
    /// </summary>
    [TestClass]
    public sealed class TestingSortForArray
    {
        /// <summary>
        /// Tests default alphabetical sorting of a string array.
        /// </summary>
        [TestMethod]
        public void TestForSort()
        {
            string[] words = { "The", "quick", "brown", "fox", "jumps", "over",
                               "the", "lazy", "dog" };
            Array.Sort(words);
            //string[] finalResult = {"brown","dog","fox","jumps","lazy","over","quick","the","The"};
            Assert.AreEqual("brown", words[0]);
        }

        /// <summary>
        /// Tests reverse case-insensitive sorting using ReverserClass.
        /// </summary>
        [TestMethod]
        public void TestForReverseSort()
        {
            string[] words = { "The", "quick", "brown", "fox", "jumps", "over",
                               "the", "lazy", "dog" };
            Array.Sort(words, new ReverserClass());
            Assert.AreEqual("The", words[0]);
        }

        /// <summary>
        /// Tests sorting based on the second character of each word.
        /// </summary>
        [TestMethod]
        public void TestForSecondCharCompare()
        {
            string[] words = { "The", "quick", "brown", "fox", "jumps", "over",
                               "the", "lazy", "dog" };
            Array.Sort(words, new SecondCharCompare());
            Assert.AreEqual("lazy", words[0]);
        }
    }
}
