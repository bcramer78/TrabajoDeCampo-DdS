using CORE.DTOs;
using DataBase.Models;

namespace Servicios.Interfaces
{
    public interface IDomicilioService
    {
        Task<RespuestaPrivada<ICollection<DomicilioDTOConId>>> GetDomicilios();
        Task<RespuestaPrivada<DomicilioDTO>> PostDomicilio(DomicilioDTO domicilioDTO);
        Task<RespuestaPrivada<Domicilio>> DeleteDomicilio(int id);
        Task<RespuestaPrivada<DomicilioDTO>> PutDomicilio(int id, DomicilioDTO domicilioDTO);
    }
}