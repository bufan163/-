using System;
using System.Collections.Generic;

namespace 控制反转
{
    class Program
    {
        static void Main(string[] args)
        {
            JunitApplication.register(new TestCase2());
            JunitApplication.register(new TestCase3());
            JunitApplication.register(new TestCase2());
            JunitApplication.register(new TestCase3());

            foreach (TestCase c in JunitApplication.testCases)
            {
                c.run();
            }
            Console.ReadKey();
        }

        public abstract class TestCase
        {
            public void run()
            {
                if (doTest())
                {
                    Console.WriteLine("Test Success");
                }
                else
                {
                    Console.WriteLine("Test failed");
                }
            }

            public abstract bool doTest();
            public abstract bool doTest2(bool parm);
        }
        public class TestCase2 : TestCase
        {
            public override bool doTest()
            {
                Console.WriteLine("TestCase2 is doTest");
                return true;
            }

            public override bool doTest2(bool parm)
            {
                Console.WriteLine($"the parm is {parm}");
                return parm;
            }
        }
        public class TestCase3 : TestCase
        {
            public override bool doTest()
            {
                Console.WriteLine("TestCase3 is doTest");
                return false;
            }
            public override bool doTest2(bool parm)
            {
                Console.WriteLine($"the parm is {parm}");
                return parm;
            }
        }
        public class JunitApplication
        {
            public static List<TestCase> testCases = new List<TestCase>();

            public static void register(TestCase testCase)
            {
                testCases.Add(testCase);
            }
        }
    }
}
