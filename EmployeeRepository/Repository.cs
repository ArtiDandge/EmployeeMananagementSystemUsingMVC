using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EmployeeModel.Models;

namespace EmployeeRepository
{
    public class Repository :  IRepository
    {
        EmployeeContext employeeContext;
        public Repository(EmployeeContext employeeContext)
        {
            this.employeeContext = employeeContext;
        }
        
        public string CreateEmployee(Employee employee)
        {
            this.employeeContext.Employees.Add(employee);
            this.employeeContext.SaveChanges();
            string message = "SUCCESS";
            return message;
        }

        public IEnumerable<Employee> GetEmployee(string id)
        {
            List<Employee> employees = new List<Employee>();
            employees = employeeContext.Employees.ToList();
            return employees;
        }

    }
}
