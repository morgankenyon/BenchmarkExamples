using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace BenchmarkExamples
{
    [MemoryDiagnoser]
    public class JsonSerializerBenchmark
    {
        string xmlString = @"<xmlinfo>
   <about>Occaecat tempor id ad culpa anim.Eiusmod sit commodo exercitation occaecat dolor commodo ullamco velit. Fugiat mollit esse id proident.</about>
   <address>693 Duffield Street, Moraida, Wisconsin, 1658</address>
   <age>36</age>
   <balance>$3,998.67</balance>
   <company>SAVVY</company>
   <email>york.bonner @savvy.biz</email>
   <eyeColor>green</eyeColor>
   <favoriteFruit>apple</favoriteFruit>
   <friends>
      <Friend>
         <id>0</id>
         <name>Dodson Knox</name>
      </Friend>
      <Friend>
         <id>1</id>
         <name>Kendra Wilder</name>
      </Friend>
      <Friend>
         <id>2</id>
         <name>Jocelyn Knowles</name>
      </Friend>
   </friends>
   <greeting>Hello, York! You have 10 unread messages.</greeting>
   <guid>c57d7018-5f87-4f79-a8ac-9e29b6b8f2d2</guid>
   <id>5cf72414b97023feed70111c</id>
   <index>0</index>
   <isActive>false</isActive>
   <latitude>-10.211243</latitude>
   <longitude>-15.700221</longitude>
   <name>
      <first>York</first>
      <last>Bonner</last>
   </name>
   <phone>+1 (833) 529-2011</phone>
   <picture>http://placehold.it/32x32</picture>
   <tags>
      <element>sint</element>
      <element>deserunt</element>
      <element>id</element>
      <element>sint</element>
      <element>consectetur</element>
   </tags>
</xmlinfo>";
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

        [Params(100)]
        public int N;

        [GlobalSetup]
        public void prepareDataFiles()
        {
            //creating file for protobuf to read
            var parsedObject = JsonConvert.DeserializeObject<ProtoInfo>(jsonString);
            using (var file = File.Create("info.bin"))
            {
                Serializer.Serialize(file, parsedObject);
            }

            //creating file for json parser
            File.WriteAllText("info.json", jsonString);

            //creating file for xml parser
            File.WriteAllText("info.xml", xmlString);
        }

        [Benchmark]
        public void JsonTest()
        {
            for (int i = 0; i < N; i++)
            {
                var jsonInfo = File.ReadAllText("info.json");
                var json = JObject.Parse(jsonInfo);

                var id = json["id"];
                var index = json["index"];
                var guid = json["guid"];
                var isActive = json["isActive"];
                var balance = json["balance"];
                var picture = json["picture"];
                var age = json["age"];
                var eyeColor = json["eyeColor"];
                var name = json["name"];
                var firstName = name["first"];
                var lastName = name["last"];
                var company = json["company"];
                var email = json["email"];
                var phone = json["phone"];
                var address = json["address"];
                var about = json["about"];
                var latitude = json["latitude"];
                var longitude = json["longitude"];
                var tags = json["tags"];
                var friends = json["friends"];
                var friendZero = friends[0];
                var friendOne = friends[1];
                var friendTwo = friends[2];
                var greeting = json["greeting"];
                var favoriteFruit = json["favoriteFruit"];
            }
        }

        [Benchmark(Baseline = true)]
        public void ObjectTest()
        {
            for (int i = 0; i < N; i++)
            {
                var jsonInfo = File.ReadAllText("info.json");
                var parsedObject = JsonConvert.DeserializeObject<Info>(jsonInfo);
                var id = parsedObject.id;
                var index = parsedObject.index;
                var guid = parsedObject.guid;
                var isActive = parsedObject.isActive;
                var balance = parsedObject.balance;
                var picture = parsedObject.picture;
                var age = parsedObject.age;
                var eyeColor = parsedObject.eyeColor;
                var name = parsedObject.name;
                var firstName = name.first;
                var lastName = name.last;
                var company = parsedObject.company;
                var email = parsedObject.email;
                var phone = parsedObject.phone;
                var address = parsedObject.address;
                var about = parsedObject.about;
                var latitude = parsedObject.latitude;
                var longitude = parsedObject.longitude;
                var tags = parsedObject.tags;
                var friends = parsedObject.friends;
                var friendZero = friends[0];
                var friendOne = friends[1];
                var friendTwo = friends[2];
                var greeting = parsedObject.greeting;
                var favoriteFruit = parsedObject.favoriteFruit;
            }
        }

        [Benchmark]
        public void XmlTest()
        {
            for (int i = 0; i < N; i++)
            {
                var xmlInfo = File.ReadAllText("info.xml");
                var xRoot = new XmlRootAttribute();
                xRoot.ElementName = "xmlinfo";
                var serializer = new XmlSerializer(typeof(Info), xRoot);
                Info info = null;
                using (TextReader reader = new StringReader(xmlInfo))
                {
                    info = (Info)serializer.Deserialize(reader);
                }
                var id = info.id;
                var index = info.index;
                var guid = info.guid;
                var isActive = info.isActive;
                var balance = info.balance;
                var picture = info.picture;
                var age = info.age;
                var eyeColor = info.eyeColor;
                var name = info.name;
                var firstName = name.first;
                var lastName = name.last;
                var company = info.company;
                var email = info.email;
                var phone = info.phone;
                var address = info.address;
                var about = info.about;
                var latitude = info.latitude;
                var longitude = info.longitude;
                var tags = info.tags;
                var friends = info.friends;
                var friendZero = friends[0];
                var friendOne = friends[1];
                var friendTwo = friends[2];
                var greeting = info.greeting;
                var favoriteFruit = info.favoriteFruit;
            }
        }

        [Benchmark]
        public void ProtoBufXmlTest()
        {

            //    var parsedObject = JsonConvert.DeserializeObject<ProtoInfo>(jsonString);

            //    using (var file = File.Create("info.bin"))
            //    {
            //        Serializer.Serialize(file, parsedObject);
            //    }

            //ProtoInfo newInfo;
            //using (var file = File.OpenRead("info.bin"))
            //{
            //    newInfo = Serializer.Deserialize<ProtoInfo>(file);
            //}
            //byte[] msgOut;
            //using (var stream = new MemoryStream())
            //{
            //    Serializer.Serialize(stream, parsedObject);
            //    msgOut = stream.GetBuffer();
            //};
            //string converted = Encoding.UTF8.GetString(msgOut, 0, msgOut.Length);

            //var memoryStream = new MemoryStream(msgOut);
            //var infoObject = Serializer.Deserialize<ProtoInfo>(memoryStream);
            for (int i = 0; i < N; i++)
            {
                ProtoInfo info;
                using (var file = File.OpenRead("info.bin"))
                {
                    info = Serializer.Deserialize<ProtoInfo>(file);
                }
                var id = info.id;
                var index = info.index;
                var guid = info.guid;
                var isActive = info.isActive;
                var balance = info.balance;
                var picture = info.picture;
                var age = info.age;
                var eyeColor = info.eyeColor;
                var name = info.name;
                var firstName = name.first;
                var lastName = name.last;
                var company = info.company;
                var email = info.email;
                var phone = info.phone;
                var address = info.address;
                var about = info.about;
                var latitude = info.latitude;
                var longitude = info.longitude;
                var tags = info.tags;
                var friends = info.friends;
                var friendZero = friends[0];
                var friendOne = friends[1];
                var friendTwo = friends[2];
                var greeting = info.greeting;
                var favoriteFruit = info.favoriteFruit;
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
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string[] tags { get; set; }
        public Friend[] friends { get; set; }
        public string greeting { get; set; }
        public string favoriteFruit { get; set; }
    }

    [ProtoContract]
    public class ProtoName
    {
        [ProtoMember(1)]
        public string first { get; set; }
        [ProtoMember(2)]
        public string last { get; set; }
    }
    [ProtoContract]
    public class ProtoFriend
    {
        [ProtoMember(1)]
        public int id { get; set; }
        [ProtoMember(2)]
        public string name { get; set; }
    }
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
        public string[] tags { get; set; }
        [ProtoMember(18)]
        public ProtoFriend[] friends { get; set; }
        [ProtoMember(19)]
        public string greeting { get; set; }
        [ProtoMember(20)]
        public string favoriteFruit { get; set; }
    }
}
