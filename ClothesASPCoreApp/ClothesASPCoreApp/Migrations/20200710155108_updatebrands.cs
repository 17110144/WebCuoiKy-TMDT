using Microsoft.EntityFrameworkCore.Migrations;

namespace ClothesASPCoreApp.Migrations
{
    public partial class updatebrands : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isPublic",
                table: "Brands",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isPublic",
                table: "Brands");
        }
    }
}
