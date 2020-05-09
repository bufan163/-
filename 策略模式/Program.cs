using System;
using System.Dynamic;

namespace 策略模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            StrategyFactory strategyFactory = new StrategyFactory();
            Strategy strategya= strategyFactory.getStrategy("A");
            strategya.algorithmInterface();
            Strategy strategyb = strategyFactory.getStrategy("B");
            strategyb.algorithmInterface();
            Console.ReadKey();
        }
    }
}
