using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using EmployeeModel.Models;

namespace EmployeeRepository
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options)
        : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }

    }
}
