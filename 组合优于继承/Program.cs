using System;
namespace 组合优于继承
{
    class Program
    {
        static void Main(string[] args)
        {
            Ostrich ostrich = new Ostrich("鸵鸟");
            ostrich.tweet();
            ostrich.layEgg();
            Sparrow sparrow = new Sparrow("麻雀");
            sparrow.fly();
            sparrow.layEgg();
            sparrow.tweet();
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }

}
