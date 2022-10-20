using Microsoft.EntityFrameworkCore.Migrations;

namespace tobedeleted.Migrations
{
    public partial class removeSubIDColATHod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubID",
                table: "HOD");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
