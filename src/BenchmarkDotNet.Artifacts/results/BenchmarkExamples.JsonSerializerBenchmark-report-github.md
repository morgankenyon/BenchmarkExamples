``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.503 (1809/October2018Update/Redstone5)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT


```
|          Method |   N |         Mean |     Error |    StdDev |       Median |  Ratio | RatioSD |      Gen 0 | Gen 1 | Gen 2 |  Allocated |
|---------------- |---- |-------------:|----------:|----------:|-------------:|-------:|--------:|-----------:|------:|------:|-----------:|
|        JsonTest | 100 |     2.125 ms | 0.0532 ms | 0.0813 ms |     2.091 ms |   1.38 |    0.10 |   562.5000 |     - |     - |  1770400 B |
|      ObjectTest | 100 |     1.554 ms | 0.0420 ms | 0.1179 ms |     1.483 ms |   1.00 |    0.00 |   166.0156 |     - |     - |   526400 B |
|         XmlTest | 100 | 1,504.386 ms | 7.3077 ms | 6.4781 ms | 1,504.723 ms | 923.69 |   71.53 | 13000.0000 |     - |     - | 42608048 B |
| ProtoBufXmlTest | 100 |           NA |        NA |        NA |           NA |      ? |       ? |          - |     - |     - |          - |

Benchmarks with issues:
  JsonSerializerBenchmark.ProtoBufXmlTest: DefaultJob [N=100]
