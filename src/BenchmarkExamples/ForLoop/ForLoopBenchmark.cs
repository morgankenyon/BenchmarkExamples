using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace BenchmarkExamples.ForLoop
{
    [MemoryDiagnoser]
    public class ForLoopBenchmark
    {
        [Params(100, 1000, 10000)]
        public int N;

        public List<int> intList;

        [GlobalSetup]
        public void PrepareList()
        {
            intList = new List<int>();
            for(int i = 0; i < N; i++)
            {
                intList.Add(i);
            }
        }

        [Benchmark(Baseline = true)]
        public void RegularForLoop()
        {
            var sum = 0;
            var intArray = new object[N];
            for (int i = 0; i < intArray.Length; i++)
                sum++;
        }

        [Benchmark]
        public void ForEachLoop()
        {
            var sum = 0;
            var intArray = new object[N];
            foreach (var i in intArray)
                sum++;
        }

        [Benchmark]
        public void WithIndexLoop()
        {
            var sum = 0;
            var intArray = new object[N];
            foreach (var (item, index) in intArray.WithIndex())
                sum++;
        }

        [Benchmark]
        public void RegularForLoopList()
        {
            var sum = 0;
            for (int i = 0; i < intList.Count; i++)
                sum++;
        }

        [Benchmark]
        public void ForEachLoopList()
        {
            var sum = 0;
            foreach (var i in intList)
                sum++;
        }

        [Benchmark]
        public void WithIndexLoopList()
        {
            var sum = 0;
            foreach (var (item, index) in intList.WithIndex())
                sum++;
        }

    }

    public static class Extensions
    {
        //https://thomaslevesque.com/2019/11/18/using-foreach-with-index-in-c/
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> source)
        {
            return source.Select((item, index) => (item, index));
        }
    }
}
