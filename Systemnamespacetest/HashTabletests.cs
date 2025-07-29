using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace SystemCollectionsTests
{
    [TestClass]
    public class HashtableTests
    {
        [TestMethod]
        public void Add_And_Access_Item()
        {
            Hashtable ht = new Hashtable();
            ht.Add("id", 42);
            Assert.AreEqual(42, ht["id"]);
        }

        [TestMethod]
        public void ContainsKey_IsCaseSensitiveByDefault()
        {
            Hashtable ht = new Hashtable();
            ht["Name"] = "Alice";
            Assert.IsFalse(ht.ContainsKey("name"));
        }

        [TestMethod]
        public void CaseInsensitiveHashtable_WithComparer()
        {
            // Fix: Use a case-insensitive comparer with Hashtable by passing a custom IEqualityComparer
            var ht = new Hashtable(StringComparer.OrdinalIgnoreCase);
            ht["User"] = "Bob";
            Assert.IsTrue(ht.ContainsKey("user"));
            Assert.AreEqual("Bob", ht["USER"]);
        }

        [TestMethod]
        public void Remove_Item()
        {
            Hashtable ht = new Hashtable();
            ht["temp"] = 1;
            ht.Remove("temp");
            Assert.IsFalse(ht.Contains("temp"));
        }

        [TestMethod]
        public void Iterate_KeysAndValues()
        {
            Hashtable ht = new Hashtable();
            ht["x"] = 1;
            ht["y"] = 2;

            int sum = 0;
            foreach (DictionaryEntry entry in ht)
            {
                sum += (int)entry.Value;
            }

            Assert.AreEqual(3, sum);
        }
    }
}
