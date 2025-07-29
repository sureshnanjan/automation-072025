/*
* MIT License
* 
* Copyright (c) 2025 Elangovan R
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.
*/
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SortingTests
{
    [TestClass]
    public class SortComparerTests
    {


        [TestMethod]
        public void Test_DefaultSort_FirstElement()
        {
            //Assemble
            string[] words = { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
            string expectedResult = "brown";
            //Act
            Array.Sort(words);
            string actualResult = words[0];
            //Assert
            Assert.AreEqual(expectedResult, actualResult); // After default sort
        }

        [TestMethod]
        public void Test_ReverseCaseInsensitiveSort_FirstElement()
        {
            string[] words = { "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
            string expectedResult = "the";
            Array.Sort(words, new ReverserClass());
            string actualResult = words[0];
            Assert.AreEqual(expectedResult, actualResult); ; // After reverse case-insensitive sort
        }

        [TestMethod]
        public void Test_SecondLetterSort_FirstElement()
        {
            string[] words = { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
            string expectedResult = "lazy";
            Array.Sort(words, new SecondLetterClass());
            string actualResult = words[0];
            Assert.AreEqual(expectedResult, actualResult); // After second letter sort
        }
    }

    // Case-insensitive reverse comparer
    public class ReverserClass : IComparer
    {
        // Call CaseInsensitiveComparer.Compare with the parameters reversed.
        int IComparer.Compare(Object x, Object y)
        {
            return ((new CaseInsensitiveComparer()).Compare(y, x));
        }
    }


    // Custom comparer: compares second letter of strings
    public class SecondLetterClass : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            return Comparer<char>.Default.Compare(x![1], y![1]);
        }
    }
}
