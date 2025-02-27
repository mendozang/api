﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PetPalzAPI.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250226182135_connection")]
    partial class connection
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PetPalzAPI.Models.HistorialMedico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Enfermedades")
                        .HasColumnType("text");

                    b.Property<int>("MascotaId")
                        .HasColumnType("integer");

                    b.Property<string>("Tratamientos")
                        .HasColumnType("text");

                    b.Property<string>("Vacunas")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MascotaId");

                    b.ToTable("HistorialesMedicos");
                });

            modelBuilder.Entity("PetPalzAPI.Models.Mascota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Especie")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ImagenUrl")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Peso")
                        .HasColumnType("double precision");

                    b.Property<string>("Raza")
                        .HasColumnType("text");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Mascotas");
                });

            modelBuilder.Entity("PetPalzAPI.Models.Monitoreo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Latitud")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitud")
                        .HasColumnType("double precision");

                    b.Property<int>("MascotaId")
                        .HasColumnType("integer");

                    b.Property<int>("Pulso")
                        .HasColumnType("integer");

                    b.Property<int>("Respiración")
                        .HasColumnType("integer");

                    b.Property<double>("Temperatura")
                        .HasColumnType("double precision");

                    b.Property<int>("VFC")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MascotaId");

                    b.ToTable("Monitoreos");
                });

            modelBuilder.Entity("PetPalzAPI.Models.PrimerosAuxilios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Contenido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagenUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Resumen")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PrimerosAuxilios");
                });

            modelBuilder.Entity("PetPalzAPI.Models.Recordatorio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaFin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FechaInicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("FechaUnica")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Frecuencia")
                        .HasColumnType("text");

                    b.Property<TimeSpan?>("Hora")
                        .HasColumnType("interval");

                    b.Property<int>("MascotaId")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MascotaId");

                    b.ToTable("Recordatorios");
                });

            modelBuilder.Entity("PetPalzAPI.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagenUrl")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("PetPalzAPI.Models.Veterinario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Direccion")
                        .HasColumnType("text");

                    b.Property<string>("InformacionContacto")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Veterinarios");
                });

            modelBuilder.Entity("PetPalzAPI.Models.HistorialMedico", b =>
                {
                    b.HasOne("PetPalzAPI.Models.Mascota", "Mascota")
                        .WithMany("HistorialesMedicos")
                        .HasForeignKey("MascotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mascota");
                });

            modelBuilder.Entity("PetPalzAPI.Models.Mascota", b =>
                {
                    b.HasOne("PetPalzAPI.Models.Usuario", "Usuario")
                        .WithMany("Mascotas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PetPalzAPI.Models.Monitoreo", b =>
                {
                    b.HasOne("PetPalzAPI.Models.Mascota", "Mascota")
                        .WithMany("Monitoreos")
                        .HasForeignKey("MascotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mascota");
                });

            modelBuilder.Entity("PetPalzAPI.Models.Recordatorio", b =>
                {
                    b.HasOne("PetPalzAPI.Models.Mascota", "Mascota")
                        .WithMany("Recordatorios")
                        .HasForeignKey("MascotaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mascota");
                });

            modelBuilder.Entity("PetPalzAPI.Models.Mascota", b =>
                {
                    b.Navigation("HistorialesMedicos");

                    b.Navigation("Monitoreos");

                    b.Navigation("Recordatorios");
                });

            modelBuilder.Entity("PetPalzAPI.Models.Usuario", b =>
                {
                    b.Navigation("Mascotas");
                });
#pragma warning restore 612, 618
        }
    }
}
