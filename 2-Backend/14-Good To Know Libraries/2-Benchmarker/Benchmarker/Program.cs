using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using System;
using System.Text;

namespace Benchmarker
{
    internal static class Program
    {
        public static void Main()
        {
            var results = BenchmarkRunner.Run<IntroDisassemblyRyuJit>();
        }
    }
}
