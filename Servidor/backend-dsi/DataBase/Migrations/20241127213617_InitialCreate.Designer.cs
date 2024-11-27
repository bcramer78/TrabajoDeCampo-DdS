﻿// <auto-generated />
using System;
using DataBase.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataBase.Migrations
{
    [DbContext(typeof(dsiContext))]
    [Migration("20241127213617_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DataBase.Models.Asiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Numero")
                        .HasColumnType("integer");

                    b.Property<int>("SalaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SalaId");

                    b.ToTable("Asiento", (string)null);
                });

            modelBuilder.Entity("DataBase.Models.AsientoEstado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AsientoEstado", (string)null);
                });

            modelBuilder.Entity("DataBase.Models.Cine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DomicilioId")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Numero")
                        .HasColumnType("integer");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DomicilioId");

                    b.ToTable("Cine", (string)null);
                });

            modelBuilder.Entity("DataBase.Models.Clasificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clasificacion", (string)null);
                });

            modelBuilder.Entity("DataBase.Models.Domicilio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Calle")
                        .HasColumnType("integer");

                    b.Property<int>("LocalidadId")
                        .HasColumnType("integer");

                    b.Property<int>("Numero")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LocalidadId");

                    b.ToTable("Domicilio", (string)null);
                });

            modelBuilder.Entity("DataBase.Models.Entrada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AsientoId")
                        .HasColumnType("integer");

                    b.Property<int>("CompradorId")
                        .HasColumnType("integer");

                    b.Property<int>("Numero")
                        .HasColumnType("integer");

                    b.Property<int>("ProyeccionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AsientoId");

                    b.HasIndex("CompradorId");

                    b.HasIndex("ProyeccionId");

                    b.ToTable("Entrada", (string)null);
                });

            modelBuilder.Entity("DataBase.Models.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genero", (string)null);
                });

            modelBuilder.Entity("DataBase.Models.Localidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProvinciaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProvinciaId");

                    b.ToTable("Localidad", (string)null);
                });

            modelBuilder.Entity("DataBase.Models.Pelicula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClasificacionId")
                        .HasColumnType("integer");

                    b.Property<int>("DirectorId")
                        .HasColumnType("integer");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Numero")
                        .HasColumnType("integer");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ClasificacionId");

                    b.HasIndex("DirectorId");

                    b.ToTable("Pelicula", (string)null);
                });

            modelBuilder.Entity("DataBase.Models.PeliculaEstado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PeliculaEstado", (string)null);
                });

            modelBuilder.Entity("DataBase.Models.PeliculaGenero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GeneroId")
                        .HasColumnType("integer");

                    b.Property<int>("PeliculaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GeneroId");

                    b.HasIndex("PeliculaId");

                    b.ToTable("PeliculaGenero", (string)null);
                });

            modelBuilder.Entity("DataBase.Models.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Persona", (string)null);
                });

            modelBuilder.Entity("DataBase.Models.Personaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ActorId")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PeliculaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ActorId");

                    b.HasIndex("PeliculaId");

                    b.ToTable("Personaje", (string)null);
                });

            modelBuilder.Entity("DataBase.Models.Provincia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Provincia", (string)null);
                });

            modelBuilder.Entity("DataBase.Models.Proyeccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeOnly>("HoraFin")
                        .HasColumnType("time without time zone");

                    b.Property<int>("Numero")
                        .HasColumnType("integer");

                    b.Property<int>("PeliculaId")
                        .HasColumnType("integer");

                    b.Property<int>("SalaId")
                        .HasColumnType("integer");

                    b.Property<int>("TurnoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PeliculaId");

                    b.HasIndex("SalaId");

                    b.HasIndex("TurnoId");

                    b.ToTable("Proyeccion", (string)null);
                });

            modelBuilder.Entity("DataBase.Models.Sala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CineId")
                        .HasColumnType("integer");

                    b.Property<int>("Numero")
                        .HasColumnType("integer");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CineId");

                    b.ToTable("Sala", (string)null);
                });

            modelBuilder.Entity("DataBase.Models.SalaTipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SalaTipo", (string)null);
                });

            modelBuilder.Entity("DataBase.Models.Turno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Turno", (string)null);
                });

            modelBuilder.Entity("DataBase.Models.TurnoPrecio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CineId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Precio")
                        .HasColumnType("numeric");

                    b.Property<int>("TurnoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CineId");

                    b.HasIndex("TurnoId");

                    b.ToTable("TurnoPrecio", (string)null);
                });

            modelBuilder.Entity("DataBase.Models.TurnoTipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TurnoTipo", (string)null);
                });

            modelBuilder.Entity("DataBase.Models.Asiento", b =>
                {
                    b.HasOne("DataBase.Models.Sala", "Sala")
                        .WithMany("Asientos")
                        .HasForeignKey("SalaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sala");
                });

            modelBuilder.Entity("DataBase.Models.Cine", b =>
                {
                    b.HasOne("DataBase.Models.Domicilio", "Domicilio")
                        .WithMany()
                        .HasForeignKey("DomicilioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Domicilio");
                });

            modelBuilder.Entity("DataBase.Models.Domicilio", b =>
                {
                    b.HasOne("DataBase.Models.Localidad", "Localidad")
                        .WithMany("Domicilios")
                        .HasForeignKey("LocalidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Localidad");
                });

            modelBuilder.Entity("DataBase.Models.Entrada", b =>
                {
                    b.HasOne("DataBase.Models.Asiento", "Asiento")
                        .WithMany()
                        .HasForeignKey("AsientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBase.Models.Persona", "Comprador")
                        .WithMany("Entradas")
                        .HasForeignKey("CompradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBase.Models.Proyeccion", "Proyeccion")
                        .WithMany("Entradas")
                        .HasForeignKey("ProyeccionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asiento");

                    b.Navigation("Comprador");

                    b.Navigation("Proyeccion");
                });

            modelBuilder.Entity("DataBase.Models.Localidad", b =>
                {
                    b.HasOne("DataBase.Models.Provincia", "Provincia")
                        .WithMany("Localidades")
                        .HasForeignKey("ProvinciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provincia");
                });

            modelBuilder.Entity("DataBase.Models.Pelicula", b =>
                {
                    b.HasOne("DataBase.Models.Clasificacion", "Clasificacion")
                        .WithMany("Peliculas")
                        .HasForeignKey("ClasificacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBase.Models.Persona", "Director")
                        .WithMany("Peliculas")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clasificacion");

                    b.Navigation("Director");
                });

            modelBuilder.Entity("DataBase.Models.PeliculaGenero", b =>
                {
                    b.HasOne("DataBase.Models.Genero", "Genero")
                        .WithMany("PeliculasGeneros")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBase.Models.Pelicula", "Pelicula")
                        .WithMany("PeliculasGeneros")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genero");

                    b.Navigation("Pelicula");
                });

            modelBuilder.Entity("DataBase.Models.Personaje", b =>
                {
                    b.HasOne("DataBase.Models.Persona", "Actor")
                        .WithMany("Personajes")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBase.Models.Pelicula", "Pelicula")
                        .WithMany("Personajes")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Pelicula");
                });

            modelBuilder.Entity("DataBase.Models.Proyeccion", b =>
                {
                    b.HasOne("DataBase.Models.Pelicula", "Pelicula")
                        .WithMany("Proyecciones")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBase.Models.Sala", "Sala")
                        .WithMany("Proyecciones")
                        .HasForeignKey("SalaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBase.Models.Turno", "Turno")
                        .WithMany("Proyecciones")
                        .HasForeignKey("TurnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pelicula");

                    b.Navigation("Sala");

                    b.Navigation("Turno");
                });

            modelBuilder.Entity("DataBase.Models.Sala", b =>
                {
                    b.HasOne("DataBase.Models.Cine", "Cine")
                        .WithMany("Salas")
                        .HasForeignKey("CineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cine");
                });

            modelBuilder.Entity("DataBase.Models.TurnoPrecio", b =>
                {
                    b.HasOne("DataBase.Models.Cine", "Cine")
                        .WithMany("TurnosPrecios")
                        .HasForeignKey("CineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBase.Models.Turno", "Turno")
                        .WithMany("TurnosPrecios")
                        .HasForeignKey("TurnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cine");

                    b.Navigation("Turno");
                });

            modelBuilder.Entity("DataBase.Models.Cine", b =>
                {
                    b.Navigation("Salas");

                    b.Navigation("TurnosPrecios");
                });

            modelBuilder.Entity("DataBase.Models.Clasificacion", b =>
                {
                    b.Navigation("Peliculas");
                });

            modelBuilder.Entity("DataBase.Models.Genero", b =>
                {
                    b.Navigation("PeliculasGeneros");
                });

            modelBuilder.Entity("DataBase.Models.Localidad", b =>
                {
                    b.Navigation("Domicilios");
                });

            modelBuilder.Entity("DataBase.Models.Pelicula", b =>
                {
                    b.Navigation("PeliculasGeneros");

                    b.Navigation("Personajes");

                    b.Navigation("Proyecciones");
                });

            modelBuilder.Entity("DataBase.Models.Persona", b =>
                {
                    b.Navigation("Entradas");

                    b.Navigation("Peliculas");

                    b.Navigation("Personajes");
                });

            modelBuilder.Entity("DataBase.Models.Provincia", b =>
                {
                    b.Navigation("Localidades");
                });

            modelBuilder.Entity("DataBase.Models.Proyeccion", b =>
                {
                    b.Navigation("Entradas");
                });

            modelBuilder.Entity("DataBase.Models.Sala", b =>
                {
                    b.Navigation("Asientos");

                    b.Navigation("Proyecciones");
                });

            modelBuilder.Entity("DataBase.Models.Turno", b =>
                {
                    b.Navigation("Proyecciones");

                    b.Navigation("TurnosPrecios");
                });
#pragma warning restore 612, 618
        }
    }
}
