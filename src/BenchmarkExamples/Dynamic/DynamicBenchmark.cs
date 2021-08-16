using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace BenchmarkExamples.Dynamic
{
    [MemoryDiagnoser]
    public class DynamicBenchmark
    {

        [Params(100)]
        public int N;

        [GlobalSetup]
        public void GlobalS()
        {
            StringConcat_V = "";
            DynamicStringConcat_V = "";
            FormatUser_V = new DynamicUser("John Billon", "Arlington", 23);
            DynamicallyFormatUser_V = FormatUser_V;
            StructFormatUser_V = new DynamicStruct();
            StructDynamicallyFormatUser_V = StructFormatUser_V;
        }

        private string StringConcat_V;
        [Benchmark]
        public object StringConcat()
        {
            var StringConcat_V = this.StringConcat_V;
            string message = "Message";
            for (int i = 0; i < N; i++)
                StringConcat_V = this.StringConcat_V + StringConcat_V;
            return StringConcat_V;
        }

        private dynamic DynamicStringConcat_V;
        [Benchmark]
        public object DynamicStringConcat()
        {
            var DynamicStringConcat_V = this.DynamicStringConcat_V;
            string message = "Message";
            for (int i = 0; i < N; i++)
                DynamicStringConcat_V = this.DynamicStringConcat_V + DynamicStringConcat_V;
            return DynamicStringConcat_V;
        }


        public DynamicUser FormatUser_V;
        [Benchmark]
        public object FormatUser()
        {
            var FormatUser_V = this.FormatUser_V;
            for (int i = 0; i < N; i++)
            {
                FormatUser_V.UpdateName("Crazy");
            }
            return FormatUser_V;
        }

        private dynamic DynamicallyFormatUser_V;
        [Benchmark]
        public object DynamicallyFormatUser()
        {
            var DynamicallyFormatUser_V = this.DynamicallyFormatUser_V;
            for (int i = 0; i < N; i++)
            {
                DynamicallyFormatUser_V.UpdateName("Crazy");
            }
            return DynamicallyFormatUser_V;
        }

        private DynamicStruct StructFormatUser_V;
        [Benchmark]
        public object StructFormatUser()
        {
            var StructFormatUser_V = this.StructFormatUser_V;
            for (int i = 0; i < N; i++)
            {
                StructFormatUser_V.UpdateName("Crazy");
            }
            return StructFormatUser_V;
        }

        public dynamic StructDynamicallyFormatUser_V;
        [Benchmark]
        public object StructDynamicallyFormatUser()
        {
            var StructDynamicallyFormatUser_V = this.StructDynamicallyFormatUser_V;
            for (int i = 0; i < N; i++)
            {
                StructDynamicallyFormatUser_V.UpdateName("Crazy");
            }
            return StructDynamicallyFormatUser_V;
        }
    }
}
