using System;
using System.Linq;
using TestCommon;

namespace A9
{
    public class Q2MergingTables : Processor
    {
        long[] parent;
        long[] tableSizes;
        long[] rank;

        public Q2MergingTables(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)Solve);


        public long[] Solve(long[] tableSizes, long[] targetTables, long[] sourceTables)
        {
			rank = new long[targetTables.Length];
			parent = new long[tableSizes.Length];

			for(int i = 0; i < tableSizes.Length; i++)
			{
				parent[i] = i + 1;			
			}

			for(int i = 0; i < targetTables.Length; i++)
			{
				long sourceParent = FindRoot(parent, sourceTables[i] - 1) + 1;
				long targetParent = FindRoot(parent, targetTables[i] - 1) + 1;
				
				if(sourceParent != targetParent)
				{
					//age node taki bood ...
					if (parent[sourceTables[i] - 1] == sourceTables[i])
					{
						parent[sourceTables[i] - 1] = targetTables[i];

						//bayad check beshe age target, root nabood bayad taghiresh bedim be rootesh
						if (parent[targetTables[i] - 1] != targetTables[i])
							targetTables[i] = FindRoot(parent, targetTables[i] - 1) + 1;												
					}

					//bayad berim ta beresim be root
					else
					{
						if (parent[targetTables[i] - 1] != targetTables[i])
							targetTables[i] = FindRoot(parent, targetTables[i] - 1) + 1;

						if (parent[sourceTables[i] - 1] != sourceTables[i])
							sourceTables[i] = FindRoot(parent, sourceTables[i] - 1) + 1;

						parent[FindRoot(parent, sourceTables[i] - 1)] = targetTables[i];
					}

					tableSizes[targetTables[i] - 1] += tableSizes[sourceTables[i] - 1];
					tableSizes[sourceTables[i] - 1] = 0;
				}		
				rank[i] = Enumerable.Max(tableSizes);
			}
			return rank;
        }

		public static long FindRoot(long[] array, long idx)
		{
			while (array[idx] != idx + 1)
				idx = array[idx] - 1;
			return idx;
		}
    }


}
