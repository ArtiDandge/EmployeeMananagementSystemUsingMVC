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
        public IEnumerable<Employee> GetEmployee(int id);
        public string UpdateEmployee(Employee employee);
        public string ForgotPasswordUpdate(string email);
        public string ResetPassword(string oldPassword, string newPassword);
    }
}
