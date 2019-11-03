using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q1BinarySearch : Processor
    {
        public Q1BinarySearch(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long [], long[]>)Solve);


        public virtual long[] Solve(long []a, long[] b) 
        {
			for(int i = 0; i < b.Length; i++)
			{
				b[i] = BinarySearch(a, b[i], 0, a.Length - 1);
			}

			return b;
        }

		public int BinarySearch (long[] nums,long key, int low, int high)
		{
			if (low > high)
				return -1;

			int mid = (low + high) / 2;

			if (nums[mid] == key)
				return mid;

			if (key < nums[mid])
				return BinarySearch(nums, key, low, mid - 1);

			if (key > nums[mid])
				return BinarySearch(nums, key, mid + 1, high);

			return 0;
		}
    }
}
