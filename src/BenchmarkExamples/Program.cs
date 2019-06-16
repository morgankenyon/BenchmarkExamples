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
            //var serializer = new SerializationBenchmark();
            //try
            //{
            //    serializer.prepareDataFiles();
            //    serializer.N = 2;
            //    serializer.ProtoBufToObjectTest();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.ReadLine();
            //}
        }
    }
}
