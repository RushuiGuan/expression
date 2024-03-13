using BenchmarkDotNet.Attributes;

namespace Benchmark;

[MemoryDiagnoser]
public class MemoryBenchmark
{
    private static List<string> listA;
    private static List<string> listB;

    private static string[] arrayA;
    private static string[] arrayB;

    [GlobalSetup]
    public void Setup()
    {
        // Setup your test data here
        listA = Enumerable.Range(0, 10000).Select(i => "val" + i).ToList();
        listB = Enumerable.Range(1000, 9000).Select(i => "val" + i).ToList();

        arrayA = listA.ToArray();
        arrayB = listB.ToArray();
    }

    [Benchmark]
    public void ListComparisonTest()
    {
        _ = listA.Any(val => listB.Contains(val));
    }

    [Benchmark]
    public void ArrayComparisonTest()
    {
        _ = arrayA.Any(val => arrayB.Contains(val));
    }
}
