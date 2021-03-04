using Microsoft.VisualStudio.Services.CircuitBreaker;
using System;
using System.Collections.Generic;
using System.Text;

namespace 单例模式_实战
{

    public class IdGenerator
    {

        private AtomicLong id = new AtomicLong(0);
        private static IdGenerator instance;
        private IdGenerator() { }
        private static readonly object padlock = new object();
        public static IdGenerator getInstance()
        {
            if (instance == null)
            {
                lock (padlock)
                { // 此处为类级别的锁
                    if (instance == null)
                    {
                        instance = new IdGenerator();
                    }
                }
            }
            return instance;
        }
        public long getId()
        {
            return id.IncrementAndGet();
        }
    }
}
