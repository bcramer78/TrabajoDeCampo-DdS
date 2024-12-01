using CORE.DTOs;
using DataBase.Models;

namespace Servicios.Interfaces
{
    public interface ISalaService
    {
        Task<RespuestaPrivada<ICollection<SalaDTOConId>>> GetSalas();
        Task<RespuestaPrivada<SalaDTO>> PostSala(SalaDTO salaDTO);
        Task<RespuestaPrivada<Sala>> DeleteSala(int id);
        Task<RespuestaPrivada<SalaDTO>> PutSala(int id, SalaDTO salaDTO);
    }
}