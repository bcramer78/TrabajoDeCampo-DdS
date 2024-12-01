using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DTOs
{
    public class TurnoDTO
    {
        public string Tipo { get; set; }
    }

    public class TurnoDTOConId : TurnoDTO
    {
        public int Id { get; set; }
    }
}
