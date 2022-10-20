﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tobedeleted.Data;

namespace tobedeleted.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("tobedeleted.Models.Announcements", b =>
                {
                    b.Property<int>("AnnounceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AnnounceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AnnouncementDescr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnnouncementName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnnounceID");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("tobedeleted.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Addressline1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Addressline2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("contactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("tobedeleted.Models.AssignLearnerToParent", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("userLearnerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userParent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("AssignLearnerToParent");
                });

            modelBuilder.Entity("tobedeleted.Models.AssignSubject", b =>
                {
                    b.Property<int>("SubID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SubCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubDesc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubID");

                    b.ToTable("AssignSubject");
                });

            modelBuilder.Entity("tobedeleted.Models.AssignSubjectGrade", b =>
                {
                    b.Property<int>("SubGrID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GrID")
                        .HasColumnType("int");

                    b.Property<int>("SubId")
                        .HasColumnType("int");

                    b.Property<string>("userTeacher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubGrID");

                    b.ToTable("SubsToGrade");
                });

            modelBuilder.Entity("tobedeleted.Models.Assignment", b =>
                {
                    b.Property<int>("AssignmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AssignmentDueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AssignmentInstructions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssignmentTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssignmentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AssignmentID");

                    b.ToTable("Assignment");
                });

            modelBuilder.Entity("tobedeleted.Models.Attendance", b =>
                {
                    b.Property<int>("AttendanceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AttendanceID");

                    b.ToTable("Attendance");
                });

            modelBuilder.Entity("tobedeleted.Models.Department", b =>
                {
                    b.Property<int>("DepID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("DepPhoto")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("HODsHoDId")
                        .HasColumnType("int");

                    b.Property<int?>("HoDId")
                        .HasColumnType("int");

                    b.HasKey("DepID");

                    b.HasIndex("HODsHoDId");

                    b.HasIndex("HoDId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("tobedeleted.Models.Grade", b =>
                {
                    b.Property<int>("GrID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GrDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GrID");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("tobedeleted.Models.HOD", b =>
                {
                    b.Property<int>("HoDId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepID")
                        .HasColumnType("int");

                    b.Property<string>("userHoDId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HoDId");

                    b.ToTable("HOD");
                });

            modelBuilder.Entity("tobedeleted.Models.HODs", b =>
                {
                    b.Property<int>("HoDId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepID")
                        .HasColumnType("int");

                    b.Property<string>("userHoDId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HoDId");

                    b.ToTable("HODs");
                });

            modelBuilder.Entity("tobedeleted.Models.Learner", b =>
                {
                    b.Property<int>("learnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GradeId")
                        .HasColumnType("int");

                    b.Property<int>("Parentid")
                        .HasColumnType("int");

                    b.Property<string>("userLearnerId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("learnerId");

                    b.ToTable("Learner");
                });

            modelBuilder.Entity("tobedeleted.Models.MeetingScheduler", b =>
                {
                    b.Property<int>("MeetingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MeetingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SetDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("userID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MeetingID");

                    b.ToTable("MeetingScheduler");
                });

            modelBuilder.Entity("tobedeleted.Models.MeetingUser", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("userParent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userTeacher")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("MeetingUser");
                });

            modelBuilder.Entity("tobedeleted.Models.Parent", b =>
                {
                    b.Property<int>("Parentid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("userLearnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userParentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Parentid");

                    b.ToTable("Parent");
                });

            modelBuilder.Entity("tobedeleted.Models.Subject", b =>
                {
                    b.Property<int>("SubID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepID")
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentDepID")
                        .HasColumnType("int");

                    b.Property<int?>("HODsHoDId")
                        .HasColumnType("int");

                    b.Property<int?>("HoDId")
                        .HasColumnType("int");

                    b.Property<string>("SubCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("SubImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("learnerId")
                        .HasColumnType("int");

                    b.HasKey("SubID");

                    b.HasIndex("DepartmentDepID");

                    b.HasIndex("HODsHoDId");

                    b.HasIndex("HoDId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("tobedeleted.Models.TimeTable", b =>
                {
                    b.Property<int>("TtID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepID")
                        .HasColumnType("int");

                    b.Property<int>("Exam")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GradeID")
                        .HasColumnType("int");

                    b.Property<int>("Subject")
                        .HasColumnType("int");

                    b.HasKey("TtID");

                    b.ToTable("TimeTables");
                });

            modelBuilder.Entity("tobedeleted.Models.learners", b =>
                {
                    b.Property<int>("LeanerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserlearnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LeanerId");

                    b.ToTable("learners");
                });

            modelBuilder.Entity("tobedeleted.Models.studentMeeting", b =>
                {
                    b.Property<int>("LearnerMeetingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Meetingdesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("setdate")
                        .HasColumnType("datetime2");

                    b.HasKey("LearnerMeetingID");

                    b.ToTable("studentMeetings");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("tobedeleted.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("tobedeleted.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tobedeleted.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("tobedeleted.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("tobedeleted.Models.Department", b =>
                {
                    b.HasOne("tobedeleted.Models.HODs", null)
                        .WithMany("Departments")
                        .HasForeignKey("HODsHoDId");

                    b.HasOne("tobedeleted.Models.HOD", null)
                        .WithMany("Departments")
                        .HasForeignKey("HoDId");
                });

            modelBuilder.Entity("tobedeleted.Models.Subject", b =>
                {
                    b.HasOne("tobedeleted.Models.Department", null)
                        .WithMany("Subjects")
                        .HasForeignKey("DepartmentDepID");

                    b.HasOne("tobedeleted.Models.HODs", null)
                        .WithMany("Subjects")
                        .HasForeignKey("HODsHoDId");

                    b.HasOne("tobedeleted.Models.HOD", null)
                        .WithMany("Subjects")
                        .HasForeignKey("HoDId");
                });

            modelBuilder.Entity("tobedeleted.Models.Department", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("tobedeleted.Models.HOD", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("tobedeleted.Models.HODs", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
