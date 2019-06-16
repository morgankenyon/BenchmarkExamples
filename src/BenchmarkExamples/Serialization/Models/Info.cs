using System;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkExamples.Serialization.Models
{
    public class Info
    {
        public string id { get; set; }
        public int index { get; set; }
        public Guid guid { get; set; }
        public bool isActive { get; set; }
        public string balance { get; set; }
        public string picture { get; set; }
        public int age { get; set; }
        public string eyeColor { get; set; }
        public Name name { get; set; }
        public string company { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string about { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string greeting { get; set; }
        public string favoriteFruit { get; set; }
    }
}
