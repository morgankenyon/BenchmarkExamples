``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.7 (CoreCLR 4.6.28008.02, CoreFX 4.6.28008.03), 64bit RyuJIT


```
|                 Method |    N |      Mean |     Error |    StdDev |    Median |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |----- |----------:|----------:|----------:|----------:|--------:|------:|------:|----------:|
|      TestingSyncMethod | 1000 |  2.937 us | 0.0420 us | 0.0392 us |  2.930 us |  7.6256 |     - |     - |  23.44 KB |
| TestingSyncAsyncMethod | 1000 | 31.348 us | 1.2063 us | 3.3825 us | 30.310 us | 30.3040 |     - |     - |  93.12 KB |
