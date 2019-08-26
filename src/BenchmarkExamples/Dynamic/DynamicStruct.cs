using System;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkExamples.Dynamic
{
    public struct DynamicStruct
    {

        public DynamicStruct(string name, string city, int age)
        {
            Name = name;
            City = city;
            Age = age;
        }


        public int Age;
        public string Name;
        public string City;

        public string UpdateName(string newName)
        {
            Name = newName;
            return newName;
        }
    }
}
