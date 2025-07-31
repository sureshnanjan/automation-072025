using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace SystemCollectionsTests
{
    // Minimal derived class to test CollectionBase
    public class MyCollection : CollectionBase
    {
        public void Add(object obj) { List.Add(obj); }
        public void Remove(object obj) { List.Remove(obj); }
        public object this[int index] { get => List[index]; }
    }

    [TestClass]
    public class CollectionBaseDerivedTests
    {
        [TestMethod]
        public void AddRemoveIndexing()
        {
            MyCollection mc = new MyCollection();
            mc.Add("x");
            mc.Add("y");
            Assert.AreEqual("x", mc[0]);
            mc.Remove("x");
            Assert.AreEqual("y", mc[0]);
            Assert.AreEqual(1, mc.Count);
        }

        [TestMethod]
        public void Clear_ClearsAll()
        {
            MyCollection mc = new MyCollection();
            mc.Add(1);
            mc.Add(2);
            mc.Clear();
            Assert.AreEqual(0, mc.Count);
        }
    }
}
