using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkExamples
{
    [MemoryDiagnoser]
    public class JsonSerializerBenchmark
    {

        string jsonString = @"{
	        'id': '5cf72414b97023feed70111c',
	        'index': 0,
	        'guid': 'c57d7018-5f87-4f79-a8ac-9e29b6b8f2d2',
	        'isActive': false,
	        'balance': '$3,998.67',
	        'picture': 'http://placehold.it/32x32',
	        'age': 36,
	        'eyeColor': 'green',
	        'name': {
		        'first': 'York',
		        'last': 'Bonner'
	        },
	        'company': 'SAVVY',
	        'email': 'york.bonner@savvy.biz',
	        'phone': '+1 (833) 529-2011',
	        'address': '693 Duffield Street, Moraida, Wisconsin, 1658',
	        'about': 'Occaecat tempor id ad culpa anim. Eiusmod sit commodo exercitation occaecat dolor commodo ullamco velit. Fugiat mollit esse id proident.',
	        'registered': 'Thursday, May 18, 2017 7:22 PM',
	        'latitude': '-10.211243',
	        'longitude': '-15.700221',
	        'tags': [
		        'sint',
		        'deserunt',
		        'id',
		        'sint',
		        'consectetur'
	        ],
	        'friends': [
		        {
			        'id': 0,
			        'name': 'Dodson Knox'
		        },
		        {
			        'id': 1,
			        'name': 'Kendra Wilder'
		        },
		        {
			        'id': 2,
			        'name': 'Jocelyn Knowles'
		        }
	        ],
	        'greeting': 'Hello, York! You have 10 unread messages.',
	        'favoriteFruit': 'apple'
        }";

        [Params(100, 10_000)]
        public int N;

        [Benchmark]
        public void JsonTest()
        {
            for (int i = 0; i < N; i++)
            {
                var json = JObject.Parse(jsonString);

                var company = json["company"];
                var firstFriend = json["friends"][0];
            }
        }

        [Benchmark(Baseline = true)]
        public void ObjectTest()
        {
            for (int i = 0; i < N; i++)
            {
                var parsedObject = JsonConvert.DeserializeObject<Info>(jsonString);
                var company = parsedObject.company;
                var firstFriend = parsedObject.friends[0];
            }
        }
    }


    public class Name
    {
        public string first { get; set; }
        public string last { get; set; }
    }
    public class Friend
    {
        public int id { get; set; }
        public string name { get; set; }
    }
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
        public DateTime registered { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string[] tags { get; set; }
        public Friend[] friends { get; set; }
        public string greeting { get; set; }
        public string favoriteFruit { get; set; }

    }
}
