using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EmployeeModel.Models;
using Microsoft.EntityFrameworkCore;
using WebMatrix.WebData;
using System.Security.Policy;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace EmployeeRepository
{
    public class EmailManager
    {
        public static void AppSettings(out string UserID, out string Password, out string SMTPPort, out string Host)
        {
            UserID = ConfigurationManager.AppSettings.Get("UserID");
            Password = ConfigurationManager.AppSettings.Get("Password");
            SMTPPort = ConfigurationManager.AppSettings.Get("SMTPPort");
            Host = ConfigurationManager.AppSettings.Get("Host");
        }
        public static void SendEmail(string From, string Subject, string Body, string To, string UserID, string Password, string SMTPPort, string Host)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(To);
            mail.From = new MailAddress(From);
            mail.Subject = Subject;
            mail.Body = Body;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = Host;
            smtp.Port = Convert.ToInt16(SMTPPort);
            smtp.Credentials = new NetworkCredential(UserID, Password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
    public class Repository : IRepository
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
            catch (Exception e)
            {
                throw e;
            }

        }

        public IEnumerable<Employee> GetEmployee(int id)
        {
            var employee = this.employeeContext.Employees
                           .Where(x => x.EmployeeId == id);
            IEnumerable<Employee> result = employee;
            return result;
        }

        public string UpdateEmployee(Employee employee)
        {
            if(employee.EmployeeId != 0)
            {
                employeeContext.Entry(employee).State = EntityState.Modified;
            }
            this.employeeContext.SaveChanges();
            string message = "SUCCESS";
            return message;
        }

        public string ForgotPasswordUpdate(string email)
        {
            var employee = this.employeeContext.Employees
                            .Where(x => x.Email == email);
            if (employee != null)
            {
               return "Employee Exist !";
            }
            else
            {
                return "Employee does not Exist !";
            }
        }

        public string ResetPassword(string oldPassword, string newPassword)
        {
            var employeePassword = this.employeeContext.Employees
                            .SingleOrDefault(x=> x.Password == oldPassword);
            if (employeePassword != null)
            {
                employeePassword.Password = newPassword;
                employeeContext.Entry(employeePassword).State = EntityState.Modified;
                employeeContext.SaveChanges();
                return "Password Reset Successfull ! ";
            }
            else
            {
                return "Error While Resetting Password !";
            }
        }
    }
}
