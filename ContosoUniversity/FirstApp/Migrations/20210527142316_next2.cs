using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstApp.Migrations
{
    public partial class next2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentsForExpulsion_StudentId",
                table: "StudentsForExpulsion");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsForExpulsion_StudentId",
                table: "StudentsForExpulsion",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentsForExpulsion_StudentId",
                table: "StudentsForExpulsion");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsForExpulsion_StudentId",
                table: "StudentsForExpulsion",
                column: "StudentId",
                unique: true);
        }
    }
}
