using System;

namespace MainProgram
{
    public class DemoUser : IComparable<DemoUser>, ICloneable
    {
        public int Value { get; set; }
        public string Name { get; set; }

        public DemoUser(int val, string name)
        {
            Value = val;
            Name = name;
        }

        public override string? ToString()
        {
            return $"User-{this.Value}:{this.Name}";
        }

        public int CompareTo(DemoUser? other)
        {
            if (other == null) return 1;
            return this.Name.CompareTo(other.Name);
        }

        public object Clone()
        {
            return new DemoUser(this.Value, this.Name);
        }
    }
}
