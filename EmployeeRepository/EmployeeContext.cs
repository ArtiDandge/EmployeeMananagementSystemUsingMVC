using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using EmployeeModel.Models;

namespace EmployeeRepository
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public EmployeeContext()
        {

        }

        public EmployeeContext(DbContextOptions<EmployeeContext> options)
        : base(options)
        {

        }
    }
}
