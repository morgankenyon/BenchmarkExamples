``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18362
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.6 (CoreCLR 4.6.27817.03, CoreFX 4.6.27818.02), 64bit RyuJIT


```
|                 Method |    N |        Mean |      Error |     StdDev |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|----------------------- |----- |------------:|-----------:|-----------:|--------:|-------:|------:|----------:|
|             TestNormal | 1000 |    24.80 us |  0.4956 us |  0.9308 us | 23.2544 |      - |     - |  71.45 KB |
|             TestBoxing | 1000 |    54.82 us |  1.0944 us |  2.0285 us | 47.6074 | 0.0610 |     - |  146.7 KB |
|          TestInterface | 1000 |    24.66 us |  0.4805 us |  0.4719 us | 23.2544 |      - |     - |  71.45 KB |
| TestBoxingAndInterface | 1000 |    59.77 us |  1.1883 us |  1.9524 us | 47.6074 | 0.1221 |     - |  146.7 KB |
|       TestingArrayList | 1000 | 2,237.95 us | 42.5661 us | 43.7123 us | 19.5313 |      - |     - |  63.09 KB |
|      TestingObjectList | 1000 | 1,825.73 us | 12.7165 us | 10.6188 us | 19.5313 |      - |     - |  63.09 KB |
|         TestingIntList | 1000 |   313.32 us |  5.6448 us |  5.7968 us |  2.4414 |      - |     - |   8.23 KB |
