using System;
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
                name: "Gatunek",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gatuneknazwa = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gatunek", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MarkaUbranie",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    markaubrania = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarkaUbranie", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Producents",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    producentnazwa = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producents", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RodzajElektronika",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rodzajelektroniki = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodzajElektronika", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RodzajUbranie",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rodzajubrania = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RodzajUbranie", x => x.id);
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    ProducentsId = table.Column<long>(type: "bigint", nullable: false),
                    RodzajElektronikaId = table.Column<long>(type: "bigint", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_DZgubaElektronika_Producents_ProducentsId",
                        column: x => x.ProducentsId,
                        principalTable: "Producents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DZgubaElektronika_RodzajElektronika_RodzajElektronikaId",
                        column: x => x.RodzajElektronikaId,
                        principalTable: "RodzajElektronika",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DZgubaUbranie",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Kolor = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    RodzajUbranieId = table.Column<long>(type: "bigint", nullable: false),
                    MarkaUbranieId = table.Column<long>(type: "bigint", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_DZgubaUbranie_MarkaUbranie_MarkaUbranieId",
                        column: x => x.MarkaUbranieId,
                        principalTable: "MarkaUbranie",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DZgubaUbranie_RodzajUbranie_RodzajUbranieId",
                        column: x => x.RodzajUbranieId,
                        principalTable: "RodzajUbranie",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DZgubaZwierze",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    umaszczenie = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    GatunekId = table.Column<long>(type: "bigint", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_DZgubaZwierze_Gatunek_GatunekId",
                        column: x => x.GatunekId,
                        principalTable: "Gatunek",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_DZgubaElektronika_ProducentsId",
                table: "DZgubaElektronika",
                column: "ProducentsId");

            migrationBuilder.CreateIndex(
                name: "IX_DZgubaElektronika_RodzajElektronikaId",
                table: "DZgubaElektronika",
                column: "RodzajElektronikaId");

            migrationBuilder.CreateIndex(
                name: "IX_DZgubaUbranie_MarkaUbranieId",
                table: "DZgubaUbranie",
                column: "MarkaUbranieId");

            migrationBuilder.CreateIndex(
                name: "IX_DZgubaUbranie_RodzajUbranieId",
                table: "DZgubaUbranie",
                column: "RodzajUbranieId");

            migrationBuilder.CreateIndex(
                name: "IX_DZgubaZwierze_GatunekId",
                table: "DZgubaZwierze",
                column: "GatunekId");

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
                name: "Producents");

            migrationBuilder.DropTable(
                name: "RodzajElektronika");

            migrationBuilder.DropTable(
                name: "MarkaUbranie");

            migrationBuilder.DropTable(
                name: "RodzajUbranie");

            migrationBuilder.DropTable(
                name: "DZguby");

            migrationBuilder.DropTable(
                name: "Gatunek");

            migrationBuilder.DropTable(
                name: "DUser");
        }
    }
}
