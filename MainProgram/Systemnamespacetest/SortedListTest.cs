using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace SystemCollectionsTests
{
    [TestClass]
    public class SortedListTests
    {
        [TestMethod]
        public void Add_And_Indexer_And_KeysValues()
        {
            SortedList sl = new SortedList();
            sl.Add("b", 2);
            sl.Add("a", 1);
            Assert.AreEqual(1, sl["a"]);
            Assert.AreEqual(2, sl["b"]);
            CollectionAssert.AreEqual(new object[] { "a", "b" }, new ArrayList(sl.Keys));
            CollectionAssert.AreEqual(new object[] { 1, 2 }, new ArrayList(sl.Values));
        }

        [TestMethod]
        public void Remove_ByKey()
        {
            string[] strings = new[] { "x", "y" };
            SortedList sl = new SortedList();
            for (int i = 0; i < strings.Length; i++)
            {
                sl.Add(strings[i], i == 0 ? 10 : 20);
            }
            sl.Remove("x");
            Assert.IsFalse(sl.Contains("x"));
            Assert.AreEqual(1, sl.Count);
        }

        [TestMethod]
        public void IndexOfKey_NotFound()
        {
            SortedList sl = new SortedList();
            sl.Add(5, "five");
            Assert.AreEqual(-1, sl.IndexOfKey(3));
        }

        [TestMethod]
        public void GetByIndex()
        {
            SortedList sl = new SortedList();
            sl.Add("k", "K");
            sl.Add("l", "L");
            Assert.AreEqual("L", sl.GetByIndex(1));
            Assert.AreEqual("l", sl.GetKey(1));
        }
    }
}
