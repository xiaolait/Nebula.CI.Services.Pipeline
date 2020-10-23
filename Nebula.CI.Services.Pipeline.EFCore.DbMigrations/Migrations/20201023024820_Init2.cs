using Microsoft.EntityFrameworkCore.Migrations;

namespace Nebula.CI.Services.Pipeline.EFCore.DbMigrations.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FailedTimes",
                table: "Pipeline",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SucceededTimes",
                table: "Pipeline",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FailedTimes",
                table: "Pipeline");

            migrationBuilder.DropColumn(
                name: "SucceededTimes",
                table: "Pipeline");
        }
    }
}
