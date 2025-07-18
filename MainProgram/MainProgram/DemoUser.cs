using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram
{
    public class DemoUser: IComparable<DemoUser>, ICloneable
    {
        public int Value { get; set; }
        public string Name { get; set; }

        public override string? ToString()
        {

            return $"User-{this.Value}:{this.Name}";
        }

        public int CompareTo(DemoUser? other)
        {
            return other.Name.CompareTo(this.Name);
        }

        public object Clone()
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
