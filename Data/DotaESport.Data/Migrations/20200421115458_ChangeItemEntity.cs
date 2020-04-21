using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotaESport.Data.Migrations
{
    public partial class ChangeItemEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Recipe_RecipeId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Items_RecipeId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Items");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_RecipeId",
                table: "Items",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_IsDeleted",
                table: "Recipe",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Recipe_RecipeId",
                table: "Items",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
