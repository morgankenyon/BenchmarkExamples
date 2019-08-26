using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace BenchmarkExamples.Dynamic
{
    [MemoryDiagnoser]
    public class DynamicBenchmark
    {

        [Params(100)]
        public int N;

        [Benchmark]
        public void SumOneToN()
        {
            var sum = 0;
            for(int i = 0; i < N; i++)
                sum += i;
        }

        [Benchmark]
        public void StringConcat()
        {
            string concated = "";
            string message = "Message";
            for (int i = 0; i < N; i++)
                concated = message + concated.ToString();
        }

        [Benchmark]
        public void DynamicStringConcat()
        {
            dynamic concated = "";
            string message = "Message";
            for (int i = 0; i < N; i++)
                concated = message + concated.ToString();
        }

        [Benchmark]
        public void FormatUser()
        {
            for (int i = 0; i < N; i++)
            {
                var user = new DynamicUser("John Billon", "Arlington", 23);
                user.UpdateName("Crazy");
            }
        }

        [Benchmark]
        public void DynamicallyFormatUser()
        {
            for (int i = 0; i < N; i++)
            {
                dynamic user = new DynamicUser("John Billon", "Arlington", 23);
                user.UpdateName("Crazy");
            }
        }

        [Benchmark]
        public void StructFormatUser()
        {
            for (int i = 0; i < N; i++)
            {
                var user = new DynamicStruct("John Billon", "Arlington", 23);
                user.UpdateName("Crazy");
            }
        }

        [Benchmark]
        public void StructDynamicallyFormatUser()
        {
            for (int i = 0; i < N; i++)
            {
                dynamic user = new DynamicStruct("John Billon", "Arlington", 23);
                user.UpdateName("Crazy");
            }
        }
    }
}
