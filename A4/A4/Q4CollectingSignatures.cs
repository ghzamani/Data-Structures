using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q4CollectingSignatures : Processor
    {
        public Q4CollectingSignatures(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long tenantCount, long[] startTimes, long[] endTimes)
        {
			List<long> start = startTimes.ToList();
			List<long> end = endTimes.ToList();
			long result = 0;

			while(start.Count() != 0)
			{
				int minIndex = IndexOfMinStartTime(end);
				long endMinIndex = end[minIndex];
				List<int> toRemove = new List<int>();

				for(int i=0; i < tenantCount; i++)
					
					if ((start[i] <= endMinIndex) &&
						(end[i] >= endMinIndex))
						toRemove.Add(i);	
									
				foreach(var a in toRemove.OrderByDescending(x => x))
				{
					start.RemoveAt(a);
					end.RemoveAt(a);
				}
				result++;
				tenantCount -= toRemove.Count();
			}
            return result;
        }

		public int IndexOfMinStartTime(List<long> start)
		{
			long min = long.MaxValue;
			int idx = 0;
			for(int i = 0; i < start.Count; i++)
			{
				if(start[i] < min)
				{
					min = start[i];
					idx = i;
				}
			}
			return idx;
		}
    }
}
