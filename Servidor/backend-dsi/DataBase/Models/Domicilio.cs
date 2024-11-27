using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Domicilio
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Calle { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public int LocalidadId { get; set; }
        [ForeignKey("LocalidadId")]
        public virtual Localidad Localidad { get; set; }
    }
}
