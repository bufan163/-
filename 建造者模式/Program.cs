using System;

namespace 建造者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            // 这段代码会抛出IllegalArgumentException，因为minIdle>maxIdle
            ResourcePoolConfig config = new ResourcePoolConfig.Builder()
                    .setName("dbconnectionpool")
                    .setMaxTotal(16)
                    .setMaxIdle(10)
                    .setMinIdle(12)
                    .build();
            config.Message = "123";

            ConstructorArg arg = new ConstructorArg.MyBuilder().IsRef(true).builder();

            Console.WriteLine("Hello World!");
            //.net core 中 WebHostBuilder 就是建造者模式
        }
    }
}
