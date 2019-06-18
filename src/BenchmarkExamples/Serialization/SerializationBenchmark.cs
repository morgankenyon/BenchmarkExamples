using BenchmarkDotNet.Attributes;
using BenchmarkExamples.Serialization.Models;
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
        private string jsonInfo;
        private string xmlInfo;
        private FileStream protobufInputStream;
        private FileStream protobufOutputStream;
        private string infoFolder = "Serialization";
        [GlobalSetup]
        public void prepareDataFiles()
        {
            //read in json string
            jsonInfo = File.ReadAllText($"{infoFolder}/info.json");

            //read in xml string
            xmlInfo = File.ReadAllText($"{infoFolder}/info.xml");

            //read in protobuf-net file
            protobufInputStream = File.OpenRead($"{infoFolder}/info.bin");

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
            }
        }

        [Benchmark(Baseline = true)]
        public void JsonToObjectTest()
        {
            for (int i = 0; i < N; i++)
            {
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
            }
        }

        [Benchmark]
        public void XmlToObjectTest()
        {
            for (int i = 0; i < N; i++)
            {
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
                }
            }
        }

        [Benchmark]
        public void XmlPrepTimeExcludedTest()
        {
            for (int i = 0; i < N; i++)
            {
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
                }
            }
        }

        [Benchmark]
        public void ProtoBufToObjectTest()
        {
            for (int i = 0; i < N; i++)
            {
                ProtoInfo info;
                protobufInputStream.Position = 0;
                info = Serializer.Deserialize<ProtoInfo>(protobufInputStream);
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


                var outputStream = new MemoryStream();
                Serializer.Serialize(outputStream, info);
            }
        }
    } 
}
