using System;
using System.Collections.Generic;
using System.Text;

namespace 组合模式_实战
{
    public class Employee : HumanResource
    {
        public Employee(long id, double salary) : base(id)
        {
            this.salary = salary;
        }

        public override double calculateSalary()
        {
            return salary;
        }
    }
}
