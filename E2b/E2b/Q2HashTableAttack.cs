using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestCommon;

namespace E2b
{
    public class Q2HashTableAttack : Processor
    {
        public Q2HashTableAttack (string testDataName) : base(testDataName) 
        {
			//this.ExcludeTestCaseRangeInclusive(9, 10);
		}

        public override string Process(string inStr)
        {
            long bucketCount = long.Parse(inStr);
            return string.Join("\n", Solve(bucketCount));
        }

        public string[] Solve(long bucketCount)
        {
			double MaxLoadingFactor = 0.9;

			string[] result = new string[(int) (MaxLoadingFactor * bucketCount)];

			result[0] = RandomString();
			int j = 1;
			while(result.Last() == null)
			{
				string random = RandomString();
				if (GetBucketNumber(result[0], bucketCount) == GetBucketNumber(random, bucketCount))
				{
					result[j] = random;
					j++;
				}
			}
           
			return result;
        }

        #region Chars
        static char[] LowChars = Enumerable
            .Range(0, 26)
            .Select(n => (char)('a' + n))
            .ToArray();

        static char[] CapChars = Enumerable
            .Range(0, 26)
            .Select(n => (char)('A' + n))
            .ToArray();

        static char[] Numbers = Enumerable
            .Range(0, 10)
            .Select(n => (char)('0' + n))
            .ToArray();

		static char[] AllChars =
			LowChars.Concat(CapChars).Concat(Numbers).ToArray();
		#endregion

		public string RandomString()
		{
			string result = string.Empty;
			//rnd is length of result
			int rnd = new Random(1).Next(1, 5);
			for (int j = 0; j < rnd; j++)
			{
				result += AllChars[new Random().Next(0, AllChars.Length - 1)];
			}
			return result;
		}

		// پیاده‌سازی مورد استفاده دات‌نت برای پیدا کردن شماره باکت
		// https://referencesource.microsoft.com/#mscorlib/system/collections/generic/dictionary.cs,bcd13bb775d408f1
		public static long GetBucketNumber(string str, long bucketCount) =>
            (str.GetHashCode() & 0x7FFFFFFF) % bucketCount;
    }
}
