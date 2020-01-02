using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2.Tests
{
    [DeploymentItem("TestData")]
    [TestClass()]
    public class GradedTests
    {
        [TestMethod()]
        public void SolveTest_Q1NaiveMaxPairWise()
        {
            RunTest(new Q1NaiveMaxPairWise("TD1"));
        }

        [TestMethod(), Timeout(1600)]
        public void SolveTest_Q2FastMaxPairWise()
        {
            RunTest(new Q2FastMaxPairWise("TD2"));
        }

        [TestMethod()]
        public void SolveTest_StressTest()
        {
			Random rnd = new Random();
			Stopwatch watch = new Stopwatch();
			watch.Start();
			while (true)
			{
				int arrayBound = rnd.Next(2, 200000);
				long[] testArray = new long[arrayBound];

				for (int i=0; i <arrayBound; i++)
				{
					testArray[i] = rnd.Next(200000);
				}

				long fastRes = new Q2FastMaxPairWise("TD1").Solve(testArray);
				long naiveRes = new Q1NaiveMaxPairWise("TD1").Solve(testArray);

				Assert.AreEqual(fastRes, naiveRes);

				if (watch.ElapsedMilliseconds >= 5000)
					break;
			}
			watch.Stop();
        }

        public static void RunTest(Processor p)
        {
            TestTools.RunLocalTest("A2", p.Process, p.TestDataName, p.Verifier);
        }

    }
}