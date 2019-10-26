using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace E1b
{
    public class Q4HungryFrog : Processor
    {
        public Q4HungryFrog(string testDataName) : base(testDataName)
        {			
		}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long>)Solve);

		public virtual long Solve(long n, long p, long[][] numbers)
		{			
			for (int i = 1; i < n ; i++)
			{
				numbers[0][i] = Math.Max(numbers[0][i - 1] + numbers[0][i],
					numbers[1][i - 1] + numbers[0][i] - p);

				numbers[1][i] = Math.Max(numbers[1][i - 1] + numbers[1][i],
					numbers[0][i - 1] + numbers[1][i] - p);
			}
			return Math.Max(numbers[0][n - 1], numbers[1][n - 1]);
        }	
		
	}
}
