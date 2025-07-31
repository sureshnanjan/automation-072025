using Microsoft.VisualStudio.TestTools.UnitTesting; // MSTest framework for writing test cases
using System.Collections;                          // For using Hashtable and DictionaryEntry

namespace SystemCollectionsTests
{
    [TestClass] // Marks this class as containing test methods
    public class HashtableTests
    {
        [TestMethod]
        public void Add_And_Access_Item()
        {
            Hashtable ht = new Hashtable(); // Create a new Hashtable
            ht.Add("id", 42);               // Add key "id" with value 42

            Assert.AreEqual(42, ht["id"]);  // Check if value can be accessed by key
        }

        [TestMethod]
        public void ContainsKey_IsCaseSensitiveByDefault()
        {
            Hashtable ht = new Hashtable(); // New Hashtable
            ht["Name"] = "Alice";           // Add entry with key "Name"

            // ContainsKey is case-sensitive by default, so "name" != "Name"
            Assert.IsFalse(ht.ContainsKey("name"));
        }

        [TestMethod]
        public void CaseInsensitiveHashtable_WithComparer()
        {
            // Use a case-insensitive comparer so keys like "User", "user", "USER" are treated the same
            var ht = new Hashtable(StringComparer.OrdinalIgnoreCase);
            ht["User"] = "Bob"; // Add key "User" with value "Bob"

            Assert.IsTrue(ht.ContainsKey("user"));    // Case-insensitive lookup should succeed
            Assert.AreEqual("Bob", ht["USER"]);       // Should return "Bob" even with different casing
        }

        [TestMethod]
        public void Remove_Item()
        {
            Hashtable ht = new Hashtable(); // Create Hashtable
            ht["temp"] = 1;                 // Add key "temp"

            ht.Remove("temp");              // Remove the key
            Assert.IsFalse(ht.Contains("temp")); // Should no longer contain the key
        }

        [TestMethod]
        public void Iterate_KeysAndValues()
        {
            Hashtable ht = new Hashtable(); // Create Hashtable
            ht["x"] = 1;                    // Add key "x" with value 1
            ht["y"] = 2;                    // Add key "y" with value 2

            int sum = 0; // Variable to hold sum of values

            // Iterate through the Hashtable using DictionaryEntry
            foreach (DictionaryEntry entry in ht)
            {
                sum += (int)entry.Value; // Add each value to the sum
            }

            Assert.AreEqual(3, sum); // 1 + 2 = 3
        }
    }
}
