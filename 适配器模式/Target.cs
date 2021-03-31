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
        void fc();//fc为 Adaptee 和 Adaptor 共有的接口
    }
    //被收养者
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
    //适应者（适配器）
    public class Adaptor : Adaptee, ITarget
    {
        public void f1()
        {
        }

        public void f2()
        {
            //...重新实现f2()...  适配器重新实现了基础类（Adaptee）中的逻辑，对新的逻辑进行适配，一般这样就可以对之前的方法进行“补救”
        }
        // 这里fc()不需要实现，直接继承自Adaptee，这是跟对象适配器最大的不同点
    }

}