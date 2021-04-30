using System;

namespace 鉴权接口实战
{
    class Program
    {
        static void Main(string[] args)
        {
            //鉴权
            ApiAuthenticator apiAuthenticator = new DefaultApiAuthenticatorImpl();
            apiAuthenticator.auth("");
            Console.WriteLine("Hello World!");
        }
    }
}
