using Microsoft.EntityFrameworkCore.Migrations;

namespace tobedeleted.Migrations
{
    public partial class whatever : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HODsHoDId",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HODsHoDId",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HOD",
                columns: table => new
                {
                    HoDId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userHoDId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOD", x => x.HoDId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_HoDId",
                table: "Subjects",
                column: "HODsHoDId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_HoDId",
                table: "Departments",
                column: "HODsHoDId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_HOD_HoDId",
                table: "Departments",
                column: "HODsHoDId",
                principalTable: "HOD",
                principalColumn: "HoDId",
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
                name: "FK_Subjects_HOD_HoDId",
                table: "Subjects");

            migrationBuilder.DropTable(
                name: "HOD");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_HoDId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Departments_HoDId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "HoDId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "HoDId",
                table: "Departments");
        }
    }
}
