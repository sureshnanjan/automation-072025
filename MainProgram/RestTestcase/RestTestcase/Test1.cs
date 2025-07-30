using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using InterfaceDemo;

namespace InterfaceDemo.Tests
{
    [TestClass]
    public class InterfaceTests
    {
        [TestMethod]
        public void MyCollection_ShouldContainThreeItems()
        {
            // Arrange
            MyCollection collection = new MyCollection();

            // Act
            int count = collection.Count;

            // Assert
            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void ReverseComparer_ShouldSortDescending()
        {
            // Arrange
            ArrayList numbers = new ArrayList { 1, 3, 2 };
            ArrayList expected = new ArrayList { 3, 2, 1 };

            // Act
            numbers.Sort(new ReverseComparer());

            // Assert
            CollectionAssert.AreEqual(expected, numbers);
        }

        [TestMethod]
        public void Dictionary_ShouldContainCorrectValues()
        {
            // Arrange
            IDictionary dict = new Hashtable
            {
                ["Name"] = "Arpita",
                ["Role"] = "Developer"
            };

            // Act
            var role = dict["Role"];

            // Assert
            Assert.AreEqual("Developer", role);
        }

        [TestMethod]
        public void CaseInsensitiveComparer_ShouldReturnTrueForDifferentCaseKeys()
        {
            // Arrange
            Hashtable table = new Hashtable(new CaseInsensitiveComparer())
            {
                ["apple"] = "fruit"
            };

            // Act
            bool contains = table.Contains("APPLE");

            // Assert
            Assert.IsTrue(contains);
        }

        [TestMethod]
        public void MyHashCodeProvider_ShouldReturnExpectedValue()
        {
            // Arrange
            var provider = new MyHashCodeProvider();

            // Act
            int hash = provider.GetHashCode("Test");

            // Assert (length 4 * 31 = 124)
            Assert.AreEqual(124, hash);
        }

        [TestMethod]
        public void MyEnumerable_ShouldReturnThreeItems()
        {
            // Arrange
            var enumerable = new MyEnumerable();
            List<string> actual = new List<string>();

            // Act
            foreach (var item in enumerable)
            {
                actual.Add(item.ToString());
            }

            // Assert
            CollectionAssert.AreEqual(new List<string> { "X", "Y", "Z" }, actual);
        }

        [TestMethod]
        public void StructuralComparable_ShouldCompareTuples()
        {
            // Arrange
            IStructuralComparable t1 = Tuple.Create(1, 2);
            IStructuralComparable t2 = Tuple.Create(1, 3);

            // Act
            int result = t1.CompareTo(t2, Comparer.Default);

            // Assert
            Assert.IsTrue(result < 0); // because 2 < 3
        }

        [TestMethod]
        public void StructuralEquatable_ShouldBeEqualIgnoringCase()
        {
            // Arrange
            IStructuralEquatable tuple = Tuple.Create("a", "b");
            var compareTuple = Tuple.Create("A", "b");

            // Act
            bool result = tuple.Equals(compareTuple, StringComparer.OrdinalIgnoreCase);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
