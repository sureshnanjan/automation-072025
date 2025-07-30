using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Category
    {
        Pet[] pets;

        public string Name { get; set; }
        private int myVar;
        private float myFloatVar;

        public Category(string name, int myVar)
        {
            Name = name;
            this.myVar = myVar;
        }

        public int MyProperty
        {
            get { myVar = 10; return myVar; }
            set { myVar = value; }
        }

        public float MyFloatVar { get => myFloatVar; set => myFloatVar = value; }

        public override string? ToString()
        {
            return $"{this.Name}-{this.MyProperty}";
        }

        public void DoSomeThing()
        {
            // Signature
        }

        public int addTwoNumbers(int first, int second)
        {
            return first + second;
        }

        public double addTwoNumbers(double first, double second)
        {
            return first + second;
        }


    }
}