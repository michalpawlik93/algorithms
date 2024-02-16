namespace Collections.Arrays;
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

    public static char[] CopyByFor(char[] array1, char[] array2)
    {
        var mergedArray = new char[array1.Length + array2.Length];

        for (int i = 0; i < array1.Length; i++)
        {
            mergedArray[i] = array1[i];
        }

        for (int i = 0; i < array2.Length; i++)
        {
            mergedArray[array1.Length + i] = array2[i];
        }

        return mergedArray;
    }

    public static void DisplayAllArrayElements(this char[] arr)
    {
        foreach (char c in arr)
        {
            Console.WriteLine(c);
        }
    }

    public static void DisplayAllArrayElements<T>(this T[] arr)
    {
        foreach (T c in arr)
        {
            Console.WriteLine(c);
        }
    }

    public static char[] CopyByConat(char[] array1, char[] array2)
    {
        return array1.Concat(array2).ToArray();
    }

    /// <summary>
    /// Complexity O(inputArray.length)
    /// </summary>
    /// <param name="inputArray"></param>
    /// <returns></returns>
    public static char[] CopyToNewArray(this char[] inputArray)
    {
        var outputArray = new char[inputArray.Length];
        inputArray.CopyTo(outputArray, 0);
        return outputArray;
    }
}
