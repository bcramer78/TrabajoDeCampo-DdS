using CORE.DTOs;
using DataBase.Models;

namespace Servicios.Interfaces
{
    public interface ILocalidadService
    { 
        Task<RespuestaPrivada<ICollection<LocalidadDTOConId>>> GetLocalidades();
        Task<RespuestaPrivada<LocalidadDTO>> PostLocalidad(LocalidadDTO localidadDTO);
        Task<RespuestaPrivada<Localidad>> DeleteLocalidad(int id);
        Task<RespuestaPrivada<LocalidadDTO>> PutLocalidad(int id, LocalidadDTO localidadDTO);
    }
}