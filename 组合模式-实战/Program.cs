using System;
using System.Collections.Generic;

namespace 组合模式_实战
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        //private static final long ORGANIZATION_ROOT_ID = 1001;
        //private DepartmentRepo departmentRepo; // 依赖注入
        //private EmployeeRepo employeeRepo; // 依赖注入
        //static void Main(string[] args)
        //{



        //public void buildOrganization()
        //{
        //    Department rootDepartment = new Department(ORGANIZATION_ROOT_ID);
        //    buildOrganization(rootDepartment);
        //}

        //private void buildOrganization(Department department)
        //{
        //    List<long> subDepartmentIds = departmentRepo.getSubDepartmentIds(department.getId());
        //    foreach (Long subDepartmentId in subDepartmentIds)
        //    {
        //        Department subDepartment = new Department(subDepartmentId);
        //        department.addSubNode(subDepartment);
        //        buildOrganization(subDepartment);
        //    }
        //    List<Long> employeeIds = employeeRepo.getDepartmentEmployeeIds(department.getId());
        //    for (Long employeeId : employeeIds)
        //    {
        //        double salary = employeeRepo.getEmployeeSalary(employeeId);
        //        department.addSubNode(new Employee(employeeId, salary));
        //    }
        //}
    }
}

