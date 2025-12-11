using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SporSalonu_Odev.Migrations
{
    /// <inheritdoc />
    public partial class SureBilgisiEklendi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SureDakika",
                table: "Hizmetler",
                newName: "Sure");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sure",
                table: "Hizmetler",
                newName: "SureDakika");
        }
    }
}
