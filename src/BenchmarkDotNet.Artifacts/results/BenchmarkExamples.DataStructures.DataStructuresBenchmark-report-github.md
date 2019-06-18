``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.557 (1809/October2018Update/Redstone5)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT


```
|                       Method |   N |         Mean |      Error |     StdDev |       Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |---- |-------------:|-----------:|-----------:|-------------:|-------:|------:|------:|----------:|
|                     ArrayAdd | 100 |     85.08 ns |   2.003 ns |   5.713 ns |     82.32 ns | 0.1347 |     - |     - |     424 B |
|                      ListAdd | 100 |    357.73 ns |   9.272 ns |  18.517 ns |    350.57 ns | 0.3786 |     - |     - |    1192 B |
|                 SizedListAdd | 100 |    185.68 ns |   3.513 ns |   2.933 ns |    186.93 ns | 0.1473 |     - |     - |     464 B |
|                   HashSetAdd | 100 |  2,152.94 ns |  47.110 ns |  62.891 ns |  2,128.06 ns | 1.9035 |     - |     - |    6000 B |
|                LinkedListAdd | 100 |  1,529.46 ns |  28.701 ns |  26.847 ns |  1,534.72 ns | 1.5392 |     - |     - |    4848 B |
|                 ArrayListAdd | 100 |  1,365.87 ns |  66.714 ns | 196.708 ns |  1,305.91 ns | 1.4610 |     - |     - |    4600 B |
|                DictionaryAdd | 100 |  2,244.36 ns |  49.513 ns | 102.253 ns |  2,206.77 ns | 2.3460 |     - |     - |    7392 B |
| ArrayAddIfUniqueUnknownIndex | 100 |  7,220.36 ns |  89.312 ns |  79.172 ns |  7,251.59 ns | 0.1297 |     - |     - |     424 B |
|   ArrayAddIfUniqueKnownIndex | 100 |     98.17 ns |   3.693 ns |  10.536 ns |     92.58 ns | 0.1347 |     - |     - |     424 B |
|              ListAddIfUnique | 100 |  5,016.25 ns | 100.014 ns | 283.723 ns |  5,010.16 ns | 0.3738 |     - |     - |    1192 B |
|         SizedListAddIfUnique | 100 |  4,682.19 ns |  92.637 ns | 203.340 ns |  4,588.05 ns | 0.1450 |     - |     - |     464 B |
|           HashSetAddIfUnique | 100 |  3,408.85 ns |  34.343 ns |  28.678 ns |  3,415.20 ns | 1.9035 |     - |     - |    6000 B |
|        LinkedListAddIfUnique | 100 | 12,306.68 ns | 244.921 ns | 521.946 ns | 12,053.42 ns | 1.5259 |     - |     - |    4848 B |
|         ArrayListAddIfUnique | 100 | 29,287.56 ns | 550.869 ns | 889.550 ns | 28,905.20 ns | 2.1973 |     - |     - |    7000 B |
|        DictionaryAddIfUnique | 100 |  3,197.07 ns |  19.445 ns |  16.237 ns |  3,197.25 ns | 2.3460 |     - |     - |    7392 B |
|            ArrayAddAndRemove | 100 | 11,618.57 ns | 242.869 ns | 501.566 ns | 11,360.12 ns | 0.1221 |     - |     - |     424 B |
|             ListAddAndRemove | 100 |  2,376.22 ns |  49.551 ns |  64.430 ns |  2,361.51 ns | 0.3777 |     - |     - |    1192 B |
|        SizedListAddAndRemove | 100 |  2,155.64 ns |  42.750 ns |  94.731 ns |  2,106.61 ns | 0.1450 |     - |     - |     464 B |
|          HashSetAddAndRemove | 100 |  4,141.28 ns |  59.954 ns |  53.148 ns |  4,123.29 ns | 1.8997 |     - |     - |    6000 B |
|          LinkedListAddRemove | 100 |  3,021.27 ns |  83.048 ns | 158.008 ns |  2,950.35 ns | 1.5373 |     - |     - |    4848 B |
|           ArrayListAddRemove | 100 |  9,156.60 ns |  40.862 ns |  36.223 ns |  9,155.12 ns | 2.2125 |     - |     - |    7000 B |
|          DictionaryAddRemove | 100 |  3,724.62 ns | 140.497 ns | 412.052 ns |  3,577.86 ns | 2.3460 |     - |     - |    7392 B |
