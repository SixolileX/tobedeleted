using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tobedeleted.Migrations
{
    public partial class changeHoDDepSubCols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "HOD");
            migrationBuilder.DropTable(
                name: "Department");
            migrationBuilder.DropTable(
                name: "Subject");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            //migrationBuilder.CreateTable(
            //    name: "SubDep",
            //    columns: table => new
            //    {
            //        SubDepID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DepDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        SubDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SubDep", x => x.SubDepID);
            //    });
        }
    }
}
