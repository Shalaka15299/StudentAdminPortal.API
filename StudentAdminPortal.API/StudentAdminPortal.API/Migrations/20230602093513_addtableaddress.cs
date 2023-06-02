using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAdminPortal.API.Migrations
{
    public partial class addtableaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresse_Student_StudentId",
                table: "Addresse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresse",
                table: "Addresse");

            migrationBuilder.RenameTable(
                name: "Addresse",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_Addresse_StudentId",
                table: "Address",
                newName: "IX_Address_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Student_StudentId",
                table: "Address",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Student_StudentId",
                table: "Address");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresse");

            migrationBuilder.RenameIndex(
                name: "IX_Address_StudentId",
                table: "Addresse",
                newName: "IX_Addresse_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresse",
                table: "Addresse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresse_Student_StudentId",
                table: "Addresse",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
