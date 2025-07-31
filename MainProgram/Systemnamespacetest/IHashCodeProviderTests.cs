using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace SystemCollectionsTests
{
    public class CaseInsensitiveHashCodeProvider : IHashCodeProvider
    {
        public int GetHashCode(object obj)
        {
            return obj?.ToString().ToLowerInvariant().GetHashCode() ?? 0;
        }
    }

    [TestClass]
    public class IHashCodeProviderTests
    {
        [TestMethod]
        public void HashCodeProvider_SameHashForDifferentCases()
        {
            var provider = new CaseInsensitiveHashCodeProvider();
            int hash1 = provider.GetHashCode("VALUE");
            int hash2 = provider.GetHashCode("value");
            Assert.AreEqual(hash1, hash2);
        }

        [TestMethod]
        public void HashCodeProvider_WithHashtable_WorksCaseInsensitively()
        {
            var hashtable = new Hashtable(new CaseInsensitiveHashCodeProvider(), new CaseInsensitiveComparer());
            hashtable["Name"] = "Alice";

            Assert.AreEqual("Alice", hashtable["name"]);
            Assert.IsTrue(hashtable.ContainsKey("NAME"));
        }

        [TestMethod]
        public void HashCodeProvider_DistinctObjects_ProduceDifferentHashes()
        {
            var provider = new CaseInsensitiveHashCodeProvider();
            int h1 = provider.GetHashCode("one");
            int h2 = provider.GetHashCode("two");
            Assert.AreNotEqual(h1, h2);
        }
    }
}
