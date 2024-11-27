using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Sala
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public int CineId { get; set; }
        [ForeignKey("CineId")]
        public virtual Cine Cine { get; set; }

        //propiedad de navegacion
        public List<Proyeccion> Proyecciones { get; set; }
        public List<Asiento> Asientos { get; set; }
    }
}
