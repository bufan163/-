using System;
using System.Collections.Generic;

namespace 桥接模式
{
    class Program
    {
        static void Main(string[] args)
        {
            //方法是从最内层往外层调用的，首先通过TelephoneMsgSender构造函数初始化参数，构建MsgSender对象
            SevereNotification severeNotification = new SevereNotification(new TelephoneMsgSender(new List<string> { "1234" }));
            //把参数123，传到SevereNotification，然后再调用TelephoneMsgSender的 send方法
            severeNotification.notify("123");
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
