``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.557 (1809/October2018Update/Redstone5)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host] : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT


```
|                  Method |   N | Mean | Error | Ratio | RatioSD |
|------------------------ |---- |-----:|------:|------:|--------:|
|       JsonToJObjectTest | 100 |   NA |    NA |     ? |       ? |
|        JsonToObjectTest | 100 |   NA |    NA |     ? |       ? |
|         XmlToObjectTest | 100 |   NA |    NA |     ? |       ? |
| XmlPrepTimeIncludedTest | 100 |   NA |    NA |     ? |       ? |
| XmlPrepTimeExcludedTest | 100 |   NA |    NA |     ? |       ? |
|    ProtoBufToObjectTest | 100 |   NA |    NA |     ? |       ? |

Benchmarks with issues:
  SerializationBenchmark.JsonToJObjectTest: DefaultJob [N=100]
  SerializationBenchmark.JsonToObjectTest: DefaultJob [N=100]
  SerializationBenchmark.XmlToObjectTest: DefaultJob [N=100]
  SerializationBenchmark.XmlPrepTimeIncludedTest: DefaultJob [N=100]
  SerializationBenchmark.XmlPrepTimeExcludedTest: DefaultJob [N=100]
  SerializationBenchmark.ProtoBufToObjectTest: DefaultJob [N=100]
