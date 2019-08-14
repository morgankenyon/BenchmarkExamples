``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT


```
|               Method |  N |         Mean |      Error |      StdDev |       Median |     Gen 0 |    Gen 1 |    Gen 2 |  Allocated |
|--------------------- |--- |-------------:|-----------:|------------:|-------------:|----------:|---------:|---------:|-----------:|
|  RegularReturn1Level | 10 |     2.191 us |  0.0460 us |   0.0853 us |     2.159 us |    1.4839 |        - |        - |    4.57 KB |
|    YieldReturn1Level | 10 |     2.593 us |  0.0642 us |   0.1281 us |     2.558 us |    1.2817 |        - |        - |    3.95 KB |
| RegularReturn2Levels | 10 |    27.953 us |  0.5569 us |   1.1747 us |    27.547 us |   16.9373 |        - |        - |   52.11 KB |
|   YieldReturn2Levels | 10 |    16.082 us |  0.6043 us |   0.6959 us |    15.742 us |    9.3994 |        - |        - |   28.91 KB |
| RegularReturn3Levels | 10 |   281.971 us |  5.6377 us |  12.3749 us |   275.433 us |  156.7383 |        - |        - |  483.52 KB |
|   YieldReturn3Levels | 10 |   160.055 us |  3.2334 us |   9.1199 us |   156.720 us |   80.8105 |        - |        - |  249.06 KB |
| RegularReturn4Levels | 10 | 3,616.332 us | 71.9992 us | 138.7181 us | 3,575.700 us | 1097.6563 | 332.0313 | 332.0313 | 4610.63 KB |
|   YieldReturn4Levels | 10 | 2,065.284 us | 45.8461 us | 123.1625 us | 2,019.865 us |  664.0625 | 332.0313 | 332.0313 | 2938.91 KB |
