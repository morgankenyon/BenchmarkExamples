``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.557 (1809/October2018Update/Redstone5)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host] : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT


```
|          Method |   N | Mean | Error | Ratio | RatioSD |
|---------------- |---- |-----:|------:|------:|--------:|
|        JsonTest | 100 |   NA |    NA |     ? |       ? |
|      ObjectTest | 100 |   NA |    NA |     ? |       ? |
|         XmlTest | 100 |   NA |    NA |     ? |       ? |
| ProtoBufXmlTest | 100 |   NA |    NA |     ? |       ? |

Benchmarks with issues:
  JsonSerializerBenchmark.JsonTest: DefaultJob [N=100]
  JsonSerializerBenchmark.ObjectTest: DefaultJob [N=100]
  JsonSerializerBenchmark.XmlTest: DefaultJob [N=100]
  JsonSerializerBenchmark.ProtoBufXmlTest: DefaultJob [N=100]
