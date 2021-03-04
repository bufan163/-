using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace 单例模式
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            for (int i = 0; i < 10000; i++)
            {
                //问题复现
                //Task.Run(Dosth);//模拟并发，读取文件的时候就会提示文件被另一线程使用
                Dosth();//正常调用不会
            }
            

            Console.ReadKey();
        }
        static void Dosth()
        {
            UserController user = new UserController();
            user.login("abc", "123");
            OrderController order = new OrderController();
            order.create(new OrderVo());
        }
    }

    public class Logger
    {
        private FileStream fs;

        public Logger()
        {
            //string path = Directory.GetCurrentDirectory()+"\\log.txt";
            string path = "E:/Users/abind/Desktop/Temp/log.txt";
            fs = new FileStream(path, FileMode.Append); //表示追加写入
        }

        public void log(string message)
        {
           // byte[] data = new UTF8Encoding().GetBytes(message);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine($"{DateTime.Now}:{message}");
            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }

    // Logger类的应用示例：
    public class UserController
    {
        private Logger logger = new Logger();

        public void login(string username, string password)
        {
            // ...省略业务逻辑代码...
            logger.log(username + " logined!");
            Console.WriteLine("用户登陆");
        }
    }

    public class OrderController
    {
        private Logger logger = new Logger();

        public void create(OrderVo order)
        {
            // ...省略业务逻辑代码...
            logger.log("Created an order: " + order.toString());
            Console.WriteLine("创建订单");
        }
    }
}
