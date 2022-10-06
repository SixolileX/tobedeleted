using Microsoft.EntityFrameworkCore.Migrations;

namespace tobedeleted.Migrations
{
    public partial class Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_assignSubjects",
                table: "assignSubjects");

            migrationBuilder.RenameTable(
                name: "assignSubjects",
                newName: "AssignSubject");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssignSubject",
                table: "AssignSubject",
                column: "SubID");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssignSubject",
                table: "AssignSubject");

            migrationBuilder.RenameTable(
                name: "AssignSubject",
                newName: "assignSubjects");

            migrationBuilder.AddPrimaryKey(
                name: "PK_assignSubjects",
                table: "assignSubjects",
                column: "SubID");
        }
    }
}
