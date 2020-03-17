using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotaESport.Data.Migrations
{
    public partial class AddHeroAndHeroAbilitiesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttributeInfo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    MainAttribute = table.Column<string>(nullable: true),
                    BaseStrength = table.Column<double>(nullable: false),
                    StrengthPerLevel = table.Column<double>(nullable: false),
                    BaseAgility = table.Column<double>(nullable: false),
                    AgilityPerLevel = table.Column<double>(nullable: false),
                    BaseIntelligence = table.Column<double>(nullable: false),
                    IntelligencePerLevel = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    AttackType = table.Column<int>(nullable: true),
                    AttributeInfoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Heroes_AttributeInfo_AttributeInfoId",
                        column: x => x.AttributeInfoId,
                        principalTable: "AttributeInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HeroAbilities",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
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
                name: "IX_Heroes_AttributeInfoId",
                table: "Heroes",
                column: "AttributeInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroAbilities");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "AttributeInfo");
        }
    }
}
