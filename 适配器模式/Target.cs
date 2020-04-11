using System;
using System.Collections.Generic;
using System.Text;

namespace 适配器模式
{

    // 类适配器: 基于继承
    public interface ITarget
    {
        void f1();
        void f2();
        void fc();
    }

    public class Adaptee
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

    public class Adaptor : Adaptee, ITarget
    {
        public void f1()
        {
        }

        public void f2()
        {
            //...重新实现f2()...
        }
        // 这里fc()不需要实现，直接继承自Adaptee，这是跟对象适配器最大的不同点
    }

}