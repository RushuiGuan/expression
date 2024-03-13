
using BenchmarkDotNet.Running;

namespace Benchmark;

class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<MemoryBenchmark>();
    }
}