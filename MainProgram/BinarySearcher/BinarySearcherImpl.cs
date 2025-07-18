namespace BinarySearcher
{
    public class BinarySearcherImpl
    {
        public int doBinarySearch(int[] array, int value)
        {
            int low = 0;
            int high = array.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (array[mid] == value) return mid;
                if (array[mid] < value) low = mid + 1;
                else high = mid - 1;
            }

            return ~low;  // If not found, return bitwise complement of insertion point
        }
    }
}
