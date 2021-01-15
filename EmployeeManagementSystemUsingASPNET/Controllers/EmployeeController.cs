﻿using Microsoft.AspNetCore.Mvc;
using EmployeeRepository;
using EmployeeModel.Models;
using System.Collections.Generic;
using System;

namespace EmployeeManagementSystemUsingASPNET.Controllers
{
    //[ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository repository;
        public EmployeeController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        //[Produces("application/json")]
        [Route("api/addEmployee")]
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
        //[Produces("application/json")]
        [Route("api/Login")]
        public IActionResult GetLoginDetails([FromBody] Employee employee)
        {
           // Employee employee = new Employee();
            var result = this.repository.LoginIntoSystem(employee.Email, employee.Password);
            if (result.Equals("LOGIN SUCCESS"))
            {
                return this.Ok(result);
            }
            else
            {
                return this.BadRequest();
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
    }
}
