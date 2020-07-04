using Microsoft.EntityFrameworkCore.Migrations;

namespace ClothesASPCoreApp.Migrations
{
    public partial class updatecustumer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Customers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
