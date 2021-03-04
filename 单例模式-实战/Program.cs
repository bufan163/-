using System;
using System.IO;
using System.Threading.Tasks;

namespace 单例模式_实战
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            for (int i = 0; i < 2000; i++)
            {
                //问题复现
                //Task.Run(Dosth);//模拟并发，读取文件的时候就会提示文件被另一线程使用
                  Task.Run(() => Dosth2(i));//模拟并发，读取文件的时候就会提示文件被另一线程使用
                 //Dosth();//正常调用不会
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
        static async Task Dosth2(int index)
        {
            UserController user = new UserController();
            user.login($"abc{index}", "123");
            OrderController order = new OrderController();
            order.create(new OrderVo());
        }
    }

    public class Logger
    {
        private StreamWriter writer;
        private static Logger instance = new Logger();
        public Logger()
        {
            string path = "E:/Users/abind/Desktop/Temp/log.txt";
            writer = new StreamWriter(path, true);
        }
        public static Logger GetInstance()
        {
            return instance;
        }
        public static Logger Instance
        {
            get {
                return instance;
            }
        }

        public void log(string message)
        {
            writer.WriteLine($"{DateTime.Now}:{message}");
        }
    }

    // Logger类的应用示例：
    public class UserController
    {
        // private Logger logger = new Logger();

        public void login(string username, string password)
        {
            // ...省略业务逻辑代码...
            Logger.Instance.log(username + " logined!");
            Console.WriteLine("用户登陆");
        }
    }

    public class OrderController
    {
        //private Logger logger = new Logger();

        public void create(OrderVo order)
        {
            // ...省略业务逻辑代码...
            Logger.Instance.log("Created an order: " + order.toString());
            Console.WriteLine("创建订单");
        }
    }
}
