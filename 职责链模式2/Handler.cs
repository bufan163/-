using System;
using System.Collections.Generic;
using System.Text;

namespace 职责链模式2
{

    public interface IHandler
    {
        bool handle();
    }

    public class HandlerA : IHandler
    {

        public bool handle()
        {
            bool handled = false;
            Console.WriteLine("HandlerA handle");
            return handled;
        }
    }

    public class HandlerB : IHandler
    {

        public bool handle()
        {
            bool handled = false;
            Console.WriteLine("HandlerB handle");
            return handled;
        }
    }

    public class HandlerChain
    {
        private List<IHandler> handlers = new List<IHandler>();

        public void addHandler(IHandler handler)
        {
            this.handlers.Add(handler);
        }

        public void handle()
        {
            foreach (IHandler handler in handlers)
            {
                bool handled = handler.handle();
                if (handled)
                {
                    break;
                }
            }
        }
    }
}
