using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkExamples.DataStructures
{
    public class DataStructuresAddRemoveBenchmark
    {
        [Params(100)]
        public int N;

        [Benchmark]
        public void ArrayAddAndRemove()
        {
            var numberArray = new int[N];
            for (int i = 0; i < N; i++)
            {
                numberArray[i] = i;
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < numberArray.Length; j++)
                {
                    if (numberArray[j] == i)
                    {
                        numberArray[j] = 0;
                    }
                }
            }
        }

        [Benchmark]
        public void ListAddAndRemove()
        {
            var numberList = new List<int>();
            for (int i = 0; i < N; i++)
            {
                numberList.Add(i);
            }

            for (int i = 0; i < numberList.Count; i++)
            {
                numberList.Remove(i);
            }
        }

        [Benchmark]
        public void SizedListAddAndRemove()
        {
            var numberList = new List<int>(N);
            for (int i = 0; i < N; i++)
            {
                numberList.Add(i);
            }

            for (int i = 0; i < numberList.Count; i++)
            {
                numberList.Remove(i);
            }
        }

        [Benchmark]
        public void HashSetAddAndRemove()
        {
            var numberSet = new HashSet<int>();
            for (int i = 0; i < N; i++)
            {
                numberSet.Add(i);
            }

            for (int i = 0; i < N; i++)
            {
                numberSet.Remove(i);
            }
        }

        [Benchmark]
        public void DictionaryAddRemove()
        {
            var dictionary = new Dictionary<int, int>();
            for (int i = 0; i < N; i++)
            {
                dictionary.Add(i, i);
            }

            for (int i = 0; i < N; i++)
            {
                dictionary.Remove(i);
            }
        }
    }
}
