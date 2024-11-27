using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Pelicula
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public int DirectorId { get; set; }
        [Required]
        public int ClasificacionId { get; set; }

        [ForeignKey("DirectorId")]
        public virtual Persona Director { get; set; }
        [ForeignKey("ClasificacionId")]
        public virtual Clasificacion Clasificacion { get; set; }

        //propiedad de navegacion
        public List<Proyeccion> Proyecciones { get; set; }
        public List<Personaje> Personajes { get; set; }
        public List<PeliculaGenero> PeliculasGeneros { get; set; }
    }
}
