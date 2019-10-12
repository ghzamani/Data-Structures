using System;
using System.Collections.Generic;
using TestCommon;

namespace A3
{
    public class Q6FibonacciMod : Processor
    {
        public Q6FibonacciMod(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
        {
			List<long> remainders = new List<long>();
			//دنباله پیزانو با مد 
			//b
			remainders.Add(0);
			remainders.Add(1);

			for (int i = 2; ; i++)
			{
				long rem = (remainders[i - 1] + remainders[i - 2]) % b;

				if ((rem == 1) &&
					(remainders[i - 1] == 0))
				{
					remainders.RemoveAt(i - 1);
					break;
				}
				remainders.Add(rem);
			}

			return remainders[(int)(a % remainders.Count)];
        }
    }
}
