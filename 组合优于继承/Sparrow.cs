using System;
using System.Collections.Generic;
using System.Text;

namespace 组合优于继承
{
    public class Sparrow
    {
        private FlyAbility flyAbility = new FlyAbility();
        private TweetAbility tweetAbility = new TweetAbility(); //组合
        private EggLayAbility eggLayAbility = new EggLayAbility(); //组合
       
        //... 省略其他属性和方法...
        private string _name;
        private string _type="麻雀";
        private int count = 0;
        public Sparrow(string name)
        {
            _name = name;
        }
        public void fly()
        {
            count++;
            Console.WriteLine(_type+count);
            flyAbility.fly(this._name);
        }
        public void tweet()
        {
            count++;
            Console.WriteLine(_type + count);
            tweetAbility.tweet(this._name); // 委托
        }

        public void layEgg()
        {
            Console.WriteLine(_type);
            eggLayAbility.layEgg(this._name); // 委托
        }
    }
}
