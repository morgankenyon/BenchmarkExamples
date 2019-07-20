using BenchmarkDotNet.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkExamples.Boxing
{
    [MemoryDiagnoser]
    public class BoxingBenchmark
    {

        [Params(1000)]
        public int N;

        [Benchmark]
        public void TestNormal()
        {
            var dictionary = new Dictionary<int, int>();

            for (int i = 0; i < N; i++)
            {
                if (!dictionary.ContainsKey(i))
                {
                    dictionary.Add(i, i);
                }
            }
        }

        [Benchmark]
        public void TestBoxing()
        {
            var dictionary = new Dictionary<object, int>();

            for (int i = 0; i < N; i++)
            {
                if (!dictionary.ContainsKey(i))
                {
                    dictionary.Add(i, i);
                }
            }
        }

        [Benchmark]
        public void TestInterface()
        {
            IDictionary<int, int> dictionary = new Dictionary<int, int>();

            for (int i = 0; i < N; i++)
            {
                if (!dictionary.ContainsKey(i))
                {
                    dictionary.Add(i, i);
                }
            }
        }

        [Benchmark]
        public void TestBoxingAndInterface()
        {
            IDictionary<object, int> dictionary = new Dictionary<object, int>();

            for (int i = 0; i < N; i++)
            {
                if (!dictionary.ContainsKey(i))
                {
                    dictionary.Add(i, i);
                }
            }
        }

        [Benchmark]
        public void TestingArrayList()
        {
            var arrayList = new ArrayList();

            for (int i = 0; i < N; i++)
            {
                if (!arrayList.Contains(i))
                {
                    arrayList.Add(i);
                }
            }
        }

        [Benchmark]
        public void TestingObjectList()
        {
            var list = new List<object>();

            for (int i = 0; i < N; i++)
            {
                if (!list.Contains(i))
                {
                    list.Add(i);
                }
            }
        }

        [Benchmark]
        public void TestingIntList()
        {
            var list = new List<int>();

            for (int i = 0; i < N; i++)
            {
                if (!list.Contains(i))
                {
                    list.Add(i);
                }
            }
        }
    }
}
