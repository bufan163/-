using System;
using 工厂模式;

namespace 设计模式
{
    class Program
    {
        static void Main(string[] args)
        {
            
            RuleConfigSource ruleConfigSource = new RuleConfigSource();
            ruleConfigSource.load("123");

        }
    }
}
