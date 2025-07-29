using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace SystemCollectionsTests
{
    public class ModuloEqualityComparer : IEqualityComparer
    {
        private readonly int _mod;

        public ModuloEqualityComparer(int mod)
        {
            _mod = mod;
        }

        public new bool Equals(object x, object y)
        {
            return ((int)x % _mod) == ((int)y % _mod);
        }

        public int GetHashCode(object obj)
        {
            return ((int)obj % _mod).GetHashCode();
        }
    }

    [TestClass]
    public class IEqualityComparerTests
    {
        [TestMethod]
        public void Dictionary_UsesModuloEquality()
        {
            Hashtable ht = new Hashtable(new ModuloEqualityComparer(10));
            ht[21] = "Twenty-One";
            Assert.AreEqual("Twenty-One", ht[11]); // 21 % 10 == 11 % 10
        }

        [TestMethod]
        public void Equals_ReturnsTrueForModuloMatch()
        {
            var comparer = new ModuloEqualityComparer(5);
            Assert.IsTrue(comparer.Equals(10, 15));
        }

        [TestMethod]
        public void GetHashCode_IsSameForModuloEqualValues()
        {
            var comparer = new ModuloEqualityComparer(3);
            Assert.AreEqual(comparer.GetHashCode(6), comparer.GetHashCode(9));
        }
    }
}
