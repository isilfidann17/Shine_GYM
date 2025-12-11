using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SporSalonu_Odev.Migrations
{
    /// <inheritdoc />
    public partial class RandevuSonGuncelleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Hizmetler_HizmetId",
                table: "Randevular");

            migrationBuilder.DropColumn(
                name: "Durum",
                table: "Randevular");

            migrationBuilder.RenameColumn(
                name: "TarihSaat",
                table: "Randevular",
                newName: "RandevuTarihi");

            migrationBuilder.RenameColumn(
                name: "HizmetId",
                table: "Randevular",
                newName: "SalonHizmetiId");

            migrationBuilder.RenameIndex(
                name: "IX_Randevular_HizmetId",
                table: "Randevular",
                newName: "IX_Randevular_SalonHizmetiId");

            migrationBuilder.AlterColumn<string>(
                name: "UyeId",
                table: "Randevular",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Hizmetler_SalonHizmetiId",
                table: "Randevular",
                column: "SalonHizmetiId",
                principalTable: "Hizmetler",
                principalColumn: "HizmetId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameIndex(
                name: "IX_Randevular_SalonHizmetiId",
                table: "Randevular",
                newName: "IX_Randevular_HizmetId");

            migrationBuilder.AlterColumn<string>(
                name: "UyeId",
                table: "Randevular",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Durum",
                table: "Randevular",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Hizmetler_HizmetId",
                table: "Randevular",
                column: "HizmetId",
                principalTable: "Hizmetler",
                principalColumn: "HizmetId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
