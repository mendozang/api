using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class mascotasUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tamaño",
                schema: "public",
                table: "Mascotas",
                newName: "Tamano");

            migrationBuilder.RenameColumn(
                name: "AñoNacimiento",
                schema: "public",
                table: "Mascotas",
                newName: "AnoNacimiento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tamano",
                schema: "public",
                table: "Mascotas",
                newName: "Tamaño");

            migrationBuilder.RenameColumn(
                name: "AnoNacimiento",
                schema: "public",
                table: "Mascotas",
                newName: "AñoNacimiento");
        }
    }
}
