// Importing required namespaces
using Microsoft.VisualStudio.TestTools.UnitTesting; // MSTest framework for creating unit tests
using System;                                      // Base classes
using System.Collections;                          // Provides Stack class
using System.Collections.Generic;                  // Provides List<T> and LINQ extensions
using System.Linq;                                 // Allows casting and list operations

namespace StackTests
{
    [TestClass] // Marks this class as a container for test methods
    public class StackCrudTests
    {
        private Stack _stack; // Declare a stack instance to be used in tests

        [TestInitialize] // This method runs before every test case
        public void Setup()
        {
            // Arrange: Initialize a fresh stack before each test
            _stack = new  Stack();
        }

        // ------------------- CREATE TEST -------------------
        [TestMethod] // Marks this method as a test case
        public void Create_PushItems_ShouldIncreaseCount()
        {
            // Act: Push elements into the stack
            _stack.Push("Item1"); // Adds first item
            _stack.Push("Item2"); // Adds second item
            _stack.Push("Item3"); // Adds third item

            // Assert: Verify stack count is now 3
            Assert.AreEqual(3, _stack.Count, "Pushing items should increase stack count.");
        }

        // ------------------- READ TEST -------------------
        [TestMethod]
        public void Read_PeekItem_ShouldReturnTopElementWithoutRemovingIt()
        {
            // Arrange: Add two items to the stack
            _stack.Push("First");  // First pushed item
            _stack.Push("Second"); // Second pushed item (top of stack)

            // Act: Peek reads the top element without removing it
            var topItem = _stack.Peek();

            // Assert: The top item should be "Second", count should remain 2
            Assert.AreEqual("Second", topItem, "Peek should return the last pushed item.");
            Assert.AreEqual(2, _stack.Count, "Peek should not remove the element from stack.");
        }

        // ------------------- UPDATE TEST -------------------
        [TestMethod]
        public void Update_TopItem_ShouldBeModifiedSuccessfully()
        {
            // Arrange: Push an old value
            _stack.Push("OldValue");

            // Act: Remove top element and add updated value
            _stack.Pop();                // Removes "OldValue"
            _stack.Push("NewValue");     // Adds updated value

            // Assert: Peek should now return "NewValue"
            Assert.AreEqual("NewValue", _stack.Peek(), "Top item should be updated to new value.");
        }

        // ------------------- DELETE TEST -------------------
        [TestMethod]
        public void Delete_PopItem_ShouldRemoveTopElement()
        {
            // Arrange: Push two elements
            _stack.Push("Item1");  // First element
            _stack.Push("Item2");  // Second element (top of stack)

            // Act: Pop removes and returns the top element
            var removedItem = _stack.Pop();

            // Assert: The removed item should be "Item2", count should now be 1
            Assert.AreEqual("Item2", removedItem, "Pop should remove and return the last pushed item.");
            Assert.AreEqual(1, _stack.Count, "Stack count should decrease after pop.");
        }

        // ------------------- DELETE ALL TEST -------------------
        [TestMethod]
        public void DeleteAll_Clear_ShouldEmptyStack()
        {
            // Arrange: Push two elements
            _stack.Push("One");
            _stack.Push("Two");

            // Act: Clear removes all elements from the stack
            _stack.Clear();

            // Assert: Count should now be zero
            Assert.AreEqual(0, _stack.Count, "Clear should remove all items from the stack.");
        }

        // ------------------- ENUMERABLE TEST -------------------
        [TestMethod]
        public void Enumerable_ShouldIterateStackInLifoOrder()
        {
            // Arrange: Push three items
            _stack.Push("A");
            _stack.Push("B");
            _stack.Push("C");

            // Act: Cast the stack (IEnumerable) to a list for easy comparison
            var items = _stack.Cast<object>().ToList();

            /* Explanation:
             * - The Stack implements IEnumerable
             * - Using Cast<object>() allows iterating elements
             * - ToList() converts the sequence into a List for assertion
             * - The order of enumeration in Stack is LIFO (Last In, First Out)
             */

            // Assert: Verify the order is "C", "B", "A"
            CollectionAssert.AreEqual(
                new List<object> { "C", "B", "A" },
                items,
                "Enumerable should return stack items in LIFO order."
            );
        }
    }
}
  