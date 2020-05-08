using System;
using System.Collections.Generic;
using System.Text;

namespace 组合模式_实战
{
   public abstract class HumanResource
    {
        protected long id;
        protected double salary;
        public HumanResource(long id)
        {
            this.id = id;
        }
        public long getId()
        {
            return id;
        }
        public abstract double calculateSalary();
    }
}
