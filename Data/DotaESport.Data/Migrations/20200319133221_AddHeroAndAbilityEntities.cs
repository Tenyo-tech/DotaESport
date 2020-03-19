using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotaESport.Data.Migrations
{
    public partial class AddHeroAndAbilityEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    MainAttribute = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeroAbilities",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ManaCost = table.Column<int>(nullable: false),
                    Cooldown = table.Column<double>(nullable: false),
                    ImgURL = table.Column<string>(nullable: true),
                    VideoURL = table.Column<string>(nullable: true),
                    HeroId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroAbilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeroAbilities_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroAbilities_HeroId",
                table: "HeroAbilities",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroAbilities_IsDeleted",
                table: "HeroAbilities",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_IsDeleted",
                table: "Heroes",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroAbilities");

            migrationBuilder.DropTable(
                name: "Heroes");
        }
    }
}
