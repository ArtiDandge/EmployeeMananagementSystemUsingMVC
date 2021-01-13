using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRepository;
using EmployeeModel.Models;

namespace EmployeeManagementSystemUsingASPNET.Controllers
{
    public class EmployeeController : Controller
    {
        private IRepository repository;
        Repository EmpRepository = new Repository();
        public EmployeeController(IRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //[Route("api/addEmployee")]
        //public IActionResult AddEmployee(Employee employee)
        //{
        //    var result = repository.CreateEmployee();
        //}
    }
}
