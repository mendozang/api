using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class historialUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HistorialesMedicos_MascotaId",
                schema: "public",
                table: "HistorialesMedicos");

            migrationBuilder.DropColumn(
                name: "Enfermedades",
                schema: "public",
                table: "HistorialesMedicos");

            migrationBuilder.DropColumn(
                name: "Tratamientos",
                schema: "public",
                table: "HistorialesMedicos");

            migrationBuilder.DropColumn(
                name: "Vacunas",
                schema: "public",
                table: "HistorialesMedicos");

            migrationBuilder.RenameColumn(
                name: "Respiración",
                schema: "public",
                table: "Monitoreos",
                newName: "Respiracion");

            migrationBuilder.AddColumn<int>(
                name: "HistorialMedicoId",
                schema: "public",
                table: "Mascotas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Enfermedades",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    FechaDiagnostico = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    HistorialMedicoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermedades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enfermedades_HistorialesMedicos_HistorialMedicoId",
                        column: x => x.HistorialMedicoId,
                        principalSchema: "public",
                        principalTable: "HistorialesMedicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tratamientos",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    HistorialMedicoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tratamientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tratamientos_HistorialesMedicos_HistorialMedicoId",
                        column: x => x.HistorialMedicoId,
                        principalSchema: "public",
                        principalTable: "HistorialesMedicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacunas",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    FechaAplicacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    HistorialMedicoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacunas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacunas_HistorialesMedicos_HistorialMedicoId",
                        column: x => x.HistorialMedicoId,
                        principalSchema: "public",
                        principalTable: "HistorialesMedicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistorialesMedicos_MascotaId",
                schema: "public",
                table: "HistorialesMedicos",
                column: "MascotaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enfermedades_HistorialMedicoId",
                schema: "public",
                table: "Enfermedades",
                column: "HistorialMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tratamientos_HistorialMedicoId",
                schema: "public",
                table: "Tratamientos",
                column: "HistorialMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacunas_HistorialMedicoId",
                schema: "public",
                table: "Vacunas",
                column: "HistorialMedicoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enfermedades",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Tratamientos",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Vacunas",
                schema: "public");

            migrationBuilder.DropIndex(
                name: "IX_HistorialesMedicos_MascotaId",
                schema: "public",
                table: "HistorialesMedicos");

            migrationBuilder.DropColumn(
                name: "HistorialMedicoId",
                schema: "public",
                table: "Mascotas");

            migrationBuilder.RenameColumn(
                name: "Respiracion",
                schema: "public",
                table: "Monitoreos",
                newName: "Respiración");

            migrationBuilder.AddColumn<string>(
                name: "Enfermedades",
                schema: "public",
                table: "HistorialesMedicos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tratamientos",
                schema: "public",
                table: "HistorialesMedicos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vacunas",
                schema: "public",
                table: "HistorialesMedicos",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistorialesMedicos_MascotaId",
                schema: "public",
                table: "HistorialesMedicos",
                column: "MascotaId");
        }
    }
}
