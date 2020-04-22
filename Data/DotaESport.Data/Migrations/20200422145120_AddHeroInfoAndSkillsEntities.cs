using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotaESport.Data.Migrations
{
    public partial class AddHeroInfoAndSkillsEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeroInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    Portrait = table.Column<string>(nullable: true),
                    Bio = table.Column<string>(nullable: true),
                    Str = table.Column<decimal>(nullable: false),
                    StrPerLvl = table.Column<decimal>(nullable: false),
                    Agi = table.Column<decimal>(nullable: false),
                    AgiPerLvl = table.Column<decimal>(nullable: false),
                    Int = table.Column<decimal>(nullable: false),
                    IntPerLvl = table.Column<decimal>(nullable: false),
                    MinDamage = table.Column<decimal>(nullable: false),
                    MaxDamage = table.Column<decimal>(nullable: false),
                    MovementSpeed = table.Column<double>(nullable: false),
                    Armor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Ability = table.Column<string>(nullable: true),
                    DamageType = table.Column<int>(nullable: true),
                    PierceSpellImmunity = table.Column<int>(nullable: false),
                    Affects = table.Column<string>(nullable: true),
                    Cooldown = table.Column<string>(nullable: true),
                    ManaCost = table.Column<string>(nullable: true),
                    HeroInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_HeroInfos_HeroInfoId",
                        column: x => x.HeroInfoId,
                        principalTable: "HeroInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroInfos_IsDeleted",
                table: "HeroInfos",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_HeroInfoId",
                table: "Skills",
                column: "HeroInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_IsDeleted",
                table: "Skills",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "HeroInfos");
        }
    }
}
