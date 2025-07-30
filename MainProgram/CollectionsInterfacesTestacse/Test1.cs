using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace CollectionTests
{
    [TestClass]
    public class ArrayListTests
    {
        [TestMethod]
        public void Create_AddItemsToArrayList_ShouldContainItems() //Create
        {
            // Arrange
            ArrayList list = new ArrayList();

            // Act
            list.Add("Apple");
            list.Add("Banana");

            // Assert
            Assert.AreEqual(2, list.Count);
            CollectionAssert.Contains(list, "Apple");
            CollectionAssert.Contains(list, "Banana");
        }

        [TestMethod]
        public void Read_GetItemByIndex_ShouldReturnCorrectItem() //Read
        {
            // Arrange
            ArrayList list = new ArrayList { "Apple", "Banana" };

            // Act
            var result = list[1];

            // Assert
            Assert.AreEqual("Banana", result);
        }

        [TestMethod]
        public void Update_ModifyItemAtIndex_ShouldReflectUpdatedValue() //Update
        {
            // Arrange
            ArrayList list = new ArrayList { "Apple", "Banana" };

            // Act
            list[1] = "Blueberry";

            // Assert
            Assert.AreEqual("Blueberry", list[1]);
        }

        [TestMethod]
        public void Delete_RemoveItem_ShouldReduceCount()//delete
        {
            // Arrange
            ArrayList list = new ArrayList { "Apple", "Banana" };

            // Act
            list.Remove("Banana");

            // Assert
            Assert.AreEqual(1, list.Count);
            CollectionAssert.DoesNotContain(list, "Banana");
        }
        [TestMethod]
        public void ReadItems_ShouldReturnExpectedValues() //enumerable
        {
            // Arrange
            ArrayList fruits = new ArrayList { "Orange", "Grapes", "Kiwi" };

            // Act
            string[] expected = { "Orange", "Grapes", "Kiwi" };
            string[] actual = new string[fruits.Count];
            for (int i = 0; i < fruits.Count; i++)
            {
                actual[i] = fruits[i].ToString();
            }

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}