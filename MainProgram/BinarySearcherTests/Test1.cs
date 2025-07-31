using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace CollectionTest
{

    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void Create_PushToStack()
        {
            // Arrange
            Stack stack = new Stack();

            // Act
            stack.Push("Top");

            // Assert
            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]
        public void Read_PeekStack()
        {
            // Arrange
            Stack stack = new Stack();
            stack.Push("Peek");

            // Act
            var top = stack.Peek();
            var count = stack.Count;

            // Assert
            Assert.AreEqual("Peek", top);
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void Delete_PopFromStack()
        {
            // Arrange
            Stack stack = new Stack();
            stack.Push("A");

            // Act
            var popped = stack.Pop();
            var countAfterPop = stack.Count;

            // Assert
            Assert.AreEqual("A", popped);
            Assert.AreEqual(0, countAfterPop);
        }
    }

    [TestClass]
    //Compares two objects for equivalence, ignoring the case of strings.
    public class CaseInsensitiveComparerTests
    {
        [TestMethod]
        public void Compare_EqualStringsDifferentCase_ShouldBeEqual()
        {

            //Arrange
            var comparer = new CaseInsensitiveComparer();

            //Act
            int result = comparer.Compare("hello", "HELLO");

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Compare_DifferentStrings_ShouldNotBeEqual()
        {

            //Arrange
            var comparer = new CaseInsensitiveComparer();

            //Act
            int result = comparer.Compare("abc", "xyz");

            //Assert
            Assert.AreNotEqual(0, result);
        }
    }
    [TestClass]
    public class HashtableTests
    {
        [TestMethod]
        public void Create_AddToHashtable()
        {
            Hashtable ht = new Hashtable();
            ht["name"] = "Alice";

            Assert.AreEqual("Alice", ht["name"]);
        }

        [TestMethod]
        public void Read_RetrieveValueFromHashtable()
        {
            Hashtable ht = new Hashtable() { { "age", 30 } };
            Assert.AreEqual(30, ht["age"]);
        }

        [TestMethod]
        public void Update_ChangeValueInHashtable()
        {
            Hashtable ht = new Hashtable() { { "key", 1 } };
            ht["key"] = 100;

            Assert.AreEqual(100, ht["key"]);
        }

        [TestMethod]
        public void Delete_RemoveFromHashtable()
        {
            Hashtable ht = new Hashtable() { { "city", "Delhi" } };
            ht.Remove("city");

            Assert.IsFalse(ht.ContainsKey("city"));
        }
    }

    [TestClass]
    public class ArrayListTests
    {
        [TestMethod]
        public void Create_AddItems_ArrayList()
        {

            ArrayList list = new ArrayList();
            list.Add("Apple");
            list.Add("Banana");

            Assert.AreEqual(2, list.Count);
        }

        [TestMethod]
        public void Read_RetrieveItemFromArrayList()
        {
            ArrayList list = new ArrayList() { "A", "B", "C" };
            var item = list[1];
            Assert.AreEqual("B", item);
        }

        [TestMethod]
        public void Update_ModifyItemInArrayList()
        {
            ArrayList list = new ArrayList() { 10, 20, 30 };
            list[1] = 200;

            Assert.AreEqual(200, list[1]);
        }

        [TestMethod]
        public void Delete_RemoveItemFromArrayList()
        {
            ArrayList list = new ArrayList() { "One", "Two", "Three" };
            list.Remove("Two");

            CollectionAssert.DoesNotContain(list, "Two");
        }
    }
}
