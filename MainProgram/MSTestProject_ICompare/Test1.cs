using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ReverseSortExample.Tests
{
    // IComparer for descending (case-insensitive)
    public class DescendingComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return StringComparer.InvariantCultureIgnoreCase.Compare(y, x);
        }
    }

    // IComparer<string> for second character
    public class SecondCharComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x.Length < 2 || y.Length < 2)
                return x.Length.CompareTo(y.Length);

            return x[1].CompareTo(y[1]);
        }
    }

    [TestClass]
    public class SortTests
    {
        [TestMethod]
        public void Test_AscendingOrder_DefaultSort()
        {
            string[] input = { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
            string[] expected = { "brown", "dog", "fox", "jumps", "lazy", "over", "quick", "the", "The" };

            Array.Sort(input);
            CollectionAssert.AreEqual(expected, input);
        }

        [TestMethod]
        public void Test_DescendingOrder_UsingIComparer()
        {
            // Arrange
            string[] input = { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
            string[] expected = { "the", "The", "quick", "over", "lazy", "jumps", "fox", "dog", "brown" };

            // Act
            Array.Sort(input, new DescendingComparer());

            // Assert (case-insensitive match)
            for (int i = 0; i < input.Length; i++)
            {
                Assert.IsTrue(
                    string.Equals(input[i], expected[i], StringComparison.InvariantCultureIgnoreCase),
                    $"Mismatch at index {i}: expected '{expected[i]}', got '{input[i]}'"
                );
            }
        }

        [TestMethod]
        public void Test_SortBySecondCharacter()
        {
            // Arrange
            List<string> input = new List<string> { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
            List<string> expected = new List<string> { "lazy", "The", "the", "fox", "dog", "brown", "quick", "jumps", "over" };

            // Act
            input.Sort(new SecondCharComparer());

            // Assert
            CollectionAssert.AreEqual(expected, input);
        }

         public void ReverseSortExample()
        {
            string[] input = { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
            Console.WriteLine("The array initially contains the following values:");
            PrintIndexAndValues(input);
            // Sort the array values using the default comparer.
            Array.Sort(input);
            Console.WriteLine("After sorting with the default comparer:");
            string expected = "brown, dog, fox, jumps, lazy, over, quick, the, The";
            Array.reverse(input);
            Console.WriteLine("After sorting with the reverse case-insensitive comparer:");
            PrintIndexAndValues(input);
        }
    }
