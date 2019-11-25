``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT


```
|                               Method |     N |         Mean |        Error |       StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------- |------ |-------------:|-------------:|-------------:|------:|--------:|------:|------:|------:|----------:|
|                       **RegularForLoop** |   **100** |     **85.50 ns** |     **1.871 ns** |     **2.001 ns** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
| WithIndexSpecificEnumeratorLoopArray |   100 |    738.91 ns |    14.403 ns |    14.145 ns |  8.62 |    0.17 |     - |     - |     - |         - |
|                                      |       |              |              |              |       |         |       |       |       |           |
|                       **RegularForLoop** |  **1000** |    **775.28 ns** |    **15.350 ns** |    **33.370 ns** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
| WithIndexSpecificEnumeratorLoopArray |  1000 |  7,460.11 ns |   147.641 ns |   216.411 ns |  9.54 |    0.51 |     - |     - |     - |         - |
|                                      |       |              |              |              |       |         |       |       |       |           |
|                       **RegularForLoop** | **10000** |  **7,538.59 ns** |   **148.172 ns** |   **251.607 ns** |  **1.00** |    **0.00** |     **-** |     **-** |     **-** |         **-** |
| WithIndexSpecificEnumeratorLoopArray | 10000 | 73,774.65 ns | 1,454.560 ns | 2,264.574 ns |  9.76 |    0.40 |     - |     - |     - |         - |
