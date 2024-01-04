namespace Algorithms.Sort.Algorithms
{
    /// <summary>
    /// Divide and conquer metodology on the same array
    /// Time complexity O(inputArray.length* log inputArray.length)
    /// Space complexity O(log inputArray.length)
    /// </summary>
    public static class QuickSort
    {
        public static char[] SortQuick(this char[] inputArray)
        {
            quickSort(inputArray, 0, inputArray.Length - 1);
            return inputArray;
        }

        private static void quickSort(char[] arr, int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                int pivot = partition(arr, startIndex, endIndex);
                quickSort(arr, startIndex, pivot - 1);
                quickSort(arr, pivot + 1, endIndex);
            }
        }

        /// <summary>
        /// Return location of pivot
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        private static int partition(char[] arr, int startIndex, int endIndex)
        {
            int pivot = arr[endIndex];
            int i = startIndex - 1;
            for (int j = startIndex; j < endIndex; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    char temp2 = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp2;
                }
            }
            // move pivot
            i++;
            char temp = arr[i];
            arr[i] = arr[endIndex];
            arr[endIndex] = temp;
            return i;
        }
    }
}
