using System;
using System.Collections.Generic;

namespace 迭代器模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<string> names = new List<string>();
            names.Add("xzg");
            names.Add("wang");
            names.Add("zheng");

            ArrayIterator<string> iterator = new ArrayIterator<string>(names);
            while (iterator.hasNext())
            {
                Console.WriteLine(iterator.currentItem());
                iterator.next();
            }
            Console.ReadKey();
        }
    }
}
