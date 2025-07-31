using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace SystemCollectionsTests
{
    public class ReverseComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return Comparer.Default.Compare(y, x); // Reverse order
        }
    }

    [TestClass]
    public class IComparerTests
    {
        [TestMethod]
        public void ReverseComparer_SortsDescending()
        {
            ArrayList list = new ArrayList { 5, 2, 9, 1 };
            list.Sort(new ReverseComparer());
            CollectionAssert.AreEqual(new ArrayList { 9, 5, 2, 1 }, list);
        }

        [TestMethod]
        public void ReverseComparer_CompareEquality()
        {
            var comp = new ReverseComparer();
            Assert.AreEqual(0, comp.Compare("hello", "hello"));
        }

        [TestMethod]
        public void ReverseComparer_DetectsLarger()
        {
            var comp = new ReverseComparer();
            Assert.IsTrue(comp.Compare(10, 5) < 0);  // reversed
            Assert.IsTrue(comp.Compare(5, 10) > 0);  // reversed
        }
    }
}
