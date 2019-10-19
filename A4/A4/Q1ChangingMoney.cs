using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q1ChangingMoney : Processor
    {
        public Q1ChangingMoney(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);


        public virtual long Solve(long money)
		{
			var coins = new[] { 10, 5, 1 };
			long tenCount = money / coins[0];
			money %= coins[0];
			long fiveCount = money / coins[1];
			money %= coins[1];
			long oneCount = money / coins[2];

			return tenCount + fiveCount + oneCount;
		}
    }
}
