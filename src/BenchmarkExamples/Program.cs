using BenchmarkDotNet.Running;
using System;

namespace BenchmarkExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<JsonSerializerBenchmark>();
        }
    }
}
