using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CrudOperations
{

    [TestClass]
    public class ArrayListCrudOperations
    {
        [TestMethod] //Adding single element
        public void AddOperation()
        {
            
            ArrayList fruits = new ArrayList();
            fruits.Add("Apple");

            Assert.AreEqual(1, fruits.Count); // Checking the count after adding a single element
            Assert.AreEqual("Apple", fruits[0]);
        }


        [TestMethod] //Adding multiple elements using AddRange
        public void AddRangeOperation()
        {
            // Arrange: Create a new ArrayList
            ArrayList fruits = new ArrayList();
            // Act Add multiple items at once using AddRange
            fruits.AddRange(new string[] { "Banana", "Cherry", "Mango"});
            // Assert
            Assert.AreEqual(3, fruits.Count);
            CollectionAssert.DoesNotContain(fruits, "Dates"); // Confirms that Dates is not in the list
            CollectionAssert.Contains(fruits, "Banana");      // Verifies weather banana is in the list or not
        }

        [TestMethod]
        public void ReadOperation()
        {
            ArrayList Days = new ArrayList() { "Mon", "Tues", "Wednes", "Thrus", "Fri", "Sat"};
            string week = (string)Days[1];
            string index = (string)Days[0];
            Assert.AreEqual("Tues", week);

        }


        [TestMethod]
        public void Read_Contains()
        {
            ArrayList list = new ArrayList() { "Cat", "Dog", "Elephant" };

            Assert.IsTrue(list.Contains("Dog"));         // Positive case
            Assert.IsFalse(list.Contains("Tiger"));      // Negative case but still testcase pass 
        }

        [TestMethod]
        public void Read_IndexOf()  //Finding Index of a value
        {
            ArrayList list = new ArrayList() { 10, 20, 30, 20 };
            int index = list.IndexOf(20);

            Assert.AreEqual(1, index);                   // Returns first occurrence in that array
        }
        //Updating the element
        [TestMethod]
        public void Update_Element()
        {
            ArrayList list = new ArrayList() { 1, 2, 5, 3, 7};
            list[2] = 6;
            Assert.AreEqual(6, list[2]);

        }
        //Trying to update a different type
        [TestMethod]
        public void Update_DifferentType()
        {
            ArrayList list = new ArrayList() { 1, 2, 3 };
            list[1] = "Hello";                           // Allowed, but inconsistent types

            Assert.AreEqual("Hello", list[1]);
        }
        //Deleting the element
        [TestMethod]
        public void Deleting_Element()
        {
            ArrayList list = new ArrayList() { "Red", "Green", "Blue" };
            list.Remove("Green");

            Assert.IsFalse(list.Contains("Green"));
        }
        // DELETE: Remove at index
        [TestMethod]
        public void Test_Delete_RemoveAt()
        {
            ArrayList list = new ArrayList() { 100, 200, 300 };
            list.RemoveAt(1);

            Assert.AreEqual(2, list.Count); //checking count after deleting
            Assert.AreEqual(300, list[1]);
        }

        // DELETE: Clear entire list
        [TestMethod]
        public void Test_Delete_Clear()
        {
            ArrayList list = new ArrayList() { 1, 2, 3 };
            list.Clear();  //Removes all elements from the Arraylist

            Assert.AreEqual(0, list.Count);
            CollectionAssert.AllItemsAreUnique(list);    // Should be empty
        }


        //Using Enumerator
        [TestMethod]
        public void Test_ArrayListForeach()
        {
            // Arrange
            ArrayList colors = new ArrayList() { "Red", "Green", "Blue" };

            // Act
            ArrayList collected = new ArrayList();
            foreach (var item in colors)
            {
                collected.Add(item);
            }

           // IEnumerator enumerator = colors.GetEnumerator();

            // Manually iterate over the collection
            //while (enumerator.MoveNext())
            //{
            //    collected.Add(enumerator.Current);
           // }


            // Assert
            Assert.AreEqual(3, collected.Count);
            Assert.AreEqual("Red", collected[0]);
            Assert.AreEqual("Green", collected[1]);
            Assert.AreEqual("Blue", collected[2]);
        }
    }

}