using Castle.DynamicProxy;
using System;

namespace 代理模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IUserController userController = new UserControllerProxy(new UserController());
            userController.login("123","456");
            Console.ReadKey();
            // 代理插件
            ProxyGenerator proxyGenerator = new ProxyGenerator();


        }
    }
}
