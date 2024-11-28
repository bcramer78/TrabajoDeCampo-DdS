using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DTOs
{
    public class CineDTO
    {
        public string Nombre { get; set; }
        public int Numero { get; set; }
        public string Telefono { get; set; }
        public int DomicilioId { get; set; }
    }

    public class CineDTOConId : CineDTO
    {
        public int Id { get; set; }
    }
}
