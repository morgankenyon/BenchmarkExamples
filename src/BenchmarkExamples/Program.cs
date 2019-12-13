using BenchmarkDotNet.Running;
using BenchmarkExamples.Boxing;
using BenchmarkExamples.CollectionReturnType;
using BenchmarkExamples.Dynamic;
using BenchmarkExamples.ForLoop;
using BenchmarkExamples.Serialization;
using BenchmarkExamples.SyncAsync;
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
            "Yield",
            "Dynamic",
            "SyncAsync",
            "ForLoop",
            "CollectionReturnType"
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
            switch (option)
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
                case "Dynamic":
                    var dynamicSummary = BenchmarkRunner.Run<DynamicBenchmark>();
                    break;
                case "SyncAsync":
                    var syncAsync = BenchmarkRunner.Run<SyncAsyncBenchmark>();
                    break;
                case "ForLoop":
                    var forLoop = BenchmarkRunner.Run<ForLoopBenchmark>();
                    break;
                case "CollectionReturnType":
                    var returnType = BenchmarkRunner.Run<CollectionReturnTypeBenchmark>();
                    break;
            }
        }
    }
}
