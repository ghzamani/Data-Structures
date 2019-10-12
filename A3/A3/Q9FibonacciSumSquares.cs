using System;
using TestCommon;

namespace A3
{
    public class Q9FibonacciSumSquares : Processor
    {
        public Q9FibonacciSumSquares(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
			Q6FibonacciMod fibMod = new Q6FibonacciMod(null);

			long nthFibMod = fibMod.Solve(n, 10);
			long nMinusOneFibMod = fibMod.Solve(n-1, 10);

			return (nthFibMod + nMinusOneFibMod) * nthFibMod % 10;			
        }
    }
}
