// Import necessary namespaces
using Microsoft.VisualStudio.TestTools.UnitTesting;  // MSTest framework for unit testing
using System;                                       // Basic system classes
using System.Collections;                           // Non-generic IEnumerable
using System.Collections.Generic;                   // Generic collections like List<T>
using System.Linq;                                  // LINQ for queries

namespace CollectionTests
{
    // ----------------------------
    // Product entity class
    // ----------------------------
    public class Product
    {
        public int ProductId { get; set; }     // Unique ID for each product
        public string Name { get; set; }       // Product name
        public double Price { get; set; }      // Product price
    }

    // ----------------------------
    // ProductCollection implementing IEnumerable<Product>
    // ----------------------------
    public class ProductCollection : IEnumerable<Product>
    {
        // Internal list to hold products
        private readonly List<Product> _products = new List<Product>();

        // CREATE: Add a new product
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        // READ: Retrieve a product by ID
        public Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.ProductId == id);
        }

        // UPDATE: Update product price by ID
        public bool UpdateProductPrice(int id, double newPrice)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            if (product != null)
            {
                product.Price = newPrice;
                return true;
            }
            return false;
        }

        // DELETE: Remove product by ID
        public bool DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            if (product != null)
            {
                _products.Remove(product);
                return true;
            }
            return false;
        }

        // Enable IEnumerable (foreach support)
        public IEnumerator<Product> GetEnumerator()
        {
            return _products.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
    }
    }
