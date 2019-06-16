``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.557 (1809/October2018Update/Redstone5)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT


```
|                  Method |   N |         Mean |      Error |      StdDev |       Median |  Ratio | RatioSD |      Gen 0 | Gen 1 | Gen 2 |   Allocated |
|------------------------ |---- |-------------:|-----------:|------------:|-------------:|-------:|--------:|-----------:|------:|------:|------------:|
|       JsonToJObjectTest | 100 |     2.437 ms |  0.0482 ms |   0.0952 ms |     2.424 ms |   1.36 |    0.10 |   695.3125 |     - |     - |   2137.5 KB |
|        JsonToObjectTest | 100 |     1.820 ms |  0.0498 ms |   0.1372 ms |     1.796 ms |   1.00 |    0.00 |   292.9688 |     - |     - |   903.91 KB |
|         XmlToObjectTest | 100 | 1,326.049 ms | 50.2027 ms | 144.0408 ms | 1,298.398 ms | 737.92 |   98.96 | 10000.0000 |     - |     - | 32641.11 KB |
| XmlPrepTimeIncludedTest | 100 |    13.341 ms |  0.2635 ms |   0.3607 ms |    13.181 ms |   7.38 |    0.57 |   843.7500 |     - |     - |  2599.01 KB |
| XmlPrepTimeExcludedTest | 100 |     2.891 ms |  0.0149 ms |   0.0132 ms |     2.893 ms |   1.63 |    0.13 |   734.3750 |     - |     - |  2260.16 KB |
|    ProtoBufToObjectTest | 100 |     1.234 ms |  0.0245 ms |   0.0624 ms |     1.204 ms |   0.69 |    0.07 |   105.4688 |     - |     - |   326.56 KB |
