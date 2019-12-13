using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace BenchmarkExamples.CollectionReturnType
{
    [MemoryDiagnoser]
    public class CollectionReturnTypeBenchmark
    {
        [Params(100, 1000)]
        public int N;
        
        public List<Number> GetListAsList()
        {
            var list = new List<Number>();
            for (int i = 0; i < N; i++)
            {
                list.Add(new Number(i));
            }
            return list;
        }

        public IList<Number> GetListAsIList()
        {
            var list = new List<Number>();
            for (int i = 0; i < N; i++)
            {
                list.Add(new Number(i));
            }
            return list;
        }

        public IEnumerable<Number> GetListAsIEnumerable()
        {
            var list = new List<Number>();
            for (int i = 0; i < N; i++)
            {
                list.Add(new Number(i));
            }
            return list;
        }

        public ICollection<Number> GetListAsICollection()
        {
            var list = new List<Number>();
            for (int i = 0; i < N; i++)
            {
                list.Add(new Number(i));
            }
            return list;
        }

        public Collection<Number> GetCollection()
        {
            var collection = new Collection<Number>();
            for (int i = 0; i < N; i++)
            {
                collection.Add(new Number(i));
            }
            return collection;
        }


        [Benchmark(Baseline = true)]
        public void ListAsList()
        {
            var sum = 0;
            var list = GetListAsList();
            foreach (var item in list)
                sum = sum + 1 + 2;
        }

        [Benchmark]
        public void ListAsIList()
        {
            var sum = 0;
            var iList = GetListAsIList();
            foreach (var item in iList)
                sum = sum + 1 + 2;
        }

        [Benchmark]
        public void ListAsIEnumerable()
        {
            var sum = 0;
            var iEnumerable = GetListAsIEnumerable();
            foreach (var item in iEnumerable)
                sum = sum + 1 + 2;
        }

        [Benchmark]
        public void ListAsICollection()
        {
            var sum = 0;
            var iCollection = GetListAsICollection();
            foreach (var item in iCollection)
                sum = sum + 1 + 2;
        }

        [Benchmark]
        public void CollectionAsCollection()
        {
            var sum = 0;
            var list = GetCollection();
            foreach (var item in list)
                sum = sum + 1 + 2;
        }

        [Benchmark]
        public void CollectionToList()
        {
            var sum = 0;
            var collection = GetCollection().ToList();
            foreach (var item in collection)
                sum = sum + 1 + 2;

        }

        [Benchmark]
        public void IListToList()
        {
            var sum = 0;
            var list = GetListAsIList().ToList();
            foreach (var item in list)
                sum = sum + 1 + 2;
        }

        [Benchmark]
        public void IEnumerableToList()
        {
            var sum = 0;
            var list = GetListAsIEnumerable().ToList();
            foreach (var item in list)
                sum = sum + 1 + 2;
        }

        [Benchmark]
        public void ICollectionToList()
        {
            var sum = 0;
            var list = GetListAsIEnumerable().ToList();
            foreach (var item in list)
                sum = sum + 1 + 2;
        }
    }
}
