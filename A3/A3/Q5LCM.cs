using System;
using TestCommon;

namespace A3
{
    public class Q5LCM : Processor
    {
        public Q5LCM(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
			Q4GCD _gcd = new Q4GCD(null);
			long gcd = _gcd.Solve(a, b);
			return a * b / gcd;
        }
    }
}
