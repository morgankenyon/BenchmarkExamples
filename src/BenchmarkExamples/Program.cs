using BenchmarkDotNet.Running;
using BenchmarkExamples.Serialization;
using System;

namespace BenchmarkExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SerializationBenchmark>();
            //var json = new JsonSerializerBenchmark();
            //try
            //{
            //    json.N = 1;
            //    json.XmlTest();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.ReadLine();
            //}
        }
    }
}
