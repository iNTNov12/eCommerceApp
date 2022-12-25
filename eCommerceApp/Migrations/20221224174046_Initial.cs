using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerceApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PozaProfilURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeIntreg = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cinematografe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinematografe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producatori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PozaProfilURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeIntreg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producatori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pret = table.Column<double>(type: "float", nullable: false),
                    ImagineURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataIncepere = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataIncheiere = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategorieFilm = table.Column<int>(type: "int", nullable: false),
                    IdCinema = table.Column<int>(type: "int", nullable: false),
                    IdProducator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filme_Cinematografe_IdCinema",
                        column: x => x.IdCinema,
                        principalTable: "Cinematografe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Filme_Producatori_IdProducator",
                        column: x => x.IdProducator,
                        principalTable: "Producatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Actori_Filme",
                columns: table => new
                {
                    IdFilm = table.Column<int>(type: "int", nullable: false),
                    IdActor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actori_Filme", x => new { x.IdActor, x.IdFilm });
                    table.ForeignKey(
                        name: "FK_Actori_Filme_Actori_IdActor",
                        column: x => x.IdActor,
                        principalTable: "Actori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Actori_Filme_Filme_IdFilm",
                        column: x => x.IdFilm,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actori_Filme_IdFilm",
                table: "Actori_Filme",
                column: "IdFilm");

            migrationBuilder.CreateIndex(
                name: "IX_Filme_IdCinema",
                table: "Filme",
                column: "IdCinema");

            migrationBuilder.CreateIndex(
                name: "IX_Filme_IdProducator",
                table: "Filme",
                column: "IdProducator");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actori_Filme");

            migrationBuilder.DropTable(
                name: "Actori");

            migrationBuilder.DropTable(
                name: "Filme");

            migrationBuilder.DropTable(
                name: "Cinematografe");

            migrationBuilder.DropTable(
                name: "Producatori");
        }
    }
}
