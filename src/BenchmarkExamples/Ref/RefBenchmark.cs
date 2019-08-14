using BenchmarkDotNet.Attributes;

namespace BenchmarkExamples.Ref
{
    [MemoryDiagnoser]
    public class RefBenchmark
    {
        [Params(500)]
        public int N;

        [Benchmark]
        public void RegularAddition()
        {
            var sum = 0;
            for (int i = 0; i < N; i++)
            {
                var value = i;
                var addOne = RegularAddOne(value);
                sum += addOne;
            }
        }

        public int RegularAddOne(int i)
        {
            return i + 1;
        }

        [Benchmark]
        public void RefAddition()
        {
            var sum = 0;
            for (int i = 0; i < N; i++)
            {
                var value = i;
                RefAddOne(ref value);
                sum += value;
            }
        }

        public void RefAddOne(ref int i)
        {
            i = i + 1;
        }

        [Benchmark]
        public void RegularCreationg()
        {
            for(int i = 0; i < N; i++)
            {

            }
        }

        public ref decimal GetDollarAmount(ref decimal dollar)
        {
            return ref dollar;
        }
    }
}
