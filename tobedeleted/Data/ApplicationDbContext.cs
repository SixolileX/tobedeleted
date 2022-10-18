﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using tobedeleted.Models;

namespace tobedeleted.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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

        public DbSet<tobedeleted.Models.AssignSubjectGrade> SubsToGrade { get; set; }

        public DbSet<tobedeleted.Models.HOD> HOD { get; set; }
        public DbSet<tobedeleted.Models.SubDep> SubDep { get; set; }

        public DbSet<tobedeleted.Models.Grade> Grades { get; set; }

        public DbSet<tobedeleted.Models.MeetingScheduler> MeetingScheduler { get; set; }

        public DbSet<tobedeleted.Models.Attendance> Attendance { get; set; }

        public DbSet<AssignSubject> AssignSubject { get; set; }

        public DbSet<tobedeleted.Models.Assignment> Assignment { get; set; }

        public DbSet<tobedeleted.Models.Parent> Parent { get; set; }
        public DbSet<tobedeleted.Models.Learner> Learner { get; set; }

        public DbSet<tobedeleted.Models.learners> learners { get; set; }

        //public DbSet<tobedeleted.Models.AssignLearnerToParent> AssignLearnerToParent { get; set; }

        public DbSet<tobedeleted.Models.EnrollStudent> EnrollStudents { get; set; }





    }
}
