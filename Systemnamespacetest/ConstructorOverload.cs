using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace ArrayListConstructorTests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void Test_DefaultConstructor()
        {
            // Arrange
            ArrayList list = new ArrayList();

            // Act
            int count = list.Count;

            // Assert
            Assert.AreEqual(0, count, "Default constructor should create an empty list.");
        }

        [TestMethod]
        public void Test_ConstructorWithCapacity()
        {
            // Arrange
            int initialCapacity = 10;
            ArrayList list = new ArrayList(initialCapacity);

            // Act
            int capacity = list.Capacity;

            // Assert
            Assert.IsTrue(capacity >= initialCapacity, "Constructor with capacity should initialize with at least the specified capacity.");
        }

        [TestMethod]
        public void Test_ConstructorWithCollection()
        {
            // Arrange
            string[] sourceArray = new string[] { "A", "B", "C" };
            ArrayList list = new ArrayList(sourceArray);

            // Act
            int count = list.Count;

            // Assert
            Assert.AreEqual(3, count, "Constructor with collection should copy elements.");
            CollectionAssert.AreEqual(sourceArray, list, "Elements should match the source collection.");
        }
    }
}
