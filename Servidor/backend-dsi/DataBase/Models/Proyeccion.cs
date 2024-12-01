using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Proyeccion
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public TimeOnly HoraFin { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public int PeliculaId { get; set; }
        [Required]
        public int TurnoId { get; set; }
        [Required]
        public int SalaId { get; set; }

        [ForeignKey("PeliculaId")]
        public virtual Pelicula Pelicula { get; set; }
        [ForeignKey("TurnoId")]
        public virtual Turno Turno { get; set; }
        [ForeignKey("SalaId")]
        public virtual Sala Sala { get; set; }

        //Propiedades de navegacion
        public List<Entrada> Entradas { get; set; }
    }
}
