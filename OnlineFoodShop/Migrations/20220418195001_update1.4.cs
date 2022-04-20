using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineFoodShop.Migrations
{
    public partial class update14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CartProduct");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CartProduct",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
