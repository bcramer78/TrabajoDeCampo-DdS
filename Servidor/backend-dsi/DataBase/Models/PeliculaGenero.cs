using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class PeliculaGenero
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int GeneroId { get; set; }
        [Required]
        public int PeliculaId { get; set; }
        [ForeignKey("GeneroId")]
        public virtual Genero Genero { get; set; }
        [ForeignKey("PeliculaId")]
        public virtual Pelicula Pelicula { get; set; }
    }
}
