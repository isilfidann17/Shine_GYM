using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SporSalonu_Odev.Migrations
{
    /// <inheritdoc />
    public partial class RandevuTablosuGuncelle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Hizmetler_SalonHizmetiId",
                table: "Randevular");

            migrationBuilder.RenameColumn(
                name: "SalonHizmetiId",
                table: "Randevular",
                newName: "HizmetId");

            migrationBuilder.RenameColumn(
                name: "RandevuTarihi",
                table: "Randevular",
                newName: "TarihSaat");

            migrationBuilder.RenameColumn(
                name: "RandevuId",
                table: "Randevular",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Randevular_SalonHizmetiId",
                table: "Randevular",
                newName: "IX_Randevular_HizmetId");

            migrationBuilder.AddColumn<bool>(
                name: "OnaylandiMi",
                table: "Randevular",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Hizmetler_HizmetId",
                table: "Randevular",
                column: "HizmetId",
                principalTable: "Hizmetler",
                principalColumn: "HizmetId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Hizmetler_HizmetId",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "OnaylandiMi",
                table: "Randevular");

            migrationBuilder.RenameColumn(
                name: "TarihSaat",
                table: "Randevular",
                newName: "RandevuTarihi");

            migrationBuilder.RenameColumn(
                name: "HizmetId",
                table: "Randevular",
                newName: "SalonHizmetiId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Randevular",
                newName: "RandevuId");

            migrationBuilder.RenameIndex(
                name: "IX_Randevular_HizmetId",
                table: "Randevular",
                newName: "IX_Randevular_SalonHizmetiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Hizmetler_SalonHizmetiId",
                table: "Randevular",
                column: "SalonHizmetiId",
                principalTable: "Hizmetler",
                principalColumn: "HizmetId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
