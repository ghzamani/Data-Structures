using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q2IsItBST : Processor
    {
        public Q2IsItBST(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], bool>)Solve);

        public bool Solve(long[][] nodes)
        {
			long[] inOrderTraverse = Q1BinaryTreeTraversals.InOrder(nodes);

			for(int i = 0; i < inOrderTraverse.Length - 1; i++)			
				if (inOrderTraverse[i] >= inOrderTraverse[i + 1])
					return false;
			
			return true;
        }
    }
}
