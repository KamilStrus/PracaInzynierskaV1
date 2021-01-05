using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PracaInzynierskaV1.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DUser",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    image = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUser", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DZguby",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    location = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    image = table.Column<byte[]>(type: "image", nullable: true),
                    imageB = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    freward = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    user = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DZguby", x => x.id);
                    table.ForeignKey(
                        name: "FK_DZguby_DUser_user",
                        column: x => x.user,
                        principalTable: "DUser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DZguby_user",
                table: "DZguby",
                column: "user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DZguby");

            migrationBuilder.DropTable(
                name: "DUser");
        }
    }
}
