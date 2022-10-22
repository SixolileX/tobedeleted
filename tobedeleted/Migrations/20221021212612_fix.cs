using Microsoft.EntityFrameworkCore.Migrations;

namespace tobedeleted.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Exam",
                table: "TimetableDisplay");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "TimetableDisplay",
                newName: "SubDesc");

            migrationBuilder.RenameColumn(
                name: "GradeID",
                table: "TimetableDisplay",
                newName: "GrDesc");

            migrationBuilder.RenameColumn(
                name: "DepID",
                table: "TimetableDisplay",
                newName: "DepDesc");

            migrationBuilder.AddColumn<string>(
                name: "AssignmentType",
                table: "TimetableDisplay",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignmentType",
                table: "TimetableDisplay");

            migrationBuilder.RenameColumn(
                name: "SubDesc",
                table: "TimetableDisplay",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "GrDesc",
                table: "TimetableDisplay",
                newName: "GradeID");

            migrationBuilder.RenameColumn(
                name: "DepDesc",
                table: "TimetableDisplay",
                newName: "DepID");

            migrationBuilder.AddColumn<int>(
                name: "Exam",
                table: "TimetableDisplay",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
