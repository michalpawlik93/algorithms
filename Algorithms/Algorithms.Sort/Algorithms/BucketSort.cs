namespace Algorithms.Sort.Algorithms;

public static class BucketSort
{
    public static IEnumerable<string> SortBucketOnBuildInStructures(this string[] inputArray)
    {
        var dictionary = new Dictionary<string, LinkedList<string>>(new AnagramEqualityComparer());
        foreach (var text in inputArray)
        {
            dictionary.AddItem(text);
        }
        foreach (var linkedLists in dictionary.Values)
        {
            foreach (var text in linkedLists)
            {
                yield return text;
            }
        }
    }

    private static void AddItem(this Dictionary<string, LinkedList<string>> dictionary, string text)
    {
        if (dictionary.ContainsKey(text))
        {
            dictionary[text].AddLast(text);
        }
        else
        {
            dictionary.Add(text, new LinkedList<string>());
            dictionary[text].AddLast(text);
        }
    }
}

public class AnagramEqualityComparer : IEqualityComparer<string>
{
    public bool Equals(string? x, string? y)
    {
        if (x == null || y == null)
        {
            return false;
        }

        if (x.Length != y.Length)
        {
            return false;
        }
        return x.OrderBy(c => c).SequenceEqual(y.OrderBy(c => c));
    }

    public int GetHashCode(string obj) =>
        obj.ToCharArray().Aggregate(0, (acc, c) => acc + c.GetHashCode());
}
