using System;
using System.Collections.Generic;
using System.Text;

namespace 职责链模式
{

    /// <summary>
    /// 链表处理方式
    /// </summary>
    public abstract class Handler
    {
        protected Handler successor = null;

        public void setSuccessor(Handler successor)
        {
            //链的关键在于这里把下一个节点设置成继承者
            this.successor = successor;
            Console.WriteLine($"[Handler赋值]:{successor}");
        }
        public abstract void handle();
    }

    public class HandlerA : Handler
    {

        public override void handle()
        {
            bool handled = false;
            if (!handled && successor != null)
            {
                Console.WriteLine($"handled:{handled}");
                Console.WriteLine($"successor:{successor}");
                successor.handle();
            }
        }
    }

    public class HandlerB : Handler
    {

        public override void handle()
        {
            bool handled = false;
            //外面处理是处理器B的处理逻辑
            if (!handled && successor != null)
            {
                //如果还需要处理继承者的逻辑并且还有继承者，那么就继续执行if里面的逻辑
                Console.WriteLine($"handledB:{handled}");
                Console.WriteLine($"successorB:{successor}");
                successor.handle();
            }
        }
    }
    public class HandlerC : Handler
    {

        public override void handle()
        {
            bool handled = false;
            if (!handled && successor != null)
            {
                Console.WriteLine($"handledC:{handled}");
                Console.WriteLine($"successorC:{successor}");
                successor.handle();
            }
        }
    }
    /// <summary>
    /// 核心方法
    /// </summary>
    public class HandlerChain
    {

        private Handler head = null;
        private Handler tail = null;

        public void addHandler(Handler handler)
        {
           //设置handle，当前节点的继承者为空
            handler.setSuccessor(null);
            Console.WriteLine($"head_set:{handler}");
            
            if (head == null)
            {
                head = handler;
                tail = handler;
                return;
            }
           //当前链最后一个节点的继承者；新增的处理器就是当前链最后一个节点的继承者
            tail.setSuccessor(handler);
            tail = handler;
            Console.WriteLine($"tail_set:{handler}");
        }

        public void handle()
        {
            if (head != null)
            {
                Console.WriteLine($"{head}");
                head.handle();
            }
        }
    }


}
