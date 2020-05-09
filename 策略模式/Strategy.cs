using System;
using System.Collections.Generic;
using System.Text;

namespace 策略模式
{

    public interface Strategy
    {
        void algorithmInterface();
    }

    public class ConcreteStrategyA : Strategy
    {

        public void algorithmInterface()
        {
            Console.WriteLine("ConcreteStrategyA");
        }
    }

    public class ConcreteStrategyB : Strategy
    {

        public void algorithmInterface()
        {
            Console.WriteLine("ConcreteStrategyB");
        }
    }
}
