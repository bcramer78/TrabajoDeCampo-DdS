using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Personaje
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int ActorId { get; set; }
        [Required]
        public int PeliculaId { get; set; }

        [ForeignKey("ActorId")]
        public virtual Persona Actor { get; set; }
        [ForeignKey("PeliculaId")]
        public virtual Pelicula Pelicula { get; set; }
    }
}
