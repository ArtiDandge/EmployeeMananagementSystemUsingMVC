using Microsoft.AspNetCore.Mvc;
using EmployeeRepository;
using EmployeeModel.Models;

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
    }
}
