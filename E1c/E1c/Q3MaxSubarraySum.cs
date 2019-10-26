using System;
using TestCommon;

namespace E1b
{
    public class Q3MaxSubarraySum : Processor
    {
        public Q3MaxSubarraySum(string testDataName) : base(testDataName)
        {			
		}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public virtual long Solve(long n, long[] numbers)
        {
			long sum = 0;
			long maxValue = long.MinValue;
			
			foreach(var num in numbers)
			{
				sum += num;
				if (sum < 0)
					sum = 0;
				if (sum > maxValue)
					maxValue = sum;
			}
			return maxValue;		
			
        }
    }
}
