using CORE.DTOs;
using DataBase.Models;

namespace Servicios.Interfaces
{
    public interface ICineService
    {
        Task<RespuestaPrivada<ICollection<CineDTOConId>>> GetCines();
        Task<RespuestaPrivada<CineDTO>> PostCine(CineDTO cineDTO);
        Task<RespuestaPrivada<Cine>> DeleteCine(int id);
        Task<RespuestaPrivada<CineDTO>> PutCine(int id, CineDTO cineDTO);
    }
}