``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-8565U CPU 1.80GHz (Whiskey Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT


```
|            Method |    N |       Mean |      Error |     StdDev |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |----- |-----------:|-----------:|-----------:|--------:|------:|------:|----------:|
|  TestingArrayList | 1000 | 1,929.4 us | 18.8946 us | 16.7496 us | 13.6719 |     - |     - |  63.09 KB |
| TestingObjectList | 1000 | 2,092.7 us | 22.8327 us | 21.3577 us | 11.7188 |     - |     - |  63.09 KB |
|    TestingIntList | 1000 |   220.0 us |  0.9243 us |  0.8194 us |  1.9531 |     - |     - |   8.23 KB |
