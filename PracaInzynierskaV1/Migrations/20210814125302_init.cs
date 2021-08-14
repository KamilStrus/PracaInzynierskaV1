using Microsoft.EntityFrameworkCore.Migrations;

namespace PracaInzynierskaV1.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DNagroda",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    imageB = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    cost = table.Column<int>(type: "int", nullable: false),
                    ilosc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DNagroda", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DUser",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    surname = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    imageB = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUser", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Email",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    clientemail = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    content = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    sent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Email", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DUser_DNagroda",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DUserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DNagrodaID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUser_DNagroda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DUser_DNagroda_DNagroda_DNagrodaID",
                        column: x => x.DNagrodaID,
                        principalTable: "DNagroda",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DUser_DNagroda_DUser_DUserID",
                        column: x => x.DUserID,
                        principalTable: "DUser",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DZguby",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    location = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    imageB = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    freward = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    user = table.Column<string>(type: "nvarchar(450)", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "DZgubaElektronika",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Rodzaj = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Producent = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DZgubaElektronika", x => x.id);
                    table.ForeignKey(
                        name: "FK_DZgubaElektronika_DZguby_id",
                        column: x => x.id,
                        principalTable: "DZguby",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DZgubaUbranie",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Rodzaj = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Marka = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Kolor = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DZgubaUbranie", x => x.id);
                    table.ForeignKey(
                        name: "FK_DZgubaUbranie_DZguby_id",
                        column: x => x.id,
                        principalTable: "DZguby",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DZgubaZwierze",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    gatunek = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    umaszczenie = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DZgubaZwierze", x => x.id);
                    table.ForeignKey(
                        name: "FK_DZgubaZwierze_DZguby_id",
                        column: x => x.id,
                        principalTable: "DZguby",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DUser_DNagroda_DNagrodaID",
                table: "DUser_DNagroda",
                column: "DNagrodaID");

            migrationBuilder.CreateIndex(
                name: "IX_DUser_DNagroda_DUserID",
                table: "DUser_DNagroda",
                column: "DUserID");

            migrationBuilder.CreateIndex(
                name: "IX_DZguby_user",
                table: "DZguby",
                column: "user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DUser_DNagroda");

            migrationBuilder.DropTable(
                name: "DZgubaElektronika");

            migrationBuilder.DropTable(
                name: "DZgubaUbranie");

            migrationBuilder.DropTable(
                name: "DZgubaZwierze");

            migrationBuilder.DropTable(
                name: "Email");

            migrationBuilder.DropTable(
                name: "DNagroda");

            migrationBuilder.DropTable(
                name: "DZguby");

            migrationBuilder.DropTable(
                name: "DUser");
        }
    }
}
