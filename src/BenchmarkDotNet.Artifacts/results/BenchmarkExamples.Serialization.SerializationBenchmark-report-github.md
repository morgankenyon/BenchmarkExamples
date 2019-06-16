``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.557 (1809/October2018Update/Redstone5)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT


```
|                  Method |   N |         Mean |      Error |     StdDev |       Median |  Ratio | RatioSD |      Gen 0 | Gen 1 | Gen 2 |   Allocated |
|------------------------ |---- |-------------:|-----------:|-----------:|-------------:|-------:|--------:|-----------:|------:|------:|------------:|
|       JsonToJObjectTest | 100 |     2.572 ms |  0.0814 ms |  0.2363 ms |     2.486 ms |   1.58 |    0.19 |   695.3125 |     - |     - |   2137.5 KB |
|        JsonToObjectTest | 100 |     1.669 ms |  0.0317 ms |  0.0618 ms |     1.656 ms |   1.00 |    0.00 |   292.9688 |     - |     - |   903.91 KB |
|         XmlToObjectTest | 100 | 1,275.455 ms | 33.8151 ms | 93.7014 ms | 1,257.803 ms | 767.88 |   51.52 | 10000.0000 |     - |     - | 32596.84 KB |
| XmlPrepTimeIncludedTest | 100 |    15.033 ms |  0.8596 ms |  2.4526 ms |    14.248 ms |   9.38 |    1.47 |   843.7500 |     - |     - |  2604.43 KB |
| XmlPrepTimeExcludedTest | 100 |     2.878 ms |  0.0175 ms |  0.0155 ms |     2.878 ms |   1.75 |    0.07 |   734.3750 |     - |     - |  2260.16 KB |
|    ProtoBufToObjectTest | 100 |     1.254 ms |  0.0315 ms |  0.0615 ms |     1.234 ms |   0.75 |    0.05 |   105.4688 |     - |     - |   326.56 KB |
