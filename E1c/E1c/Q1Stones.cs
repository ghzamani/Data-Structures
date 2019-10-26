using System;
using TestCommon;

namespace E1a
{
    public class Q1Stones : Processor
    {
        public Q1Stones(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);


        public virtual long Solve(long n, long[] stones)
        {
			long sum = 0;
			for(int i = 0; i < stones.Length; i++)
			{
				sum += stones[i];

				if (n == sum)
					return i + 1;

				if (n > sum)
				{
					if (i == stones.Length - 1)
						return 0;

					if(n < sum + stones[i + 1])
						return i + 2;
				}

				if (n < sum)
					return 1;
			}

			return 0;
        }
    }
}
