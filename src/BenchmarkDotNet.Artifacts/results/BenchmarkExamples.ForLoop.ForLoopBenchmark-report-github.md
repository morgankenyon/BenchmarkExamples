``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i5-7300U CPU 2.60GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT


```
|                               Method |     N |          Mean |       Error |      StdDev |        Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------- |------ |--------------:|------------:|------------:|--------------:|------:|--------:|-------:|------:|------:|----------:|
|                       **RegularForLoop** |   **100** |      **41.34 ns** |   **0.8616 ns** |   **1.9796 ns** |      **41.72 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                          ForEachLoop |   100 |      65.87 ns |   1.3507 ns |   3.3385 ns |      64.25 ns |  1.60 |    0.10 |      - |     - |     - |         - |
|                        WithIndexLoop |   100 |   1,461.12 ns |   6.1526 ns |   5.7552 ns |   1,461.69 ns | 34.74 |    0.94 | 0.0706 |     - |     - |     112 B |
|          WithIndexCachedDelegateLoop |   100 |   1,464.82 ns |   6.6471 ns |   6.2177 ns |   1,463.35 ns | 34.83 |    0.99 | 0.0706 |     - |     - |     112 B |
|                WithIndexIteratorLoop |   100 |   1,159.69 ns |   5.9494 ns |   5.5650 ns |   1,158.54 ns | 27.57 |    0.75 | 0.0591 |     - |     - |      96 B |
|        WithIndexCustomEnumeratorLoop |   100 |     848.43 ns |   3.3475 ns |   2.9675 ns |     848.06 ns | 20.26 |    0.47 | 0.0200 |     - |     - |      32 B |
| WithIndexSpecificEnumeratorLoopArray |   100 |     549.90 ns |   1.4711 ns |   1.3041 ns |     550.00 ns | 13.13 |    0.31 |      - |     - |     - |         - |
|                   RegularForLoopList |   100 |      41.42 ns |   1.3196 ns |   3.8073 ns |      39.10 ns |  1.04 |    0.12 |      - |     - |     - |         - |
|                      ForEachLoopList |   100 |     226.17 ns |   4.3938 ns |   5.7131 ns |     229.54 ns |  5.41 |    0.26 |      - |     - |     - |         - |
|                    WithIndexLoopList |   100 |   1,622.57 ns |  10.7027 ns |   9.4877 ns |   1,620.38 ns | 38.75 |    1.13 | 0.0744 |     - |     - |     120 B |
|      WithIndexCachedDelegateLoopList |   100 |   1,622.22 ns |  13.9653 ns |  13.0632 ns |   1,623.70 ns | 38.57 |    1.05 | 0.0744 |     - |     - |     120 B |
|            WithIndexIteratorLoopList |   100 |   1,402.59 ns |  20.6560 ns |  18.3110 ns |   1,392.24 ns | 33.49 |    0.95 | 0.0648 |     - |     - |     104 B |
|    WithIndexCustomEnumeratorLoopList |   100 |     998.74 ns |  79.8885 ns |  74.7278 ns |     968.86 ns | 23.73 |    1.72 | 0.0248 |     - |     - |      40 B |
|  WithIndexSpecificEnumeratorLoopList |   100 |     777.35 ns |   0.9606 ns |   0.7499 ns |     777.58 ns | 18.62 |    0.43 |      - |     - |     - |         - |
|                                      |       |               |             |             |               |       |         |        |       |       |           |
|                       **RegularForLoop** |  **1000** |     **301.18 ns** |   **1.5289 ns** |   **1.4301 ns** |     **300.75 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                          ForEachLoop |  1000 |     587.45 ns |   2.9649 ns |   2.7733 ns |     587.36 ns |  1.95 |    0.01 |      - |     - |     - |         - |
|                        WithIndexLoop |  1000 |  14,105.96 ns |  69.9420 ns |  54.6061 ns |  14,102.36 ns | 46.88 |    0.28 | 0.0610 |     - |     - |     112 B |
|          WithIndexCachedDelegateLoop |  1000 |  14,161.45 ns |  68.7005 ns |  57.3681 ns |  14,148.71 ns | 47.05 |    0.21 | 0.0610 |     - |     - |     112 B |
|                WithIndexIteratorLoop |  1000 |  11,182.91 ns |  50.0185 ns |  41.7677 ns |  11,176.61 ns | 37.15 |    0.21 | 0.0458 |     - |     - |      96 B |
|        WithIndexCustomEnumeratorLoop |  1000 |   8,413.37 ns |  38.1557 ns |  33.8240 ns |   8,404.43 ns | 27.93 |    0.20 | 0.0153 |     - |     - |      32 B |
| WithIndexSpecificEnumeratorLoopArray |  1000 |   5,498.21 ns |  11.3172 ns |  10.5861 ns |   5,497.66 ns | 18.26 |    0.11 |      - |     - |     - |         - |
|                   RegularForLoopList |  1000 |     299.75 ns |   1.1355 ns |   1.0066 ns |     299.78 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                      ForEachLoopList |  1000 |   2,055.30 ns |   8.8853 ns |   8.3113 ns |   2,052.61 ns |  6.82 |    0.04 |      - |     - |     - |         - |
|                    WithIndexLoopList |  1000 |  15,297.98 ns | 132.5053 ns | 123.9456 ns |  15,280.84 ns | 50.79 |    0.42 | 0.0610 |     - |     - |     120 B |
|      WithIndexCachedDelegateLoopList |  1000 |  15,234.49 ns |  56.3662 ns |  49.9671 ns |  15,233.94 ns | 50.58 |    0.29 | 0.0610 |     - |     - |     120 B |
|            WithIndexIteratorLoopList |  1000 |  12,867.67 ns |  52.6312 ns |  43.9495 ns |  12,867.46 ns | 42.75 |    0.20 | 0.0610 |     - |     - |     104 B |
|    WithIndexCustomEnumeratorLoopList |  1000 |   9,585.65 ns |  34.3980 ns |  30.4930 ns |   9,574.52 ns | 31.82 |    0.19 | 0.0153 |     - |     - |      40 B |
|  WithIndexSpecificEnumeratorLoopList |  1000 |   7,527.56 ns |  20.2614 ns |  18.9525 ns |   7,520.48 ns | 24.99 |    0.08 |      - |     - |     - |         - |
|                                      |       |               |             |             |               |       |         |        |       |       |           |
|                       **RegularForLoop** | **10000** |   **2,914.63 ns** |   **7.8017 ns** |   **6.9160 ns** |   **2,914.80 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|                          ForEachLoop | 10000 |   5,835.68 ns |  40.0818 ns |  35.5315 ns |   5,819.61 ns |  2.00 |    0.01 |      - |     - |     - |         - |
|                        WithIndexLoop | 10000 | 140,303.27 ns | 487.2530 ns | 431.9371 ns | 140,321.59 ns | 48.14 |    0.21 |      - |     - |     - |     112 B |
|          WithIndexCachedDelegateLoop | 10000 | 140,874.43 ns | 436.0567 ns | 407.8877 ns | 140,844.80 ns | 48.35 |    0.18 |      - |     - |     - |     112 B |
|                WithIndexIteratorLoop | 10000 | 111,385.43 ns | 299.8157 ns | 280.4478 ns | 111,285.28 ns | 38.20 |    0.13 |      - |     - |     - |      96 B |
|        WithIndexCustomEnumeratorLoop | 10000 |  83,798.31 ns | 252.7530 ns | 236.4253 ns |  83,709.16 ns | 28.75 |    0.11 |      - |     - |     - |      32 B |
| WithIndexSpecificEnumeratorLoopArray | 10000 |  55,200.43 ns | 656.8261 ns | 548.4796 ns |  55,019.55 ns | 18.94 |    0.19 |      - |     - |     - |         - |
|                   RegularForLoopList | 10000 |   2,996.71 ns | 109.9978 ns | 171.2534 ns |   2,923.15 ns |  1.06 |    0.08 |      - |     - |     - |         - |
|                      ForEachLoopList | 10000 |  21,239.14 ns | 424.2575 ns | 488.5756 ns |  21,447.20 ns |  7.26 |    0.19 |      - |     - |     - |         - |
|                    WithIndexLoopList | 10000 | 151,685.63 ns | 754.2991 ns | 705.5719 ns | 151,350.83 ns | 52.06 |    0.33 |      - |     - |     - |     120 B |
|      WithIndexCachedDelegateLoopList | 10000 | 152,174.19 ns | 429.9120 ns | 381.1058 ns | 152,012.60 ns | 52.21 |    0.18 |      - |     - |     - |     120 B |
|            WithIndexIteratorLoopList | 10000 | 127,792.32 ns | 243.8076 ns | 190.3489 ns | 127,818.14 ns | 43.83 |    0.14 |      - |     - |     - |     104 B |
|    WithIndexCustomEnumeratorLoopList | 10000 |  95,605.27 ns | 308.5503 ns | 288.6182 ns |  95,600.13 ns | 32.79 |    0.13 |      - |     - |     - |      40 B |
|  WithIndexSpecificEnumeratorLoopList | 10000 |  75,147.30 ns | 315.0366 ns | 294.6854 ns |  75,009.88 ns | 25.79 |    0.14 |      - |     - |     - |         - |
