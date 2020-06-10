namespace DotaESport.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddLogoToTournamentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Tournaments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Tournaments");
        }
    }
}
