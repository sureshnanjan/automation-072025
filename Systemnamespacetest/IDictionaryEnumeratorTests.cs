using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace SystemCollectionsTests
{
    [TestClass]
    public class IDictionaryEnumeratorTests
    {
        [TestMethod]
        public void Enumerator_IteratesKeysAndValuesCorrectly()
        {
            Hashtable table = new Hashtable
            {
                ["id"] = 101,
                ["name"] = "Alice"
            };

            IDictionaryEnumerator enumerator = table.GetEnumerator();
            int count = 0;

            while (enumerator.MoveNext())
            {
                Assert.IsNotNull(enumerator.Key);
                Assert.IsNotNull(enumerator.Value);
                count++;
            }

            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void Enumerator_ReturnsEntry()
        {
            Hashtable table = new Hashtable { ["x"] = "y" };
            IDictionaryEnumerator enumerator = table.GetEnumerator();
            enumerator.MoveNext();
            DictionaryEntry entry = enumerator.Entry;

            Assert.AreEqual("x", entry.Key);
            Assert.AreEqual("y", entry.Value);
        }
    }
}
