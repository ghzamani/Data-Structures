using System;
using TestCommon;

namespace A3
{
    public class Q2FibonacciFast : Processor
    {
        public Q2FibonacciFast(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
			long[] fib = new long[n + 2];
			fib[0] = 0;
			fib[1] = 1;

			for(int i = 2; i <= n; i++)
			{
				fib[i] = fib[i - 1] + fib[i - 2];
			}
			return fib[n];
        }
    }
}
