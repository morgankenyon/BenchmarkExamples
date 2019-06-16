using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkExamples.Serialization.Models
{
    [ProtoContract]
    public class ProtoInfo
    {
        [ProtoMember(1)]
        public string id { get; set; }
        [ProtoMember(2)]
        public int index { get; set; }
        [ProtoMember(3)]
        public Guid guid { get; set; }
        [ProtoMember(4)]
        public bool isActive { get; set; }
        [ProtoMember(5)]
        public string balance { get; set; }
        [ProtoMember(6)]
        public string picture { get; set; }
        [ProtoMember(7)]
        public int age { get; set; }
        [ProtoMember(8)]
        public string eyeColor { get; set; }
        [ProtoMember(9)]
        public ProtoName name { get; set; }
        [ProtoMember(10)]
        public string company { get; set; }
        [ProtoMember(11)]
        public string email { get; set; }
        [ProtoMember(12)]
        public string phone { get; set; }
        [ProtoMember(13)]
        public string address { get; set; }
        [ProtoMember(14)]
        public string about { get; set; }
        [ProtoMember(15)]
        public string latitude { get; set; }
        [ProtoMember(16)]
        public string longitude { get; set; }
        [ProtoMember(17)]
        public string greeting { get; set; }
        [ProtoMember(18)]
        public string favoriteFruit { get; set; }
    }
}
