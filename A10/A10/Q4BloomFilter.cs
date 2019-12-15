// Bloom filter: https://www.jasondavies.com/bloomfilter/
using System;
using System.Collections;
using System.Linq;
using TestCommon;


namespace A10
{
    public class Q4BloomFilter
    {
        BitArray Filter;
        Func<string, int>[] HashFunctions;

        public Q4BloomFilter(int filterSize, int hashFnCount)
        { 
			Filter = new BitArray(filterSize);
			HashFunctions = new Func<string, int>[hashFnCount];
			for(int i = 0; i < hashFnCount; i++)
			{
				long x = new Random().Next(1, (int)Q2HashingWithChain.BigPrimeNumber - 1);
				Func<string, int> f = (str) =>
				{ return (int)PolyHash(str, 0, str.Length, x) % filterSize; };
				HashFunctions[i] = f;
			}

        }
		public static long PolyHash(
			string str, int start, int count, long x,
			long p = Q2HashingWithChain.BigPrimeNumber)
		{
			long hash = 0;
			for (int i = start + count - 1; i >= start; i--)
			{
				checked
				{
					hash = (hash * x + str[i]) % p;
				}
			}
			return hash;
		}

		public void Add(string str)
        {
            for (int i=0; i< HashFunctions.Length; i++)
            {
                Filter[HashFunctions[i](str)] = true;
            }
        }

        public bool Test(string str)
        {
            for (int i=0; i<HashFunctions.Length; i++)
            {
                if (Filter[HashFunctions[i](str)] == true)
                {
                    continue;
                }
                return false;
            }
            return true;
        }
    }
}