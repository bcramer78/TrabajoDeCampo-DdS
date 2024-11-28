using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.DTOs
{
    public class LocalidadDTO
    {
        public string Nombre { get; set; }
        public int ProvinciaId { get; set; }
    }

    public class LocalidadDTOConId : LocalidadDTO
    {
        public int Id { get; set; }
    }
}
