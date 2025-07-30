using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BinarySearcher
{
    [TestClass]
    public class TestDefaultSort
    {
        [TestMethod]
        public void DefaultSortTestCase()
        {
            string[] words = { "The", , "quick", "brown", "fox", "jumps", "over",
                         "the", "lazy", "dog" };
            string Expected = "brown";
            Array.sort(words);
            string Actual = words[0];

            Assert.AreEqual(Expected, Actual);

        }

    }
}