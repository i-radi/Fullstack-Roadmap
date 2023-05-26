using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using System;
using System.Text;

namespace Benchmarker
{
    //[SimpleJob(RuntimeMoniker.Net60, baseline: true)]
    [SimpleJob(RuntimeMoniker.Net50)]
    [MemoryDiagnoser(false)]
    public class Demo
    {
        [Params(10, 50, 100)]
        public int N;

        //[GlobalSetup]
        //public void Setup()
        //{
        //}
        //private class Config : ManualConfig
        //{
        //    public Config()
        //    {
        //        AddJob(Job.Dry);
        //        AddColumn(new TagColumn("Kind", name => name.Substring(0, 3)));
        //        AddColumn(new TagColumn("Number", name => name.Substring(3)));
        //    }
        //}
        [Benchmark(Baseline = true)]
        public string GetFullStringNormally()
        {
            string output = "";

            for (int i = 0; i < N; i++)
            {
                output += i;
            }

            return output;
        }

        [Benchmark]
        public string GetFullStringWithStringBuilder()
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < N; i++)
            {
                output.Append(i);
            }

            return output.ToString();
        }
    }
}
