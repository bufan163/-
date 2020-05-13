using System;
using System.Collections.Generic;
using System.Text;

namespace 职责链模式
{
    /// <summary>
    /// 模板模式
    /// </summary>
    public abstract class Handler2
    {
        protected Handler2 successor = null;

        public void setSuccessor(Handler2 successor)
        {
            this.successor = successor;
        }

        public void handle()
        {
            bool handled = doHandle();
            if (successor != null && !handled)
            {
                successor.handle();
            }
        }

        protected abstract bool doHandle();
    }

    public class HandlerA2 : Handler2
    {
        protected override bool doHandle()
        {
            bool handled = false;
            Console.WriteLine("HandlerA2:doHandle");
            return handled;
        }
    }

    public class HandlerB2 : Handler2
    {
        protected override bool doHandle()
        {
            bool handled = false;
            Console.WriteLine("HandlerB2:doHandle");
            return handled;
        }
    }
    public class HandlerChain2
    {

        private Handler2 head = null;
        private Handler2 tail = null;

        public void addHandler(Handler2 handler)
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
