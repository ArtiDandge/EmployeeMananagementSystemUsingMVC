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
            string employee;
            string mailSubject = "Your Employee Management Credentials";
            var employeeCheck = this.employeeContext.Employees
                            .SingleOrDefault(x => x.Email == email);
            if (employeeCheck != null)
            {
               employee = employeeCheck.Password;
                using (MailMessage mailMessage = new MailMessage("dartis2512@gmail.com", email))
                {
                    mailMessage.Subject = mailSubject;
                    mailMessage.Body = employee;
                    mailMessage.IsBodyHtml = true;
                    SmtpClient Smtp = new SmtpClient();
                    Smtp.Host = "smtp.gmail.com";
                    Smtp.EnableSsl = true;
                    Smtp.UseDefaultCredentials = false;
                    Smtp.Credentials = new NetworkCredential("dartis2512@gmail.com", "Arti@1234567890");
                    Smtp.Port = 587;
                    Smtp.Send(mailMessage);
                }
                return "Mail Sent Successfully !";
            }
            else
            {
                return "Error while sending mail !";
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
