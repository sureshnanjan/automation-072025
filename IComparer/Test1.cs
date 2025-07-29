using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System;

namespace ReverseSortExample.Tests
{
    [TestClass]
    public class SortTests
    {
        private class ReverserClass : IComparer
        {
            public int Compare(object x, object y)
            {
                return StringComparer.InvariantCultureIgnoreCase.Compare(y, x);
            }
        }

        [TestMethod]
        public void DefaultSort_ShouldBeAscending_CaseSensitive()
        {
            string[] input = { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
            string[] expected = { "brown", "dog", "fox", "jumps", "lazy", "over", "quick", "the", "The" };

            Array.Sort(input);

            CollectionAssert.AreEqual(expected, input);
        }

        [TestMethod]
        public void ReverseSort_ShouldBeDescending_CaseInsensitive()
        {
            string[] input = { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
            string[] expected = { "the", "The", "quick", "over", "lazy", "jumps", "fox", "dog", "brown" };

            Array.Sort(input, new ReverserClass());

            CollectionAssert.AreEqual(expected, input);
        }
    }
}
