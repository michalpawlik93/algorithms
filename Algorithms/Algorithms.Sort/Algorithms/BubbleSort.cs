using Algorithms.Sort.Utils;

namespace Algorithms.Sort.Algorithms;

public static class BubbleSort
{
    public static char[] Sort(char[] array1, char[] array2)
    {
        var mergedArray = ArrayUtils.CopyByForeach(array1, array2);

        var swaped = false;
        do
        {
            swaped = false;
            for (var i = 0; i < mergedArray.Length - 1; i++)
            {
                if (mergedArray[i] > mergedArray[i + 1])
                {
                    var temp1 = mergedArray[i];
                    var temp2 = mergedArray[i + 1];
                    mergedArray[i] = temp2;
                    mergedArray[i + 1] = temp1;
                    swaped = true;
                    if (i == mergedArray.Length - 2)
                    {
                        break;
                    }
                }
            }
        } while (swaped);
        return mergedArray;
    }
}
