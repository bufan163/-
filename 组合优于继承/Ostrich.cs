using System;
using System.Collections.Generic;
using System.Text;

namespace 组合优于继承
{
    /// <summary>
    /// 鸵鸟，在具体的类中组合功能
    /// </summary>
    public class Ostrich
    {
        private   tweetAbility = new TweetAbility(); //组合
        private EggLayAbility eggLayAbility = new EggLayAbility(); //组合
        //... 省略其他属性和方法...
        public string _name;
        public string _type = "鸵鸟";
        public Ostrich(string name)
        {
            _name = name;
        }
        public void tweet()
        {
            Console.WriteLine(_type);
            tweetAbility.tweet(this._name); // 委托
        }

        public void layEgg()
        {
            Console.WriteLine(_type);
            eggLayAbility.layEgg(this._name); // 委托
        }
    }
}
