``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.503 (1809/October2018Update/Redstone5)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT


```
|     Method |   N |         Mean |      Error |      StdDev |       Median |    Ratio | RatioSD |      Gen 0 | Gen 1 | Gen 2 |   Allocated |
|----------- |---- |-------------:|-----------:|------------:|-------------:|---------:|--------:|-----------:|------:|------:|------------:|
|   JsonTest | 100 |     2.450 ms |  0.0537 ms |   0.1515 ms |     2.401 ms |     1.42 |    0.12 |   562.5000 |     - |     - |  1728.91 KB |
| ObjectTest | 100 |     1.731 ms |  0.0457 ms |   0.1303 ms |     1.703 ms |     1.00 |    0.00 |   166.0156 |     - |     - |   514.06 KB |
|    XmlTest | 100 | 1,807.331 ms | 58.6486 ms | 171.0806 ms | 1,761.381 ms | 1,049.68 |  120.20 | 13000.0000 |     - |     - | 41609.19 KB |
