using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace CORE.DTOs
{
    public class ProvinciaDTO
    {
        public string Nombre { get; set; }
    }

    public class ProvinciaDTOConId : ProvinciaDTO
    {
        public int Id { get; set; }
    }
}
