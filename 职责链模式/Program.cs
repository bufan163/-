using System;

namespace 职责链模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            HandlerChain chain = new HandlerChain();
            chain.addHandler(new HandlerA());
            chain.addHandler(new HandlerB());
            chain.addHandler(new HandlerC());
            chain.handle();  //处理

            HandlerChain2 chain2 = new HandlerChain2();
            chain2.addHandler(new HandlerA2());
            chain2.addHandler(new HandlerB2());
            chain2.handle();  //处理
            Console.ReadKey();
        }
    }
}
