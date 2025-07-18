using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram
{
    /// <summary>
    /// Represents a demo user with a name and value.
    /// Implements comparison and cloning functionality.
    /// </summary>
    public class DemoUser : IComparable<DemoUser>, ICloneable
    {
        /// <summary>
        /// Gets or sets the integer value associated with the user.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Returns a string that represents the current <see cref="DemoUser"/>.
        /// </summary>
        /// <returns>A formatted string in the format "User-{Value}:{Name}".</returns>
        public override string? ToString()
        {
            return $"User-{this.Value}:{this.Name}";
        }

        /// <summary>
        /// Compares the current <see cref="DemoUser"/> instance with another <see cref="DemoUser"/> based on the name.
        /// </summary>
        /// <param name="other">The other <see cref="DemoUser"/> to compare with.</param>
        /// <returns>
        /// An integer indicating the relative order:
        /// - Less than 0 if this instance precedes <paramref name="other"/>.
        /// - 0 if they are equal.
        /// - Greater than 0 if this instance follows <paramref name="other"/>.
        /// </returns>
        public int CompareTo(DemoUser? other)
        {
            return other.Name.CompareTo(this.Name); // Note: reverse order
        }

        /// <summary>
        /// Creates a shallow copy of the current <see cref="DemoUser"/> instance.
        /// </summary>
        /// <returns>A copy of the current object.</returns>
        /// <exception cref="NotImplementedException">Thrown as the method is not implemented.</exception>
        public object Clone()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DemoUser"/> class with a specified value and name.
        /// </summary>
        /// <param name="val">The integer value of the user.</param>
        /// <param name="name">The name of the user.</param>
        public DemoUser(int val, string name)
        {
            Value = val;
            Name = name;
        }
    }
}
