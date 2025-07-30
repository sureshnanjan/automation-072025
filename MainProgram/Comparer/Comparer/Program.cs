using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearcherIcomparer
{
    public class ArraySort
    {
        public class ReverserClass : IComparer
        {
            // Call CaseInsensitiveComparer.Compare with the parameters reversed.
            int IComparer.Compare(Object x, Object y)
            {
                return ((new CaseInsensitiveComparer()).Compare(y, x));
            }
        }
    }
    internal class secondcharcterClass : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            return (x[1].CompareTo(y[1]));
        }

        // Call CaseInsensitiveComparer.Compare with the parameters reversed.

    }

}