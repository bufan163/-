using System;
using System.Collections.Generic;

namespace 迭代器模式
{
    class Program
    {

        //一个返回类型为IEnumerable<int>，其中包含三个yield return
        public static IEnumerable<int> enumerableFuc()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }
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

            #region yield 用法
            foreach (int item in enumerableFuc())
            {
                Console.WriteLine($"yield :{item}");
            }
            #endregion
            Console.ReadKey();
        }
    }
}
