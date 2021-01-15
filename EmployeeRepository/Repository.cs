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

        public string LoginIntoSystem(string Email,  string Password)
        {
            string message;
            var Login = this.employeeContext.Employees
                        .Where(x => x.Email == Email && x.Password == Password).SingleOrDefault();
            if (Login != null)
            {
                message = "LOGIN SUCCESS";
            }
            else
            {
                message = "LOGIN UNSUCCESSFUL";

            }
            return message;
        }

        public IEnumerable<Employee> GetEmployee()
        {
            IEnumerable<Employee> Login = this.employeeContext.Employees;
            return Login;
        }

        public string RemoveEmployee(int id)
        {
            try
            {
                var employee = this.employeeContext.Employees.Find(id);
                this.employeeContext.Employees.Remove(employee);
                this.employeeContext.SaveChangesAsync();
                return "Employee Data Deleted Successfully"; ;
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }

    }
}
