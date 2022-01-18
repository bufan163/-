using System;

namespace 原型模式
{
    class Program
    {
        static void Main(string[] args)
        {
            var demo = new Demo();
            demo.init();//初始化
            foreach (var item in demo.currentKeywords)
            {
                Console.WriteLine($"{item.Value.timestamp} --  {item.Key} -- {item.Value.status}");
            }
            demo.refresh();//刷新
            foreach (var item in demo.currentKeywords)
            {
                Console.WriteLine($"{item.Value.timestamp} --  {item.Key} -- {item.Value.status}");
            }

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
