﻿using Microsoft.AspNetCore.Mvc;
using EmployeeRepository;
using EmployeeModel.Models;
using System.Collections.Generic;
using System;

namespace EmployeeManagementSystemUsingASPNET.Controllers
{
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository repository;
        public EmployeeController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Route("api/Employee")]
        public IActionResult AddEmployee([FromBody]Employee employee)
        {
            var result = this.repository.CreateEmployee(employee);
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(result);
            }
            else
            {
                return this.BadRequest();
            }
        }

        [HttpPost]
        [Route("api/Login")]
        public IActionResult GetLoginDetails([FromBody] Employee employee)
        {
            var result = this.repository.LoginIntoSystem(employee.Email, employee.Password);
            if (result.Equals("LOGIN SUCCESS"))
            {
                return this.Ok(new { success = true, Message = "Get All Users successfully", Data = result });
            }
            else
            {
                return this.BadRequest(new { success = false, Message = "Failed to fetch Employee" });
            }
        }

        [HttpGet]
        [Route("api/GetAllEmployee")]
        public IActionResult GetAllEmployee()
        {
            try
            {
                IEnumerable<Employee> result = this.repository.GetEmployee();
                return this.Ok(result);
            }
            catch(Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("api/DeleteEmployee")]
        public IActionResult RemoveEmployeeById(int id)
        {
            var result = this.repository.RemoveEmployee(id);
            if (result.Equals("Employee Data Deleted Successfully"))
            {
                return this.Ok(result);
            }
            else
            {
                return this.BadRequest();
            }
        }

        [HttpGet]
        [Route("api/AnEmployeeDetails")]
        public IActionResult GetEmployee(int id)
        {
            IEnumerable<Employee> result = this.repository.GetEmployee(id);
            if (result != null )
            {
                return this.Ok(result);
            }
            else
            {
                return this.BadRequest();
            }
        }

        [HttpPut]
        [Route("api/UpdateEmployeeDetails")]
        public IActionResult UpdateEmployeeDetails([FromBody] Employee employee)
        {
            var result = this.repository.UpdateEmployee(employee);
            if (result.Equals("SUCCESS"))
            {
                return this.Ok(result);
            }
            else
            {
                return this.BadRequest();
            }
        }

        [HttpPut]
        [Route("api/ForgotPassword")]
        public IActionResult UpdateEmployeePassword(string email)
        {
            var result = this.repository.ForgotPasswordUpdate(email);
            if (result.Equals("Mail Sent Successfully !"))
            {
                return this.Ok(result);
            }
            else
            {
                return this.BadRequest();
            }

        }

        [HttpPut]
        [Route("api/ResetPassword")]
        public IActionResult ResetPassword(string oldPassword, string newPassword)
        {
            var result = this.repository.ResetPassword(oldPassword,  newPassword);
            if (result.Equals("Password Reset Successfull ! "))
            {
                return this.Ok(result);
            }
            else
            {
                return this.BadRequest();
            }
        }

    }
}
