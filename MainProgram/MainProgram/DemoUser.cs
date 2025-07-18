using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram
{
    /// <summary>
    /// Represents a user with a name and value.
    /// </summary>
    public class DemoUser : IComparable<DemoUser>
    {
        /// <summary>
        /// Gets or sets the user's value.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets the user's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Returns a string representation of the user.
        /// </summary>
        public override string? ToString()
        {
            return $"User-{this.Value}:{this.Name}";
        }

        /// <summary>
        /// Compares this user to another based on name.
        /// </summary>
        public int CompareTo(DemoUser? other)
        {
            return this.Name.CompareTo(other.Name);
        }

        /// <summary>
        /// Initializes a new instance of DemoUser.
        /// </summary>
        public DemoUser(int val, string name)
        {
            Value = val;
            Name = name;
        }
    }
}
