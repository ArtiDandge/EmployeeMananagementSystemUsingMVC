using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using EmployeeModel.Models;

namespace EmployeeRepository
{
    public interface IRepository
    {
        public ActionResult CreateEmployee(Employee employee);
        public JsonResult GetEmployee(string id);
    }
}
