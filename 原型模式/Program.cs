using System;

namespace 原型模式
{
    class Program
    {
        static void Main(string[] args)
        {
            var demo = new Demo();
            demo.init();
            foreach (var item in demo.currentKeywords)
            {
                Console.WriteLine($"{item.Value.timestamp} --  {item.Key} -- {item.Value.status}");
            }
            demo.refresh();
            foreach (var item in demo.currentKeywords)
            {
                Console.WriteLine($"{item.Value.timestamp} --  {item.Key} -- {item.Value.status}");
            }

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
