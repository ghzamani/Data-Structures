using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A11
{
    public class Q1BinaryTreeTraversals : Processor
    {
        public Q1BinaryTreeTraversals(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[][], long[][]>)Solve);

        public long[][] Solve(long[][] nodes)
        {
			long[][] result = new long[3][];

			result[0] = InOrder(nodes);
			result[1] = PreOrder(nodes);
			result[2] = PostOrder(nodes);
			return result;
        }

		public static long[] InOrder(long[][] nodes)
		{
			long[] result = new long[nodes.Length];
			Stack<Tuple<long, long>> stack = new Stack<Tuple<long, long>>();

			long current = 0;
			int i = 0;
			while (i != result.Length)
			{
				//while the node has left child loop
				while (current != -1)
				{
					stack.Push(new Tuple<long, long>(nodes[current][0], current));
					current = nodes[current][1]; //set current to index of left child
				}
				if ((current == -1) && (stack.Count != 0))
				{
					current = nodes[stack.Peek().Item2][2]; // set current to index of right child
					result[i] = stack.Pop().Item1;
					i++;
					continue;
				}
			}					   
			return result;
		}

		public static long[] PreOrder(long[][] nodes)
		{
			long[] result = new long[nodes.Length];
			Stack<Tuple<long, long>> stack = new Stack<Tuple<long, long>>();
			stack.Push(new Tuple<long, long>(nodes[0][0], 0));
			
			int i = 0;
			long current = 0;
			while(stack.Count != 0)
			{
				current = stack.Peek().Item2;

				result[i] = stack.Pop().Item1;
				i++;
				if(nodes[current][2] != -1)
					stack.Push(new Tuple<long, long>(nodes[nodes[current][2]][0], nodes[current][2]));

				if (nodes[current][1] != -1)
					stack.Push(new Tuple<long, long>(nodes[nodes[current][1]][0], nodes[current][1]));
			}
			return result;
		}

		public static long[] PostOrder(long[][] nodes)
		{
			long[] result = new long[nodes.Length];
			//first item: key //second item: index
			Stack<Tuple<long, long>> stack1 = new Stack<Tuple<long, long>>();
			Stack<Tuple<long, long>> stack2 = new Stack<Tuple<long, long>>();
			
			int i = 0;
			long current = 0;

			stack1.Push(new Tuple<long, long>(nodes[current][0], current));

			while (stack1.Count != 0)
			{
				current = stack1.Peek().Item2;
				stack2.Push(stack1.Pop());

				if(nodes[current][1] != -1)
					stack1.Push(new Tuple<long, long>(nodes[nodes[current][1]][0], nodes[current][1]));

				if(nodes[current][2] != -1)
					stack1.Push(new Tuple<long, long>(nodes[nodes[current][2]][0], nodes[current][2]));
			} 

			while(stack2.Count != 0)
			{
				result[i] = stack2.Pop().Item1;
				i++;
			}
			
			return result;
		}
	}

}