using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A10
{
	public class Q3RabinKarp : Processor
	{
		public Q3RabinKarp(string testDataName) : base(testDataName) { }

		public override string Process(string inStr) =>
			TestTools.Process(inStr, (Func<string, string, long[]>)Solve);

		public long[] Solve(string pattern, string text)
		{
			long p = Q2HashingWithChain.BigPrimeNumber;
			long x = 263;//new Random().Next(1, (int)p - 1);
			long patternHash = Q2HashingWithChain.PolyHash(pattern, 0, pattern.Length, p, x);

			List<long> positions = new List<long>();
			long[] H = PreComputeHashes(text, pattern.Length, p, x);
			for (int i = 0; i <= text.Length - pattern.Length; i++)
			{
				if (patternHash != H[i])
					continue;

				StringBuilder sb = new StringBuilder(pattern.Length);
				for (int j = i; j <= i + pattern.Length - 1; j++)
					sb.Append(text[j]);
				if (sb.ToString() == pattern)
					positions.Add(i);
			}
			return positions.ToArray();
		}

		public static long[] PreComputeHashes(
			string T,
			int P,
			long p,
			long x)
		{
			long[] H = new long[T.Length - P + 1];
			H[H.Length - 1] = Q2HashingWithChain.PolyHash(T, T.Length - P, P, p, x);

			long y = 1;
			for (int i = 1; i <= P; i++)
				checked
				{
					y = y * x % p;
				}
			for (int i = T.Length - P - 1; i >= 0; i--)
				checked
				{
					H[i] = x * H[i + 1] + T[i] - (y * T[i + P]);
					//does not calculate the negative numbers mod sth correctly
					//so first we make it positive
					while (H[i] < 0)
						H[i] += p;

					H[i] %= p;
				}

			return H;
		}
	}
}
