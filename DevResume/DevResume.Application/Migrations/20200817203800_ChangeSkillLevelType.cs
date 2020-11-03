using Microsoft.EntityFrameworkCore.Migrations;

namespace DevResume.Application.Migrations
{
    public partial class ChangeSkillLevelType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Level",
                table: "Skill",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Level",
                table: "Skill",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
