using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace BenchmarkExamples.SyncAsync
{
    public class SyncExample
    {
        readonly int _number;
        public SyncExample(int number)
        {
            _number = number;
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

        public async Task<int> SyncAsyncNumber()
        {
            return _number;
        }
    }

    public class ValueTaskExample
    { 
        readonly int _number;
        public ValueTaskExample(int number)
        {
            _number = number;
        }

        public async ValueTask<int> ValueTaskNumber()
        {
            return _number;
        }
    }

    [MemoryDiagnoser]
    public class SyncAsyncBenchmark
    {

        [Params(1000, 5000, 10000)]
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

        //[Benchmark]
        //public async Task TestingValueTaskMethod()
        //{
        //    var sum = 0;
        //    for (int i = 0; i < N; i++)
        //    {
        //        var valueTask = new ValueTaskExample(i);
        //        sum += await valueTask.ValueTaskNumber();
        //    }
        //}

    }

}