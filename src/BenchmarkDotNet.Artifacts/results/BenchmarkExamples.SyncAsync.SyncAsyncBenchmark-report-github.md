``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT


```
|                 Method |     N |       Mean |     Error |     StdDev |     Median |    Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |------ |-----------:|----------:|-----------:|-----------:|---------:|------:|------:|----------:|
|      **TestingSyncMethod** |  **1000** |   **4.282 us** | **0.0938 us** |  **0.2735 us** |   **4.258 us** |   **7.6218** |     **-** |     **-** |  **23.44 KB** |
| TestingSyncAsyncMethod |  1000 |  35.206 us | 1.0723 us |  1.2348 us |  34.858 us |  30.2734 |     - |     - |  93.12 KB |
|      **TestingSyncMethod** |  **5000** |  **21.333 us** | **0.5167 us** |  **1.4402 us** |  **20.896 us** |  **38.1165** |     **-** |     **-** | **117.19 KB** |
| TestingSyncAsyncMethod |  5000 | 182.263 us | 4.4757 us | 12.9847 us | 182.059 us | 152.3438 |     - |     - | 468.12 KB |
|      **TestingSyncMethod** | **10000** |  **45.021 us** | **0.9646 us** |  **2.7522 us** |  **44.505 us** |  **76.2329** |     **-** |     **-** | **234.38 KB** |
| TestingSyncAsyncMethod | 10000 | 351.563 us | 6.9928 us | 18.6652 us | 348.298 us | 304.6875 |     - |     - | 936.87 KB |
