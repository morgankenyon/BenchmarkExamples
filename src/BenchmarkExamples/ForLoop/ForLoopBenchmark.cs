using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace BenchmarkExamples.ForLoop
{
    [MemoryDiagnoser]
    public class ForLoopBenchmark
    {
        [Params(100, 1000, 10000)]
        public int N;

        public List<int> intList;
        public int[] intArray;

        [GlobalSetup]
        public void PrepareList()
        {
            intList = new List<int>();
            intArray = new int[N];
            for(int i = 0; i < N; i++)
            {
                intList.Add(i);
                intArray[i] = i;
            }
        }

        [Benchmark(Baseline = true)]
        public void RegularForLoop()
        {
            var sum = 0;
            for (int i = 0; i < intArray.Length; i++)
                sum += i + intArray[i];
        }

        [Benchmark]
        public void ForEachLoop()
        {
            var sum = 0;
            int index = 0;
            foreach (var i in intArray)
            {
                sum += index + i;
                index++;
            }
        }

        [Benchmark]
        public void WithIndexLoop()
        {
            var sum = 0;
            foreach (var (item, index) in intArray.WithIndex())
                sum += item + index;
        }

        [Benchmark]
        public void WithIndexCachedDelegateLoop()
        {
            var sum = 0;
            foreach (var (item, index) in intArray.WithIndexCachedDelegate())
                sum += item + index;
        }

        [Benchmark]
        public void WithIndexIteratorLoop()
        {
            var sum = 0;
            foreach (var (item, index) in intArray.WithIndexIterator())
                sum += item + index;
        }

        [Benchmark]
        public void WithIndexCustomEnumeratorLoop()
        {
            var sum = 0;
            foreach (var (item, index) in intArray.WithIndexCustomEnumerator())
                sum += item + index;
        }

        [Benchmark]
        public void WithIndexSpecificEnumeratorLoopArray()
        {
            var sum = 0;
            foreach (var (item, index) in intArray.WithIndexArray())
                sum += item + index;
        }

        [Benchmark]
        public void RegularForLoopList()
        {
            var sum = 0;
            for (int i = 0; i < intList.Count; i++)
                sum += i + intList[i];
        }

        [Benchmark]
        public void ForEachLoopList()
        {
            var sum = 0;
            int index = 0;
            foreach (var i in intList)
            {
                sum += index + i;
                index++;
            }
        }

        [Benchmark]
        public void WithIndexLoopList()
        {
            var sum = 0;
            foreach (var (item, index) in intList.WithIndex())
                sum += item + index;
        }


        [Benchmark]
        public void WithIndexCachedDelegateLoopList()
        {
            var sum = 0;
            foreach (var (item, index) in intList.WithIndexCachedDelegate())
                sum += item + index;
        }

        
        [Benchmark]
        public void WithIndexIteratorLoopList()
        {
            var sum = 0;
            foreach (var (item, index) in intList.WithIndexIterator())
                sum += item + index;
        }


        [Benchmark]
        public void WithIndexCustomEnumeratorLoopList()
        {
            var sum = 0;
            foreach (var (item, index) in intList.WithIndexCustomEnumerator())
                sum += item + index;
        }

        [Benchmark]
        public void WithIndexSpecificEnumeratorLoopList()
        {
            var sum = 0;
            foreach (var (item, index) in intList.WithIndexList())
                sum += item + index;
        }
    }

    public static class Extensions
    {
        //https://thomaslevesque.com/2019/11/18/using-foreach-with-index-in-c/
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> source)
        {
            return source.Select((item, index) => (item, index));
        }

        public static IEnumerable<(T item, int index)> WithIndexCachedDelegate<T>(this IEnumerable<T> source)
        {
            return source.Select(Cache<T>.Projection);
        }
        
        private static class Cache<T>
        {
            public static readonly Func<T, int, (T, int)> Projection = (item, index) => (item, index);
        }

        public static IEnumerable<(T item, int index)> WithIndexIterator<T>(this IEnumerable<T> source)
        {
            int index = 0;
            foreach (var item in source)
            {
                yield return (item, index);
                index++;
            }
        }
        
        public static WithIndexEnumerable<T> WithIndexCustomEnumerator<T>(this IEnumerable<T> source)
        {
            return new WithIndexEnumerable<T>(source);
        }
        
        public struct WithIndexEnumerable<T>
        {
            private readonly IEnumerable<T> _source;
            
            public WithIndexEnumerable(IEnumerable<T> source)
            {
                _source = source;
            }
            
            public WithIndexEnumerator<T> GetEnumerator() => new WithIndexEnumerator<T>(_source.GetEnumerator());
        }
        
        public struct WithIndexEnumerator<T>
        {
            private readonly IEnumerator<T> _innerEnumerator;
            private int _index;

            public WithIndexEnumerator(IEnumerator<T> inner)
            {
                _innerEnumerator = inner;
                _index = -1;
            }

            public bool MoveNext()
            {
                if (_innerEnumerator.MoveNext())
                {
                    _index++;
                    return true;
                }
                
                return false;
            }
            
            public (T item, int index) Current => (_innerEnumerator.Current, _index);
        }

        public static WithIndexListEnumerable<T> WithIndexList<T>(this List<T> source)
        {
            return new WithIndexListEnumerable<T>(source);
        }

        public struct WithIndexListEnumerable<T>
        {
            private readonly List<T> _list;
            
            public WithIndexListEnumerable(List<T> list)
            {
                _list = list;
            }
            
            public Enumerator GetEnumerator() => new Enumerator(_list.GetEnumerator());

            public struct Enumerator
            {
                private List<T>.Enumerator _inner;
                private int _index;

                public Enumerator(List<T>.Enumerator inner)
                {
                    _inner = inner;
                    _index = -1;
                }

                public bool MoveNext()
                {
                    if (_inner.MoveNext())
                    {
                        _index++;
                        return true;
                    }

                    return false;
                }

                public (T, int) Current => (_inner.Current, _index);
            }
        }
        
        public static WithIndexArrayEnumerable<T> WithIndexArray<T>(this T[] source)
        {
            return new WithIndexArrayEnumerable<T>(source);
        }
        
        public struct WithIndexArrayEnumerable<T>
        {
            private readonly T[] _array;
            
            public WithIndexArrayEnumerable(T[] array)
            {
                _array = array;
            }
            
            public Enumerator GetEnumerator() => new Enumerator(_array);
            
            public struct Enumerator
            {
                private readonly T[] _array;
                private int _index;
                
                public Enumerator(T[] array)
                {
                    _array = array;
                    _index = -1;
                }
                
                public bool MoveNext()
                {
                    if (_index + 1 < _array.Length)
                    {
                        _index++;
                        return true;
                    }
                    
                    return false;
                }
                
                public (T, int) Current => (_array[_index], _index);
            }
        }
    }
}
