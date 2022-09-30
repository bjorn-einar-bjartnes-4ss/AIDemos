using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Benchmarks
{
    public class ActivationFunctionBenchmarks
    {
        private Random _rnd;
        private double _rndValue;

        [GlobalSetup]
        public void Setup()
        {
            _rnd = new Random();
        }

        [IterationSetup]
        public void IterationSetup()
        {
            _rndValue= (_rnd.NextDouble() - 1.0) * 5.0;
        }


        [Benchmark]
        public void ReluBenchmark()
        {
            VotingData.Program.Relu(_rndValue);
        }

        [Benchmark]
        public void SigmoidBenchmark()
        {
            VotingData.Program.Sigmoid(_rndValue);
        }

        [Benchmark]
        public void JustRandom()
        {
            VotingData.Program.NoActivation(_rndValue);
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
