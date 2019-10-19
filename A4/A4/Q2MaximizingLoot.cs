using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q2MaximizingLoot : Processor
    {
        public Q2MaximizingLoot(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long capacity, long[] weights, long[] values)
        {
			double result = 0;
			List<Tuple<long, long, double>> knapsackItems = new List<Tuple<long, long, double>>();
			
			for (int i = 0; i < weights.Length; i++)
				knapsackItems.Add(Tuple.Create(weights[i], values[i], (double)values[i] / weights[i]));

			knapsackItems = knapsackItems.OrderByDescending(i => i.Item3).ToList();

			while(capacity > 0)
			{
				if(knapsackItems[0].Item1 > capacity)
				{
					result += ((double)knapsackItems[0].Item2 / knapsackItems[0].Item1) * capacity;
					return (long)result;
				}

				capacity -= knapsackItems[0].Item1;
				knapsackItems[0] = new Tuple<long, long, double>
					(0, knapsackItems[0].Item2, knapsackItems[0].Item3);
				result += knapsackItems[0].Item2;
				knapsackItems.RemoveAt(0);
			}
			return (long)result;
        }
		
        public override Action<string, string> Verifier { get; set; } =
            TestTools.ApproximateLongVerifier;
    }
}
