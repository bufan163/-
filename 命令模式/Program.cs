
GameApplication gameApplication=new GameApplication();
gameApplication.mainloop();
public class GameApplication
{
    private static int MAX_HANDLED_REQ_COUNT_PER_LOOP = 100;
    private Queue<Command> queue = new Queue<Command>();

    public void mainloop()
    {
        while (true)
        {
            List<int> requests = new List<int>{1,2,3,4};

            //省略从epoll或者select中获取数据，并封装成Request的逻辑，
            //注意设置超时时间，如果很长时间没有接收到请求，就继续下面的逻辑处理。

            foreach (int request in requests)
            {

                Command command = null;
                if (request == 1)
                {
                    command = new GotDiamondCommand("1");
                }
                else if (request == 2)
                {
                    command = new GotStartCommand("2");
                }
                else if (request == 3)
                {
                    command = new HitObstacleCommand("3");
                }
                else if (request == 4)
                {
                    command = new ArchiveCommand("4");
                }

                queue.Enqueue(command);
            }

            int handledCount = 0;
            while (handledCount < MAX_HANDLED_REQ_COUNT_PER_LOOP)
            {
                if (queue.Count <= 0)
                {
                    break;
                }
                Command command = queue.Dequeue();
                command.execute();
            }
        }
    }
}


public interface Command
{
    void execute();
}

public class GotDiamondCommand : Command
{
    // 省略成员变量

    public GotDiamondCommand(string data)
    {
        Console.WriteLine($"GotDiamondCommand{data}");
    }
    public void execute()
    {
        Console.WriteLine("GotDiamondCommand execute");
    }
}

public class GotStartCommand : Command
{
    // 省略成员变量

    public GotStartCommand(string data)
    {
        Console.WriteLine($"GotStartCommand{data}");
    }
    public void execute()
    {
        Console.WriteLine("GotStartCommand execute");
    }
}

public class HitObstacleCommand : Command
{
    // 省略成员变量

    public HitObstacleCommand(string data)
    {
        Console.WriteLine($"HitObstacleCommand{data}");
    }
    public void execute()
    {
        Console.WriteLine("HitObstacleCommand execute");
    }
}

public class ArchiveCommand : Command
{
    // 省略成员变量

    public ArchiveCommand(string data)
    {
        Console.WriteLine($"ArchiveCommand{data}");
    }
    public void execute()
    {
        Console.WriteLine("ArchiveCommand execute");
    }
}
//GotStartCommand/HitObstacleCommand/ArchiveCommand类省略
