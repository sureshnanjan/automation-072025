using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Represents a category with properties and utility methods.
    /// </summary>
    public class Category
    {
        private Pet[] pets;

        /// <summary>
        /// Category name.
        /// </summary>
        public string Name { get; set; }

        private int myVar;
        private float myFloatVar;

        /// <summary>
        /// Creates a new Category.
        /// </summary>
        public Category(string name, int myVar)
        {
            Name = name;
            this.myVar = myVar;
        }

        /// <summary>
        /// Integer property.
        /// </summary>
        public int MyProperty
        {
            get { myVar = 10; return myVar; }
            set { myVar = value; }
        }

        /// <summary>
        /// Float property.
        /// </summary>
        public float MyFloatVar
        {
            get => myFloatVar;
            set => myFloatVar = value;
        }

        /// <summary>
        /// Returns name and MyProperty as a string.
        /// </summary>
        public override string? ToString()
        {
            return $"{this.Name}-{this.MyProperty}";
        }

        /// <summary>
        /// Example method.
        /// </summary>
