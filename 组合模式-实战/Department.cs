using System;
using System.Collections.Generic;
using System.Text;

namespace 组合模式_实战
{
    public class Department : HumanResource
    {
        private List<HumanResource> subNodes = new List<HumanResource>();

        public Department(long id) : base(id)
        {
        }

        public override double calculateSalary()
        {
            double totalSalary = 0;
            foreach (HumanResource hr in subNodes)
            {
                totalSalary += hr.calculateSalary();
            }
            this.salary = totalSalary;
            return totalSalary;
        }

        public void addSubNode(HumanResource hr)
        {
            subNodes.Add(hr);
        }
    }
}
