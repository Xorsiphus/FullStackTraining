using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstApp.Migrations
{
    public partial class next : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsForExpulsion_Students_StudentId",
                table: "StudentsForExpulsion");

            migrationBuilder.DropIndex(
                name: "IX_StudentsForExpulsion_StudentId",
                table: "StudentsForExpulsion");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "StudentsForExpulsion",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentsForExpulsion_StudentId",
                table: "StudentsForExpulsion",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsForExpulsion_Students_StudentId",
                table: "StudentsForExpulsion",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentsForExpulsion_Students_StudentId",
                table: "StudentsForExpulsion");

            migrationBuilder.DropIndex(
                name: "IX_StudentsForExpulsion_StudentId",
                table: "StudentsForExpulsion");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "StudentsForExpulsion",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsForExpulsion_StudentId",
                table: "StudentsForExpulsion",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentsForExpulsion_Students_StudentId",
                table: "StudentsForExpulsion",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
