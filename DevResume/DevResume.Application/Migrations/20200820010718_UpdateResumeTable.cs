using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevResume.Application.Migrations
{
    public partial class UpdateResumeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telegram",
                table: "Resume");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Resume",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Resume",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Resume",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CommunicationMethod",
                table: "Resume",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Resume",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Languages",
                table: "Resume",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Resume",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "CommunicationMethod",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "Languages",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Resume");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Resume",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telegram",
                table: "Resume",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
