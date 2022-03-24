using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YieldReturnTest;

namespace LinqYieldReturnBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = BenchmarkRunner.Run<YieldBenchmarks>();
            Console.ReadLine();
        }
    }

}
