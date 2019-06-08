using BenchmarkDotNet.Running;

namespace UnmatchedSocksSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmarker>();
        }
    }
}
