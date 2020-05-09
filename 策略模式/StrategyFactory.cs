using System;
using System.Collections.Generic;
using System.Text;

namespace 策略模式
{

    public class StrategyFactory
    {
        private Dictionary<string, Strategy> strategies = new Dictionary<string, Strategy>();

        public StrategyFactory()
        {
            strategies.Add("A", new ConcreteStrategyA());
            strategies.Add("B", new ConcreteStrategyB());
        }

        public  Strategy getStrategy(string type)
        {
            if (type == null || string.IsNullOrEmpty(type))
            {
                throw new ArgumentNullException("type should not be empty.");
            }
            return strategies[type];
        }
    }
}
