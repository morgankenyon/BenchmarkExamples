``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i5-7300U CPU 2.60GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT


```
|                               Method |     N |          Mean |         Error |        StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------- |------ |--------------:|--------------:|--------------:|------:|--------:|-------:|------:|------:|----------:|
|                       **RegularForLoop** |   **100** |      **75.29 ns** |     **0.6080 ns** |     **0.5390 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                          ForEachLoop |   100 |      64.58 ns |     0.3106 ns |     0.2753 ns |  0.86 |    0.01 |      - |     - |     - |         - |
|                        WithIndexLoop |   100 |   1,484.17 ns |     2.6752 ns |     2.5023 ns | 19.72 |    0.16 | 0.0706 |     - |     - |     112 B |
|          WithIndexCachedDelegateLoop |   100 |   1,473.91 ns |    12.5878 ns |    10.5114 ns | 19.57 |    0.14 | 0.0706 |     - |     - |     112 B |
|                WithIndexIteratorLoop |   100 |   1,245.92 ns |     5.3578 ns |     5.0117 ns | 16.55 |    0.12 | 0.0591 |     - |     - |      96 B |
|        WithIndexCustomEnumeratorLoop |   100 |     972.34 ns |     3.5635 ns |     2.9757 ns | 12.91 |    0.11 | 0.0191 |     - |     - |      32 B |
| WithIndexSpecificEnumeratorLoopArray |   100 |     683.54 ns |     2.4219 ns |     2.1470 ns |  9.08 |    0.07 |      - |     - |     - |         - |
|                   RegularForLoopList |   100 |     116.02 ns |     0.4040 ns |     0.3154 ns |  1.54 |    0.01 |      - |     - |     - |         - |
|                      ForEachLoopList |   100 |     231.11 ns |     1.1563 ns |     1.0816 ns |  3.07 |    0.02 |      - |     - |     - |         - |
|                    WithIndexLoopList |   100 |   1,602.86 ns |     2.8957 ns |     2.5670 ns | 21.29 |    0.17 | 0.0744 |     - |     - |     120 B |
|      WithIndexCachedDelegateLoopList |   100 |   1,592.63 ns |     5.0318 ns |     4.4606 ns | 21.15 |    0.15 | 0.0744 |     - |     - |     120 B |
|            WithIndexIteratorLoopList |   100 |   1,336.89 ns |     6.3426 ns |     5.6226 ns | 17.76 |    0.15 | 0.0648 |     - |     - |     104 B |
|    WithIndexCustomEnumeratorLoopList |   100 |   1,066.05 ns |     2.1547 ns |     2.0155 ns | 14.16 |    0.11 | 0.0248 |     - |     - |      40 B |
|  WithIndexSpecificEnumeratorLoopList |   100 |     862.67 ns |     1.9767 ns |     1.7523 ns | 11.46 |    0.09 |      - |     - |     - |         - |
|                                      |       |               |               |               |       |         |        |       |       |           |
|                       **RegularForLoop** |  **1000** |     **704.05 ns** |     **3.5087 ns** |     **3.1104 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                          ForEachLoop |  1000 |     594.27 ns |     3.1980 ns |     2.9914 ns |  0.84 |    0.00 |      - |     - |     - |         - |
|                        WithIndexLoop |  1000 |  14,265.50 ns |    47.1638 ns |    39.3839 ns | 20.26 |    0.10 | 0.0610 |     - |     - |     112 B |
|          WithIndexCachedDelegateLoop |  1000 |  14,151.59 ns |    17.2253 ns |    16.1126 ns | 20.10 |    0.08 | 0.0610 |     - |     - |     112 B |
|                WithIndexIteratorLoop |  1000 |  12,067.26 ns |    58.9621 ns |    52.2683 ns | 17.14 |    0.12 | 0.0458 |     - |     - |      96 B |
|        WithIndexCustomEnumeratorLoop |  1000 |   9,640.24 ns |    26.2846 ns |    21.9489 ns | 13.69 |    0.05 | 0.0153 |     - |     - |      32 B |
| WithIndexSpecificEnumeratorLoopArray |  1000 |   6,844.83 ns |    17.2629 ns |    16.1477 ns |  9.72 |    0.04 |      - |     - |     - |         - |
|                   RegularForLoopList |  1000 |   1,094.84 ns |    27.4160 ns |    22.8936 ns |  1.56 |    0.03 |      - |     - |     - |         - |
|                      ForEachLoopList |  1000 |   2,126.07 ns |    13.1167 ns |    12.2694 ns |  3.02 |    0.03 |      - |     - |     - |         - |
|                    WithIndexLoopList |  1000 |  15,403.61 ns |    37.0226 ns |    30.9155 ns | 21.88 |    0.09 | 0.0610 |     - |     - |     120 B |
|      WithIndexCachedDelegateLoopList |  1000 |  15,435.64 ns |   134.0825 ns |   118.8606 ns | 21.92 |    0.18 | 0.0610 |     - |     - |     120 B |
|            WithIndexIteratorLoopList |  1000 |  12,920.56 ns |    73.5482 ns |    65.1985 ns | 18.35 |    0.06 | 0.0610 |     - |     - |     104 B |
|    WithIndexCustomEnumeratorLoopList |  1000 |  10,562.63 ns |    39.9885 ns |    37.4053 ns | 15.00 |    0.10 | 0.0153 |     - |     - |      40 B |
|  WithIndexSpecificEnumeratorLoopList |  1000 |   8,414.32 ns |    13.9246 ns |    13.0251 ns | 11.95 |    0.06 |      - |     - |     - |         - |
|                                      |       |               |               |               |       |         |        |       |       |           |
|                       **RegularForLoop** | **10000** |   **7,015.39 ns** |    **59.7616 ns** |    **49.9036 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                          ForEachLoop | 10000 |   5,841.42 ns |    24.0700 ns |    22.5151 ns |  0.83 |    0.01 |      - |     - |     - |         - |
|                        WithIndexLoop | 10000 | 142,305.80 ns |   679.5454 ns |   602.3993 ns | 20.28 |    0.15 |      - |     - |     - |     112 B |
|          WithIndexCachedDelegateLoop | 10000 | 141,137.35 ns | 1,323.8123 ns | 1,238.2949 ns | 20.11 |    0.26 |      - |     - |     - |     112 B |
|                WithIndexIteratorLoop | 10000 | 120,804.36 ns |   560.9428 ns |   524.7063 ns | 17.22 |    0.15 |      - |     - |     - |      96 B |
|        WithIndexCustomEnumeratorLoop | 10000 |  96,032.36 ns |   177.1508 ns |   165.7070 ns | 13.69 |    0.09 |      - |     - |     - |      32 B |
| WithIndexSpecificEnumeratorLoopArray | 10000 |  68,525.07 ns |   123.2870 ns |   109.2907 ns |  9.77 |    0.06 |      - |     - |     - |         - |
|                   RegularForLoopList | 10000 |  10,830.09 ns |    18.4434 ns |    15.4011 ns |  1.54 |    0.01 |      - |     - |     - |         - |
|                      ForEachLoopList | 10000 |  20,976.38 ns |    76.7002 ns |    67.9927 ns |  2.99 |    0.02 |      - |     - |     - |         - |
|                    WithIndexLoopList | 10000 | 153,289.78 ns |   947.7729 ns |   886.5474 ns | 21.87 |    0.24 |      - |     - |     - |     120 B |
|      WithIndexCachedDelegateLoopList | 10000 | 153,241.20 ns |   602.7275 ns |   503.3048 ns | 21.84 |    0.18 |      - |     - |     - |     120 B |
|            WithIndexIteratorLoopList | 10000 | 128,684.03 ns |   869.2305 ns |   770.5502 ns | 18.33 |    0.15 |      - |     - |     - |     104 B |
|    WithIndexCustomEnumeratorLoopList | 10000 | 105,263.91 ns |   194.7628 ns |   182.1812 ns | 15.00 |    0.10 |      - |     - |     - |      40 B |
|  WithIndexSpecificEnumeratorLoopList | 10000 |  83,874.38 ns |   121.4005 ns |   107.6184 ns | 11.96 |    0.08 |      - |     - |     - |         - |
