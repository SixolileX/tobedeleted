using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace tobedeleted.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Lies.Models.Department> Departments { get; set; }
        public DbSet<Lies.Models.Subject> Subjects { get; set; }
        //public DbSet<Lies.Models.Role> Roles { get; set; }
        public DbSet<Lies.Models.HOD> HODs { get; set; }
        //public DbSet<Lies.Models.User> Users { get; set; }
        public DbSet<Lies.Models.Grade> Grades { get; set; }
        public DbSet<tobedeleted.Models.Assignment> Assignments { get; set; }
    }
}
