using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearcherNew
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
    }
}