using Microsoft.VisualStudio.TestTools.UnitTesting; // MSTest framework for unit testing
using System.Collections;                          // Needed for using ArrayList
using BinaryPractice;                              // Reference to the namespace containing the Person class

namespace BinaryPracticeTests
{
    [TestClass] // Marks this class as a test class for MSTest
    public class BinaryTestCases
    {
        // Helper method to return a sorted ArrayList of Person objects by Age
        private ArrayList GetSortedArrayList()
        {
            ArrayList list = new ArrayList
            {
                new Person { Name = "Teja", Age = 20 },
                new Person { Name = "Alice", Age = 21 },
                new Person { Name = "Charlie", Age = 19 },
                new Person { Name = "Dan", Age = 22 }
            };

            list.Sort(); // Uses Person.CompareTo to sort based on Age
            return list;
        }

        [TestMethod] // Test 1: Check if a person that exists in the list is found
        public void BinarySearch_PersonExists_ReturnsCorrectIndex()
        {
            ArrayList list = GetSortedArrayList();               // Get the sorted list
            Person find = new Person { Age = 19 };               // Create a person to search for (by age only)
            int index = list.BinarySearch(find);                 // Perform binary search
            Assert.IsTrue(index >= 0);                           // Assert that the index is valid (person found)
        }

        [TestMethod] // Test 2: Check that searching for a non-existent person returns negative index
        public void BinarySearch_PersonNotExists_ReturnsNegative()
        {
            ArrayList list = GetSortedArrayList();               // Get the sorted list
            Person find = new Person { Age = 25 };               // Age 25 is not in the list
            int index = list.BinarySearch(find);                 // Perform binary search
            Assert.IsTrue(index < 0, "Person with Age 25 does not exist, should return negative index.");
        }

        [TestMethod] // Test 3: Check that searching in an empty list returns negative index
        public void BinarySearch_EmptyList_ReturnsNegative()
        {
            ArrayList emptyList = new ArrayList();               // Create an empty list
            Person find = new Person { Age = 20 };               // Person to search
            int index = emptyList.BinarySearch(find);            // Perform binary search
            Assert.IsTrue(index < 0, "BinarySearch on empty list should return negative index.");
        }
    }
}
