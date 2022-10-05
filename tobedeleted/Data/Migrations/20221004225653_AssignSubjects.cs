using Microsoft.EntityFrameworkCore.Migrations;

namespace tobedeleted.Migrations
{
    public partial class AssignSubjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
             name: "assignSubjects",
             columns: table => new
             {
                 SubID = table.Column<int>(type: "int", nullable: false)
                     .Annotation("SqlServer:Identity", "1, 1"),
                 SubDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                 SubCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_assignSubjects", x => x.SubID);
             });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "assignSubjects");
        }
    }
}
