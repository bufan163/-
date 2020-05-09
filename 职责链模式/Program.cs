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
            chain.handle();
            Console.ReadKey();
        }
    }
}
