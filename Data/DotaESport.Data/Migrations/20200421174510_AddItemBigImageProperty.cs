namespace DotaESport.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddItemBigImageProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemBigImage",
                table: "Items",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemBigImage",
                table: "Items");
        }
    }
}
