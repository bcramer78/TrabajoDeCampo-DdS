using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DTOs
{
    public class SalaDTO
    {
        public int Numero { get; set; }
        public string Tipo { get; set; }
        public int CineId { get; set; }
    }

    public class SalaDTOConId : SalaDTO
    {
        public int Id { get; set; }
    }
}
