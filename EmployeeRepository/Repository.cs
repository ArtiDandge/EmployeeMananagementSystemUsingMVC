using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using EmployeeModel.Models;
using System.Web.Mvc;

namespace EmployeeRepository
{
    public class Repository : Controller, IRepository
    {
        EmployeeContext employeeContext = new EmployeeContext();
        public ActionResult CreateEmployee(Employee employee)
        {
            employeeContext.Employees.Add(employee);
            employeeContext.SaveChanges();
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }

        [HttpGet]
        public JsonResult GetEmployee(string id)
        {
            List<Employee> employees = new List<Employee>();
            employees = employeeContext.Employees.ToList();
            return Json(employees, JsonRequestBehavior.AllowGet);
        }

    }
}
