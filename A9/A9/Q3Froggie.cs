using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A9
{
    public class Q3Froggie : Processor
    {
        public Q3Froggie(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long[], long[], long>)Solve);

        public long Solve(long initialDistance, long initialEnergy, long[] distance, long[] food)
        {
			SimplePriorityQueue<long,long> distances = new SimplePriorityQueue<long,long>();
			SimplePriorityQueue<long, long> food2 = new SimplePriorityQueue<long, long>();
			long count = 0;

			for(int i = 0; i < distance.Length; i++)
				distances.Enqueue(i, distance[i] * -1);			

			for(int i = 0; i < distance.Length; i++)
			{
				long maxIdx = distances.Dequeue();
				
				if (initialDistance - distance[maxIdx] > initialEnergy)
				{
					if (food2.Count == 0)
						return -1;

					long maxIdxFood = Math.Abs(food2.Dequeue());
					initialEnergy += food[maxIdxFood];
					count++;
					while (initialEnergy < (initialDistance- distance[maxIdx]))
					{
						if (food2.Count == 0) return -1;
						maxIdxFood = Math.Abs(food2.Dequeue());
						initialEnergy += food[maxIdxFood];
						count++;
					}
				}
				food2.Enqueue(maxIdx, food[maxIdx]*(-1));
			}
			while (initialEnergy < initialDistance)
			{
				if (food2.Count == 0) return -1;
				long maxIdxFood = Math.Abs(food2.Dequeue());
				initialEnergy += food[maxIdxFood];
				count++;
			}
			return count;
        }
    }
}
