using System;
using System.Collections.Generic;
using System.Text;
using EmployeeModel.Models;

namespace EmployeeRepository
{
    public interface IRepository
    {
        public string CreateEmployee(Employee employee);
        public string LoginIntoSystem(string Email, string Password);
        public IEnumerable<Employee> GetEmployee();
        public string RemoveEmployee(int id);
    }
}
