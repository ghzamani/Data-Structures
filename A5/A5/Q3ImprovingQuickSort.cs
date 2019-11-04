using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q3ImprovingQuickSort:Processor
    {
        public Q3ImprovingQuickSort(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public virtual long[] Solve(long n, long[] a)
        {
			QuickSort(a, 0, a.Length - 1);
			return a;
        }

		public void QuickSort(long[] a, int l, int r)
		{
			if (l >= r)
				return;

			int m1, m2;
			(m1, m2) = Partition3(a, l, r);
			QuickSort(a, l, m1 - 1);
			QuickSort(a, m2 + 1, r);
		}

		public Tuple<int,int> Partition3(long[] a, int l, int r)
		{			
			int m1 = l;
			int i = l;
			int m2 = r;
			long pivot = a[l];
			while (i <= m2)
			{
				if(a[i] < pivot)
				{
					Swap(ref a[m1], ref a[i]);
					m1++;
					i++;
				}
				else
				{
					if (a[i] > pivot)
					{
						Swap(ref a[i], ref a[m2]);
						m2--;
					}
					else i++;
				}
			}
			return new Tuple<int, int>(m1, m2);
		}

		private void Swap(ref long v1, ref long v2)
		{
			long hold = v1;
			v1 = v2;
			v2 = hold;			
		}
	}
}
