``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.17763.503 (1809/October2018Update/Redstone5)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT


```
|     Method |     N |       Mean |     Error |    StdDev | Ratio | RatioSD |      Gen 0 | Gen 1 | Gen 2 |    Allocated |
|----------- |------ |-----------:|----------:|----------:|------:|--------:|-----------:|------:|------:|-------------:|
|   **JsonTest** |   **100** |   **2.009 ms** | **0.0382 ms** | **0.0339 ms** |  **1.10** |    **0.05** |   **570.3125** |     **-** |     **-** |   **1760.94 KB** |
| ObjectTest |   100 |   1.804 ms | 0.0355 ms | 0.0543 ms |  1.00 |    0.00 |   169.9219 |     - |     - |    528.13 KB |
|            |       |            |           |           |       |         |            |       |       |              |
|   **JsonTest** | **10000** | **202.443 ms** | **1.8458 ms** | **1.7266 ms** |  **1.15** |    **0.02** | **57000.0000** |     **-** |     **-** | **176093.75 KB** |
| ObjectTest | 10000 | 175.646 ms | 3.0549 ms | 2.8575 ms |  1.00 |    0.00 | 17000.0000 |     - |     - |   52812.5 KB |
