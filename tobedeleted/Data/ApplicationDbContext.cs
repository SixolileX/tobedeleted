using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace tobedeleted.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<tobedeleted.Models.Department> Departments { get; set; }
        public DbSet<tobedeleted.Models.Subject> Subjects { get; set; }
        //public DbSet<tobedeleted.Models.Meeting> Meetings { get; set; }
        //public DbSet<tobedeleted.Models.HOD> HODs { get; set; }
        public DbSet<tobedeleted.Models.SubDep> SubDep { get; set; }
        public DbSet<tobedeleted.Models.Grade> Grades { get; set; }
        public DbSet<tobedeleted.Models.MeetingScheduler> MeetingScheduler { get; set; }
        public DbSet<tobedeleted.Models.Attendance> Attendance { get; set; }

    }
}
