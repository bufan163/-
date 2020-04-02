using System;

namespace 实战
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationContext applicationContext = new ClassPathXmlApplicationContext("beans.xml"); RateLimiter rateLimiter = (RateLimiter)applicationContext.GetBean("rateLimiter"); rateLimiter.test();
            Console.WriteLine("Hello World!");
        }
    }
}
