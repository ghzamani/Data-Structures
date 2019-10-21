using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace E1a
{
    public class Q2UnitFractions : Processor
    {
        public Q2UnitFractions(string testDataName) : base(testDataName)
        {
			this.ExcludeTestCaseRangeInclusive(18, 40);
		}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);


		long lastNum = 0;
		long result;
		public virtual long Solve(long nr, long dr)
        {

			double frac = (double)nr / dr;
			long lastNum = 1;
					   
			if (nr % dr == 0)
				return 1;

			for (long i = lastNum + 1; ; i++)
			{
				if (dr % nr == 0)
				{
					result = dr / nr;
					break;
				}

				if (frac < (double)1 / i)
				{
					continue;
				}

				else
				{
					frac = frac - (double)1 / i;
					lastNum = i;
					Solve(i * nr - dr, i * dr);
					break;
				}
			}
			lastNum = 1;
			return result;
		}

		
    }
}
