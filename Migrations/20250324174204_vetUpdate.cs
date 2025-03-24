using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class vetUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InformacionContacto",
                schema: "public",
                table: "Veterinarios",
                newName: "Telefono");

            migrationBuilder.AddColumn<double>(
                name: "Calificacion",
                schema: "public",
                table: "Veterinarios",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                schema: "public",
                table: "Veterinarios",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "public",
                table: "Veterinarios",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Horario",
                schema: "public",
                table: "Veterinarios",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Latitud",
                schema: "public",
                table: "Veterinarios",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitud",
                schema: "public",
                table: "Veterinarios",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calificacion",
                schema: "public",
                table: "Veterinarios");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                schema: "public",
                table: "Veterinarios");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "public",
                table: "Veterinarios");

            migrationBuilder.DropColumn(
                name: "Horario",
                schema: "public",
                table: "Veterinarios");

            migrationBuilder.DropColumn(
                name: "Latitud",
                schema: "public",
                table: "Veterinarios");

            migrationBuilder.DropColumn(
                name: "Longitud",
                schema: "public",
                table: "Veterinarios");

            migrationBuilder.RenameColumn(
                name: "Telefono",
                schema: "public",
                table: "Veterinarios",
                newName: "InformacionContacto");
        }
    }
}
