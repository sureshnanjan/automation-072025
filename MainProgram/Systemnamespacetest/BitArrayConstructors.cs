using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace BitArrayConstructorTests
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void Test_ConstructorFromBooleanArray()
        {
            bool[] source = { true, false, true };
            BitArray bits = new BitArray(source);

            Assert.AreEqual(3, bits.Length);
            Assert.IsTrue(bits[0]);
            Assert.IsFalse(bits[1]);
            Assert.IsTrue(bits[2]);
        }

        [TestMethod]
        public void Test_ConstructorFromByteArray()
        {
            byte[] source = { 0b00001111 }; // Only lowest 8 bits
            BitArray bits = new BitArray(source);

            Assert.AreEqual(8, bits.Length);
            for (int i = 0; i < 4; i++)
                Assert.IsTrue(bits[i]);
            for (int i = 4; i < 8; i++)
                Assert.IsFalse(bits[i]);
        }

        [TestMethod]
        public void Test_ConstructorFromInt32Array()
        {
            int[] source = { 5 }; // 000...0101
            BitArray bits = new BitArray(source);

            Assert.AreEqual(32, bits.Length);
            Assert.IsTrue(bits[0]);
            Assert.IsFalse(bits[1]);
            Assert.IsTrue(bits[2]);
            for (int i = 3; i < 32; i++)
                Assert.IsFalse(bits[i]);
        }

        [TestMethod]
        public void Test_ConstructorWithLength()
        {
            int length = 10;
            BitArray bits = new BitArray(length);

            Assert.AreEqual(10, bits.Length);
            foreach (bool bit in bits)
                Assert.IsFalse(bit);
        }

        [TestMethod]
        public void Test_ConstructorWithLengthAndDefaultValue()
        {
            BitArray bits = new BitArray(5, true);

            Assert.AreEqual(5, bits.Length);
            foreach (bool bit in bits)
                Assert.IsTrue(bit);
        }

        [TestMethod]
        public void Test_ConstructorFromBitArray()
        {
            BitArray original = new BitArray(new[] { true, false, true });
            BitArray copy = new BitArray(original);

            Assert.AreEqual(3, copy.Length);
            for (int i = 0; i < 3; i++)
                Assert.AreEqual(original[i], copy[i]);
        }
    }
}
