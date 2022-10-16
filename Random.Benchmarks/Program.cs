using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.Emit;
using BenchmarkDotNet.Validators;
using Depra.Random.Benchmarks.Extensions;

namespace Depra.Random.Benchmarks;

public static class Program
{
    private static void Main()
    {
        BenchmarkRunner.Run<RandomizerExtensionsBenchmarks>(DefaultConfig.Instance
            .AddValidator(JitOptimizationsValidator.FailOnError)
            .AddJob(Job.Default.WithToolchain(InProcessEmitToolchain.Instance))
            .WithOrderer(new DefaultOrderer(SummaryOrderPolicy.FastestToSlowest)));
            
        // BenchmarkRunner.Run(typeof(Program).Assembly, DefaultConfig.Instance
        //     .AddValidator(JitOptimizationsValidator.FailOnError)
        //     .AddJob(Job.Default.WithToolchain(InProcessEmitToolchain.Instance))
        //     .WithOrderer(new DefaultOrderer(SummaryOrderPolicy.FastestToSlowest)));
    }
}