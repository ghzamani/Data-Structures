using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace E1b
{
    public class Q4HungryFrog : Processor
    {
        public Q4HungryFrog(string testDataName) : base(testDataName)
        {
			
		}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[][], long>)Solve);


		public virtual long Solve(long n, long p, long[][] numbers)
		{
			long res = 0;
			//long sum = 0;
			//List<long> nums1 = numbers[0].ToList();
			//List<long> nums2 = numbers[1].ToList();

			//if (nums1[0] > nums2[0])
			//	sum += nums1[0];
			//else sum += nums2[0];

			//for(int i = 1; i < nums1.Count; i++)
			//{
			//	if(nums1[i] > )
			//}
			//if (n == 1)
			//{
			//	return numbers[0][0] > numbers[1][0] ? numbers[0][0] : numbers[1][0];
			//}



			//res = Solve(n - 1, p, new long[][] { numbers[0].Take((int) n-1).ToArray()
			//	, numbers[1].Take((int) n-1).ToArray() }) +
			//	Solve(n - 2, p, new long[][] { numbers[0].Take((int) n-2).ToArray()
			//	, numbers[1].Take((int) n-2).ToArray() });


			//if (numbers[0][n - 1] > numbers[1][n - 1])
			//	return Solve(n - 1, p, new long[][] { numbers[0].Take((int) n-1).ToArray()
			//	, numbers[1].Take((int) n-1).ToArray() }) + numbers[0][n - 1];

			//return Solve(n - 1, p, new long[][] { numbers[0].Take((int) n-1).ToArray()
			//	, numbers[1].Take((int) n-1).ToArray() }) + numbers[1][n - 1];

			int whichRow;
			if (numbers[0][0] > numbers[1][0])
			{
				res += numbers[0][0];
				whichRow = 0;
			}
			else
			{ 
				res += numbers[1][0];
				whichRow = 1;
			}

			for(long i = 1; i < n; i++)
			{
				if (whichRow == 0)
				{
					if (res + numbers[0][i] > res + numbers[1][i] - p)
					{
						res += numbers[0][i];
						
					}
					else 
					{
						if (res + numbers[0][i] == res + numbers[1][i] - p)
						{
							whichRow = CheckNext(numbers, i, whichRow, res, p);
							if (whichRow == 0)
							{
								res += numbers[0][i];
							}
							else { res += numbers[0][i] - p; }
						}
						else
						{
							res += res + numbers[1][i] - p;
							whichRow = 1;
						}
					}
				}

				else
				{
					if (res + numbers[0][i] - p > res + numbers[1][i])
					{
						res += numbers[0][i] - p;
						whichRow = 0;
					}
					else 
					{
						if(res + numbers[0][i] - p == res + numbers[1][i])
						{
							whichRow = CheckNext(numbers, i, whichRow, res, p);
							if (whichRow == 0)
							{
								res += numbers[0][i] - p;
							}
							else res += numbers[1][i];
						}
						else
						{
							res += numbers[1][i]; 
						}
						
					}
				}
			}
			return res;
        }

		public int CheckNext(long[][] numbers, long i, int whichRow, long res, long p)
		{
			if(whichRow == 0)
			{
				if(numbers[0][i] > numbers[1][i] - p)
				{
					return 0;
				}

				if(numbers[0][i ] > numbers[1][i] - p)
				{
					return 1;
				}

				return CheckNext(numbers, i + 1, whichRow, res, p);
			}

			else
			{
				if(numbers[0][i] - p < numbers[1][i])
				{
					return 1;
				}

				if (numbers[0][i] - p > numbers[1][i])
				{
					return 0;
				}

				return CheckNext(numbers, i + 1, whichRow, res, p);
			}
			
		}
	}
}
