using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataBase.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AsientoEstado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsientoEstado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clasificacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clasificacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeliculaEstado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaEstado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaTipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaTipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TurnoTipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurnoTipo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pelicula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false),
                    DirectorId = table.Column<int>(type: "integer", nullable: false),
                    ClasificacionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelicula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pelicula_Clasificacion_ClasificacionId",
                        column: x => x.ClasificacionId,
                        principalTable: "Clasificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pelicula_Persona_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Localidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    ProvinciaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Localidad_Provincia_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeliculaGenero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GeneroId = table.Column<int>(type: "integer", nullable: false),
                    PeliculaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaGenero", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeliculaGenero_Genero_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculaGenero_Pelicula_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Pelicula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personaje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    ActorId = table.Column<int>(type: "integer", nullable: false),
                    PeliculaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personaje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personaje_Pelicula_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Pelicula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personaje_Persona_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Domicilio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Calle = table.Column<int>(type: "integer", nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    LocalidadId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domicilio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Domicilio_Localidad_LocalidadId",
                        column: x => x.LocalidadId,
                        principalTable: "Localidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: false),
                    DomicilioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cine_Domicilio_DomicilioId",
                        column: x => x.DomicilioId,
                        principalTable: "Domicilio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    CineId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sala_Cine_CineId",
                        column: x => x.CineId,
                        principalTable: "Cine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TurnoPrecio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Precio = table.Column<decimal>(type: "numeric", nullable: false),
                    CineId = table.Column<int>(type: "integer", nullable: false),
                    TurnoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurnoPrecio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TurnoPrecio_Cine_CineId",
                        column: x => x.CineId,
                        principalTable: "Cine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TurnoPrecio_Turno_TurnoId",
                        column: x => x.TurnoId,
                        principalTable: "Turno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Asiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false),
                    SalaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Asiento_Sala_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Sala",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proyeccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HoraFin = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    PeliculaId = table.Column<int>(type: "integer", nullable: false),
                    TurnoId = table.Column<int>(type: "integer", nullable: false),
                    SalaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyeccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proyeccion_Pelicula_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Pelicula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proyeccion_Sala_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Sala",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proyeccion_Turno_TurnoId",
                        column: x => x.TurnoId,
                        principalTable: "Turno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entrada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    CompradorId = table.Column<int>(type: "integer", nullable: false),
                    ProyeccionId = table.Column<int>(type: "integer", nullable: false),
                    AsientoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entrada_Asiento_AsientoId",
                        column: x => x.AsientoId,
                        principalTable: "Asiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entrada_Persona_CompradorId",
                        column: x => x.CompradorId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entrada_Proyeccion_ProyeccionId",
                        column: x => x.ProyeccionId,
                        principalTable: "Proyeccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asiento_SalaId",
                table: "Asiento",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cine_DomicilioId",
                table: "Cine",
                column: "DomicilioId");

            migrationBuilder.CreateIndex(
                name: "IX_Domicilio_LocalidadId",
                table: "Domicilio",
                column: "LocalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_AsientoId",
                table: "Entrada",
                column: "AsientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_CompradorId",
                table: "Entrada",
                column: "CompradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_ProyeccionId",
                table: "Entrada",
                column: "ProyeccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Localidad_ProvinciaId",
                table: "Localidad",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pelicula_ClasificacionId",
                table: "Pelicula",
                column: "ClasificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Pelicula_DirectorId",
                table: "Pelicula",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaGenero_GeneroId",
                table: "PeliculaGenero",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaGenero_PeliculaId",
                table: "PeliculaGenero",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Personaje_ActorId",
                table: "Personaje",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Personaje_PeliculaId",
                table: "Personaje",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyeccion_PeliculaId",
                table: "Proyeccion",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyeccion_SalaId",
                table: "Proyeccion",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proyeccion_TurnoId",
                table: "Proyeccion",
                column: "TurnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Sala_CineId",
                table: "Sala",
                column: "CineId");

            migrationBuilder.CreateIndex(
                name: "IX_TurnoPrecio_CineId",
                table: "TurnoPrecio",
                column: "CineId");

            migrationBuilder.CreateIndex(
                name: "IX_TurnoPrecio_TurnoId",
                table: "TurnoPrecio",
                column: "TurnoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsientoEstado");

            migrationBuilder.DropTable(
                name: "Entrada");

            migrationBuilder.DropTable(
                name: "PeliculaEstado");

            migrationBuilder.DropTable(
                name: "PeliculaGenero");

            migrationBuilder.DropTable(
                name: "Personaje");

            migrationBuilder.DropTable(
                name: "SalaTipo");

            migrationBuilder.DropTable(
                name: "TurnoPrecio");

            migrationBuilder.DropTable(
                name: "TurnoTipo");

            migrationBuilder.DropTable(
                name: "Asiento");

            migrationBuilder.DropTable(
                name: "Proyeccion");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "Pelicula");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "Turno");

            migrationBuilder.DropTable(
                name: "Clasificacion");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Cine");

            migrationBuilder.DropTable(
                name: "Domicilio");

            migrationBuilder.DropTable(
                name: "Localidad");

            migrationBuilder.DropTable(
                name: "Provincia");
        }
    }
}
