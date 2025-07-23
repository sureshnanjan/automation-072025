namespace BinarySearcher
{
    /// <summary>
    /// This is the implementation of a binary search algorithm.
    /// </summary>
    public class BinarySearcherImpl
    {
        /// <summary>
        /// Performs a binary search on the given array for the specified key.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public int doBinaryDearch(Array input, Object key) {
            return Array.BinarySearch(input, key);
        }

        // Code added just for Reference . Please ignore this
        public int doBinarySearch(List<int> input, int key)
        {
            int low = 0;
            int high = input.Count - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (input[mid] == key)
                {
                    return mid; // Key found
                }
                else if (input[mid] < key)
                {
                    low = mid + 1; // Search in the right half
                }
                else
                {
                    high = mid - 1; // Search in the left half
                }
            }
            return -1; // Key not found
        }

    }
}
