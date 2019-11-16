using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A7
{
	public class Q3MaximizingArithmeticExpression : Processor
	{
		public Q3MaximizingArithmeticExpression(string testDataName) : base(testDataName) { }

		public override string Process(string inStr) =>
			TestTools.Process(inStr, (Func<string, long>)Solve);

		char[] operations;
		int[,] Max;
		int[,] Min;
		public long Solve(string expression)
		{
			operations = new char[expression.Length / 2];
			int j = 0;

			for (int i = 1; i < expression.Length - 1; i += 2)
			{
				operations[j] = expression[i];
				j++;
			}

			int arraysLength = expression.Length / 2 + 1;
			Max = new int[arraysLength, arraysLength];
			Min = new int[arraysLength, arraysLength];

			j = 0;
			for (int i = 0; i < arraysLength; i++)
			{
				Max[i, i] = Min[i, i] = int.Parse(expression[j].ToString());
				j += 2;
			}

			for (int i = 1; i <= arraysLength - 1; i++)
			{
				for (int k = 0; k < arraysLength - i; k++)
				{
					j = i + k;
					Tuple<int,int> minAndMax = CalculateMinAndMax(k, j);
					Min[k, j] = minAndMax.Item1;
					Max[k, j] = minAndMax.Item2;
				}
			}
			return Max[0, arraysLength - 1];
		}

		public Tuple<int, int> CalculateMinAndMax(int i, int j)
		{
			int min = int.MaxValue;
			int max = int.MinValue;

			for (int k = i; k <= j - 1; k++)
			{
				int a = Operate(Min[i, k], Min[k + 1, j], operations[k]);
				int b = Operate(Min[i, k], Max[k + 1, j], operations[k]);
				int c = Operate(Max[i, k], Min[k + 1, j], operations[k]);
				int d = Operate(Max[i, k], Max[k + 1, j], operations[k]);
				min = SmallestNum(a, b, c, d, min);
				max = BiggestNum(a, b, c, d, max);
			}
			return Tuple.Create(min, max);
		}			
		public int Operate(int a, int b, char o)
		{
			switch (o)
			{
				case '+':
					return a + b;
				case '-':
					return a - b;
				case '*':
					return a * b;
			}
			return 0;
		}
		public static int SmallestNum(params int[] values) => Enumerable.Min(values);
		public static int BiggestNum(params int[] values) => Enumerable.Max(values);		
	}
}
