using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A3
{
    public class Q1MergeSort : Processor
    {
        public Q1MergeSort(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public long[] Solve(long n, long[] a)
        {
			int mid = (int)n / 2;

			long[] sorted = new long[n];

			if (n == 1)
			{
				return new long[] { a[0] };
			}
			else
			{
				long[] firstPart = Solve(mid, a.ToList().Take(mid).ToArray());
				long[] secPart = Solve(n - mid, a.ToList().Skip(mid).ToArray());

				sorted = Merge(firstPart, secPart);
			}
			return sorted;
        }

		public long[] Merge(long[] firstPart, long[] secPart)
		{
			long[] result = new long[firstPart.Length + secPart.Length];
			int i = 0; //for iterating in firstPart
			int j = 0; //for iterating in secPart
			int k = 0; //for iterating in result

			while (i<firstPart.Length && j<secPart.Length)
			{
				if(firstPart[i] <= secPart[j])
				{
					result[k] = firstPart[i];
					i++;
				}
				else
				{
					result[k] = secPart[j];
					j++;
				}
				k++;
			}

			for(int a = i; a < firstPart.Length; a++)
			{
				result[k] = firstPart[a];
				k++;
			}

			for(int b = j; b < secPart.Length; b++)
			{
				result[k] = secPart[b];
				k++;
			}
			
			return result;
		}
	}
}
