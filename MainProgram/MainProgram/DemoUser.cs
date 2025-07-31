//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MainProgram
//{

//    // Fixed duplicate and conflicting class declarations
//    public class DemoUser : IComparable<DemoUser>, ICloneable, IComparable
//    {
//        public int Value { get; set; } // Property for Value
//        public string Name { get; set; } // Property for Name

//        public override string? ToString()
//        {
//            return $"User-{this.Value}:{this.Name}";
//        }

//        public int CompareTo(DemoUser? other)
//        {
//            if (other == null) return 1; // Handle null case
//            return this.Name.CompareTo(other.Name);
//        }

//        public object Clone()
//        {
//            return new DemoUser(this.Value, this.Name); // Implemented Clone method
//        }

//        public int CompareTo(object? obj)
//        {
//            if (obj is DemoUser otherUser)
//            {
//                return CompareTo((DemoUser?)otherUser); // Explicitly call the strongly-typed CompareTo
//            }
//            throw new ArgumentException("Object is not a DemoUser");
//        }

//        public DemoUser(int val, string name)
//        {
//            Value = val;
//            Name = name;
//        }
//    }
//    public class DemoUser: IComparable<DemoUser>, ICloneable;

//    public class DemoUser: IComparable<DemoUser>, ICloneable, IComparable

//    {
//        public int Value { get; set; }
//        public string Name { get; set; }

//        public override string? ToString()
//        {

//            return $"User-{this.Value}:{this.Name}";
//        }

//        public int CompareTo(DemoUser? other)
//        {

//            return this.Name.CompareTo(other.Name
//                );

//            return other.Name.CompareTo(this.Name);

//            return other.Name.CompareTo(this.Name);

//        }

//        public object Clone()
//        {
//            throw new NotImplementedException();

//        }

//        public int CompareTo(object? obj)
//        {
//            throw new NotImplementedException();
//        }

//#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
//        public DemoUser(int val, string name)
//#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
//        {
//            Value = val;
//            Name = name;
//        }
//    }
//}
