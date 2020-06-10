namespace DotaESport.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class FK_Skills_HeroInfos_HeroId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_HeroInfos_HeroId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_HeroId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "HeroId",
                table: "Skills");

            migrationBuilder.AddColumn<int>(
                name: "HeroInfoId",
                table: "Skills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_HeroInfoId",
                table: "Skills",
                column: "HeroInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_HeroInfos_HeroInfoId",
                table: "Skills",
                column: "HeroInfoId",
                principalTable: "HeroInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_HeroInfos_HeroInfoId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_HeroInfoId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "HeroInfoId",
                table: "Skills");

            migrationBuilder.AddColumn<int>(
                name: "HeroId",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_HeroId",
                table: "Skills",
                column: "HeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_HeroInfos_HeroId",
                table: "Skills",
                column: "HeroId",
                principalTable: "HeroInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
