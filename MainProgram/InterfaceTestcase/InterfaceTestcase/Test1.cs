using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterfaceDemo; // Replace with your actual namespace

namespace InterfaceTests
{
    [TestClass]
    public class InterfaceUnitTests
    {
        [TestMethod]
        public void ICollectionTest()
        {
            MyCollection collection = new MyCollection();
            Assert.AreEqual(3, collection.Count);
        }

        [TestMethod]
        public void IComparerTest()
        {
            ArrayList numbers = new ArrayList { 5, 1, 3 };
            numbers.Sort(new ReverseComparer());
            CollectionAssert.AreEqual(new ArrayList { 5, 3, 1 }, numbers);
        }

        [TestMethod]
        public void IDictionaryTest()
        {
            IDictionary dict = new Hashtable();
            dict["Name"] = "Arpita";
            dict["Role"] = "Developer";

            Assert.AreEqual("Developer", dict["Role"]);
        }

        [TestMethod]
        public void IEnumerableTest()
        {
            MyEnumerable list = new MyEnumerable();
            int count = 0;

            foreach (var item in list)
                count++;

            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void IEqualityComparerTest()
        {
            Hashtable table = new Hashtable(new CaseInsensitiveComparer());
            table["fruit"] = "apple";

            Assert.AreEqual("apple", table["FRUIT"]);
        }

        [TestMethod]
        public void IHashCodeProviderTest()
        {
            MyHashCodeProvider hashProvider = new MyHashCodeProvider();
            int hash = hashProvider.GetHashCode("abc"); // 3*31 = 93
            Assert.AreEqual(93, hash);
        }

        [TestMethod]
        public void IListTest()
        {
            IList items = new ArrayList { "X", "Y", "Z" };
            Assert.AreEqual("Y", items[1]);
        }

        [TestMethod]
        public void IStructuralComparableTest()
        {
            var tuple1 = Tuple.Create(1, 2);
            var tuple2 = Tuple.Create(1, 3);

            IStructuralComparable sc = tuple1;
            Assert.IsTrue(sc.CompareTo(tuple2, Comparer<object>.Default) < 0);
        }

        [TestMethod]
        public void IStructuralEquatableTest()
        {
            var tuple1 = Tuple.Create("Hello", "World");
            var tuple2 = Tuple.Create("hello", "world");

            IStructuralEquatable eq = tuple1;
            Assert.IsTrue(eq.Equals(tuple2, StringComparer.OrdinalIgnoreCase));
        }
    }
}
