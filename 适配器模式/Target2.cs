using System;
using System.Collections.Generic;
using System.Text;

namespace 适配器模式
{
    // 对象适配器：基于组合
    public interface ITarget2
    {
        void f1();
        void f2();
        void fc();
    }

    public class Adaptee2
    {
        public void fa()
        { //... 
        }
        public void fb()
        { //...
        }
        public void fc()
        { //... 
        }
    }

    public class Adaptor2 : ITarget2
    {
        private Adaptee2 adaptee;
        public Adaptor2(Adaptee2 adaptee)
        {
            this.adaptee = adaptee;
        }
        public void f1()
        {
            adaptee.fa(); //委托给Adaptee
        }
        public void f2()
        {
            //...重新实现f2()...
        }
        public void fc()
        {
            adaptee.fc();
        }
    }
}
