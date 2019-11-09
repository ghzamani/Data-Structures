using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q4LCSOfTwo : Processor
    {
        public Q4LCSOfTwo(string testDataName) : base(testDataName) {	}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2)
        {
			long[,] alignmentScore = new long[seq1.Length, seq2.Length];

			long s = 0;
			//first row
			for(int i = 0; i < seq2.Length; i++)
			{
				if (seq1[0] == seq2[i])
				{
					s = 1;
					alignmentScore[0, i] = s;
				}

				else alignmentScore[0, i] = s;
			}

			s = 0;
			//first column
			for(int i = 0; i < seq1.Length; i++)
			{
				if (seq2[0] == seq1[i])
				{
					s = 1;
					alignmentScore[i, 0] = s;
				}

				else alignmentScore[i, 0] = s;				
			}

			for(int i = 1; i < seq1.Length; i++)
			{
				for (int j = 1; j < seq2.Length; j++)
				{
					alignmentScore[i, j] = Math.Max(alignmentScore[i - 1, j],
						Math.Max(alignmentScore[i, j - 1], alignmentScore[i - 1, j - 1]));

					if (seq1[i] == seq2[j])
					{
						alignmentScore[i, j]++;
					}
				}
			}
			return alignmentScore[seq1.Length - 1, seq2.Length - 1];
		}
    }
}
