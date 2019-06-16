``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.557 (1809/October2018Update/Redstone5)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT


```
|                  Method |   N |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |      Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------ |---- |------------:|----------:|----------:|------------:|------:|--------:|-----------:|------:|------:|----------:|
|       JsonToJObjectTest | 100 |    61.61 ms |  1.406 ms |  4.078 ms |    60.24 ms |  1.02 |    0.09 |  1375.0000 |     - |     - |   4.44 MB |
|        JsonToObjectTest | 100 |    60.93 ms |  1.624 ms |  4.579 ms |    59.85 ms |  1.00 |    0.00 |  1000.0000 |     - |     - |   3.23 MB |
|         XmlToObjectTest | 100 | 1,407.71 ms | 31.614 ms | 52.820 ms | 1,389.67 ms | 22.12 |    2.03 | 11000.0000 |     - |     - |  34.23 MB |
| XmlPrepTimeIncludedTest | 100 |    83.69 ms |  1.722 ms |  4.770 ms |    83.11 ms |  1.38 |    0.10 |  1500.0000 |     - |     - |    4.9 MB |
| XmlPrepTimeExcludedTest | 100 |    65.52 ms |  1.606 ms |  4.683 ms |    65.34 ms |  1.09 |    0.10 |  1444.4444 |     - |     - |   4.56 MB |
|    ProtoBufToObjectTest | 100 |    68.21 ms |  3.278 ms |  9.667 ms |    72.82 ms |  1.13 |    0.22 |   300.0000 |     - |     - |   1.14 MB |
