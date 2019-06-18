using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkExamples.DataStructures
{
    [MemoryDiagnoser]
    public class DataStructuresAddUniqueBenchmark
    {

        [Params(100)]
        public int N;

        [Benchmark]
        public void ArrayAddIfUniqueUnknownIndex()
        {
            var numberArray = new int[N];
            for (int i = 0; i < N; i++)
            {
                var unique = true;
                for (int j = 0; j < numberArray.Length; j++)
                {
                    if (numberArray[j] == i)
                    {
                        unique = false;
                    }
                }

                if (unique)
                {
                    numberArray[i] = i;
                }
            }
        }

        [Benchmark]
        public void ArrayAddIfUniqueKnownIndex()
        {
            var numberArray = new int[N];
            for (int i = 0; i < N; i++)
            {
                if (numberArray[i] != i)
                {
                    numberArray[i] = i;
                }
            }
        }

        [Benchmark]
        public void ListAddIfUnique()
        {
            var numberList = new List<int>();
            for (int i = 0; i < N; i++)
            {
                if (!numberList.Contains(i))
                {
                    numberList.Add(i);
                }
            }
        }

        [Benchmark]
        public void HashSetAddIfUnique()
        {
            var numberSet = new HashSet<int>();
            for (int i = 0; i < N; i++)
            {
                if (!numberSet.Contains(i))
                {
                    numberSet.Add(i);
                }
            }
        }

        [Benchmark]
        public void DictionaryAddIfUnique()
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
    }
}
