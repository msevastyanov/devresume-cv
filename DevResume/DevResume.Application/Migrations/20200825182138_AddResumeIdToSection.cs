using Microsoft.EntityFrameworkCore.Migrations;

namespace DevResume.Application.Migrations
{
    public partial class AddResumeIdToSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResumeId",
                table: "Section",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Section_ResumeId",
                table: "Section",
                column: "ResumeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Section_Resume_ResumeId",
                table: "Section",
                column: "ResumeId",
                principalTable: "Resume",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Section_Resume_ResumeId",
                table: "Section");

            migrationBuilder.DropIndex(
                name: "IX_Section_ResumeId",
                table: "Section");

            migrationBuilder.DropColumn(
                name: "ResumeId",
                table: "Section");
        }
    }
}
