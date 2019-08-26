``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT


```
|           Method |     N |         Mean |        Error |       StdDev |       Median |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------- |------ |-------------:|-------------:|-------------:|-------------:|--------:|------:|------:|----------:|
|        **SumOneToN** |   **100** |     **43.46 ns** |     **1.355 ns** |     **3.822 ns** |     **42.86 ns** |       **-** |     **-** |     **-** |         **-** |
| DynamicSumOneToN |   100 |    730.79 ns |    14.481 ns |    38.653 ns |    728.45 ns |  0.7696 |     - |     - |    2424 B |
|        **SumOneToN** | **10000** |  **3,572.07 ns** |   **170.544 ns** |   **483.806 ns** |  **3,398.05 ns** |       **-** |     **-** |     **-** |         **-** |
| DynamicSumOneToN | 10000 | 66,913.28 ns | 1,318.762 ns | 2,922.286 ns | 66,290.49 ns | 76.2939 |     - |     - |  240024 B |
