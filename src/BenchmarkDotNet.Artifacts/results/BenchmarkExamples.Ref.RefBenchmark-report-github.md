``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT


```
|          Method |   N |     Mean |    Error |   StdDev | Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |---- |---------:|---------:|---------:|------:|------:|------:|----------:|
| RegularAddition | 500 | 175.6 ns | 3.508 ns | 7.475 ns |     - |     - |     - |         - |
|     RefAddition | 500 | 242.7 ns | 4.636 ns | 4.337 ns |     - |     - |     - |         - |
