using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SporSalonu_Odev.Migrations
{
    /// <inheritdoc />
    public partial class EgitmenDuzeltme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MusaitMi",
                table: "Egitmenler");

            migrationBuilder.RenameColumn(
                name: "UzmanlikAlani",
                table: "Egitmenler",
                newName: "Uzmanlik");

            migrationBuilder.RenameColumn(
                name: "CalismaAraligi",
                table: "Egitmenler",
                newName: "Musaitlik");

            migrationBuilder.RenameColumn(
                name: "EgitmenId",
                table: "Egitmenler",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Aciklama",
                table: "Egitmenler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FotoUrl",
                table: "Egitmenler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HizmetTurleri",
                table: "Egitmenler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aciklama",
                table: "Egitmenler");

            migrationBuilder.DropColumn(
                name: "FotoUrl",
                table: "Egitmenler");

            migrationBuilder.DropColumn(
                name: "HizmetTurleri",
                table: "Egitmenler");

            migrationBuilder.RenameColumn(
                name: "Uzmanlik",
                table: "Egitmenler",
                newName: "UzmanlikAlani");

            migrationBuilder.RenameColumn(
                name: "Musaitlik",
                table: "Egitmenler",
                newName: "CalismaAraligi");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Egitmenler",
                newName: "EgitmenId");

            migrationBuilder.AddColumn<bool>(
                name: "MusaitMi",
                table: "Egitmenler",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
