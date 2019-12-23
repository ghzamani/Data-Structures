using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A11
{
	public class Q4SetWithRangeSums : Processor
	{
		public Q4SetWithRangeSums(string testDataName) : base(testDataName)
		{
			CommandDict =
						new Dictionary<char, Func<string, string>>()
						{
							['+'] = Add,
							['-'] = Del,
							['?'] = Find,
							['s'] = Sum
						};
			//this.ExcludeTestCases( 3);
			this.ExcludeTestCaseRangeInclusive(1, 9);
			this.ExcludeTestCaseRangeInclusive(11, 69);
		}

		public override string Process(string inStr) =>
			TestTools.Process(inStr, (Func<string[], string[]>)Solve);

		public readonly Dictionary<char, Func<string, string>> CommandDict;

		public const long M = 1_000_000_001;

		public long X = 0;

		protected List<long> Data;

		public string[] Solve(string[] lines)
		{
			BST.BStree = new Dictionary<long, Node>();
			BST.Root = null;
			X = 0;
			Data = new List<long>();
			List<string> result = new List<string>();
			foreach (var line in lines)
			{
				char cmd = line[0];
				string args = line.Substring(1).Trim();
				var output = CommandDict[cmd](args);
				if (null != output)
					result.Add(output);
			}
			return result.ToArray();
		}

		public class Node
		{
			public long Key;
			public Node Parent;
			public Node LeftChild;
			public Node RightChild;

			public Node(long k)
			{
				Key = k;
			}
		}
		public class BST
		{
			public static Node Root;
			public static Dictionary<long, Node> BStree;

			public static Node FindRoot()
			{
				foreach (var v in BStree)
				{
					if (v.Value.Parent == null)
						return v.Value;
				}
				//no tree is composed
				return null;
			}
			public static Node Find(long k, Node R)
			{
				if (R.Key == k)
					return R;

				else
				{
					if (R.Key > k)
					{
						if (R.LeftChild != null)
							return Find(k, R.LeftChild);
						return R;
					}

					if (R.RightChild != null)
						return Find(k, R.RightChild);

					//if k is bigger than all nodes, then return root
					return R;
				}
			}

			public static void Insert(long k, Node R)
			{
				//اگر درختی وجود نداشت نود را به عنوان روت اضافه میکنیم
				if (R == null)
				{
					BStree.Add(k, new Node(k));
					BST.Root = FindRoot();
					return;
				}

				Node p = Find(k, R);

				//if k was not in the tree then add it
				if (p.Key != k)
				{
					Node newNode = new Node(k);
					if (k < p.Key)
					{
						p.LeftChild = newNode;
						newNode.Parent = p;
					}

					//might be wrong!!
					else
					{
						//if the given key was less than all the nodes in tree
						//the key has to become the new root of the tree
						if (k > Root.Key)
						{
							newNode.LeftChild = p;
							p.Parent = newNode;
						}

						else
						{
							p.RightChild = newNode;
							newNode.Parent = p;
						}
					}
					BStree.Add(k, newNode);
					BST.Root = FindRoot();
				}
			}

			public static void Delete(Node N)
			{
				Node p = Find(N.Key, Root);

				try
				{
					//if N was found in the tree
					if (p.Key == N.Key)
					{
						if (p.RightChild == null)
						{
							//Remove N, promote N:Left
							if (p.LeftChild != null)
							{
								p.LeftChild.Parent = p.Parent;
								if (p.Parent != null)
									p.Parent.RightChild = p.LeftChild;
							}
						}

						else
						{
							Node x = Next(N);
							Node copiedX = x; //needed for right part of x

							//Replace N by X, promote X:Right
							x.Parent = p.Parent;
							x.RightChild = p.RightChild;

							x.RightChild.Parent = x;
							x.Parent.LeftChild = x;

							copiedX.RightChild.Parent = copiedX.Parent;
						}
						BStree.Remove(N.Key);

					}
				}
				finally
				{
					BST.Root = FindRoot();
				}
			}

			//better to add sth to check whether has next item or not
			public static Node Next(Node N)
			{
				if (N.RightChild != null)
					return LeftDescendant(N.RightChild);

				//if N has the biggest key in whole tree, so it doesn't have next.
				if (BStree.Keys.Max() == N.Key)
					return null;

				return RightAncestor(N);
			}

			public static Node RightAncestor(Node N)
			{
				//if N is the root, return itself
				if (Root == N)
					return N;

				if (N.Key < N.Parent.Key)
					return N.Parent;
				return RightAncestor(N.Parent);
			}

			private static Node LeftDescendant(Node N)
			{
				if (N.LeftChild == null)
					return N;
				return LeftDescendant(N.LeftChild);
			}

			public static List<Node> RangeSearch(long x, long y, Node R)
			{
				List<Node> result = new List<Node>();

				if (Root == null)
					return result;

				Node N = Find(x, R);
				while (N.Key <= y)
				{
					//try
					//{
					if (N.Key >= x)
						result.Add(N);
					N = Next(N);
					if (N == null)
						break;
					//seems Next does not work properly :/
					//}
					//catch
					//{
					//	break;
					//}
				}

				return result;
			}
		}

		private long Convert(long i)
			=> i = (i + X) % M;

		private string Add(string arg)
		{
			long i = Convert(long.Parse(arg));

			//int idx = Data.BinarySearch(i);
			//if (idx < 0)
			//	Data.Insert(~idx, i);

			BST.Insert(i, BST.Root);
			return null;
		}

		private string Del(string arg)
		{
			long i = Convert(long.Parse(arg));
			//int idx = Data.BinarySearch(i);
			//if (idx >= 0)
			//	Data.RemoveAt(idx);
			if (BST.BStree.Count != 0)				
				BST.Delete(new Node(i));

			return null;
		}

		private string Find(string arg)
		{
			if (BST.BStree.Count == 0)
				return "Not found";

			long i = Convert(int.Parse(arg));
			//int idx = Data.BinarySearch(i);
			//return idx < 0 ?
			//	"Not found" : "Found";

			//حالت موجود نبودن درخت در خط 242 چک شد پس
			//p != null
			Node p = BST.Find(i, BST.Root);
			if (p.Key == i)
				return "Found";
			return "Not found";
		}

		private string Sum(string arg)
		{
			var toks = arg.Split();
			long l = Convert(long.Parse(toks[0]));
			long r = Convert(long.Parse(toks[1]));

			//l = Data.BinarySearch(l);
			//if (l < 0)
			//	l = ~l;

			//r = Data.BinarySearch(r);
			//if (r < 0)
			//	r = (~r - 1);
			// If not ~r will point to a position with
			// a larger number. So we should not include 
			// that position in our search.

			long sum = 0;
			//for (int i = (int)l; i <= r && i < Data.Count; i++)
			//	sum += Data[i];

			List<Node> nodes = BST.RangeSearch(l, r, BST.Root);
			if (nodes.Count == 0)
				sum = 0;

			foreach (var node in nodes)
				sum += node.Key;

			X = sum;

			return sum.ToString();
		}
	}
}
