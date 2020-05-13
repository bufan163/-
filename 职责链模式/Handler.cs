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
            if (!handled && successor != null)
            {
                Console.WriteLine($"handled:{handled}");
                Console.WriteLine($"successor:{successor}");
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
                Console.WriteLine($"handled:{handled}");
                Console.WriteLine($"successor:{successor}");
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
           //设置handle
            handler.setSuccessor(null);
            Console.WriteLine($"head_set:{handler}");
            
            if (head == null)
            {
                head = handler;
                tail = handler;
                return;
            }
           //设置tail(尾巴)
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
