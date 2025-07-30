using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace ComparerTests
{
    [TestClass] // Marks this as a test class for MSTest
    public class ComparerFunctionalityTests
    {
        private Comparer _comparer; // Instance of Comparer

        [TestInitialize]
        public void Setup()
        {
            // Initialize a comparer using the current culture
            _comparer = Comparer.Default;
        }

        // ------------------- TEST 1: Compare Integers -------------------
        [TestMethod]
        public void Compare_Integers_ShouldReturnCorrectOrder()
        {
            // Act
            int result = _comparer.Compare(5, 10);

            // Assert (-1 because 5 < 10)
            Assert.AreEqual(-1, result, "Comparer should return -1 when first value is smaller.");
        }

        // ------------------- TEST 2: Compare Strings -------------------
        [TestMethod]
        public void Compare_Strings_ShouldReturnZeroForEqualValues()
        {
            // Act
            int result = _comparer.Compare("Hello", "Hello");

            // Assert (0 because both strings are equal)
            Assert.AreEqual(0, result, "Comparer should return 0 when both strings are equal.");
        }

        // ------------------- TEST 3: Compare LargerValue -------------------
        [TestMethod]
        public void Compare_LargerValue_ShouldReturnPositive()
        {
            // Act
            int result = _comparer.Compare(20, 5);

            // Assert (Positive value because 20 > 5)
            Assert.IsTrue(result > 0, "Comparer should return positive when first value is larger.");
        }

        // ------------------- TEST 4: Null Handling -------------------
        [TestMethod]
        public void Compare_NullWithValue_ShouldTreatNullAsSmaller()
        {
            // Act
            int result = _comparer.Compare(null, "A");

            // Assert (-1 because null is considered smaller)
            Assert.AreEqual(-1, result, "Null should be treated as smaller than any value.");
        }
    }
}
