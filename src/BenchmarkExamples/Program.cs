using BenchmarkDotNet.Running;
using BenchmarkExamples.Boxing;
using BenchmarkExamples.Serialization;
using BenchmarkExamples.Yield;
using System;
using System.Collections.Generic;

namespace BenchmarkExamples
{
    public class Program
    {
        private static readonly List<string> BenchmarkTypes = new List<string>()
        {
            "Serialization",
            "Boxing",
            "Yield"
        };
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Please specify one of the following options to run the corresponding benchmark:");
                Console.WriteLine(string.Join(",\n", BenchmarkTypes.ToArray()));
                return;
            }

            var option = args[0];
            switch(option)
            {
                case "Serialization":
                    var serializationSummary = BenchmarkRunner.Run<SerializationBenchmark>();
                    break;
                case "Boxing":
                    var boxingSummary = BenchmarkRunner.Run<BoxingBenchmark>();
                    break;
                case "Yield":
                    var yieldSummary = BenchmarkRunner.Run<YieldBenchmark>();
                    break;

            }
        }
    }
}
