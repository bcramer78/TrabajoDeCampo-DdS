using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class Turno
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Tipo { get; set; }

        //Propiedades de navegacion
        public List<TurnoPrecio> TurnosPrecios { get; set; }
        public List<Proyeccion> Proyecciones { get; set; }

    }
}
