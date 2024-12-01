using CORE.DTOs;
using DataBase.Models;

namespace Servicios.Interfaces
{
    public interface IProvinciaService
    {
        Task<RespuestaPrivada<ICollection<ProvinciaDTOConId>>> GetProvincias();
        Task<RespuestaPrivada<ProvinciaDTO>> PostProvincia(ProvinciaDTO provinciaDTO);
        Task<RespuestaPrivada<Provincia>> DeleteProvincia(int id);
        Task<RespuestaPrivada<ProvinciaDTO>> PutProvincia(int id, ProvinciaDTO provinciaDTO);
    }
}