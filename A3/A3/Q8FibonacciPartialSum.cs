using System;
using System.Collections.Generic;
using TestCommon;

namespace A3
{
    public class Q8FibonacciPartialSum : Processor
    {
        public Q8FibonacciPartialSum(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        public long Solve(long a, long b)
		{
			if (a == b)
				return new Q2FibonacciFast(null).Solve(a) % 10;

			if (b < a)
				(a, b) = (b, a);
			//a should be smaller than b

			List<long> remainders = new List<long>();
			//دنباله پیزانو
			remainders.Add(0);
			remainders.Add(1);

			long sumOfPisano = 0;
			//last digit of sum of numbers in pisano period

			for (int i = 2; ; i++)
			{
				long rem = (remainders[i - 1] + remainders[i - 2]) % 10;

				if ((rem == 1) && (remainders[i - 1] == 0))
				{
					remainders.RemoveAt(i - 1);
					break;
				}
				remainders.Add(rem);
			}
			int remaindersLength = remainders.Count;
			remainders.ForEach(x => sumOfPisano += x);
			sumOfPisano %= 10;

			int aCount = (int)(a / remaindersLength);			
			int bCount = (int)(b / remaindersLength);
			//a,b dar chandomin daste az pisano gharar migirand

			int senCountA = (int)(a % remaindersLength);
			int senCountB = (int)(b % remaindersLength);
			//a,b chandomin jomle az donbaleye khod hastand			

			long result = (bCount - aCount) * sumOfPisano % 10;
			for (int i = senCountA; i < remaindersLength; i++)
				result += remainders[i];
			for (int i = 0; i <= senCountB; i++)
				result += remainders[i];
			return result % 10;						
		}
    }
}
