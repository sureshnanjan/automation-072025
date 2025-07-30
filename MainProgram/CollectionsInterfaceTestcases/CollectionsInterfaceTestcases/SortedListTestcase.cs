using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SortedListTests
{
    [TestClass] // Marks this class as a container for test cases
    public class SortedListCrudTests
    {
        private SortedList _sortedList; // Declare a SortedList for testing

        [TestInitialize] // Runs before every test to initialize a fresh SortedList
        public void Setup()
        {
            _sortedList = new SortedList(); // Create a new empty SortedList
        }

        // ------------------- CREATE TEST -------------------
        [TestMethod]
        public void Create_AddItems_ShouldIncreaseCount()
        {
            // Act
            _sortedList.Add(3, "Three");
            _sortedList.Add(1, "One");
            _sortedList.Add(2, "Two");

            // Assert
            Assert.AreEqual(3, _sortedList.Count, "Adding items should increase SortedList count.");
        }

        // ------------------- READ TEST -------------------
        [TestMethod]
        public void Read_GetItemByKey_ShouldReturnCorrectValue()
        {
            // Arrange
            _sortedList.Add(1, "One");
            _sortedList.Add(2, "Two");

            // Act
            var value = _sortedList[2];

            // Assert
            Assert.AreEqual("Two", value, "Accessing key 2 should return value 'Two'.");
        }

        // ------------------- UPDATE TEST -------------------
        [TestMethod]
        public void Update_ExistingKey_ShouldModifyValue()
        {
            // Arrange
            _sortedList.Add(1, "OldValue");

            // Act
            _sortedList[1] = "NewValue"; // Updating the value for key 1

            // Assert
            Assert.AreEqual("NewValue", _sortedList[1], "Updating key 1 should change its value.");
        }

        // ------------------- DELETE TEST -------------------
        [TestMethod]
        public void Delete_RemoveItem_ShouldDecreaseCount()
        {
            // Arrange
            _sortedList.Add(1, "One");
            _sortedList.Add(2, "Two");

            // Act
            _sortedList.Remove(1); // Remove item with key 1

            // Assert
            Assert.AreEqual(1, _sortedList.Count, "Removing an item should decrease count.");
            Assert.IsFalse(_sortedList.ContainsKey(1), "Key 1 should no longer exist.");
        }

        // ------------------- DELETE ALL TEST -------------------
        [TestMethod]
        public void DeleteAll_Clear_ShouldResultInEmptySortedList()
        {
            // Arrange
            _sortedList.Add(1, "One");
            _sortedList.Add(2, "Two");

            // Act
            _sortedList.Clear();

            // Assert
            Assert.AreEqual(0, _sortedList.Count, "Clearing SortedList should remove all elements.");
        }

        // ------------------- ENUMERABLE TEST -------------------
        [TestMethod]
        public void Enumerable_ShouldIterateSortedListInKeyOrder()
        {
            // Arrange
            _sortedList.Add(3, "Three");
            _sortedList.Add(1, "One");
            _sortedList.Add(2, "Two");

            // Act: Iterate using IEnumerable and convert to list of values
            var items = _sortedList.Cast<DictionaryEntry>()
                                   .Select(entry => entry.Value)
                                   .ToList();

            // Assert: Elements should be returned in ascending key order
            CollectionAssert.AreEqual(
                new List<object> { "One", "Two", "Three" },
                items,
                "Enumerable should return values sorted by their keys."
            );
        }
    }
}
