//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Models
//{
//    public class Category
//    {
//        Pet[] pets;

//        public string Name { get; set; }
//        private int myVar;
//        private float myFloatVar;

//        public Category(string name, int myVar)
//        {
//            Name = name;
//            this.myVar = myVar;
//        }

//        public int MyProperty
//        {
//            get { myVar = 10;  return myVar; }
//            set { myVar = value; }
//        }

//        public float MyFloatVar { get => myFloatVar; set => myFloatVar = value; }

//        public override string? ToString()
//        {
//            return $"{this.Name}-{this.MyProperty}";
//        }
//    }
//}


/// documentation starts here ///

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Represents a category that may contain a set of pets.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Array to hold pets related to this category (not used currently).
        /// </summary>
        private Pet[] pets;

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string Name { get; set; }

        private int myVar;
        private float myFloatVar;

        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class with the specified name and identifier.
        /// </summary>
        /// <param name="name">Name of the category.</param>
        /// <param name="myVar">An integer value associated with the category (ID or status).</param>
        public Category(string name, int myVar)
        {
            Name = name;
            this.myVar = myVar;
        }

        /// <summary>
        /// Gets or sets the integer property related to the category.
        /// Note: The getter forcibly sets the value to 10 before returning it.
        /// </summary>
        public int MyProperty
        {
            get { myVar = 10; return myVar; }  // Always returns 10 regardless of the original value
            set { myVar = value; }
        }

        /// <summary>
        /// Gets or sets a floating-point property (purpose undefined).
        /// </summary>
        public float MyFloatVar
        {
            get => myFloatVar;
            set => myFloatVar = value;
        }

        /// <summary>
        /// Returns a string that represents the current category.
        /// </summary>
        /// <returns>A string in the format "Name-MyProperty".</returns>
        public override string? ToString()
        {
            return $"{this.Name}-{this.MyProperty}";
        }

        public void DoSomeThing() {
            // Signature
        }

        public int addTwoNumbers(int first, int second) {
            return first + second;
        }

        public double addTwoNumbers(double first, double second)
        {
            return first + second;
        }

        
    }
}

