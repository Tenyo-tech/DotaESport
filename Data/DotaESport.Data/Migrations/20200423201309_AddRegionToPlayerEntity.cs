﻿namespace DotaESport.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddRegionToPlayerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Players",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Region",
                table: "Players");
        }
    }
}
