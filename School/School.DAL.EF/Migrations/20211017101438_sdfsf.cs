using Microsoft.EntityFrameworkCore.Migrations;

namespace School.DAL.EF.Migrations
{
    public partial class sdfsf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Files_FileId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_FileId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Teachers");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_TeacherId",
                table: "Files",
                column: "TeacherId",
                unique: true,
                filter: "[TeacherId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Teachers_TeacherId",
                table: "Files",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Teachers_TeacherId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_TeacherId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Files");

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "Teachers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_FileId",
                table: "Teachers",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Files_FileId",
                table: "Teachers",
                column: "FileId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
