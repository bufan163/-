using System;
using System.Collections.Generic;
using System.Text;

namespace 门面模式
{
    class Facade : IA, IB, IFacade
    {
        public string FuncA()
        {
            Console.WriteLine("Facade FuncA");
            return "A";
        }

        public string FuncB()
        {
            Console.WriteLine("Facade FuncB");
            return "B";
        }
        public string FuncC()
        {
            Console.WriteLine("Facade FuncC");
            return "C";
        }
        public string FuncD()
        {
            Console.WriteLine("门面模式调用开始");
            IA a = new A();
            IB b = new B();
            a.FuncA();
            b.FuncB();
            Console.WriteLine("Facade FuncD");
            return "C";
        }
    }
    interface IFacade
    {
        string FuncC();
    }
    interface IA
    {
        string FuncA();
    }
    interface IB
    {
        string FuncB();
    }
    class A : IA
    {
        public string FuncA()
        {
            Console.WriteLine(" FuncA");
            return "A";
        }
    }
    class B : IB
    {
        public string FuncB()
        {
            Console.WriteLine(" FuncB");
            return "B";
        }
    }
}
