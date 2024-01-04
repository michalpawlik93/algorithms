namespace Algorithms.Sort.Algorithms;

/// <summary>
/// Time complexity O(inputArray.length^2)
/// Memory complexity 1
/// </summary>
public static class BubbleSort
{
    public static char[] SortBubble(this char[] inputArray)
    {
        for (int i = 0; i < inputArray.Length - 1; i++)
        {
            for (int j = 0; j < inputArray.Length - 1 - i; j++)
            {
                if (inputArray[j] > inputArray[j + 1])
                {
                    var element1 = inputArray[j];
                    inputArray[j] = inputArray[j + 1];
                    inputArray[j + 1] = element1;
                }
            }
        }
        return inputArray;
    }

    public static char[] SortAdaptiveBubble(this char[] inputArray)
    {
        for (int i = 0; i < inputArray.Length - 1; i++)
        {
            var swaped = false;
            for (int j = 0; j < inputArray.Length - 1 - i; j++)
            {
                if (inputArray[j] > inputArray[j + 1])
                {
                    var element1 = inputArray[j];
                    inputArray[j] = inputArray[j + 1];
                    inputArray[j + 1] = element1;
                    swaped = true;
                }
            }

            if (!swaped)
            {
                break;
            }
        }
        return inputArray;
    }

    public static char[] SortAdaptiveBubbleAsSpan(this char[] inputArray)
    {
        var span = inputArray.AsSpan();

        for (int i = 0; i < span.Length - 1; i++)
        {
            var swapped = false;

            for (int j = 0; j < span.Length - 1 - i; j++)
            {
                if (span[j] > span[j + 1])
                {
                    var temp = span[j];
                    span[j] = span[j + 1];
                    span[j + 1] = temp;
                    swapped = true;
                }
            }

            if (!swapped)
            {
                break;
            }
        }

        return span.ToArray();
    }
}
