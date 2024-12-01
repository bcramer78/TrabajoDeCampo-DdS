using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DTOs
{
    public class TurnoPrecioDTO
    {
        public decimal Precio { get; set; }
        public int CineId { get; set; }
        public int TurnoId { get; set; }
    }

    public class TurnoPrecioDTOConId : TurnoPrecioDTO
    {
        public int Id { get; set; }
    }
}
