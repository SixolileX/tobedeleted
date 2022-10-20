using Microsoft.EntityFrameworkCore.Migrations;

namespace tobedeleted.Migrations
{
    public partial class RemoveRoleNameColFromHOD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleName",
                table: "HOD");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
