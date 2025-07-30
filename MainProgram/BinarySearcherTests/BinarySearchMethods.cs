using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearcherTests
{
    public class DescComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return y.CompareTo(x);
        }
    }
    [TestClass]
    public class BinarySearchMethods
    {
        [TestMethod]
        public void BinarySearchArrayObject()
        {
            string[] fruits = { "Apple", "Cherry", "Guava", "Banana", "Mango" };
            Array.Sort(fruits);
            int index = Array.BinarySearch(fruits, "Cherry");
            Assert.AreEqual(2, index);
        }
        [TestMethod]
        public void BinarySearchArrayObjIntNotFound()
        {
            int[] numbers = { 1, 4, 2, 7, 5, 9 };
            Array.Sort(numbers);
            int index = Array.BinarySearch(numbers, 3);
            Assert.AreEqual(~2, index); // 3 should be inserted at index 2
        }

        // 2. BinarySearch(Array, Object, IComparer)

        [TestMethod]
        public void BinarySearchArrayObjIComparer()
        {
            string[] languages = { "Java", "Python", "C", "Dotnet" };
            Array.Sort(languages, new DescComparer());
            int index = Array.BinarySearch(languages, "C", new DescComparer());
            Assert.AreEqual(3, index);

        }

        // 3. BinarySearch(Array, Int32, Int32, Object)
        [TestMethod]
        public void BinarySearchArrayRange()
        {
            int[] num = { 1, 5, 7, 3, 8, 2 };
            Array.Sort(num); //SortedArray = 1,2,3,5,7,8
            int ElementToFind = Array.BinarySearch(num, 2, 4, 7); 
            Assert.AreEqual(4, ElementToFind);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BinarySearch_ArrayRange_OutOfBounds_ThrowsArgumentException()
        {
            int[] numbers = { 1, 5, 7, 3, 8, 2 };
            Array.Sort(numbers); // Sorted array: {1, 2, 3, 5, 7, 8}

            // Act - this will throw because 4 (startIndex) + 3 (length) = 7 > array.Length (6)
            int index = Array.BinarySearch(numbers, 4, 3, 5);

            Assert.Fail("Expected ArgumentException was not thrown.");
        }
        //4.BinarySearch(Array, Int32, Int32, Object, IComparer)
        [TestMethod]
        public void BinarySearch_Array_Range_IComparer()
        {
            string[] Alphabets = { "F", "E", "D", "C", "B", "A" };
            Array.Sort(Alphabets, 1, 4, new DescComparer()); // sort index 1-4
            int result = Array.BinarySearch(Alphabets, 1, 4, "C", new DescComparer());
            Assert.AreEqual(3, result);
        }
        // 5. BinarySearch<T>(T[], T)
        [TestMethod]
        public void BinarySearch_Generic_Default()
        {
            double[] marks = { 45.5, 67.5, 89.0, 92.5 };
            int index = Array.BinarySearch<double>(marks, 89.0);
            Assert.AreEqual(2, index);
        }

        // 6. BinarySearch<T>(T[], T, IComparer<T>)
        [TestMethod]
        public void BinarySearch_Generic_IComparer()
        {
            int[] scores = { 90, 80, 70, 60 };
            Array.Sort(scores, new DescIntComparer()); // Descending
            int index = Array.BinarySearch<int>(scores, 80, new DescIntComparer());
            Assert.AreEqual(1, index); // Sorted: 90, 80, 70, 60
        }
        public class DescIntComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return y.CompareTo(x); 
            }
        }
        [TestMethod]
        public void BinarySearch_Generic_Range_IComparer()
        {
            int[] temperatures = { 45, 40, 35, 30, 25, 20 };
            Array.Sort(temperatures, 1, 4, new DescIntComparer()); // sort part of array
            int index = Array.BinarySearch<int>(temperatures, 1, 4, 35, new DescIntComparer());
            Assert.AreEqual(2, index);
        }
    }


}
