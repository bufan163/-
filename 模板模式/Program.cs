using System;

namespace 模板模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AbstractClass demo =new ConcreteClass1();
            demo.templateMethod();
            Console.ReadKey();
        }
    }
}
