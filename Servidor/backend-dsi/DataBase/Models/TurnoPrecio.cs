using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class TurnoPrecio
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public int CineId { get; set; }
        [Required]
        public int TurnoId { get; set; }
        [ForeignKey("CineId")]
        public virtual Cine Cine { get; set; }
        [ForeignKey("TurnoId")]
        public virtual Turno Turno { get; set; }

    }
}
