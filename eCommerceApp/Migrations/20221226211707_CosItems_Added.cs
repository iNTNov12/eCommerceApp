using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerceApp.Migrations
{
    public partial class CosItems_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CosItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmId = table.Column<int>(type: "int", nullable: true),
                    Cantitate = table.Column<int>(type: "int", nullable: false),
                    CosId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CosItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CosItems_Filme_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CosItems_FilmId",
                table: "CosItems",
                column: "FilmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CosItems");
        }
    }
}
