using Microsoft.EntityFrameworkCore.Migrations;

namespace ClothesASPCoreApp.Migrations
{
    public partial class updateappuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isLockRole",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isLockRole",
                table: "AspNetUsers");
        }
    }
}
