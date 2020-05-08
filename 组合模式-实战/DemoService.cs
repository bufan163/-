using System;
using System.Collections.Generic;
using System.Text;

namespace 组合模式_实战
{
   
    // 构建组织架构的代码
    public class DemoService
    {
        private static  long ORGANIZATION_ROOT_ID = 1001;
        //private DepartmentRepo departmentRepo; // 依赖注入
        //private EmployeeRepo employeeRepo; // 依赖注入
      
        public void buildOrganization()
        {
            Department rootDepartment = new Department(ORGANIZATION_ROOT_ID);
            buildOrganization(rootDepartment);
        }

        private void buildOrganization(Department department)
        {
            //List<long> subDepartmentIds = departmentRepo.getSubDepartmentIds(department.getId());
            //foreach (long subDepartmentId in subDepartmentIds)
            //{
            //    Department subDepartment = new Department(subDepartmentId);
            //    department.addSubNode(subDepartment);
            //    buildOrganization(subDepartment);
            //}
            //List<long> employeeIds = employeeRepo.getDepartmentEmployeeIds(department.getId());
            //foreach (long employeeId in employeeIds)
            //{
            //    double salary = employeeRepo.getEmployeeSalary(employeeId);
            //    department.addSubNode(new Employee(employeeId, salary));
            //}
        }
    }
}
