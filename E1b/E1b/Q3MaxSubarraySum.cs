﻿using System;
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
			long res = 0;
			for(int i = 0; i < n; i++)
			{
				for(int j = i + 1; j < n; j++)
				{

				}
			}
			throw new NotImplementedException();
			
        }
    }
}
