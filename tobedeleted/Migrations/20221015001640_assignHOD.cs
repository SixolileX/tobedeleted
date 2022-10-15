using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tobedeleted.Migrations
{
    public partial class assignHOD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepID",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentDepID",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HoDId",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubCode",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "SubImage",
                table: "Subjects",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "DepPhoto",
                table: "Departments",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<int>(
                name: "HoDId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HOD",
                columns: table => new
                {
                    HoDId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubID = table.Column<int>(type: "int", nullable: false),
                    DepID = table.Column<int>(type: "int", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOD", x => x.HoDId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_DepartmentDepID",
                table: "Subjects",
                column: "DepartmentDepID");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_HoDId",
                table: "Subjects",
                column: "HoDId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_HoDId",
                table: "Departments",
                column: "HoDId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_HOD_HoDId",
                table: "Departments",
                column: "HoDId",
                principalTable: "HOD",
                principalColumn: "HoDId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Departments_DepartmentDepID",
                table: "Subjects",
                column: "DepartmentDepID",
                principalTable: "Departments",
                principalColumn: "DepID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_HOD_HoDId",
                table: "Subjects",
                column: "HoDId",
                principalTable: "HOD",
                principalColumn: "HoDId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_HOD_HoDId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Departments_DepartmentDepID",
                table: "Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_HOD_HoDId",
                table: "Subjects");

            migrationBuilder.DropTable(
                name: "HOD");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_DepartmentDepID",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_HoDId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Departments_HoDId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DepID",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "DepartmentDepID",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "HoDId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "SubCode",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "SubImage",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "DepPhoto",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "HoDId",
                table: "Departments");
        }
    }
}
