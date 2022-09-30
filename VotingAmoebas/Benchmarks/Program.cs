using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Benchmarks
{
    public class ActivationFunctionBenchmarks
    {
        private Random _rnd;

        [GlobalSetup]
        public void Setup()
        {
            _rnd = new Random();
        }


        [Benchmark]
        public void ReluBenchmark()
        {
            var input = (_rnd.NextDouble() - 1.0) * 5.0;
            VotingData.Program.Relu(input);
        }

        [Benchmark]
        public void SigmoidBenchmark()
        {
            var input = (_rnd.NextDouble() - 1.0) * 5.0;
            VotingData.Program.Sigmoid(input);
        }

        [Benchmark]
        public void JustRandom()
        {
            var input = (_rnd.NextDouble() - 1.0) * 5.0;
            VotingData.Program.NoActivation(input);
        }
     }

    internal class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ActivationFunctionBenchmarks>();
            Console.Write(summary);
        }
    }
}
