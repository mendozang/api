﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PetPalzAPI.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PetPalzAPI.Models.Enfermedad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaDiagnostico")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("HistorialMedicoId")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HistorialMedicoId");

                    b.ToTable("Enfermedades", "public");
                });

            modelBuilder.Entity("PetPalzAPI.Models.HistorialMedico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MascotaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MascotaId")
                        .IsUnique();

                    b.ToTable("HistorialesMedicos", "public");
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

                    b.ToTable("Mascotas", "public");
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

                    b.Property<int>("Respiracion")
                        .HasColumnType("integer");

                    b.Property<double>("Temperatura")
                        .HasColumnType("double precision");

                    b.Property<int>("VFC")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MascotaId");

                    b.ToTable("Monitoreos", "public");
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

                    b.ToTable("PrimerosAuxilios", "public");
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

                    b.ToTable("Recordatorios", "public");
                });

            modelBuilder.Entity("PetPalzAPI.Models.Tratamiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<DateTime?>("FechaFin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("HistorialMedicoId")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HistorialMedicoId");

                    b.ToTable("Tratamientos", "public");
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

                    b.ToTable("Usuarios", "public");
                });

            modelBuilder.Entity("PetPalzAPI.Models.Vacuna", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaAplicacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("HistorialMedicoId")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HistorialMedicoId");

                    b.ToTable("Vacunas", "public");
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

                    b.ToTable("Veterinarios", "public");
                });

            modelBuilder.Entity("PetPalzAPI.Models.Enfermedad", b =>
                {
                    b.HasOne("PetPalzAPI.Models.HistorialMedico", "HistorialMedico")
                        .WithMany("Enfermedades")
                        .HasForeignKey("HistorialMedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HistorialMedico");
                });

            modelBuilder.Entity("PetPalzAPI.Models.HistorialMedico", b =>
                {
                    b.HasOne("PetPalzAPI.Models.Mascota", "Mascota")
                        .WithOne()
                        .HasForeignKey("PetPalzAPI.Models.HistorialMedico", "MascotaId")
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

            modelBuilder.Entity("PetPalzAPI.Models.Tratamiento", b =>
                {
                    b.HasOne("PetPalzAPI.Models.HistorialMedico", "HistorialMedico")
                        .WithMany("Tratamientos")
                        .HasForeignKey("HistorialMedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HistorialMedico");
                });

            modelBuilder.Entity("PetPalzAPI.Models.Vacuna", b =>
                {
                    b.HasOne("PetPalzAPI.Models.HistorialMedico", "HistorialMedico")
                        .WithMany("Vacunas")
                        .HasForeignKey("HistorialMedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HistorialMedico");
                });

            modelBuilder.Entity("PetPalzAPI.Models.HistorialMedico", b =>
                {
                    b.Navigation("Enfermedades");

                    b.Navigation("Tratamientos");

                    b.Navigation("Vacunas");
                });

            modelBuilder.Entity("PetPalzAPI.Models.Mascota", b =>
                {
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
