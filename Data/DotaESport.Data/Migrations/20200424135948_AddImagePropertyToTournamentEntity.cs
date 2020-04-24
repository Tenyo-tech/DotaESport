using Microsoft.EntityFrameworkCore.Migrations;

namespace DotaESport.Data.Migrations
{
    public partial class AddImagePropertyToTournamentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Tournaments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Tournaments");
        }
    }
}
