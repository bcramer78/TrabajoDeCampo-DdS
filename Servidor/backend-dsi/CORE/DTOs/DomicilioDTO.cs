using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DTOs
{
    public class DomicilioDTO
    {
        public int Calle { get; set; }
        public int Numero { get; set; }
        public int LocalidadId { get; set; }
    }

    public class DomicilioDTOConId : DomicilioDTO
    {
        public int Id { get; set; }
    }
}
