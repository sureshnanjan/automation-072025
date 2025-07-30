/*******************************************************
* Copyright (c) 2025, Shreya S G
* All rights reserved.
* 
* File: BitArrayCrudTestingCases.cs
* Purpose: Unit tests for CRUD operations on ArrayList.
*******************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearcherTests
{

    /// <summary>
    /// Test cases for verifying BitArray CRUD operations.
    /// </summary>

    [TestClass]
    public class BitArrayCrudTesting
    {
        ///<summary>
        ///Create : Test that a BitArray is initialized with deafult values (false)
        ///</summary>
        
        [TestMethod]
        public void Create_BitArrayPDefaultValueAreFalse()
        {
            //Arrange & Act
            BitArray bits = new BitArray(5);

            //Assert
            foreach(bool bit in bits)
                Assert.IsFalse(bit,"all bits should be false by default");
        }
        ///<summary>
        ///READ : Test that Set() correctly updates a specific bit
        ///</summary>

        [TestMethod]
        public void Set_SpecificIndex_UpdateValue()
        {
            //Arrange
            BitArray bits = new BitArray(5);

            //Act
            bits.Set(2, true);

            //Assert
            Assert.IsTrue(bits[2], "Set(0 should set the bit at index 2 to true.");
        }

        ///<summary>
        ///UPDATE : TEST THAT MULTIPLE BITS CAN BE UPDATED IN
        ///</summary>
        [TestMethod]
        public void Update_MultipleBits_AreUpdatedCorrectly()
        {
            // Arrange
            BitArray bits = new BitArray(5);

            // Act
            bits[0] = true;
            bits[3] = true;

            // Assert
            Assert.IsTrue(bits[0], "Bit at index 0 should be true.");
            Assert.IsTrue(bits[3], "Bit at index 3 should be true.");
            Assert.IsFalse(bits[1], "Other bits should remain false.");
        }
        /// <summary>
        /// DELETE: Simulate deletion by resetting all bits using SetAll(false).
        /// </summary>
        [TestMethod]
        public void Delete_ResetAllBits_AllBitsAreFalse()
        {
            // Arrange
            BitArray bits = new BitArray(5, true); // Start with all true.

            // Act
            bits.SetAll(false);

            // Assert
            foreach (bool bit in bits)
                Assert.IsFalse(bit, "All bits should be false after SetAll(false).");
        }
        /// <summary>
        /// Test that SetAll(true) sets all bits to true.
        /// </summary>
        [TestMethod]
        public void SetAll_SetToTrue_AllBitsAreTrue()
        {
            // Arrange
            BitArray bits = new BitArray(5);

            // Act
            bits.SetAll(true);

            // Assert
            foreach (bool bit in bits)
                Assert.IsTrue(bit, "SetAll(true) should set all bits to true.");
        }

        /// <summary>
        /// NEGATIVE CASE: Test that accessing an invalid index throws an exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Access_InvalidIndex_ThrowsException()
        {
            // Arrange
            BitArray bits = new BitArray(5);

            // Act
            var value = bits[10]; // Invalid index.
        }


    }
}
