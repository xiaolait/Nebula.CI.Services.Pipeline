using Microsoft.EntityFrameworkCore.Migrations;

namespace Nebula.CI.Services.Pipeline.EFCore.DbMigrations.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Pipeline",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Pipeline");
        }
    }
}
