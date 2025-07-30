using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearcherIcomparer
{
    [TestClass]
    public class ArraySortTest
    {
        [TestMethod]
        public void DefaultSortingTest()
        {
            //Arrange
            // Initialize a string array.
            string[] words = { "The", "quick", "brown", "fox", "jumps", "over",
                         "the", "lazy", "dog" };
            string Expected = "brown";

            //Act
            Array.Sort(words);

            string Actual = words[0];

            //assert
            Assert.AreEqual(Expected, Actual);
        }
        [TestMethod]
        public void SortTest() { }

        public void ReverseSort()
        {
            string[] arr = { "a", "Beta", "charlie", "Delta" };
            //Arrange

            string expected = "Delta";

            Array.Sort(arr, new ReverseSorter());

            string actual = arr[0];

            Assert.AreEqual(actual, expected);

        }


        internal class ReverseSorter : IComparer<string>
        {
            public int Compare(string? x, string? y)
            {
                //throw new NotImplementedException();
                return y.CompareTo(x);

            }
        }
    }
}
