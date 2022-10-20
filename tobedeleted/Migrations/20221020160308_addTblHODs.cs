using Microsoft.EntityFrameworkCore.Migrations;

namespace tobedeleted.Migrations
{
    public partial class addTblHODs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_HOD_HoDId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_HOD_HoDId",
                table: "Subjects");

            migrationBuilder.DropTable(
                name: "HOD");

            migrationBuilder.RenameColumn(
                name: "HoDId",
                table: "Subjects",
                newName: "HODsHoDId");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_HoDId",
                table: "Subjects",
                newName: "IX_Subjects_HODsHoDId");

            migrationBuilder.RenameColumn(
                name: "HoDId",
                table: "Departments",
                newName: "HODsHoDId");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_HoDId",
                table: "Departments",
                newName: "IX_Departments_HODsHoDId");

            migrationBuilder.CreateTable(
                name: "HODs",
                columns: table => new
                {
                    HoDId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userHoDId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HODs", x => x.HoDId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_HODs_HODsHoDId",
                table: "Departments",
                column: "HODsHoDId",
                principalTable: "HODs",
                principalColumn: "HODsHoDId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_HODs_HODsHoDId",
                table: "Subjects",
                column: "HODsHoDId",
                principalTable: "HODs",
                principalColumn: "HODsHoDId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_HODs_HODsHoDId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_HODs_HODsHoDId",
                table: "Subjects");

            migrationBuilder.DropTable(
                name: "HODs");

            migrationBuilder.RenameColumn(
                name: "HODsHoDId",
                table: "Subjects",
                newName: "HODsHoDId");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_HODsHoDId",
                table: "Subjects",
                newName: "IX_Subjects_HoDId");

            migrationBuilder.RenameColumn(
                name: "HODsHoDId",
                table: "Departments",
                newName: "HODsHoDId");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_HODsHoDId",
                table: "Departments",
                newName: "IX_Departments_HoDId");

            migrationBuilder.CreateTable(
                name: "HOD",
                columns: table => new
                {
                    HoDId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepID = table.Column<int>(type: "int", nullable: false),
                    userHoDId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOD", x => x.HoDId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_HOD_HoDId",
                table: "Departments",
                column: "HoDId",
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
    }
}
