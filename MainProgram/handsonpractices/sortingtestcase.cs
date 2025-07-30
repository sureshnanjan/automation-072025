using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace StringSortingTests
{
    public class ReverserClass : IComparer
    {
        public int Compare(object x, object y)
        {
            return (new CaseInsensitiveComparer()).Compare(y, x);
        }
    }

    [TestClass]
    public class SortTests
    {
        string[] original = { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };

        [TestMethod]
        public void TestDefaultSort()
        {
            string[] input = (string[])original.Clone();
            string[] expected = { "brown", "dog", "fox", "jumps", "lazy", "over", "quick", "the", "The" };

            Array.Sort(input);

            CollectionAssert.AreEqual(expected, input);
        }

        [TestMethod]
        public void TestReverseCaseInsensitiveSort()
        {
            string[] input = (string[])original.Clone();
            string[] expected = { "the", "The", "quick", "over", "lazy", "jumps", "fox", "dog", "brown" };

            Array.Sort(input, new ReverserClass());

            CollectionAssert.AreEqual(expected, input);
        }
    }
}
