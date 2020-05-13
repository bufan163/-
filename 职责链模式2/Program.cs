using System;

namespace 职责链模式2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            HandlerChain chain = new HandlerChain();
            chain.addHandler(new HandlerA());
            chain.addHandler(new HandlerB());
            chain.handle();
            Console.ReadKey();
        }
    }
}
