using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Entrada
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Numero {  get; set; }
        [Required]
        public int CompradorId { get; set; }
        [Required]
        public int ProyeccionId { get; set; }
        [Required]
        public int AsientoId { get; set; }

        [ForeignKey("CompradorId")]
        public virtual Persona Comprador { get; set; }
        [ForeignKey("ProyeccionId")]
        public virtual Proyeccion Proyeccion { get; set; }
        [ForeignKey("AsientoId")]
        public virtual Asiento Asiento { get; set; }
    }
}
