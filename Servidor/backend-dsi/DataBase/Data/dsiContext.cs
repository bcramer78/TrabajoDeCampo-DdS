using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Data
{
    public class dsiContext : DbContext
    {
        public dsiContext(DbContextOptions<dsiContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asiento>().ToTable("Asiento");
            modelBuilder.Entity<AsientoEstado>().ToTable("AsientoEstado");
            modelBuilder.Entity<Cine>().ToTable("Cine");
            modelBuilder.Entity<Clasificacion>().ToTable("Clasificacion");
            modelBuilder.Entity<Domicilio>().ToTable("Domicilio");
            modelBuilder.Entity<Entrada>().ToTable("Entrada");
            modelBuilder.Entity<Genero>().ToTable("Genero");
            modelBuilder.Entity<Localidad>().ToTable("Localidad");
            modelBuilder.Entity<Pelicula>().ToTable("Pelicula");
            modelBuilder.Entity<PeliculaEstado>().ToTable("PeliculaEstado");
            modelBuilder.Entity<PeliculaGenero>().ToTable("PeliculaGenero");
            modelBuilder.Entity<Persona>().ToTable("Persona");
            modelBuilder.Entity<Personaje>().ToTable("Personaje");
            modelBuilder.Entity<Provincia>().ToTable("Provincia");
            modelBuilder.Entity<Proyeccion>().ToTable("Proyeccion");
            modelBuilder.Entity<Sala>().ToTable("Sala");
            modelBuilder.Entity<SalaTipo>().ToTable("SalaTipo");
            modelBuilder.Entity<Turno>().ToTable("Turno");
            modelBuilder.Entity<TurnoPrecio>().ToTable("TurnoPrecio");
            modelBuilder.Entity<TurnoTipo>().ToTable("TurnoTipo");

        }

        public DbSet<Asiento> Asientos { get; set; }
        public DbSet<AsientoEstado> AsientoEstados { get; set; }
        public DbSet<Cine> Cines { get; set; }
        public DbSet<Clasificacion> Clasificaciones { get; set; }
        public DbSet<Domicilio> Domicilios { get; set; }
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<PeliculaEstado> PeliculaEstados { get; set; }
        public DbSet<PeliculaGenero> PeliculaGeneros { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Personaje> Personajes { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Proyeccion> Proyecciones { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<SalaTipo> SalaTipos { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<TurnoPrecio> TurnoPrecios { get; set; }
        public DbSet<TurnoTipo> TurnoTipos { get; set; }
    }
}
