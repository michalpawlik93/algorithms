using Collections.Arrays;
using System.Text;

namespace Algorithms.Sort.Exercises;

public static class SearchExercises
{
    const int bufferSize = 1024;

    /// <summary>
    /// Given an input file with intigers, file can have 20Gb size, how to sort it
    /// </summary>
    public static void SortBigFileOfIntigers()
    {
        var filePath = "E:\\Nauka\\algorithms\\Algorithms\\Algorithms.Search\\input.txt";
        if (!File.Exists(filePath))
            return;

        var buffers = new List<List<int>>();

        using var reader = new StreamReader(filePath);
        while (true)
        {
            var buffer = new char[bufferSize];
            var count = reader.Read(buffer, 0, buffer.Length);

            var ints = buffer.ConverToIntBuffer();
            // should be merge sort because data can be huge
            var sortedArray = MergeSort(ints);
            buffers.Add(sortedArray);
            if (count == 0)
            {
                break;
            }
        }

        /// merge sort k sorted arrays

        ArrayUtils.DisplayAllArrayElements(buffers.SelectMany(x => x).ToArray());
    }

    private static List<int> ConverToIntBuffer(this char[] buffer)
    {
        var tempBuilder = new StringBuilder();
        var tempStrings = new List<string>();

        for (int i = 0; i < buffer.Length - 1; i++)
        {
            if (buffer[i] == ',')
            {
                tempStrings.Add(tempBuilder.ToString());
                tempBuilder.Clear();
            }
            else if (buffer[i] == '-' || Int32.TryParse(buffer[i].ToString(), out int _))
            {
                tempBuilder.Append(buffer[i]);
            }
        }
        if (tempBuilder.Length > 0)
        {
            tempStrings.Add(tempBuilder.ToString());
            tempBuilder.Clear();
        }

        return tempStrings.Select(int.Parse).ToList();
    }

    private static List<int> QuickSort(List<int> input)
    {
        if (input.Count < 2)
        {
            return input;
        }
        var pivot = input[(input.Count - 1) / 2];
        var left = new List<int>();
        var right = new List<int>();

        for (int i = 0; i < input.Count - 1; i++)
        {
            if (input[i] > input[pivot])
            {
                right.Add(input[i]);
            }
            else
            {
                left.Add(input[i]);
            }
        }
        return [.. QuickSort(left), input[pivot], .. QuickSort(right)];
    }

    private static List<int> MergeSort(List<int> input)
    {
        if (input.Count < 2)
        {
            return input;
        }
        var middle = (input.Count) / 2;
        var left = new List<int>();
        var right = new List<int>();
        for (var i = 0; i < middle; i++)
        {
            left.Add(input[i]);
        }
        for (var i = middle; i < input.Count; i++)
        {
            right.Add(input[i]);
        }
        var mergedLeft = MergeSort(left);
        var mergedRight = MergeSort(right);

        return MergeSortedLists(mergedLeft, mergedRight);


    }

    private static List<int> MergeSortedLists(List<int> left, List<int> right)
    {
        var mergedList = new List<int>();
        var i = 0;
        var j = 0;
        while (i < left.Count && j < right.Count)
        {
            if (left[i] <= right[j])
            {
                mergedList.Add(left[i]);
                i++;
            }
            else
            {
                mergedList.Add(right[j]);
                j++;
            }
        }

        while (i < left.Count)
        {
            mergedList.Add(left[i]);
            i++;
        }

        while (j < right.Count)
        {
            mergedList.Add(right[j]);
            j++;
        }

        return mergedList;
    }
}
