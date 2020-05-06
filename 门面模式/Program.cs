using System;

namespace 门面模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IFacade c = new Facade();
            c.FuncC();
            IA a = new A();
            a.FuncA();
            Facade cc = new Facade();
            cc.FuncA();
            cc.FuncB();
            cc.FuncC();
            cc.FuncD();
            Console.ReadKey();
        }
    }
}
