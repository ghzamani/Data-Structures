using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestCommon;

namespace E2a
{
    public class Q2ThreeChildrenMinHeap : Processor
    {
        public Q2ThreeChildrenMinHeap(string testDataName) : base(testDataName) { }
        public override string Process(string inStr)
        {
            long n;
            long changeIndex, changeValue;
            long[] heap;
            using (StringReader reader = new StringReader(inStr))
            {
                n = long.Parse(reader.ReadLine());

                string line = null;
                line = reader.ReadLine();

                TestTools.ParseTwoNumbers(line, out changeIndex, out changeValue);

                line = reader.ReadLine();
                heap = line.Split(TestTools.IgnoreChars, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => long.Parse(x)).ToArray();
            }

            return string.Join("\n", Solve(n, changeIndex, changeValue, heap));

        }
        public long[] Solve(
            long n, 
            long changeIndex, 
            long changeValue, 
            long[] heap)
        {
			heap[changeIndex] += changeValue;

			SiftDown(heap, changeIndex);
			return heap;
        }

		public void SiftDown(long[] tree, long i)
		{
			long indexOfMin = i;

			long l = i * 3 + 1;
			if ((l < tree.Length) && (tree[l] < tree[indexOfMin]))
				indexOfMin = l;

			long mid = i * 3 + 2;
			if ((mid < tree.Length) && (tree[mid] < tree[indexOfMin]))
				indexOfMin = mid;

			long r = i * 3 + 3;
			if ((r < tree.Length) && (tree[r] < tree[indexOfMin]))
				indexOfMin = r;

			if(i != indexOfMin)
			{
				Swap(tree, i, indexOfMin);
				SiftDown(tree, indexOfMin);
			}
		}

		public void Swap(long[] arr, long a, long b)
		{
			var tmp = arr[a];
			arr[a] = arr[b];
			arr[b] = tmp;
		}
    }
}
