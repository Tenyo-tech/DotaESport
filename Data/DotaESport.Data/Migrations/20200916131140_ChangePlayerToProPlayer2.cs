using Microsoft.EntityFrameworkCore.Migrations;

namespace DotaESport.Data.Migrations
{
    public partial class ChangePlayerToProPlayer2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "ProPlayers");

            migrationBuilder.RenameIndex(
                name: "IX_Players_TeamId",
                table: "ProPlayers",
                newName: "IX_ProPlayers_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_IsDeleted",
                table: "ProPlayers",
                newName: "IX_ProPlayers_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProPlayers",
                table: "ProPlayers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProPlayers_Teams_TeamId",
                table: "ProPlayers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProPlayers_Teams_TeamId",
                table: "ProPlayers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProPlayers",
                table: "ProPlayers");

            migrationBuilder.RenameTable(
                name: "ProPlayers",
                newName: "Players");

            migrationBuilder.RenameIndex(
                name: "IX_ProPlayers_TeamId",
                table: "Players",
                newName: "IX_Players_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_ProPlayers_IsDeleted",
                table: "Players",
                newName: "IX_Players_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
