using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkExamples.Serialization.Models
{
    [ProtoContract]
    public class ProtoName
    {
        [ProtoMember(1)]
        public string first { get; set; }
        [ProtoMember(2)]
        public string last { get; set; }
    }
}
