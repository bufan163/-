using System;
using System.Net.Http;

namespace 里氏替换原则_LSP
{
    class Program
    {
        static void Main(string[] args)
        {
            // 里式替换原则
            Demo demo = new Demo();
            HttpClient httpClient = new HttpClient();
            String appId="";
            String appToken="";
            //SecurityTransporter在这里作为子类替换了方法中定义父类Transporter
            demo.demoFunction(new SecurityTransporter(httpClient,appId,appToken));
            Console.WriteLine("Hello World!");
        }
    }
}
