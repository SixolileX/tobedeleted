using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tobedeleted.Migrations
{
    public partial class MeetingAndTimeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "MeetingScheduler",
                newName: "SetDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExamDate",
                table: "TimeTables",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "TimeTables",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Desc",
                table: "MeetingScheduler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MeetingDate",
                table: "MeetingScheduler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "userID",
                table: "MeetingScheduler",
                type: "nvarchar(max)",
                nullable: true);

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "Date",
                table: "TimeTables");

            migrationBuilder.DropColumn(
                name: "MeetingDate",
                table: "MeetingScheduler");

            migrationBuilder.DropColumn(
                name: "userID",
                table: "MeetingScheduler");

            migrationBuilder.RenameColumn(
                name: "SetDate",
                table: "MeetingScheduler",
                newName: "Date");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "ExamDate",
                table: "TimeTables",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Desc",
                table: "MeetingScheduler",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
