using Microsoft.EntityFrameworkCore;
using StudentAdminPortal.API.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdminPortal.API.Context
{
    public class StudentAdminDbContext : DbContext
    {
        public StudentAdminDbContext(DbContextOptions<StudentAdminDbContext> options): base(options)
        {

        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Address> Addresse { get; set; }
        public DbSet<Gender> Gender { get; set; }

    }
}
