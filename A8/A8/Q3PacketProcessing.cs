using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A8
{
	public class Q3PacketProcessing : Processor
	{
		public Q3PacketProcessing(string testDataName) : base(testDataName)
		{
		}

		public override string Process(string inStr) =>
			TestTools.Process(inStr, (Func<long, long[], long[], long[]>)Solve);

		public long[] Solve(long bufferSize,
			long[] arrivalTimes,
			long[] processingTimes)
		{
			long[] result = Enumerable.Repeat((long)-1, arrivalTimes.Length).ToArray();

			if (arrivalTimes.Length == 0)
				return result;

			long totalTimePassed = arrivalTimes[0];

			Queue<long> buffer = new Queue<long>();
			long i = 0;
			while (i < arrivalTimes.Length)
			{
				while (buffer.Count > 0)
				{
					long j = buffer.Dequeue();
					result[j] = Math.Max(totalTimePassed, arrivalTimes[j]);
					totalTimePassed = result[j] + processingTimes[j];

					while (i < arrivalTimes.Length && buffer.Count < bufferSize)
					{
						if (totalTimePassed <= arrivalTimes[i])
							buffer.Enqueue(i);
						
						i++;
					}
				}

				while (i < arrivalTimes.Length && buffer.Count < bufferSize)
				{
					if (totalTimePassed <= arrivalTimes[i])
						buffer.Enqueue(i);
					
					i++;
				}
			}
			while (buffer.Count > 0)
			{
				long j = buffer.Dequeue();
				result[j] = Math.Max(totalTimePassed, arrivalTimes[j]);
				totalTimePassed = result[j] + processingTimes[j];
			}
			return result;
		}
	}
}