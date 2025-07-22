using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram
{
<<<<<<< HEAD
    public class DemoUser: IComparable<DemoUser>, ICloneable
=======
    public class DemoUser: IComparable<DemoUser>
>>>>>>> 36b0f0fc745403c37246e152e1024826ba098ee4
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
            return other.Name.CompareTo(this.Name);
        }

        public object Clone()
        {
            throw new NotImplementedException();
=======
            return this.Name.CompareTo(other.Name);
>>>>>>> 36b0f0fc745403c37246e152e1024826ba098ee4
        }

        public DemoUser(int val, string name)
        {
            Value = val;
            Name = name;
        }
    }
}
