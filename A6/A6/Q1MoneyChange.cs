using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q1MoneyChange: Processor
    {
        private static readonly int[] COINS = new int[] {1, 3, 4};

        public Q1MoneyChange(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);

        public long Solve(long n)
        {
			long[] money = new long[n + 1];
			money[0] = 0;

			for(long i = 1; i <= n; i++)
			{				
				List<long> list = new List<long>();

				foreach(var coin in COINS)
				{
					if (i >= coin)
						list.Add(money[i - coin] + 1);
				}
				money[i] = list.Min();
			}
			return money.Last();
        }
    }
}
