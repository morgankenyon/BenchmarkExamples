``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-8565U CPU 1.80GHz (Whiskey Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT


```
|            Method |    N |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |----- |----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|        **ListAsList** |  **100** |  **1.173 us** | **0.0199 us** | **0.0166 us** |  **1.00** |    **0.00** |  **1.0948** |     **-** |     **-** |   **4.49 KB** |
|  CollectionToList |  100 |  2.326 us | 0.0526 us | 0.0894 us |  2.02 |    0.08 |  1.3084 |     - |     - |   5.37 KB |
|       IListToList |  100 |  1.453 us | 0.0290 us | 0.0367 us |  1.24 |    0.04 |  1.3008 |     - |     - |   5.34 KB |
| IEnumerableToList |  100 |  1.426 us | 0.0065 us | 0.0058 us |  1.22 |    0.02 |  1.3008 |     - |     - |   5.34 KB |
| ICollectionToList |  100 |  1.396 us | 0.0235 us | 0.0208 us |  1.19 |    0.02 |  1.3008 |     - |     - |   5.34 KB |
|                   |      |           |           |           |       |         |         |       |       |           |
|        **ListAsList** | **1000** | **10.540 us** | **0.1164 us** | **0.0972 us** |  **1.00** |    **0.00** |  **9.6741** |     **-** |     **-** |  **39.66 KB** |
|  CollectionToList | 1000 | 19.156 us | 0.3370 us | 0.2987 us |  1.82 |    0.03 | 11.5967 |     - |     - |  47.56 KB |
|       IListToList | 1000 | 11.256 us | 0.1546 us | 0.1446 us |  1.07 |    0.02 | 11.5967 |     - |     - |  47.53 KB |
| IEnumerableToList | 1000 | 11.290 us | 0.1328 us | 0.1242 us |  1.07 |    0.02 | 11.5967 |     - |     - |  47.53 KB |
| ICollectionToList | 1000 | 11.369 us | 0.1291 us | 0.1144 us |  1.08 |    0.01 | 11.5967 |     - |     - |  47.53 KB |
