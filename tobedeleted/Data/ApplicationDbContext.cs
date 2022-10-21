using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using tobedeleted.Entities;
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

        public static object Categories { get; internal set; }
        public DbSet<tobedeleted.Models.Department> Departments { get; set; }
        public DbSet<tobedeleted.Models.Subject> Subjects { get; set; }

        public DbSet<tobedeleted.Models.AssignSubjectGrade> SubsToGrade { get; set; }

        public DbSet<tobedeleted.Models.HODs> HODs { get; set; }

        public DbSet<tobedeleted.Models.Grade> Grades { get; set; }
        //public DbSet<tobedeleted.Models.MailMessage> MailMessages { get; set; }
        public DbSet<tobedeleted.Models.TimeTable> TimeTables { get; set; }

        public DbSet<tobedeleted.Models.MeetingScheduler> MeetingScheduler { get; set; }

        public DbSet<tobedeleted.Models.Attendance> Attendance { get; set; }

        public DbSet<AssignSubject> AssignSubject { get; set; }

        public DbSet<tobedeleted.Models.Assignment> Assignment { get; set; }

        public DbSet<tobedeleted.Models.Parent> Parent { get; set; }
        public DbSet<tobedeleted.Models.Learner> Learner { get; set; }

        public DbSet<tobedeleted.Models.learners> learners { get; set; }

        public DbSet<tobedeleted.Models.AssignLearnerToParent> AssignLearnerToParent { get; set; }


        public DbSet<tobedeleted.Models.studentMeeting> studentMeetings { get; set; }

        public DbSet<tobedeleted.Models.Announcements> Announcements { get; set; }

        public DbSet<tobedeleted.Models.MeetingUser> MeetingUser { get; set; }

        public DbSet<tobedeleted.Models.Marks> Marks { get; set; }

        public DbSet<tobedeleted.Models.EnrollStudent> EnrollStudents { get; set; }
        public DbSet<FileOnDatabaseModel> FilesOnDatabase { get; set; }


        public DbSet<Exams> Exams { get; set; }

        public DbSet<StuMark> StuMarks { get; set; }

        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryItem> CategoryItem { get; set; }
        public DbSet<MediaType> MediaType { get; set; }
        public DbSet<UserCategory> UserCategory { get; set; }
        public DbSet<Content> Content { get; set; }

    }

}
