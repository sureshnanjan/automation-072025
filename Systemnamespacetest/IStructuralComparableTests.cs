using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace SystemCollectionsTests
{
    public class ReverseArrayComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            // Reverse logic for descending sort
            return Comparer.Default.Compare(y, x);
        }
    }

    [TestClass]
    public class IStructuralComparableTests
    {
        [TestMethod]
        public void StructuralComparison_DefaultComparer()
        {
            int[] a = { 1, 2, 3 };
            int[] b = { 1, 2, 4 };

            IStructuralComparable compA = a;
            int result = compA.CompareTo(b, Comparer.Default);
            Assert.IsTrue(result < 0); // a < b
        }

        [TestMethod]
        public void StructuralComparison_EqualArrays()
        {
            string[] x = { "a", "b" };
            string[] y = { "a", "b" };

            IStructuralComparable cmp = x;
            Assert.AreEqual(0, cmp.CompareTo(y, Comparer.Default));
        }

        [TestMethod]
        public void StructuralComparison_WithReverseComparer()
        {
            int[] a = { 1, 2 };
            int[] b = { 3, 4 };

            IStructuralComparable cmpA = a;
            int result = cmpA.CompareTo(b, new ReverseArrayComparer());
            Assert.IsTrue(result > 0); // because of reverse order
        }
    }
}
