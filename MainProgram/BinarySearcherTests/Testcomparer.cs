using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BinarySearchStringExamples
{
    [TestClass]
    public class StringBinarySearchTests
    {
        // 1. Array.BinarySearch(Array, Object)
        [TestMethod]
        public void BinarySearch_Object_Found()
        {
            string[] fruits = { "Apple", "Banana", "Mango" };
            int index = Array.BinarySearch(fruits, "Banana");
            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void BinarySearch_Object_NotFound()
        {
            string[] fruits = { "Apple", "Banana", "Mango" };
            int index = Array.BinarySearch(fruits, "Orange");
            Assert.IsTrue(index < 0);
        }

        // 2. Array.BinarySearch(Array, int, int, Object)
        [TestMethod]
        public void BinarySearch_ObjectPartial_Found()
        {
            string[] cities = { "Delhi", "Kolkata", "Mumbai", "Pune", "Ranchi" };
            int index = Array.BinarySearch(cities, 1, 3, "Mumbai"); // Kolkata, Mumbai, Pune
            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void BinarySearch_ObjectPartial_NotFound()
        {
            string[] cities = { "Delhi", "Kolkata", "Mumbai", "Pune", "Ranchi" };
            int index = Array.BinarySearch(cities, 1, 3, "Chennai");
            Assert.IsTrue(index < 0);
        }

        // 3. Array.BinarySearch<T>(T[], T)
        [TestMethod]
        public void BinarySearch_Generic_Found()
        {
            string[] days = { "Friday", "Monday", "Wednesday" };
            Array.Sort(days); // Must be sorted: Friday, Monday, Wednesday
            int index = Array.BinarySearch(days, "Monday");
            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void BinarySearch_Generic_NotFound()
        {
            string[] days = { "Friday", "Monday", "Wednesday" };
            Array.Sort(days);
            int index = Array.BinarySearch(days, "Sunday");
            Assert.IsTrue(index < 0);
        }

        // 4. Array.BinarySearch(Array, Object, IComparer)
        [TestMethod]
        public void BinarySearch_NonGenericComparer_Found()
        {
            string[] vehicles = { "bike", "Car", "Train" };
            Array.Sort(vehicles, StringComparer.OrdinalIgnoreCase);
            int index = Array.BinarySearch(vehicles, "CAR", StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void BinarySearch_NonGenericComparer_NotFound()
        {
            string[] vehicles = { "bike", "Car", "Train" };
            Array.Sort(vehicles, StringComparer.OrdinalIgnoreCase);
            int index = Array.BinarySearch(vehicles, "bus", StringComparer.OrdinalIgnoreCase);
            Assert.IsTrue(index < 0);
        }

        // 5. Array.BinarySearch<T>(T[], T, IComparer<T>)
        [TestMethod]
        public void BinarySearch_GenericComparer_Found()
        {
            string[] animals = { "Cat", "dog", "Elephant" };
            Array.Sort(animals, StringComparer.OrdinalIgnoreCase);
            int index = Array.BinarySearch(animals, "DOG", StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void BinarySearch_GenericComparer_NotFound()
        {
            string[] animals = { "Cat", "dog", "Elephant" };
            Array.Sort(animals, StringComparer.OrdinalIgnoreCase);
            int index = Array.BinarySearch(animals, "Fox", StringComparer.OrdinalIgnoreCase);
            Assert.IsTrue(index < 0);
        }

        // 6. Array.BinarySearch<T>(T[], int, int, T)
        [TestMethod]
        public void BinarySearch_GenericPartial_Found()
        {
            string[] tools = { "Brush", "Hammer", "Saw", "Screwdriver", "Wrench" };
            Array.Sort(tools); // Brush, Hammer, Saw, Screwdriver, Wrench
            int index = Array.BinarySearch(tools, 1, 3, "Screwdriver"); // Hammer to Screwdriver
            Assert.AreEqual(3, index);
        }

        [TestMethod]
        public void BinarySearch_GenericPartial_NotFound()
        {
            string[] tools = { "Brush", "Hammer", "Saw", "Screwdriver", "Wrench" };
            Array.Sort(tools);
            int index = Array.BinarySearch(tools, 1, 3, "Drill");
            Assert.IsTrue(index < 0);
        }

        // 7. Array.BinarySearch<T>(T[], int, int, T, IComparer<T>)
        [TestMethod]
        public void BinarySearch_GenericPartialComparer_Found()
        {
            string[] codes = { "alpha", "Beta", "gamma", "Theta", "Zeta" };
            Array.Sort(codes, StringComparer.OrdinalIgnoreCase);
            int index = Array.BinarySearch(codes, 1, 3, "GAMMA", StringComparer.OrdinalIgnoreCase); // Beta to Theta
            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void BinarySearch_GenericPartialComparer_NotFound()
        {
            string[] codes = { "alpha", "Beta", "gamma", "Theta", "Zeta" };
            Array.Sort(codes, StringComparer.OrdinalIgnoreCase);
            int index = Array.BinarySearch(codes, 1, 3, "OMEGA", StringComparer.OrdinalIgnoreCase);
            Assert.IsTrue(index < 0);
        }
    }
}
