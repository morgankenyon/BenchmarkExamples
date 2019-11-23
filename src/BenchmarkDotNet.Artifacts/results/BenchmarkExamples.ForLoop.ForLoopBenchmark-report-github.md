``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT


```
|             Method |     N |          Mean |         Error |       StdDev |        Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------- |------ |--------------:|--------------:|-------------:|--------------:|------:|--------:|-------:|------:|------:|----------:|
| **RegularForLoopList** |   **100** |      **41.04 ns** |     **0.8523 ns** |     **1.992 ns** |      **41.07 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|    ForEachLoopList |   100 |     286.49 ns |    11.0725 ns |    30.311 ns |     277.18 ns |  6.90 |    0.86 |      - |     - |     - |         - |
|  WithIndexLoopList |   100 |   1,732.95 ns |    70.2421 ns |   194.641 ns |   1,684.89 ns | 43.41 |    5.83 | 0.0362 |     - |     - |     120 B |
|                    |       |               |               |              |               |       |         |        |       |       |           |
| **RegularForLoopList** |  **1000** |     **301.63 ns** |     **4.3935 ns** |     **3.430 ns** |     **301.97 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|    ForEachLoopList |  1000 |   2,103.98 ns |    42.0818 ns |    76.949 ns |   2,072.54 ns |  7.29 |    0.26 |      - |     - |     - |         - |
|  WithIndexLoopList |  1000 |  15,567.89 ns |   340.9037 ns |   477.899 ns |  15,433.87 ns | 52.20 |    2.10 | 0.0305 |     - |     - |     120 B |
|                    |       |               |               |              |               |       |         |        |       |       |           |
| **RegularForLoopList** | **10000** |   **3,019.14 ns** |    **59.4111 ns** |   **110.122 ns** |   **2,968.64 ns** |  **1.00** |    **0.00** |      **-** |     **-** |     **-** |         **-** |
|    ForEachLoopList | 10000 |  20,514.23 ns |   329.8460 ns |   275.436 ns |  20,598.59 ns |  6.62 |    0.31 |      - |     - |     - |         - |
|  WithIndexLoopList | 10000 | 158,681.68 ns | 3,153.6309 ns | 6,298.142 ns | 156,291.72 ns | 52.72 |    2.48 |      - |     - |     - |     120 B |
