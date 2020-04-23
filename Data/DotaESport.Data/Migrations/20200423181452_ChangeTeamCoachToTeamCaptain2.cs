using Microsoft.EntityFrameworkCore.Migrations;

namespace DotaESport.Data.Migrations
{
    public partial class ChangeTeamCoachToTeamCaptain2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coach",
                table: "Teams");

            migrationBuilder.AddColumn<string>(
                name: "TeamCaptain",
                table: "Teams",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamCaptain",
                table: "Teams");

            migrationBuilder.AddColumn<string>(
                name: "Coach",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
