using BenchmarkDotNet.Running;
using BenchmarkExamples.DataStructures;
using BenchmarkExamples.Serialization;
using System;
using System.Collections.Generic;

namespace BenchmarkExamples
{
    public class Program
    {
        private static readonly List<string> BenchmarkTypes = new List<string>()
        {
            "Serialization",
            "DataStructures"
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
                case "DataStructures":
                    var dataStructuresSummary = BenchmarkRunner.Run<DataStructuresBenchmark>();
                    break;
            }
        }
    }
}
