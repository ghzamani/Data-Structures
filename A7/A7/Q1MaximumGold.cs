using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q1MaximumGold : Processor
    {
        public Q1MaximumGold(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long W, long[] goldBars)
        {
			long[,] values = new long[goldBars.Length + 1, W + 1];

			for (int i = 0; i <= W; i++)
				values[0, i] = 0;
			for (int i = 1; i <= goldBars.Length; i++)
				values[i, 0] = 0;

			for(int i = 1; i <= goldBars.Length; i++)
			{
				for(int j = 1; j <= W; j++)
				{
					if (j >= goldBars[i - 1])
					{
						values[i, j] = Math.Max(values[i - 1, j - goldBars[i - 1]] + goldBars[i - 1],
							values[i - 1, j]);
					}
					else values[i, j] = values[i - 1, j];
				}
			}
			return values[goldBars.Length, W];
        }
    }
}
