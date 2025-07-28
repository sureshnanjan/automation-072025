using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram
{
<<<<<<< HEAD
<<<<<<< HEAD
    public class DemoUser: IComparable<DemoUser>
=======
    public class DemoUser: IComparable<DemoUser>, ICloneable
>>>>>>> 18c84e212202e2c7edd4701945f0a27b44c470b6
=======
    public class DemoUser: IComparable<DemoUser>, ICloneable, IComparable
>>>>>>> 10e667814f0e67d7065ec9e42fceb6d191319c20
    {
        public int Value { get; set; }
        public string Name { get; set; }

        public override string? ToString()
        {

            return $"User-{this.Value}:{this.Name}";
        }

        public int CompareTo(DemoUser? other)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            return this.Name.CompareTo(other.Name
                );
=======
            return other.Name.CompareTo(this.Nam
                e);
=======
            return other.Name.CompareTo(this.Name);
>>>>>>> 10e667814f0e67d7065ec9e42fceb6d191319c20
        }

        public object Clone()
        {
            throw new NotImplementedException();
>>>>>>> 18c84e212202e2c7edd4701945f0a27b44c470b6
        }

        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }

        public DemoUser(int val, string name)
        {
            Value = val;
            Name = name;
        }
    }
}
