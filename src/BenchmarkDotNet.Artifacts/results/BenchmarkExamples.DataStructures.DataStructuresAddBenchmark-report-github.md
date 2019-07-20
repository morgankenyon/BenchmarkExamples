``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.557 (1809/October2018Update/Redstone5)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT


```
|        Method |   N |        Mean |     Error |     StdDev |      Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------- |---- |------------:|----------:|-----------:|------------:|-------:|------:|------:|----------:|
|      ArrayAdd | 100 |    94.44 ns |  3.694 ns |  10.418 ns |    88.19 ns | 0.1347 |     - |     - |     424 B |
|       ListAdd | 100 |   400.20 ns | 16.805 ns |  48.753 ns |   380.19 ns | 0.3786 |     - |     - |    1192 B |
|  SizedListAdd | 100 |   188.73 ns |  3.817 ns |   9.072 ns |   184.91 ns | 0.1473 |     - |     - |     464 B |
|    HashSetAdd | 100 | 2,218.69 ns | 22.727 ns |  20.147 ns | 2,221.05 ns | 1.9035 |     - |     - |    6000 B |
| DictionaryAdd | 100 | 2,200.68 ns | 48.173 ns | 134.287 ns | 2,157.06 ns | 2.3460 |     - |     - |    7392 B |
