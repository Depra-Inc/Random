// using System;
// using BenchmarkDotNet.Attributes;
// using Depra.Random.System;
//
// namespace Depra.Random.Benchmarks
// {
//     [MemoryDiagnoser]
//     public class ExperimentBenchmarks
//     {
//         [Benchmark]
//         public long NextLong1()
//         {
//             var buffer = new byte[8];
//             new global::System.Random().NextBytes(buffer);
//             return (long) BitConverter.ToUInt64(buffer, 0);
//         }
//
//         [Benchmark]
//         public long NextLong2()
//         {
//             return new global::System.Random().NextLong();
//         }
//     }
// }