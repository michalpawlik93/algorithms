namespace Collections.Benchmark.Fixtures;

public static class ArrayFixtures
{
    public const int Length30 = 30;
    public const int Length300 = 300;
    public const int Length1000 = 1000;

    public static Dictionary<int, char[]> GenerateTestData =>
        new Dictionary<int, char[]>
        {
            { Length30, GenerateRandomArray(Length30) },
            { Length300, GenerateRandomArray(Length300) },
            { Length1000, GenerateRandomArray(Length1000) },
        };

    public static char[] GenerateRandomArray(int length) =>
        Enumerable.Range(0, length).Select(_ => GenerateRandomChar()).ToArray();

    private static char GenerateRandomChar()
    {
        var rnd = new Random();
        return (char)rnd.Next('a', 'z');
    }
}
