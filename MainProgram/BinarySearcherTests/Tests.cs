using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearcher
{
    [TestClass]
    public class TestDefaultSort
    {
        [TestMethod]
        public void DefaultSortTestCase()
        {
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
        public void SecondCharTestCase()
        {
            //Arrange
            //string[] words = { "The", "quick", "brown", "fox", "jumps", "over",
                        // "the", "lazy", "dog" };
            //string expected = "lazy";

            //Act
           // Array.Sort(words, new SecondCharComparer());
            //string Actual = words[0];

            //assert
           // Assert.AreEqual(Expected, Actual);
        }
    }
}