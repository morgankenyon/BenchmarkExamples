using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkExamples.DataStructures
{
    [MemoryDiagnoser]
    public class DataStructuresAddBenchmark
    {

        [Params(100)]
        public int N;


        [Benchmark]
        public void ArrayAdd()
        {
            var numberArray = new int[N];
            for (int i = 0; i < N; i++)
            {
                numberArray[i] = i;
            }
        }

        [Benchmark]
        public void ListAdd()
        {
            var numberList = new List<int>();
            for (int i = 0; i < N; i++)
            {
                numberList.Add(i);
            }
        }

        [Benchmark]
        public void SizedListAdd()
        {
            var numberList = new List<int>(N);
            for (int i = 0; i < N; i++)
            {
                numberList.Add(i);
            }
        }

        [Benchmark]
        public void HashSetAdd()
        {
            var numberSet = new HashSet<int>();
            for (int i = 0; i < N; i++)
            {
                numberSet.Add(i);
            }
        }

        [Benchmark]
        public void DictionaryAdd()
        {
            var dictionary = new Dictionary<int, int>();
            for (int i = 0; i < N; i++)
            {
                dictionary.Add(i, i);
            }
        }
    }
}
