using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace SystemCollectionsTests
{
    public class CaseInsensitiveEqualityComparer : IEqualityComparer
    {
        public new bool Equals(object x, object y)
        {
            return string.Equals(x?.ToString(), y?.ToString(), System.StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(object obj)
        {
            return obj?.ToString().ToLowerInvariant().GetHashCode() ?? 0;
        }
    }

    [TestClass]
    public class IStructuralEquatableTests
    {
        [TestMethod]
        public void Arrays_AreEqual_WithCaseInsensitiveComparer()
        {
            string[] arr1 = { "One", "Two", "Three" };
            string[] arr2 = { "one", "TWO", "three" };

            IStructuralEquatable se1 = arr1;
            Assert.IsTrue(se1.Equals(arr2, new CaseInsensitiveEqualityComparer()));
        }

        [TestMethod]
        public void Arrays_AreNotEqual_WhenDifferentContent()
        {
            string[] arr1 = { "a", "b" };
            string[] arr2 = { "a", "c" };

            IStructuralEquatable se1 = arr1;
            Assert.IsFalse(se1.Equals(arr2, new CaseInsensitiveEqualityComparer()));
        }

        [TestMethod]
        public void HashCode_IsEqual_WhenStructurallyEqual()
        {
            string[] a = { "x", "Y" };
            string[] b = { "X", "y" };

            var comparer = new CaseInsensitiveEqualityComparer();
            IStructuralEquatable sea = a;
            IStructuralEquatable seb = b;

            Assert.AreEqual(sea.GetHashCode(comparer), seb.GetHashCode(comparer));
        }
    }
}
