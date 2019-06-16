using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace BenchmarkExamples.Serialization
{
    [MemoryDiagnoser]
    public class SerializationBenchmark
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
      <XmlFriend>
         <id>0</id>
         <name>Dodson Knox</name>
      </XmlFriend>
      <XmlFriend>
         <id>1</id>
         <name>Kendra Wilder</name>
      </XmlFriend>
      <XmlFriend>
         <id>2</id>
         <name>Jocelyn Knowles</name>
      </XmlFriend>
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

        private XmlSerializer xmlSerializer;
        [GlobalSetup]
        public void prepareDataFiles()
        {
            //creating file for protobuf to read
            var parsedObject = JsonConvert.DeserializeObject<ProtoInfo>(jsonString);
            using (var file = File.Create("Serialization/info.bin"))
            {
                Serializer.Serialize(file, parsedObject);
            }

            //creating file for json parser
            File.WriteAllText("Serialization/info.json", jsonString);

            //creating file for xml parser
            File.WriteAllText("Serialization/info.xml", xmlString);

            //prep xml serializer
            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "xmlinfo";
            xmlSerializer = new XmlSerializer(typeof(Info), xRoot);
        }

        [Benchmark]
        public void JsonToJObjectTest()
        {
            for (int i = 0; i < N; i++)
            {
                var jsonInfo = File.ReadAllText("Serialization/info.json");
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
                var greeting = json["greeting"];
                var favoriteFruit = json["favoriteFruit"];

                var infoString = json.ToString();
                File.WriteAllText("Serialization/JsonTestInfo.json", infoString);
            }
        }

        [Benchmark(Baseline = true)]
        public void JsonToObjectTest()
        {
            for (int i = 0; i < N; i++)
            {
                var jsonInfo = File.ReadAllText("Serialization/info.json");
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
                var greeting = parsedObject.greeting;
                var favoriteFruit = parsedObject.favoriteFruit;

                var infoString = JsonConvert.SerializeObject(parsedObject);
                File.WriteAllText("Serialization/ObjectTestInfo.json", infoString);
            }
        }

        [Benchmark]
        public void XmlToObjectTest()
        {
            for (int i = 0; i < N; i++)
            {
                var xmlInfo = File.ReadAllText("Serialization/info.xml");
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
                var greeting = info.greeting;
                var favoriteFruit = info.favoriteFruit;

                using (StringWriter textWriter = new StringWriter())
                {
                    serializer.Serialize(textWriter, info);
                    var xmlString = textWriter.ToString();
                    File.WriteAllText("Serialization/XmlTestInfo.json", xmlString);
                }
            }
        }

        [Benchmark]
        public void XmlPrepTimeIncludedTest()
        {
            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "xmlinfo";
            var serializer = new XmlSerializer(typeof(Info), xRoot);
            for (int i = 0; i < N; i++)
            {
                var xmlInfo = File.ReadAllText("Serialization/info.xml");
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
                var greeting = info.greeting;
                var favoriteFruit = info.favoriteFruit;

                using (StringWriter textWriter = new StringWriter())
                {
                    xmlSerializer.Serialize(textWriter, info);
                    var xmlString = textWriter.ToString();
                    File.WriteAllText("Serialization/XmlPrepTimeIncludeInfo.json", xmlString);
                }
            }
        }

        [Benchmark]
        public void XmlPrepTimeExcludedTest()
        {
            for (int i = 0; i < N; i++)
            {
                var xmlInfo = File.ReadAllText("Serialization/info.xml");
                Info info = null;
                using (TextReader reader = new StringReader(xmlInfo))
                {
                    info = (Info)xmlSerializer.Deserialize(reader);
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
                var greeting = info.greeting;
                var favoriteFruit = info.favoriteFruit;

                using (StringWriter textWriter = new StringWriter())
                {
                    xmlSerializer.Serialize(textWriter, info);
                    var xmlString = textWriter.ToString();
                    File.WriteAllText("Serialization/XmlPrepTimeExcludedInfo.json", xmlString);
                }
            }
        }

        [Benchmark]
        public void ProtoBufToObjectTest()
        {
            for (int i = 0; i < N; i++)
            {
                ProtoInfo info;
                using (var file = File.OpenRead("Serialization/info.bin"))
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
                var greeting = info.greeting;
                var favoriteFruit = info.favoriteFruit;


                using (var file = File.Create("Serialization/ProtoBufXmlTestInfo.bin"))
                {
                    Serializer.Serialize(file, info);
                }
            }
        }
    }


    public class Name
    {
        public string first { get; set; }
        public string last { get; set; }
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
        public string greeting { get; set; }
        public string favoriteFruit { get; set; }
    }

    public class XmlName
    {
        [XmlElement("first")]
        public string first { get; set; }
        [XmlElement("last")]
        public string last { get; set; }
    }

    public class XmlInfo
    {
        [XmlElement("id")]
        public string id { get; set; }
        [XmlElement("index")]
        public int index { get; set; }
        [XmlElement("guid")]
        public Guid guid { get; set; }
        [XmlElement("isActive")]
        public bool isActive { get; set; }
        [XmlElement("balance")]
        public string balance { get; set; }
        [XmlElement("picture")]
        public string picture { get; set; }
        [XmlElement("age")]
        public int age { get; set; }
        [XmlElement("eyeColor")]
        public string eyeColor { get; set; }
        [XmlElement("name")]
        public Name name { get; set; }
        [XmlElement("company")]
        public string company { get; set; }
        [XmlElement("email")]
        public string email { get; set; }
        [XmlElement("phone")]
        public string phone { get; set; }
        [XmlElement("address")]
        public string address { get; set; }
        [XmlElement("about")]
        public string about { get; set; }
        [XmlElement("latitude")]
        public string latitude { get; set; }
        [XmlElement("longitude")]
        public string longitude { get; set; }
        [XmlElement("greeting")]
        public string greeting { get; set; }
        [XmlElement("favoriteFruit")]
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
