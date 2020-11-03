using Microsoft.EntityFrameworkCore.Migrations;

namespace DevResume.Application.Migrations
{
    public partial class ChangeSkillTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Skill",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Skill");
        }
    }
}
