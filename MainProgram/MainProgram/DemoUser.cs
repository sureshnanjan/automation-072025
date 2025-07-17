using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram
{
    public class DemoUser: IComparable<DemoUser>
    {
        public int Value { get; set; }
        public string Name { get; set; }

        public override string? ToString()
        {

            return $"User-{this.Value}:{this.Name}";
        }

        public int CompareTo(DemoUser? other)
        {
            return this.Name.CompareTo(other.Name
                );
        }

        public DemoUser(int val, string name)
        {
            Value = val;
            Name = name;
        }
    }
}
