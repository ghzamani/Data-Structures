using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace E2b
{
    public class Q1ImplementNextForBST : Processor
    {
        public Q1ImplementNextForBST(string testDataName) : base(testDataName) 
        {
            //this.ExcludeTestCaseRangeInclusive(1, 10);
        }
        public override string Process(string inStr)
        {
            long n, node;
            var lines = inStr.Split(TestTools.NewLineChars, StringSplitOptions.RemoveEmptyEntries);
            TestTools.ParseTwoNumbers(lines[0], out n, out node);
            var bst = lines[1].Split(TestTools.IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => long.Parse(x))
                .ToArray();

            return Solve(n, node, bst).ToString();
        }

        public long Solve(long n, long node, long[] BST)
        {
			return Next(BST, node);
        }

		public long Next(long[] tree, long i)
		{
			if (tree[i] == tree.Max())
				return -1;

			//if node has right child
			if(tree[2 * i + 2] != -1)
			{
				return LeftDescendant(tree, 2 * i + 2);
			}

			return RightAncestor(tree, i);
		}

		public long RightAncestor(long[] tree, long i)
		{
			if (tree[i] < tree[(i - 1) / 2])
				return (i - 1) / 2;
			return RightAncestor(tree, (i - 1) / 2);
		}

		public long LeftDescendant(long[] tree, long i)
		{
			if (tree[2 * i + 1] == -1)
				return i;
			return LeftDescendant(tree, 2 * i + 1);
		}
	}
}