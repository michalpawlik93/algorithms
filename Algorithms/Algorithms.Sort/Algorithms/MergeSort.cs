namespace Algorithms.Sort.Algorithms;

/// <summary>
/// Divide and conquer metodology
/// Time Complexity O(inputArray.length * log inputArray.length)
/// Memory Complexity O(inputArray.length)
/// </summary>
public static class MergeSort
{
    public static char[] SortMerge(this char[] inputArray)
    {
        return Divide(inputArray, 0, inputArray.Length - 1);
    }

    /// <summary>
    /// Span overhead is too big for that algorithm
    /// </summary>
    /// <param name="inputArray"></param>
    /// <returns></returns>
    public static char[] SortMergeWithSpan(this char[] inputArray)
    {
        return DivideWithSpan(inputArray, 0, inputArray.Length - 1);
    }

    /// <summary>
    /// Divide arrays
    /// Time complexity O(log inputArray.length)
    /// Memory complexity O(log inputArray.length)
    /// </summary>
    /// <param name="inputArray"></param>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    private static char[] Divide(char[] inputArray, int left, int right)
    {
        if (left == right)
        {
            return new char[1] { inputArray[left] };
        }
        var middle = (left + right) / 2;
        var leftArray = Divide(inputArray, left, middle);
        var rightArray = Divide(inputArray, middle + 1, right);
        return Merge(leftArray, rightArray);
    }

    /// <summary>
    /// Merge arrays, they are already sorted, fill in the rest if while is broken
    /// Time Complexity O(inputArray.length)
    /// Memory complexity O(inputArray.length)
    /// </summary>
    /// <param name="leftArray"></param>
    /// <param name="rightArray"></param>
    /// <returns></returns>
    private static char[] Merge(char[] leftArray, char[] rightArray)
    {
        var mergedArray = new char[leftArray.Length + rightArray.Length];

        int mergedArrayIndex = 0;
        int leftArrayIndex = 0;
        int rightArrayIndex = 0;
        while (leftArrayIndex < leftArray.Length && rightArrayIndex < rightArray.Length)
        {
            if (leftArray[leftArrayIndex] < rightArray[rightArrayIndex])
            {
                mergedArray[mergedArrayIndex] = leftArray[leftArrayIndex];
                leftArrayIndex++;
            }
            else
            {
                mergedArray[mergedArrayIndex] = rightArray[rightArrayIndex];
                rightArrayIndex++;
            }
            mergedArrayIndex++;
        }

        if (leftArrayIndex == leftArray.Length)
        {
            while (rightArrayIndex < rightArray.Length)
            {
                mergedArray[mergedArrayIndex] = rightArray[rightArrayIndex];
                mergedArrayIndex++;
                rightArrayIndex++;
            }
        }

        if (rightArrayIndex == rightArray.Length)
        {
            while (leftArrayIndex < leftArray.Length)
            {
                mergedArray[mergedArrayIndex] = leftArray[leftArrayIndex];
                mergedArrayIndex++;
                leftArrayIndex++;
            }
        }

        return mergedArray;
    }

    private static char[] DivideWithSpan(char[] inputArray, int left, int right)
    {
        if (left == right)
        {
            return new char[1] { inputArray[left] };
        }
        var middle = (left + right) / 2;
        var leftArray = DivideWithSpan(inputArray, left, middle);
        var rightArray = DivideWithSpan(inputArray, middle + 1, right);
        return MergeWithSpan(leftArray, rightArray);
    }

    /// <summary>
    /// Use span to copy rest
    /// </summary>
    /// <param name="leftArray"></param>
    /// <param name="rightArray"></param>
    /// <returns></returns>
    private static char[] MergeWithSpan(char[] leftArray, char[] rightArray)
    {
        var mergedArray = new char[leftArray.Length + rightArray.Length];

        int mergedArrayIndex = 0;
        int leftArrayIndex = 0;
        int rightArrayIndex = 0;
        while (leftArrayIndex < leftArray.Length && rightArrayIndex < rightArray.Length)
        {
            if (leftArray[leftArrayIndex] < rightArray[rightArrayIndex])
            {
                mergedArray[mergedArrayIndex] = leftArray[leftArrayIndex];
                leftArrayIndex++;
            }
            else
            {
                mergedArray[mergedArrayIndex] = rightArray[rightArrayIndex];
                rightArrayIndex++;
            }
            mergedArrayIndex++;
        }

        if (leftArrayIndex < leftArray.Length)
        {
            var leftSpan = leftArray.AsSpan().Slice(leftArrayIndex);
            leftSpan.CopyTo(mergedArray.AsSpan().Slice(mergedArrayIndex));
        }

        if (rightArrayIndex < rightArray.Length)
        {
            var rightSpan = rightArray.AsSpan().Slice(rightArrayIndex);
            rightSpan.CopyTo(mergedArray.AsSpan().Slice(mergedArrayIndex));
        }

        return mergedArray;
    }
}
