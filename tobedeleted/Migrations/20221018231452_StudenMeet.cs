using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tobedeleted.Migrations
{
    public partial class StudenMeet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
             

            migrationBuilder.CreateTable(
                name: "studentMeetings",
                columns: table => new
                {
                    LearnerMeetingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    setdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Meetingdesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentMeetings", x => x.LearnerMeetingID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignLearnerToParent");

            migrationBuilder.DropTable(
                name: "studentMeetings");

            migrationBuilder.AddColumn<byte[]>(
                name: "Attachment",
                table: "Assignment",
                type: "varbinary(max)",
                nullable: true);

        }
    }
}
