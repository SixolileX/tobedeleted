using Microsoft.EntityFrameworkCore.Migrations;

namespace tobedeleted.Migrations
{
    public partial class HoDTableChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "HOD");

            migrationBuilder.DropColumn(
                name: "SubID",
                table: "HOD");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "HOD",
                newName: "userHoDId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userHoDId",
                table: "HOD",
                newName: "UserId");

            migrationBuilder.AddColumn<string>(
                name: "RoleName",
                table: "HOD",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SubID",
                table: "HOD",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
