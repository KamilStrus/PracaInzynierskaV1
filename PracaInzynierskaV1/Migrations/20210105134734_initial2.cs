using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PracaInzynierskaV1.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image",
                table: "DUser");

            migrationBuilder.AddColumn<string>(
                name: "imageB",
                table: "DUser",
                type: "varchar(MAX)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageB",
                table: "DUser");

            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "DUser",
                type: "image",
                nullable: true);
        }
    }
}
