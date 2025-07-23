namespace BinarySearcher
{
    public class DefiningComparer : IComparer
    {
        public int Comparer(object x, object y)
        {
            return ((int)x).CompareTo((int)y); 
        }
    }    
    public class BinarySearcherImpl
    {
        //default binary search
        public int doBinaryDearch(Array input, Object key) {
            return Array.BinarySearch(input, key);
        }
        //using BinarySearch(Array, Int32, Int32, Object, IComparer)
        public int doBinarySearchWithComparer(Array input, int startIndex, int count, object key, IComparer comparer)
        {
            return Array.BinarySearch(input, startIndex, count, key, comparer);
        }

    }
}
