﻿namespace Algorithms.Sort.Utils;
public static class ArrayUtils
{
    public static char[] CopyByArrayCopy(char[] array1, char[] array2)
    {
        var mergedArray = new char[array1.Length + array2.Length];
        Array.Copy(array1, mergedArray, array1.Length);
        Array.Copy(array2, 0, mergedArray, array1.Length, array2.Length);
        return mergedArray;
    }

    public static char[] CopyByForeach(char[] array1, char[] array2)
    {
        var mergedArray = new char[array1.Length + array2.Length];
        foreach (var (v, i) in array1.Select((v, i) => (v, i)))
        {
            mergedArray[i] = v;
        }
        foreach (var (v, i) in array2.Select((v, i) => (v, i)))
        {
            mergedArray[array1.Length + i] = v;
        }
        return mergedArray;
    }

    public static void DisplayAllArrayElements(char[] arr)
    {
        foreach (char c in arr)
        {
            Console.WriteLine(c);
        }
    }
}
