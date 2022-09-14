using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tobedeleted.Migrations
{
    public partial class AddSubDep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    MettingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.MettingID);
                });

            migrationBuilder.CreateTable(
                name: "SubDep",
                columns: table => new
                {
                    SubDepID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDep", x => x.SubDepID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meetings");

            migrationBuilder.DropTable(
                name: "SubDep");

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignID);
                });
        }
    }
}
