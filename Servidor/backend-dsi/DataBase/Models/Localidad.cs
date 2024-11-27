using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Localidad
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int ProvinciaId { get; set; }
        [ForeignKey("ProvinciaId")]
        public virtual Provincia Provincia { get; set; }

        //propiedad de navegacion
        public List<Domicilio> Domicilios { get; set; }
    }
}
