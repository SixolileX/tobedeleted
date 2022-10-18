using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tobedeleted.Migrations
{
    public partial class EnrollSubjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Attachment",
                table: "Assignment",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EnrollStudents",
                columns: table => new
                {
                    EnrollID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnrollDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollStudents", x => x.EnrollID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnrollStudents");

            migrationBuilder.DropColumn(
                name: "Attachment",
                table: "Assignment");
        }
    }
}
