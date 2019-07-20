``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT


```
|            Method |    N |       Mean |     Error |    StdDev |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |----- |-----------:|----------:|----------:|--------:|------:|------:|----------:|
|  TestingArrayList | 1000 | 2,432.9 us | 54.703 us | 152.49 us | 19.5313 |     - |     - |  63.09 KB |
| TestingObjectList | 1000 | 2,031.4 us | 68.747 us | 199.45 us | 19.5313 |     - |     - |  63.09 KB |
|    TestingIntList | 1000 |   340.3 us |  8.701 us |  25.38 us |  2.4414 |     - |     - |   8.23 KB |
