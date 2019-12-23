using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace E2a
{
    public class Q1BSTInOrderTraverse : Processor
    {
        public Q1BSTInOrderTraverse(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

		List<long> result;
        public long[] Solve(long n, long[] BST)
        {
			result = new List<long>();

			InOrder(BST,0);
			return result.ToArray();
        }

		public void InOrder(long[] tree,long idx)
		{
			if (tree[idx] == -1)
				return;

			InOrder(tree, 2 * idx + 1);
			result.Add(tree[idx]);
			InOrder(tree, 2 * idx + 2);
		}
		
    }
}