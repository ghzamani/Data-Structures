using System;
using TestCommon;

namespace A3
{
    public class Q3FibonacciLastDigit : Processor
    {
        public Q3FibonacciLastDigit(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
			int[] fib = new int[n + 1];

			if (n == 0)
				return 0;
			
			fib[0] = 0;
			fib[1] = 1;

			for(int i = 2; i <= n; i++)
			{
				fib[i] = (fib[i - 1] + fib[i - 2]) % 10;
			}

			return fib[n];
		}
    }
}
