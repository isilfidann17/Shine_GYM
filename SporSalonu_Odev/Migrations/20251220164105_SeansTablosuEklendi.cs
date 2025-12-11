using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SporSalonu_Odev.Migrations
{
    /// <inheritdoc />
    public partial class SeansTablosuEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seanslar",
                columns: table => new
                {
                    SeansId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gun = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Saat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HizmetId = table.Column<int>(type: "int", nullable: false),
                    EgitmenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seanslar", x => x.SeansId);
                    table.ForeignKey(
                        name: "FK_Seanslar_Egitmenler_EgitmenId",
                        column: x => x.EgitmenId,
                        principalTable: "Egitmenler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seanslar_Hizmetler_HizmetId",
                        column: x => x.HizmetId,
                        principalTable: "Hizmetler",
                        principalColumn: "HizmetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seanslar_EgitmenId",
                table: "Seanslar",
                column: "EgitmenId");

            migrationBuilder.CreateIndex(
                name: "IX_Seanslar_HizmetId",
                table: "Seanslar",
                column: "HizmetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seanslar");
        }
    }
}
