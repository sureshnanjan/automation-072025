using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace ArrayListUnitTests
{
    [TestClass]
    public class ArrayListTests
    {
        [TestMethod]
        public void Test_Add()
        {
            ArrayList list = new ArrayList();
            list.Add("A");
            Assert.AreEqual("A", list[0]);
        }

        [TestMethod]
        public void Test_AddRange()
        {
            ArrayList list = new ArrayList();
            list.AddRange(new[] { "A", "B" });
            CollectionAssert.AreEqual(new[] { "A", "B" }, list);
        }

        [TestMethod]
        public void Test_BinarySearch()
        {
            ArrayList list = new ArrayList() { 1, 2, 3, 4 };
            int index = list.BinarySearch(3);
            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void Test_Clear()
        {
            ArrayList list = new ArrayList() { "X", "Y" };
            list.Clear();
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void Test_Clone()
        {
            ArrayList list = new ArrayList() { "Hello" };
            ArrayList clone = (ArrayList)list.Clone();
            Assert.AreEqual("Hello", clone[0]);
        }

        [TestMethod]
        public void Test_Contains()
        {
            ArrayList list = new ArrayList() { "Test" };
            Assert.IsTrue(list.Contains("Test"));
        }

        [TestMethod]
        public void Test_CopyTo()
        {
            ArrayList list = new ArrayList() { "a", "b" };
            string[] array = new string[2];
            list.CopyTo(array, 0);
            CollectionAssert.AreEqual(new[] { "a", "b" }, array);
        }

        [TestMethod]
        public void Test_IndexOf()
        {
            ArrayList list = new ArrayList() { "a", "b", "c" };
            int index = list.IndexOf("b");
            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void Test_Insert()
        {
            ArrayList list = new ArrayList() { "a", "c" };
            list.Insert(1, "b");
            CollectionAssert.AreEqual(new[] { "a", "b", "c" }, list);
        }

        [TestMethod]
        public void Test_Remove()
        {
            ArrayList list = new ArrayList() { "x", "y" };
            list.Remove("x");
            CollectionAssert.AreEqual(new[] { "y" }, list);
        }

        [TestMethod]
        public void Test_RemoveAt()
        {
            ArrayList list = new ArrayList() { "x", "y" };
            list.RemoveAt(0);
            CollectionAssert.AreEqual(new[] { "y" }, list);
        }

        [TestMethod]
        public void Test_Reverse()
        {
            ArrayList list = new ArrayList() { 1, 2, 3 };
            list.Reverse();
            CollectionAssert.AreEqual(new[] { 3, 2, 1 }, list);
        }

        [TestMethod]
        public void Test_Sort()
        {
            ArrayList list = new ArrayList() { 3, 1, 2 };
            list.Sort();
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, list);
        }

        [TestMethod]
        public void Test_ToArray()
        {
            ArrayList list = new ArrayList() { "x", "y" };
            object[] array = list.ToArray();
            CollectionAssert.AreEqual(new[] { "x", "y" }, array);
        }

        [TestMethod]
        public void Test_TrimToSize()
        {
            ArrayList list = new ArrayList(10);
            list.Add("data");
            list.TrimToSize();
            Assert.AreEqual(1, list.Capacity);
        }
    }
}
