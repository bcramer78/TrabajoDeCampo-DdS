using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Cine
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public int DomicilioId { get; set; }
        [ForeignKey("DomicilioId")]
        public Domicilio Domicilio { get; set; }
        //propiedad de navegacion
        public List<Sala> Salas { get; set; }
        public List<TurnoPrecio> TurnosPrecios { get; set; }

    }
}
