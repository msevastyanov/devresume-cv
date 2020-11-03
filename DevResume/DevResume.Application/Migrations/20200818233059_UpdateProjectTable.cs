using Microsoft.EntityFrameworkCore.Migrations;

namespace DevResume.Application.Migrations
{
    public partial class UpdateProjectTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Repo",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Project");

            migrationBuilder.AddColumn<string>(
                name: "AppStore",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDesktopApp",
                table: "Project",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLibrary",
                table: "Project",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMobileApp",
                table: "Project",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsWebApp",
                table: "Project",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Platforms",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlayStore",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Project",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppStore",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IsDesktopApp",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IsLibrary",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IsMobileApp",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IsWebApp",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Platforms",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "PlayStore",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Project");

            migrationBuilder.AddColumn<string>(
                name: "Repo",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
