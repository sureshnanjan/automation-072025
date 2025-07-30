
// Filename: EShopCrudOperationTesting.cs
// Author: Siva Sree

using System;
using System.Collections;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EShop
{
    public class Cart
    {
        private Stack stack = new Stack();

        // CREATE: Add product to the stack
        public void AddProduct(string product)
        {
            stack.Push(product);
        }

        // READ: View the top product without removing
        public string ViewTopProduct()
        {
            if (stack.Count == 0)
                throw new InvalidOperationException("Cart is empty.");
            return (string)stack.Peek();
        }

        // UPDATE: Replace the top product
        public void UpdateTopProduct(string newProduct)
        {
            if (stack.Count == 0)
                throw new InvalidOperationException("Cart is empty. Cannot update.");

            stack.Pop();
            stack.Push(newProduct);
        }

        // DELETE: Remove top product
        public void RemoveTopProduct()
        {
            if (stack.Count == 0)
                throw new InvalidOperationException("Cart is empty. Cannot delete.");
            stack.Pop();
        }

        // ENUMERATE: Return all products (IEnumerable)
        public IEnumerable GetAllProducts()
        {
            return stack;
        }
    }

    [TestClass]
    public class CartTests
    {
        // CREATE Tests
        [TestMethod]
        public void TestAddProduct_Pass()
        {
            Cart cart = new Cart();
            cart.AddProduct("Phone");
            Assert.AreEqual("Phone", cart.ViewTopProduct());
        }

        [TestMethod]
        public void TestAddProduct_Fail()
        {
            Cart cart = new Cart();
            cart.AddProduct("Tablet");
            Assert.AreNotEqual("Laptop", cart.ViewTopProduct()); // Fails if logic wrong
        }

        [TestMethod]
        public void TestAddBlankSpaceProduct()
        {
            Cart cart = new Cart();
            cart.AddProduct(" "); // adding a single space
            Assert.AreEqual(" ", cart.ViewTopProduct()); // still valid — stack accepts any string
        }

        [TestMethod]
        public void TestAddProduct_BlankInput_Fail()
        {
            // Arrange
            Cart cart = new Cart();

            // Act
            cart.AddProduct("   "); // whitespace

            // Assert
            // FAIL: No exception is thrown, but one should be!
            string topItem = cart.ViewTopProduct();
            Assert.AreNotEqual("   ", topItem, "Blank item should not be allowed, but was added.");
        }


        // READ Tests
        [TestMethod]
        public void TestViewTopProduct_Pass()
        {
            Cart cart = new Cart();
            cart.AddProduct("Shoes");
            Assert.AreEqual("Shoes", cart.ViewTopProduct());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestViewTopProduct_Fail_EmptyCart()
        {
            Cart cart = new Cart();
            string top = cart.ViewTopProduct(); // Should throw
        }

        // UPDATE Tests
        [TestMethod]
        public void TestUpdateTopProduct_Pass()
        {
            Cart cart = new Cart();
            cart.AddProduct("Book");
            cart.UpdateTopProduct("Notebook");
            Assert.AreEqual("Notebook", cart.ViewTopProduct());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestUpdateTopProduct_Fail_EmptyCart()
        {
            Cart cart = new Cart();
            cart.UpdateTopProduct("Pen"); // Should throw
        }

        // DELETE Tests
        [TestMethod]
        public void TestRemoveTopProduct_Pass()
        {
            Cart cart = new Cart();
            cart.AddProduct("Headphones");
            cart.RemoveTopProduct();
            Assert.ThrowsException<InvalidOperationException>(() => cart.ViewTopProduct());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRemoveTopProduct_Fail_EmptyCart()
        {
            Cart cart = new Cart();
            cart.RemoveTopProduct(); // Should throw
        }

        // ENUMERATE Tests
        [TestMethod]
        public void TestEnumerateCart_Pass()
        {
            Cart cart = new Cart();
            cart.AddProduct("Keyboard");
            cart.AddProduct("Mouse");

            string actual = string.Join(",", cart.GetAllProducts().Cast<string>());
            Assert.AreEqual("Mouse,Keyboard", actual); // LIFO
        }

        [TestMethod]
        public void TestEnumerateCart_Fail()
        {
            Cart cart = new Cart();
            cart.AddProduct("A");
            cart.AddProduct("B");

            string actual = string.Join(",", cart.GetAllProducts().Cast<string>());
            Assert.AreNotEqual("A,B", actual); // Not FIFO
        }
    }
}
