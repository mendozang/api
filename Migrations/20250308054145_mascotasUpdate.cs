using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class mascotasUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaNacimiento",
                schema: "public",
                table: "Mascotas");

            migrationBuilder.AddColumn<string>(
                name: "AñoNacimiento",
                schema: "public",
                table: "Mascotas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                schema: "public",
                table: "Mascotas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                schema: "public",
                table: "Mascotas",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tamaño",
                schema: "public",
                table: "Mascotas",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AñoNacimiento",
                schema: "public",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "Color",
                schema: "public",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "Genero",
                schema: "public",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "Tamaño",
                schema: "public",
                table: "Mascotas");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                schema: "public",
                table: "Mascotas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
