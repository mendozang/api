using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class newconect : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "Veterinarios",
                newName: "Veterinarios",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuarios",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Recordatorios",
                newName: "Recordatorios",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "PrimerosAuxilios",
                newName: "PrimerosAuxilios",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Monitoreos",
                newName: "Monitoreos",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Mascotas",
                newName: "Mascotas",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "HistorialesMedicos",
                newName: "HistorialesMedicos",
                newSchema: "public");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Veterinarios",
                schema: "public",
                newName: "Veterinarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                schema: "public",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Recordatorios",
                schema: "public",
                newName: "Recordatorios");

            migrationBuilder.RenameTable(
                name: "PrimerosAuxilios",
                schema: "public",
                newName: "PrimerosAuxilios");

            migrationBuilder.RenameTable(
                name: "Monitoreos",
                schema: "public",
                newName: "Monitoreos");

            migrationBuilder.RenameTable(
                name: "Mascotas",
                schema: "public",
                newName: "Mascotas");

            migrationBuilder.RenameTable(
                name: "HistorialesMedicos",
                schema: "public",
                newName: "HistorialesMedicos");
        }
    }
}
