using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace BenchmarkExamples.SyncAsync
{
    [MemoryDiagnoser]
    public class SyncAsyncBenchmark
    {

        [Params(1000)]
        public int N;


        [Benchmark]
        public void TestingSyncMethod()
        {
            var sum = 0;

            for (int i = 0; i < N; i++)
            {
                var sync = new SyncExample(i);
                sum += sync.SyncNumber();
            }
        }

        [Benchmark]
        public async Task TestingSyncAsyncMethod()
        {
            var sum = 0;
            for (int i = 0; i < N; i++)
            {
                var sync = new SyncAsyncExample(i);
                sum += await sync.SyncAsyncNumber();
            }
        }
    }

    public class SyncExample
    {
        readonly int _number;
        public SyncExample(int number)
        {
            number = _number;
        }

        public int SyncNumber()
        {
            return _number;
        }
    }

    public class SyncAsyncExample
    {
        readonly int _number;
        public SyncAsyncExample(int number)
        {
            _number = number;
        }

        public async Task<int> SyncAsyncNumber() => _number;
    }

}