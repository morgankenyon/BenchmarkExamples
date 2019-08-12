using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace BenchmarkExamples.Yield
{
    [MemoryDiagnoser]
    public class YieldBenchmark
    {

        [Params(10)]
        public int N;

        [Benchmark]
        public void RegularReturn1Level()
        {
            var list = new List<int>();
            for (int i = 0; i < N; i++)
            {
                var flattened = RegularReturn1()
                    .ToList();
                list.AddRange(flattened);
            }
        }

        [Benchmark]
        public void YieldReturn1Level()
        {
            var list = new List<int>();
            for (int i = 0; i < N; i++)
            {
                var flattened = YieldReturn1()
                    .ToList();
                list.AddRange(flattened);
            }
        }


        [Benchmark]
        public void RegularReturn2Levels()
        {
            var list = new List<int>();
            for (int i = 0; i < N; i++)
            {
                var flattened = RegularReturn2()
                    .SelectMany(x => x)
                    .ToList();
                list.AddRange(flattened);
            }
        }

        [Benchmark]
        public void YieldReturn2Levels()
        {
            var list = new List<int>();
            for (int i = 0; i < N; i++)
            {
                var flattened = YieldReturn2()
                    .SelectMany(x => x)
                    .ToList();
                list.AddRange(flattened);
            }
        }

        [Benchmark]
        public void RegularReturn3Levels()
        {
            var list = new List<int>();
            for (int i = 0; i < N; i++)
            {
                var flattened = RegularReturn3()
                    .SelectMany(x => x)
                    .SelectMany(y => y)
                    .ToList();
                list.AddRange(flattened);
            }
        }

        [Benchmark]
        public void YieldReturn3Levels()
        {
            var list = new List<int>();
            for (int i = 0; i < N; i++)
            {
                var flattened = YieldReturn3()
                    .SelectMany(x => x)
                    .SelectMany(y => y)
                    .ToList();
                list.AddRange(flattened);
            }
        }

        [Benchmark]
        public void RegularReturn4Levels()
        {
            var list = new List<int>();
            for (int i = 0; i < N; i++)
            {
                var flattened = RegularReturn4()
                    .SelectMany(x => x)
                    .SelectMany(y => y)
                    .SelectMany(z => z)
                    .ToList();
                list.AddRange(flattened);
            }
        }

        [Benchmark]
        public void YieldReturn4Levels()
        {
            var list = new List<int>();
            for (int i = 0; i < N; i++)
            {
                var flattened = YieldReturn4()
                    .SelectMany(x => x)
                    .SelectMany(y => y)
                    .SelectMany(z => z)
                    .ToList();
                list.AddRange(flattened);
            }
        }

        public IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>> RegularReturn4()
        {
            var list = new List<IEnumerable<IEnumerable<IEnumerable<int>>>>();
            for (int i = 0; i < N; i++)
            {
                list.Add(RegularReturn3());
            }
            return list;
        }

        public IEnumerable<IEnumerable<IEnumerable<int>>> RegularReturn3()
        {
            var list = new List<IEnumerable<IEnumerable<int>>>();
            for (int i = 0; i < N; i++)
            {
                list.Add(RegularReturn2());
            }
            return list;
        }

        public IEnumerable<IEnumerable<int>> RegularReturn2()
        {
            var list = new List<IEnumerable<int>>();
            for (int i = 0; i < N; i++)
            {
                list.Add(RegularReturn1());
            }
            return list;
        }

        public IEnumerable<int> RegularReturn1()
        {
            var list = new List<int>();
            for (int i = 0; i < N; i++)
            {
                list.Add(i);
            }
            return list;
        }

        public IEnumerable<IEnumerable<IEnumerable<IEnumerable<int>>>> YieldReturn4()
        {
            for (int i = 0; i < N; i++)
                yield return YieldReturn3();
        }

        public IEnumerable<IEnumerable<IEnumerable<int>>> YieldReturn3()
        {
            for (int i = 0; i < N; i++)
                yield return YieldReturn2();
        }

        public IEnumerable<IEnumerable<int>> YieldReturn2()
        {
            for (int i = 0; i < N; i++)
                yield return YieldReturn1();
        }

        public IEnumerable<int> YieldReturn1()
        {
            for (int i = 0; i < N; i++)
                yield return i;
        }
    }
}
