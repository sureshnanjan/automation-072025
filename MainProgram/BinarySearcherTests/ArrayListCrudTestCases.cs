/*******************************************************
* Copyright (c) 2025, Shreya S G
* All rights reserved.
* 
* File: ArrayListCrudTestCases.cs
* Purpose: Unit tests for CRUD operations on ArrayList.
*******************************************************/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace BinarySearcherTests
{
    /// <summary>
    /// Test cases for verifying ArrayList CRUD operations.
    /// </summary>
    [TestClass]
    public class ArrayListCrudTestCases
    {
        [TestMethod]
        public void Add_AddsElementToArrayList()
        {
            // Arrange
            ArrayList list = new ArrayList();

            // Act
            list.Add("Apple");
            list.Add("Kiwi");
           

            // Assert
            Assert.AreEqual(1, list.Count, "Item count should be 1 after Add()."); // expected value , actual value 
            Assert.AreEqual("Apple", list[0], "The first item should be 'Apple'.");
        }

        [TestMethod]
        public void Insert_InsertsElementAtSpecificIndex()
        {
            // Arrange
            ArrayList list = new ArrayList { "Apple", "Orange" };

            // Act
            list.Insert(1, "Banana");

            // Assert
            Assert.AreEqual(3, list.Count, "Item count should be 3 after Insert().");
            Assert.AreEqual("Banana", list[1], "Item at index 1 should be 'Banana'.");
        }
        [TestMethod]
        public void AddRange_AddsMultipleElementsToArrayList()
        {
            // Arrange
            ArrayList list = new ArrayList { "Apple" };
            string[] newFruits = { "Plum", "Blueberry", "Lemon" };

            // Act
            list.AddRange(newFruits);

            // Assert
            Assert.AreEqual(4, list.Count, "Item count should be 4 after AddRange().");
            Assert.AreEqual("Plum", list[1], "Item at index 1 should be 'Plum'.");
            Assert.AreEqual("Blueberry", list[2], "Item at index 2 should be 'Blueberry'.");
            Assert.AreEqual("Lemon", list[3], "Item at index 3 should be 'Lemon'.");
        }

        [TestMethod]
        public void Remove_RemovesElementByValue()
        {
            // Arrange
            ArrayList list = new ArrayList { "Apple", "Banana", "Mango" };

            // Act
            list.Remove("Banana");

            // Assert
            Assert.AreEqual(2, list.Count, "Item count should decrease after Remove().");
            CollectionAssert.DoesNotContain(list, "Banana", "'Banana' should be removed.");
        }

        [TestMethod]
        public void RemoveAt_RemovesElementAtIndex()
        {
            // Arrange
            ArrayList list = new ArrayList { "Apple", "Banana", "Mango" };

            // Act
            list.RemoveAt(1);

            // Assert
            Assert.AreEqual(2, list.Count, "Item count should decrease after RemoveAt().");
            Assert.AreEqual("Mango", list[1], "Item at index 1 should now be 'Mango'.");
        }

        [TestMethod]
        public void Reverse_ReversesArrayList()
        {
            // Arrange
            ArrayList list = new ArrayList { "Apple", "Banana", "Mango" };

            // Act
            list.Reverse();

            // Assert
            Assert.AreEqual("Mango", list[0], "First item should be 'Mango' after Reverse().");
            Assert.AreEqual("Apple", list[2], "Last item should be 'Apple' after Reverse().");
        }

        [TestMethod]
        public void Sort_SortsArrayList()
        {
            // Arrange
            ArrayList list = new ArrayList { "Mango", "Apple", "Banana" };

            // Act
            list.Sort();

            // Assert
            Assert.AreEqual("Apple", list[0], "First item should be 'Apple' after Sort().");
            Assert.AreEqual("Mango", list[2], "Last item should be 'Mango' after Sort().");
        }
        [TestMethod]
        public void Read_ReturnsAllElementsInCorrectOrder()
        {
            // Arrange
            ArrayList list = new ArrayList { "Apple", "Banana", "Mango" };
            string[] expected = { "Apple", "Banana", "Mango" };
            string[] actual = new string[list.Count];

            // Act: Reading all items
            for (int i = 0; i < list.Count; i++)
            {
                actual[i] = list[i].ToString();
            }

            // Assert
            CollectionAssert.AreEqual(expected, actual, "Read operation should return all elements in correct order.");
        }
        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void ReadOnlyArrayList_ThrowsErrorOnUpdate()
        {
            // Arrange
            ArrayList original = new ArrayList { "Apple", "Banana", "Mango" };
            ArrayList readOnlyList = ArrayList.ReadOnly(original); // make it read-only

            // Act
            readOnlyList[0] = "Pineapple"; // Trying to update should throw NotSupportedException
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void ReadOnlyArrayList_ThrowsErrorOnDelete()
        {
            // Arrange
            ArrayList original = new ArrayList { "Apple", "Banana", "Mango" };
            ArrayList readOnlyList = ArrayList.ReadOnly(original); // make it read-only

            // Act
            readOnlyList.Remove("Apple"); // Trying to delete should throw NotSupportedException
        }
        [TestMethod]
        public void ReadOnlyArrayList_Update_ShouldFailTest()
        {
            // Arrange
            ArrayList original = new ArrayList { "Apple", "Banana", "Mango" };
            ArrayList readOnlyList = ArrayList.ReadOnly(original); // make it read-only
            bool updateSucceeded = true;

            try
            {
                // Act
                readOnlyList[0] = "Pineapple"; // This will throw NotSupportedException
            }
            catch
            {
                updateSucceeded = false;
            }

            // This assertion will FAIL because updateSucceeded will be false.
            Assert.IsTrue(updateSucceeded, "Update should succeed in read-only list (this will FAIL).");
        }


    }
}
