using Microsoft.EntityFrameworkCore.Migrations;

namespace PracaInzynierskaV1.Migrations
{
    public partial class abcd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageB",
                table: "DZguby",
                type: "varchar(MAX)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageB",
                table: "DZguby");
        }
    }
}
