``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.503 (1809/October2018Update/Redstone5)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT


```
|          Method |   N |         Mean |      Error |     StdDev |  Ratio | RatioSD |      Gen 0 | Gen 1 | Gen 2 |  Allocated |
|---------------- |---- |-------------:|-----------:|-----------:|-------:|--------:|-----------:|------:|------:|-----------:|
|        JsonTest | 100 |     6.986 ms |  0.0310 ms |  0.0275 ms |   1.00 |    0.05 |  1031.2500 |     - |     - | 3182.81 KB |
|      ObjectTest | 100 |     6.945 ms |  0.3474 ms |  0.3717 ms |   1.00 |    0.00 |   632.8125 |     - |     - | 1967.97 KB |
|         XmlTest | 100 | 1,481.884 ms | 25.3610 ms | 23.7227 ms | 212.65 |   11.41 | 14000.0000 |     - |     - | 43257.7 KB |
| ProtoBufXmlTest | 100 |     5.021 ms |  0.1268 ms |  0.1557 ms |   0.73 |    0.02 |   281.2500 |     - |     - |  878.13 KB |
