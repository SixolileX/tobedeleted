using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tobedeleted.Migrations
{
    public partial class createTimeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<string>(
                name: "userTeacher",
                table: "SubsToGrade",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");


            migrationBuilder.CreateTable(
                name: "TimeTables",
                columns: table => new
                {
                    TtID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Exam = table.Column<int>(type: "int", nullable: false),
                    DepID = table.Column<int>(type: "int", nullable: false),
                    Subject = table.Column<int>(type: "int", nullable: false),
                    GradeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTables", x => x.TtID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "TimeTables");

            migrationBuilder.DropColumn(
                name: "userTeacher",
                table: "SubsToGrade");

            
        }
    }
}
