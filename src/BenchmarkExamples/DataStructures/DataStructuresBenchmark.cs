using BenchmarkDotNet.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkExamples.DataStructures
{
    [MemoryDiagnoser]
    public class DataStructuresBenchmark
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
        public void LinkedListAdd()
        {
            var numberLinkedList = new LinkedList<int>();
            for (int i = 0; i < N; i++)
            {
                numberLinkedList.AddLast(i);
            }
        }

        [Benchmark]
        public void ArrayListAdd()
        {
            var arrayList = new ArrayList();
            for (int i = 0; i < N; i++)
            {
                arrayList.Add(i);
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
        public void SizedListAddIfUnique()
        {
            var numberList = new List<int>(N);
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
        public void LinkedListAddIfUnique()
        {
            var numberLinkedList = new LinkedList<int>();
            for (int i = 0; i < N; i++)
            {
                if (!numberLinkedList.Contains(i))
                {
                    numberLinkedList.AddLast(i);
                }
            }
        }

        [Benchmark]
        public void ArrayListAddIfUnique()
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
        
        [Benchmark]
        public void ArrayAddAndRemove()
        {
            var numberArray = new int[N];
            for (int i = 0; i < N; i++)
            {
                numberArray[i] = i;
            }

            for(int i = 0; i < N; i++)
            {
                for(int j = 0; j < numberArray.Length; j++)
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
        public void LinkedListAddRemove()
        {
            var numberLinkedList = new LinkedList<int>();
            for (int i = 0; i < N; i++)
            {
                numberLinkedList.AddLast(i);
            }

            for(int i = 0; i < N; i++)
            {
                numberLinkedList.Remove(i);
            }
        }

        [Benchmark]
        public void ArrayListAddRemove()
        {
            var arrayList = new ArrayList();
            for (int i = 0; i < N; i++)
            {
                arrayList.Add(i);
            }

            for (int i = 0; i < N; i++)
            {
                arrayList.Remove(i);
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

            for(int i = 0; i < N; i++)
            {
                dictionary.Remove(i);
            }
        }
    }
}
