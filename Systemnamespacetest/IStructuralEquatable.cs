using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace SystemCollectionsTests
{
    public class CaseInsensitiveTupleComparer : IEqualityComparer
    {
        public new bool Equals(object x, object y)
        {
            var t1 = x as Tuple<string, int>;
            var t2 = y as Tuple<string, int>;
            if (t1 == null || t2 == null) return false;

            return string.Equals(t1.Item1, t2.Item1, StringComparison.OrdinalIgnoreCase)
                   && t1.Item2 == t2.Item2;
        }

        public int GetHashCode(object obj)
        {
            var t = obj as Tuple<string, int>;
            if (t == null) return 0;
            return t.Item1.ToLowerInvariant().GetHashCode() ^ t.Item2.GetHashCode();
        }
    }

    [TestClass]
    public class IStructuralEquatable_TupleArrayTests
    {
        [TestMethod]
        public void ArraysOfTuples_EqualWithCustomComparer()
        {
            var arr1 = new[] { Tuple.Create("Alice", 1), Tuple.Create("Bob", 2) };
            var arr2 = new[] { Tuple.Create("ALICE", 1), Tuple.Create("bob", 2) };

            IStructuralEquatable se1 = arr1;
            Assert.IsTrue(se1.Equals(arr2, new CaseInsensitiveTupleComparer()));
        }

        [TestMethod]
        public void ArraysOfTuples_NotEqualIfMismatch()
        {
            var arr1 = new[] { Tuple.Create("Tom", 3) };
            var arr2 = new[] { Tuple.Create("Jerry", 3) };

            IStructuralEquatable se1 = arr1;
            Assert.IsFalse(se1.Equals(arr2, new CaseInsensitiveTupleComparer()));
        }
    }
}
