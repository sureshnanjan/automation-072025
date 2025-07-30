using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram
{
<<<<<<< HEAD
    public class DemoUser: IComparable<DemoUser>, ICloneable, IComparable
=======
    /// <summary>
    /// Represents a user with a name and value.
    /// </summary>
    public class DemoUser : IComparable<DemoUser>
>>>>>>> f6bb7fb812dedd6e4734d3837588df55f2851795
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
<<<<<<< HEAD
            return other.Name.CompareTo(this.Name);
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
=======
            return this.Name.CompareTo(other.Name);
>>>>>>> f6bb7fb812dedd6e4734d3837588df55f2851795
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
