using Microsoft.EntityFrameworkCore.Migrations;

namespace tobedeleted.Migrations
{
    public partial class alotIsHappening : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HOD",
                columns: table => new
                {
                    HoDId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepID = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOD", x => x.HoDId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepPhoto = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    HoDId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepID);
                    table.ForeignKey(
                        name: "FK_Departments_HOD_HoDId",
                        column: x => x.HoDId,
                        principalTable: "HOD",
                        principalColumn: "HoDId",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepID = table.Column<int>(type: "int", nullable: false),
                    SubImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SubCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentDepID = table.Column<int>(type: "int", nullable: true),
                    HoDId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubID);
                    table.ForeignKey(
                        name: "FK_Subjects_Departments_DepartmentDepID",
                        column: x => x.DepartmentDepID,
                        principalTable: "Departments",
                        principalColumn: "DepID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subjects_HOD_HoDId",
                        column: x => x.HoDId,
                        principalTable: "HOD",
                        principalColumn: "HoDId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_HoDId",
                table: "Departments",
                column: "HoDId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_DepartmentDepID",
                table: "Subjects",
                column: "DepartmentDepID");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_HoDId",
                table: "Subjects",
                column: "HoDId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "HOD");

        }
    }
}
