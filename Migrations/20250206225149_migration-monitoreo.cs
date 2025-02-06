using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class migrationmonitoreo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Recordatorios");

            migrationBuilder.DropColumn(
                name: "Recurrente",
                table: "Recordatorios");

            migrationBuilder.RenameColumn(
                name: "Notificacion",
                table: "Recordatorios",
                newName: "Nombre");

            migrationBuilder.AddColumn<string>(
                name: "ImagenUrl",
                table: "Usuarios",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Recordatorios",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFin",
                table: "Recordatorios",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInicio",
                table: "Recordatorios",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaUnica",
                table: "Recordatorios",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Frecuencia",
                table: "Recordatorios",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Hora",
                table: "Recordatorios",
                type: "interval",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagenUrl",
                table: "Mascotas",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Monitoreos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Pulso = table.Column<int>(type: "integer", nullable: false),
                    Temperatura = table.Column<double>(type: "double precision", nullable: false),
                    Respiración = table.Column<int>(type: "integer", nullable: false),
                    VFC = table.Column<int>(type: "integer", nullable: false),
                    Latitud = table.Column<double>(type: "double precision", nullable: false),
                    Longitud = table.Column<double>(type: "double precision", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MascotaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitoreos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Monitoreos_Mascotas_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Mascotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monitoreos_MascotaId",
                table: "Monitoreos",
                column: "MascotaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monitoreos");

            migrationBuilder.DropColumn(
                name: "ImagenUrl",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Recordatorios");

            migrationBuilder.DropColumn(
                name: "FechaFin",
                table: "Recordatorios");

            migrationBuilder.DropColumn(
                name: "FechaInicio",
                table: "Recordatorios");

            migrationBuilder.DropColumn(
                name: "FechaUnica",
                table: "Recordatorios");

            migrationBuilder.DropColumn(
                name: "Frecuencia",
                table: "Recordatorios");

            migrationBuilder.DropColumn(
                name: "Hora",
                table: "Recordatorios");

            migrationBuilder.DropColumn(
                name: "ImagenUrl",
                table: "Mascotas");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Recordatorios",
                newName: "Notificacion");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Recordatorios",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Recurrente",
                table: "Recordatorios",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
