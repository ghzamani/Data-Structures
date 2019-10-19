using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q6MaximizeSalary : Processor
    {
        public Q6MaximizeSalary(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], string>) Solve);


        public virtual string Solve(long n, long[] numbers)
        {
			string result = string.Empty;
			
			int idx = 0;
			List<long> nums = numbers.ToList();
			
			while(nums.Count != 0)
			{
				long biggestNum = 0;
				for (int i = 0; i < nums.Count ; i++)
				{
					if (MSD(nums[i]) > MSD(biggestNum))
					{
						biggestNum = nums[i];
						idx = i;
					}

					else
					{
						if (MSD(nums[i]) == MSD(biggestNum))
						{
							if (long.Parse(nums[i].ToString() + biggestNum.ToString())
								> long.Parse(biggestNum.ToString() + nums[i].ToString()))

							{
								biggestNum = nums[i];
								idx = i;
							}
						}
					}					
				}
				result += biggestNum;
				nums.RemoveAt(idx);
			}
			return result;
        }

		//returns the most significant digit of number
		public int MSD (long n)
		{
			return int.Parse(n.ToString().First().ToString());
		}
    }
}

