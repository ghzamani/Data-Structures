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
		}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);
			   		
		public virtual long Solve(long nr, long dr)
        {
			if (nr % dr == 0)
				return 1;

			while (nr > dr)
			{
				nr -= dr;
			}

			while (true)
			{
				long x = (long) Math.Ceiling((double)dr / nr);
				if (x * nr == dr)
					return x;

				nr = x * nr - dr;
				dr = x * dr;

				long gcd = GCD(dr, nr);
				nr /= gcd;
				dr /= gcd;

				if (nr == 1)
					return dr;
			}
		}

		public long GCD(long a, long b)
		{
			if (a < b)
				(a, b) = (b, a);

			if (b == 0)
				return a;

			return GCD(b, a % b);
		}


	}
}
