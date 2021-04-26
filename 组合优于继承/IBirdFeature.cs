using System;
using System.Collections.Generic;
using System.Text;

namespace 组合优于继承
{
    /// <summary>
    /// 接口和接口实现
    /// </summary>
    public interface Flyable
    {
        void fly(string name);
    }
    public interface Tweetable
    {
        void tweet(string name);
    }
    public interface EggLayable
    {
        void layEgg(string name);
    }
    public class FlyAbility : Flyable
    {
        public void fly(string name)
        {
            Console.WriteLine($"{name} 飞");
        }
    }
    public class TweetAbility : Tweetable
    {
        public void tweet(string name)
        {
            Console.WriteLine($"{name} 叫");
        }
    }
    public class EggLayAbility : EggLayable
    {
        public void layEgg(string name)
        {
            Console.WriteLine($"{name} 下蛋");
        }
    }
}
